using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Launcher.LoginScreen
{
    public partial class Logins : UserControl
    {
        public event EventHandler ButtonClick;
        private const string ApiServerIp = "http://127.0.0.1:5000";
        public event EventHandler LoginSuccess;

        public Logins()
        {
            InitializeComponent();
        }

        private void Logins_Load(object sender, EventArgs e)
        {
            auto_login();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }

        private async void auto_login()
        {
            string pc_Id = GetWindowsProductId();

            // Read the user data from the JSON file
            string json = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "user_data.json");
            var userData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            // Check if the username and token are not null or undefined
            if (userData.Username == null || userData.Token == null)
            {
                Console.WriteLine("Username or token is null or undefined.");
                return;
            }

            // Prepare the HTTP request
            using (var client = new HttpClient())
            {
                var autologinData = new { username = userData.Username.ToString(), token = userData.Token.ToString(), pc_id = pc_Id };
                var content = new StringContent(JsonSerializer.Serialize(autologinData), Encoding.UTF8, "application/json");

                // Send the HTTP request
                var response = await client.PostAsync($"{ApiServerIp}/auto-login", content);

                // If the request is successful, update the token in the JSON file
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseJson);

                    // Extract the message and token from the response
                    string message = responseObj.message;
                    string newToken = responseObj.token;

                    // Update the token in the user data and save it to the JSON file
                    userData.Token = newToken;
                    string updatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
                    System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "user_data.json", updatedJson);

                    // Log the message and new token
                    Console.WriteLine($"Message: {message}, New Token: {newToken}");
                    Main.Token = newToken;

                    LoginSuccess?.Invoke(this, EventArgs.Empty); // Add this line
                }
            }
        }

        private void Password_TextBox_KeyDown(object sender, KeyEventArgs e) // Password Textbox Enter Key Event
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Button_Click(sender, e);
                Login_Button.Select();
            }
        }

        private void Username_Textbox_TextChanged(object sender, EventArgs e) // Username Textbox Text Changed Event
        {
            Alert_reset();
        }

        private void Password_Textbox_TextChanged(object sender, EventArgs e) // Password Textbox Click Event
        {
            Alert_reset();
        }

        private async void Login_Button_Click(object sender, EventArgs e) // Login Button
        {
            string Username = Username_Textbox.Text;
            string Password = Password_Textbox.Text;
            Alert_reset();
            if (EmptyCheck())
            {
                var server_result = await SendLoginRequest(Username, Password);
                if (server_result.Item1)
                {
                    int autoLogin = AutoLogin_CheckBox.Checked ? 1 : 0;
                    //Alert_Message($"{server_result.Item2}");
                    Console.WriteLine($"Message: {server_result.Item2}, Token: {server_result.Item3}, Check: {autoLogin}");
                    Main.Token = server_result.Item3;

                    string pcId = GetWindowsProductId();
                    var loginCompleteResult = await SendLoginCompleteRequest(Main.Token, autoLogin, pcId);
                    if (loginCompleteResult.Item1)
                    {
                        Console.WriteLine($"Login complete message: {loginCompleteResult.Item2}");

                        var userData = new { Username = Username, Token = Main.Token };
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
                        System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "user_data.json", json);

                        LoginSuccess?.Invoke(this, EventArgs.Empty); // Add this line
                    }
                    else
                    {
                        Console.WriteLine("Failed to send login complete request.");
                        Alert_Message($"Data Send Failed.");
                    }
                }
                else
                {
                    Alert_Message($"{server_result.Item2}");
                    Console.WriteLine($"Message: {server_result.Item2}");
                }
            }
        }

        private async Task<(bool, string, string)> SendLoginRequest(string username, string password) // Send Login Request
        {
            using (var client = new HttpClient())
            {
                var loginData = new { username = username, password = password };
                var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{ApiServerIp}/login", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                var message = string.Empty;
                var token = string.Empty;

                if (!string.IsNullOrEmpty(responseContent))
                {
                    var responseObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);
                    if (responseObject != null)
                    {
                        if (responseObject.ContainsKey("message"))
                        {
                            message = responseObject["message"];
                        }
                        if (responseObject.ContainsKey("token"))
                        {
                            token = responseObject["token"];
                        }
                    }
                }

                return (response.IsSuccessStatusCode, message, token);
            }
        }

        private async Task<(bool, string)> SendLoginCompleteRequest(string token, int autoLogin, string pcId) // Send Login Complete Request
        {
            using (var client = new HttpClient())
            {
                var loginCompleteData = new { token = token, auto_login = autoLogin, pc_id = pcId };
                var content = new StringContent(JsonSerializer.Serialize(loginCompleteData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{ApiServerIp}/login-complete", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                var message = string.Empty;

                if (!string.IsNullOrEmpty(responseContent))
                {
                    var responseObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent);
                    if (responseObject != null && responseObject.ContainsKey("message"))
                    {
                        message = responseObject["message"];
                    }
                }

                return (response.IsSuccessStatusCode, message);
            }
        }

        private bool EmptyCheck() // Textbox Empty Check
        {
            if (Username_Textbox.Text == "Username")
            {
                Alert_Message("Check Username.");
                Username_Textbox.Focus();
                return false;
            }
            else if (Password_Textbox.Text == "Password")
            {
                Alert_Message("Check Password.");
                Password_Textbox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(Username_Textbox.Text))
            {
                Alert_Message("Check Username.");
                Username_Textbox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(Password_Textbox.Text))
            {
                Alert_Message("Check Password.");
                Password_Textbox.Focus();
                return false;
            }

            return true;
        }

        private void Alert_Message(string Message) // Alert Message
        {
            Login_Button.Location = new Point(125, 320);
            Login_Alert_Label.Visible = true;
            Login_Alert_Label.Text = Message;
        }

        private void Alert_reset() // Alert Message
        {
            Login_Button.Location = new Point(125, 285);
            Login_Alert_Label.Visible = false;
        }

        public string GetWindowsProductId()
        {
            RegistryKey localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            localKey = localKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            if (localKey != null)
            {
                string productId = (string)localKey.GetValue("ProductId");
                return productId;
            }

            return string.Empty;
        }
    }
}
