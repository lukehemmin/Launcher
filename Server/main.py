# mysql 또는 mariadb 설치 후 launcher 테이블 생성
# 아래 app.config['SQLALCHEMY_DATABASE_URI'] 에서 본인의 mysql 또는 mariadb 계정 정보로 변경 후 실행
from flask import Flask, request, abort
from flask_restful import Resource, Api
from flask_sqlalchemy import SQLAlchemy
from flask_socketio import SocketIO, emit
import threading
import socket
import hashlib
import secrets
import pymysql
pymysql.install_as_MySQLdb()
from werkzeug.exceptions import BadRequest
from sqlalchemy import Column, Integer, String, Boolean

app = Flask(__name__)
api = Api(app)

app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql://root:password@localhost/launcher'
db = SQLAlchemy(app)
socketio = SocketIO(app)

def hash_password(password):
    return hashlib.sha256(password.encode()).hexdigest()

class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(80), unique=True, nullable=False)
    password_hash = db.Column(db.String(160), nullable=False)
    token = db.Column(db.String(64), unique=True)  # 토큰 필드를 추가합니다.
    auto_login = db.Column(Boolean, default=False)
    pc_id = db.Column(String(64))
    ip_address = db.Column(String(45))
    reg_ip = db.Column(String(45))

    def set_password(self, password):
        self.password_hash = hash_password(password)

    def check_password(self, password):
        return self.password_hash == hash_password(password)
    
class OwnerGame(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(80), nullable=False)
    game_name = db.Column(db.String(80), nullable=False)

class ApiStatusModel(db.Model):
    name = db.Column(db.String(80), primary_key=True)
    stats = db.Column(db.Integer, nullable=False)

class Redeem(db.Model):
    redeem_code = db.Column(db.String(80), primary_key=True)
    used = db.Column(db.Boolean, default=False)
    game_name = db.Column(db.String(80), nullable=False)

#############################################################################################################

class ApiStatus(Resource):
    def get(self):
        status = ApiStatusModel.query.filter_by(name='apis').first()
        if status is None:
            return {"message": "No status information available"}, 404

        if status.stats == 1:
            return {"message": "Server is up and running"}, 200
        else:
            return {"message": "Server is down or under maintenance"}, 503

class Register(Resource):
    def post(self):
        username = request.json.get('username')
        password = request.json.get('password')
        ip_address = request.remote_addr

        if User.query.filter_by(username=username).first() is not None:
            return {"message": "User already exists"}, 400
        
        if User.query.filter_by(reg_ip=ip_address).first() is not None:
            return {"message": "Registration from this IP address is not allowed"}, 400

        user = User(username=username)
        user.set_password(password)
        user.reg_ip = request.remote_addr

        db.session.add(user)
        db.session.commit()

        return {"message": "User created successfully"}, 201

class Login(Resource):
    def post(self):
        username = request.json.get('username')
        password = request.json.get('password')

        user = User.query.filter_by(username=username).first()

        if user is None or not user.check_password(password):
            return {"message": "Invalid username or password"}, 400

        user.token = secrets.token_hex(32)  # 로그인 성공 시 랜덤 토큰을 생성합니다.
        db.session.commit()

        return {"message": "Logged in successfully", "token": user.token}, 200
    
class Logout(Resource):
    def post(self):
        token = request.json.get('token')

        user = User.query.filter_by(token=token).first()

        if user is None:
            return {"message": "Logout failed, user not found"}, 401

        user.token = None
        user.auto_login = 0
        user.pc_id = None
        db.session.commit()

        return {"message": "Logout successful"}, 200
    
class AutoLogin(Resource):
    def post(self):
        username = request.json.get('username')
        token = request.json.get('token')
        pc_id = request.json.get('pc_id')
        ip_address = request.remote_addr

        if not pc_id or not ip_address:
            return {"message": "pc_id and ip_address must be provided"}, 400

        user = User.query.filter_by(username=username, pc_id=pc_id, ip_address=ip_address).first()

        if user is None or user.token != token:
            return {"message": "Login failed"}, 401
        
        if user.auto_login != 1:
            return {"message": "Auto login is not enabled for this user"}, 403

        new_token = secrets.token_hex(32)
        user.token = new_token
        db.session.commit()
        return {"message": "Login successful", "token": new_token}, 200
    
