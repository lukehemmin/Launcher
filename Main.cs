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
using Launcher.MainScreen;

namespace Launcher
{
    public partial class Main : Form
    {
        static public string Token;
        static public string ApiServerIp = "http://127.0.0.1:5000";

        None none = new None();
        Game1 game1 = new Game1();

        public Main()
        {
            InitializeComponent();

            this.Main_Label.MouseDown += moveFormLabel_MouseDown;
            Left_Dock.Visible = false;


        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login loginfrm = new Login();
            DialogResult result = loginfrm.ShowDialog();

            if (result != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                owner_game_refresh.Enabled = true;
                MainScreen_Load();
            }
        }

        private async void MainScreen_Load()
        {
            var games = await FetchOwnedGames();
            if (games.Any())
            {
                Left_Dock.Visible = true;
                if (MainScreen_Label.Controls.Contains(none))
                {
                    MainScreen_Label.Controls.Remove(none);
                }

                if (games[0] == "Game1")
                {
                    MainScreen_Label.Controls.Add(game1);
                }
            }
            else
            {
                MainScreen_Label.Controls.Add(none);
                Left_Dock.Visible = false;
            }
        }

        private async void owner_game_refresh_Tick(object sender, EventArgs e)
        {
            MainScreen_Load();
        }

        private async Task<List<string>> FetchOwnedGames()
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(new { token = Token }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(ApiServerIp + "/status", content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var games = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(responseBody);
            return games["games"];
        }

        private void moveFormLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Main_Label.Capture = false;

                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;

                Message message = Message.Create(Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);

                DefWndProc(ref message);
            }
        }

        private void Close_Label_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
