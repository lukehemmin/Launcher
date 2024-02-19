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
        static public string Usernames;
        static public string Token;
        static public string ApiServerIp = "http://127.0.0.1:5000";
        // Slider menu minimum/maximum width
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 64;
        // Slider menu speed
        const int STEP_SLIDING = 10;
        // Slider menu size when first loaded
        int _posSliding = 64;

        None none = new None();
        Game1 game1 = new Game1();
        Game2 game2 = new Game2();
        Settings.Settings settings = new Settings.Settings();

        public Main()
        {
            InitializeComponent();

            this.Main_Label.MouseDown += moveFormLabel_MouseDown;
            Left_Dock.Visible = false;

            Left_Dock.Width = _posSliding;
            // Image_Load
            //Logout_Label.Image = Image_Load.Logout_145_32px;
            Setting_Label.Image = Image_Load.Settings_64_200px;
            Setting_Label.Click += (Sender, e) =>
            {
                MainScreen_Label.Controls.Clear();
                MainScreen_Label.Controls.Add(settings);
            };
            //DOCK
            Left_Dock.MouseEnter += Left_Dock_MouseEnter;
            Left_Dock.MouseLeave += Left_Dock_MouseLeave;
            Setting_Label.MouseEnter += Left_Dock_MouseEnter;
            Setting_Label.MouseLeave += Left_Dock_MouseLeave; // This line is not necessary
            GameList1_Label.MouseEnter += Left_Dock_MouseEnter;
            GameList1_Label.MouseLeave += Left_Dock_MouseLeave; // This line is not necessary
            GameList2_Label.MouseEnter += Left_Dock_MouseEnter;
            GameList2_Label.MouseLeave += Left_Dock_MouseLeave; // This line is not necessary

            // Add these lines
            Timer timerCheckPanelSize = new Timer();
            timerCheckPanelSize.Interval = 10; // Check every second
            timerCheckPanelSize.Tick += TimerCheckPanelSize_Tick;
            timerCheckPanelSize.Start();
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
                
                if (MainScreen_Label.Controls.Contains(none) || MainScreen_Label.Controls.Count == 0)
                {
                    MainScreen_Label.Controls.Remove(none);
                    
                    if (games[0] == "Game1")
                    {
                        MainScreen_Label.Controls.Add(game1);
                        Console.WriteLine(games[0]);
                    }
                    else if (games[0] == "Game2")
                    {
                        MainScreen_Label.Controls.Add(game2);
                    }
                }

                if (games[0] == "Game1")
                {
                    if (GameList1_Label.Image != Image_Load.game1_64_200px)
                    {
                        GameList1_Label.Image = Image_Load.game1_64_200px;
                        GameList1_Label.Click += GameList1_Label_game1_Click;
                    }
                }
                else if (games[0] == "Game2")
                {
                    if (GameList1_Label.Image != Image_Load.game2_64_200px)
                    {
                        GameList1_Label.Image = Image_Load.game2_64_200px;
                        GameList1_Label.Click += GameList1_Label_game2_Click;
                    }
                }

                if (games.Count >= 2)
                {
                    if (games[1] == "Game1")
                    {
                        if (GameList2_Label.Image != Image_Load.game1_64_200px)
                        {
                            GameList2_Label.Image = Image_Load.game1_64_200px;
                            GameList2_Label.Click += GameList2_Label_game1_Click;
                        }
                    }
                    else if (games[1] == "Game2")
                    {
                        if (GameList2_Label.Image != Image_Load.game2_64_200px)
                        {
                            GameList2_Label.Image = Image_Load.game2_64_200px;
                            GameList2_Label.Click += GameList2_Label_game2_Click;
                        }
                    }
                }
                else
                {
                    if (GameList2_Label.Image != null)
                    {
                        GameList2_Label.Image = null;
                        GameList2_Label.Click -= GameList2_Label_game1_Click;
                        GameList2_Label.Click -= GameList2_Label_game2_Click;
                    }
                }
            }
            else
            {
                MainScreen_Label.Controls.Add(none);
                Left_Dock.Visible = false;
            }
        }

        private void GameList1_Label_game1_Click(object sender, EventArgs e)
        {
            MainScreen_Label.Controls.Clear();
            MainScreen_Label.Controls.Add(game1);
        }

        private void GameList1_Label_game2_Click(object sender, EventArgs e)
        {
            MainScreen_Label.Controls.Clear();
            MainScreen_Label.Controls.Add(game2);
        }

        private void GameList2_Label_game1_Click(object sender, EventArgs e)
        {
            MainScreen_Label.Controls.Clear();
            MainScreen_Label.Controls.Add(game1);
        }

        private void GameList2_Label_game2_Click(object sender, EventArgs e)
        {
            MainScreen_Label.Controls.Clear();
            MainScreen_Label.Controls.Add(game2);
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

        private void Left_Dock_MouseEnter(object sender, EventArgs e)
        {
            timerSlidingClose.Stop(); // Stop the closing timer
            timerSlidingOpen.Start();
        }

        private void Left_Dock_MouseLeave(object sender, EventArgs e)
        {
            timerSlidingOpen.Stop(); // Stop the opening timer
            timerSlidingClose.Start();
        }
        // Slider panel open
        private void timerSlidingOpen_Tick(object sender, EventArgs e)
        {
            if (Left_Dock.Width < MAX_SLIDING_WIDTH)
            {
                Left_Dock.Width += STEP_SLIDING;
                _posSliding = Left_Dock.Width;
            }
            else
            {
                timerSlidingOpen.Stop();
            }
        }
        // Slider panel close
        private void timerSlidingClose_Tick(object sender, EventArgs e)
        {
            if (Left_Dock.Width > MIN_SLIDING_WIDTH)
            {
                Left_Dock.Width -= STEP_SLIDING;
                _posSliding = Left_Dock.Width;
            }
            else
            {
                timerSlidingClose.Stop();
            }
        }
        // Slider panel recovery
        private void TimerCheckPanelSize_Tick(object sender, EventArgs e)
        {
            // If the panel width is not what it's supposed to be, reset it
            if (Left_Dock.Width != _posSliding)
            {
                Left_Dock.Width = _posSliding;
            }
        }

        public async void Logout()
        {
            owner_game_refresh.Enabled = false;
            MainScreen_Label.Controls.Clear();
            this.Hide();

            var httpClient = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(new { token = Token }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(ApiServerIp + "/logout", content);

            if (response.IsSuccessStatusCode)
            {
                // If the logout was successful, show the login form
                Login loginfrm = new Login();
                DialogResult result = loginfrm.ShowDialog();

                if (result != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    owner_game_refresh.Enabled = true;
                    this.Show();
                    MainScreen_Load();
                }
            }
        }
    }
}