class TokenValidation(Resource):
    def get(self):
        token = request.headers.get('Authorization')  # 헤더에서 토큰을 가져옵니다.
        if token is None:
            return {"message": "No token provided"}, 400  # 토큰이 없으면 400 Bad Request 오류를 반환합니다.

        user = User.query.filter_by(token=token).first()
        if user is None:
            return {"message": "Invalid token"}, 401  # 토큰이 유효하지 않으면 401 Unauthorized 오류를 반환합니다.

        return {"message": "Valid token"}, 200  # 토큰이 유효하면 유효성 확인 메시지를 반환합니다.
    
class LoginComplete(Resource):
    def post(self):
        try:
            token = request.json.get('token')
            auto_login = request.json['auto_login']
            pc_id = request.json['pc_id']
        except KeyError:
            raise BadRequest('auto_login and pc_id must be provided')

        user = User.query.filter_by(token=token).first()
        if user is None:
            abort(401)  # 토큰이 유효하지 않으면 401 Unauthorized 오류를 반환합니다.

        user.auto_login = auto_login
        user.pc_id = pc_id
        user.ip_address = request.remote_addr  # 클라이언트의 IP 주소를 가져옵니다.

        db.session.commit()

        return {"message": "Login Data Send complete"}, 200

class ProtectedResource(Resource):
    def get(self):
        token = request.headers.get('Authorization')  # 헤더에서 토큰을 가져옵니다.
        if token is None:
            abort(401)  # 토큰이 없으면 401 Unauthorized 오류를 반환합니다.

        user = User.query.filter_by(token=token).first()
        if user is None:
            abort(401)  # 토큰이 유효하지 않으면 401 Unauthorized 오류를 반환합니다.

        return {"message": "Protected resource"}, 200  # 토큰이 유효하면 보호된 리소스를 반환합니다.
    
class RedeemCode(Resource):
    def post(self):
        token = request.json.get('token')
        redeem_code = request.json.get('redeem_code')

        user = User.query.filter_by(token=token).first()
        if user is None:
            return {"message": "Invalid token"}, 401

        redeem = Redeem.query.filter_by(redeem_code=redeem_code).first()
        if redeem is None or redeem.used:
            return {"message": "Invalid or already used redeem code"}, 400

        redeem.used = True
        db.session.add(OwnerGame(username=user.username, game_name=redeem.game_name))
        db.session.commit()

        return {"message": "Redeem successful"}, 200
    
#############################################################################################################

class Status(Resource):
    def post(self):
        token = request.json.get('token')
        #sel_game = request.json.get('sel_game')

        # 토큰으로 사용자를 찾습니다.
        user = User.query.filter_by(token=token).first()
        if user is None:
            return {"message": "Invalid token"}, 401

        # 사용자의 게임 목록을 찾습니다.
        owned_games = OwnerGame.query.filter_by(username=user.username).all()
        game_names = [game.game_name for game in owned_games]

        return {"games": game_names}, 200

api.add_resource(ApiStatus, '/api-status')
api.add_resource(Register, '/register')
api.add_resource(Login, '/login')
api.add_resource(Logout, '/logout')
api.add_resource(AutoLogin, '/auto-login')
api.add_resource(LoginComplete, '/login-complete')  # 로그인 완료 엔드포인트를 추가합니다.
api.add_resource(ProtectedResource, '/protected')  # 보호된 리소스의 라우트를 추가합니다.
api.add_resource(TokenValidation, '/validate-token')  # 토큰 유효성 확인 엔드포인트를 추가합니다.
api.add_resource(Status, '/status')
api.add_resource(RedeemCode, '/redeem')

@socketio.on('connect')
def handle_connect():
    threading.Thread(target=background_task).start()
    threading.Thread(target=check_server, args=("127.0.0.1", 5000)).start()

if __name__ == '__main__':
    with app.app_context():
        db.create_all()
    socketio.run(app, debug=True)