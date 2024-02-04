using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher.LoginScreen
{
    public partial class Register : UserControl
    {
        public event EventHandler ButtonClick;

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 버튼이 클릭되면 ButtonClick 이벤트를 발생시킴
            ButtonClick?.Invoke(this, e);
        }
    }
}
