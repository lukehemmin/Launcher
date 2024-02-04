namespace Launcher
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login_Label = new System.Windows.Forms.Label();
            this.Close_Label = new System.Windows.Forms.Label();
            this.LoginScreen_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_Label
            // 
            this.Login_Label.BackColor = System.Drawing.Color.Black;
            this.Login_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Label.ForeColor = System.Drawing.Color.White;
            this.Login_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Login_Label.Location = new System.Drawing.Point(0, 0);
            this.Login_Label.Name = "Login_Label";
            this.Login_Label.Size = new System.Drawing.Size(400, 40);
            this.Login_Label.TabIndex = 0;
            this.Login_Label.Text = "  Launcher_Name";
            this.Login_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Close_Label
            // 
            this.Close_Label.AutoSize = true;
            this.Close_Label.BackColor = System.Drawing.Color.Black;
            this.Close_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Label.ForeColor = System.Drawing.Color.White;
            this.Close_Label.Location = new System.Drawing.Point(364, 8);
            this.Close_Label.Name = "Close_Label";
            this.Close_Label.Size = new System.Drawing.Size(24, 24);
            this.Close_Label.TabIndex = 1;
            this.Close_Label.Text = "X";
            this.Close_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Close_Label.Click += new System.EventHandler(this.Close_Label_Click);
            // 
            // LoginScreen_Label
            // 
            this.LoginScreen_Label.Location = new System.Drawing.Point(0, 40);
            this.LoginScreen_Label.Name = "LoginScreen_Label";
            this.LoginScreen_Label.Size = new System.Drawing.Size(400, 460);
            this.LoginScreen_Label.TabIndex = 2;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.ControlBox = false;
            this.Controls.Add(this.LoginScreen_Label);
            this.Controls.Add(this.Close_Label);
            this.Controls.Add(this.Login_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login_Label;
        private System.Windows.Forms.Label Close_Label;
        private System.Windows.Forms.Label LoginScreen_Label;
    }
}

