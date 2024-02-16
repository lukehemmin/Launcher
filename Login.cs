using Launcher.LoginScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Login : Form
    {
        Logins login = new Logins();
        Register register = new Register();

        public Login()
        {
            InitializeComponent();

            Laguage_check();

            // Form1이 로드될 때 UserControl1을 표시
            LoginScreen_Label.Controls.Add(login);
            login.ButtonClick += login_ButtonClick;
            register.ButtonClick += register_ButtonClick;

            // Login_Label 클릭하여 끌면 창 이동
            this.Login_Label.MouseDown += moveFormLabel_MouseDown;

            login.LoginSuccess += LoginsControl_LoginSuccess;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void moveFormLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Login_Label.Capture = false;

                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;

                Message message = Message.Create(Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);

                DefWndProc(ref message);
            }
        }

        private void login_ButtonClick(object sender, EventArgs e)
        {
            // UserControl1의 버튼이 클릭되면 UserControl2를 표시
            LoginScreen_Label.Controls.Remove(login);
            LoginScreen_Label.Controls.Add(register);
        }

        private void register_ButtonClick(object sender, EventArgs e)
        {
            // UserControl2의 버튼이 클릭되면 UserControl1을 표시
            LoginScreen_Label.Controls.Remove(register);
            LoginScreen_Label.Controls.Add(login);
        }

        private void Close_Label_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginsControl_LoginSuccess(object sender, EventArgs e)
        {
            if (Main.Token != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void Laguage_check()
        {
            string country = await GetCountryByExternalIp();
            Console.WriteLine($"Country: {country}");
        }

        private async Task<string> GetCountryByExternalIp()
        {
            using (var client = new HttpClient())
            {
                // Get the external IP address
                string externalIp = await client.GetStringAsync("https://api.ipify.org");

                // Send the HTTP request
                var response = await client.GetAsync($"http://ip-api.com/json/{externalIp}");

                // If the request is successful, extract the country from the response
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseJson);
                    string country = responseObj.country;
                    return country;
                }
                else
                {
                    return "Unknown";
                }
            }
        }
    }
}
