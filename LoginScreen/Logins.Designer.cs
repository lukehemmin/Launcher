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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logins));
            this.button1 = new System.Windows.Forms.Button();
            this.Username_Textbox = new System.Windows.Forms.TextBox();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.AutoLogin_CheckBox = new System.Windows.Forms.CheckBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Login_Alert_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Username_Textbox
            // 
            resources.ApplyResources(this.Username_Textbox, "Username_Textbox");
            this.Username_Textbox.Name = "Username_Textbox";
            this.Username_Textbox.TextChanged += new System.EventHandler(this.Username_Textbox_TextChanged);
            // 
            // Password_Textbox
            // 
            resources.ApplyResources(this.Password_Textbox, "Password_Textbox");
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.TextChanged += new System.EventHandler(this.Password_Textbox_TextChanged);
            this.Password_Textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_TextBox_KeyDown);
            // 
            // AutoLogin_CheckBox
            // 
            resources.ApplyResources(this.AutoLogin_CheckBox, "AutoLogin_CheckBox");
            this.AutoLogin_CheckBox.Name = "AutoLogin_CheckBox";
            this.AutoLogin_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Login_Button
            // 
            resources.ApplyResources(this.Login_Button, "Login_Button");
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Login_Alert_Label
            // 
            resources.ApplyResources(this.Login_Alert_Label, "Login_Alert_Label");
            this.Login_Alert_Label.Name = "Login_Alert_Label";
            // 
            // Logins
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Login_Alert_Label);
            this.Controls.Add(this.AutoLogin_CheckBox);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.Username_Textbox);
            this.Controls.Add(this.button1);
            this.Name = "Logins";
            this.Load += new System.EventHandler(this.Logins_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Username_Textbox;
        private System.Windows.Forms.TextBox Password_Textbox;
        private System.Windows.Forms.CheckBox AutoLogin_CheckBox;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Label Login_Alert_Label;
    }
}
