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
    }
}
