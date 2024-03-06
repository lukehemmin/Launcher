using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Launcher.Codes_Folder;

namespace Launcher.Settings
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Launcher_Version_Label.Text = "Game Launcher version : " + Main.Launcher_Version;
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            var game_download = new Game_Download();

            game_download.test();
        }
    }
}
