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
        private int ready = 1;

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
            if (ready == 1)
            {
                Game1_ProgressBar.Visible = true;
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
    }
}
