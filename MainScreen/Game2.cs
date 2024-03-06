using Launcher.Codes_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher.MainScreen
{
    public partial class Game2 : UserControl
    {
        Game_Download gameDownload = new Game_Download();

        public Game2()
        {
            InitializeComponent();
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            Game2_Play_Label.Image = Image_Load.download_400_150px;
            Game1_Icon_Label.Image = Image_Load.Game2_Icon_350_150px;

            Usernames_label();
        }

        private void Logout_Label_Click(object sender, EventArgs e)
        {
            // Call the Logout method in Main.cs
            ((Main)ParentForm).Logout();
        }

        private void Game2_Play_Label_Click(object sender, EventArgs e)
        {
            if (Main.Game2_Button == true)
            {
                Game2_Screen_Set("Play_Btn", "false");

                gameDownload.Button_Click("Game1");

                var downloader = new Game_Download();
                downloader.DownloadProgressChanged += UpdateProgressBar;
            }
        }

        private void UpdateProgressBar(int gameNum, int progress)
        {
            if (gameNum == 2)
            {
                Game2_ProgressBar.Value = progress;
            }
        }

        private void Usernames_label()
        {
            string short_Usernames;
            if (Main.Usernames.Length > 13)
            {
                short_Usernames = Main.Usernames.Substring(0, 13) + "...";
            }
            else
            {
                short_Usernames = Main.Usernames;
            }

            Game2_Username_Label.Text = short_Usernames;
        }

        public void Game2_Screen_Set(string change_value1, string change_value2)
        {
            if (change_value1 == "Play_Btn")
            {
                if (change_value2 == "true")
                {
                    Main.Game2_Button = true;
                }
                else if (change_value2 == "false")
                {
                    Main.Game2_Button = false;
                }
            }
            else if (change_value1 == "ProgressBar")
            {
                if (change_value2 == "true")
                {
                    Game2_ProgressBar.Visible = true;
                }
                else if (change_value2 == "false")
                {
                    Game2_ProgressBar.Visible = false;
                }
            }
            else if (change_value1 == "Image")
            {
                if (change_value2 == "Download")
                {
                    Game2_Play_Label.Image = Image_Load.download_400_150px;
                }
                else if (change_value2 == "Pause")
                {
                    Game2_Play_Label.Image = Image_Load.pause_400_150px;
                }
                else if (change_value2 == "Play")
                {
                    Game2_Play_Label.Image = Image_Load.play_400_150px;
                }
                else if (change_value2 == "Update")
                {
                    Game2_Play_Label.Image = Image_Load.update_400_150px;
                }
            }
        }
    }
}
