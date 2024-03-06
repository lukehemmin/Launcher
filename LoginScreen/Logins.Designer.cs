namespace Launcher.LoginScreen
{
    partial class Logins
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Username_Textbox = new System.Windows.Forms.TextBox();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.AutoLogin_CheckBox = new System.Windows.Forms.CheckBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Login_Alert_Label = new System.Windows.Forms.Label();
            this.Register_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username_Textbox
            // 
            this.Username_Textbox.Font = new System.Drawing.Font("Arial", 12F);
            this.Username_Textbox.Location = new System.Drawing.Point(50, 160);
            this.Username_Textbox.Name = "Username_Textbox";
            this.Username_Textbox.Size = new System.Drawing.Size(300, 26);
            this.Username_Textbox.TabIndex = 0;
            this.Username_Textbox.Text = "Username";
            this.Username_Textbox.TextChanged += new System.EventHandler(this.Username_Textbox_TextChanged);
            // 
            // Password_Textbox
            // 
            this.Password_Textbox.Font = new System.Drawing.Font("Arial", 12F);
            this.Password_Textbox.Location = new System.Drawing.Point(50, 209);
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.PasswordChar = '●';
            this.Password_Textbox.Size = new System.Drawing.Size(300, 26);
            this.Password_Textbox.TabIndex = 1;
            this.Password_Textbox.Text = "Password";
            this.Password_Textbox.TextChanged += new System.EventHandler(this.Password_Textbox_TextChanged);
            this.Password_Textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_TextBox_KeyDown);
            // 
            // AutoLogin_CheckBox
            // 
            this.AutoLogin_CheckBox.AutoSize = true;
            this.AutoLogin_CheckBox.Font = new System.Drawing.Font("Arial", 12F);
            this.AutoLogin_CheckBox.Location = new System.Drawing.Point(246, 253);
            this.AutoLogin_CheckBox.Name = "AutoLogin_CheckBox";
            this.AutoLogin_CheckBox.Size = new System.Drawing.Size(102, 22);
            this.AutoLogin_CheckBox.TabIndex = 2;
            this.AutoLogin_CheckBox.Text = "Auto Login";
            this.AutoLogin_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(125, 285);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(150, 60);
            this.Login_Button.TabIndex = 3;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Login_Alert_Label
            // 
            this.Login_Alert_Label.Font = new System.Drawing.Font("Arial", 11.25F);
            this.Login_Alert_Label.Location = new System.Drawing.Point(50, 285);
            this.Login_Alert_Label.Name = "Login_Alert_Label";
            this.Login_Alert_Label.Size = new System.Drawing.Size(300, 20);
            this.Login_Alert_Label.TabIndex = 11;
            this.Login_Alert_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Login_Alert_Label.Visible = false;
            // 
            // Register_Button
            // 
            this.Register_Button.Location = new System.Drawing.Point(125, 360);
            this.Register_Button.Name = "Register_Button";
            this.Register_Button.Size = new System.Drawing.Size(150, 60);
            this.Register_Button.TabIndex = 12;
            this.Register_Button.Text = "Register";
            this.Register_Button.UseVisualStyleBackColor = true;
            this.Register_Button.Click += new System.EventHandler(this.Register_Button_Click);
            // 
            // Logins
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Register_Button);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Login_Alert_Label);
            this.Controls.Add(this.AutoLogin_CheckBox);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.Username_Textbox);
            this.Name = "Logins";
            this.Size = new System.Drawing.Size(400, 460);
            this.Load += new System.EventHandler(this.Logins_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Username_Textbox;
        private System.Windows.Forms.TextBox Password_Textbox;
        private System.Windows.Forms.CheckBox AutoLogin_CheckBox;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Label Login_Alert_Label;
        private System.Windows.Forms.Button Register_Button;
    }
}
