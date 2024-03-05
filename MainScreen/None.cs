using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher.MainScreen
{
    public partial class None : UserControl
    {
        public None()
        {
            InitializeComponent();
        }

        private void None_Load(object sender, EventArgs e)
        {

        }

        private async void None_Redeem_btn_Click(object sender, EventArgs e)
        {
            Redeem_Textbox.Enabled = false;
            var message = await RedeemCode(Redeem_Textbox.Text);
            Alert_message(message);
            Redeem_Textbox.Enabled = true;
        }

        private async Task<string> RedeemCode(string redeemCode)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(new { token = Main.Token, redeem_code = redeemCode }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Main.ApiServerIp + "/redeem", content);

            var responseBody = await response.Content.ReadAsStringAsync();
            var message = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return message["message"];
                }
                else
                {
                    throw new HttpRequestException($"Unexpected status code: {response.StatusCode}");
                }
            }

            return message["message"];
        }

        private void Alert_message(string message)
        {
            Alert_Message_Label.Text = message;
        }
    }
}
