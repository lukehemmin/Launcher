using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Main : Form
    {
        static public string Token;

        public Main()
        {
            InitializeComponent();
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

            }
        }
    }
}
