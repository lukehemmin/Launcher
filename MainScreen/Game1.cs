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
    public partial class Game1 : UserControl
    {
        Game_Download gameDownload = new Game_Download();

        public Game1()
        {
            InitializeComponent();
        }

        private void Game1_Load(object sender, EventArgs e)
        {
            Game1_Play_Label.Image = Image_Load.download_400_150px;
            Game1_Icon_Label.Image = Image_Load.Game1_Icon_350_150px;

            Usernames_label();
        }

        private void Logout_Label_Click(object sender, EventArgs e)
        {
            // Call the Logout method in Main.cs
            ((Main)ParentForm).Logout();
        }

        private void Game1_Play_Label_Click(object sender, EventArgs e)
        {
            if (Main.Game1_Button == true)
            {

                Game1_ProgressBar.Visible = true;

                gameDownload.Button_Click("Game1");

                var downloader = new Game_Download();
                downloader.DownloadProgressChanged += UpdateProgressBar;
            }
        }

        private void UpdateProgressBar(int gameNum, int progress)
        {
            if (gameNum == 1)
            {
                Game1_ProgressBar.Value = progress;
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

            Game1_Username_Label.Text = short_Usernames;
        }

        public void Game1_Button_Set(string change_value1, string change_value2)
        {
            if (change_value1 == "Activate")
            {
                if (change_value2 == "true")
                {
                    Main.Game1_Button = true;
                }
                else if (change_value2 == "false")
                {
                    Main.Game1_Button = false;
                }
            }
            else if (change_value1 == "Image")
            {
                if (change_value2 == "Download")
                {
                    Game1_Play_Label.Image = Image_Load.download_400_150px;
                }
                else if (change_value2 == "Pause")
                {
                    Game1_Play_Label.Image = Image_Load.pause_400_150px;
                }
                else if (change_value2 == "Play")
                {
                    Game1_Play_Label.Image = Image_Load.play_400_150px;
                }
                else if (change_value2 == "Update")
                {
                    Game1_Play_Label.Image = Image_Load.update_400_150px;
                }
            }
        }
    }
}
