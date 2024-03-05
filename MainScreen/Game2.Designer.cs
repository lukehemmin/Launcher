namespace Launcher.MainScreen
{
    partial class Game2
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
            this.Game2_Play_Label = new System.Windows.Forms.Label();
            this.Game1_Icon_Label = new System.Windows.Forms.Label();
            this.Logout_Label = new System.Windows.Forms.Label();
            this.Game2_Username_Label = new System.Windows.Forms.Label();
            this.Profile_images_Label = new System.Windows.Forms.Label();
            this.Game2_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Game2_Play_Label
            // 
            this.Game2_Play_Label.BackColor = System.Drawing.Color.White;
            this.Game2_Play_Label.Location = new System.Drawing.Point(789, 488);
            this.Game2_Play_Label.Name = "Game2_Play_Label";
            this.Game2_Play_Label.Size = new System.Drawing.Size(400, 150);
            this.Game2_Play_Label.TabIndex = 1;
            this.Game2_Play_Label.Click += new System.EventHandler(this.Game2_Play_Label_Click);
            // 
            // Game1_Icon_Label
            // 
            this.Game1_Icon_Label.Location = new System.Drawing.Point(50, 20);
            this.Game1_Icon_Label.Name = "Game1_Icon_Label";
            this.Game1_Icon_Label.Size = new System.Drawing.Size(350, 150);
            this.Game1_Icon_Label.TabIndex = 2;
            // 
            // Logout_Label
            // 
            this.Logout_Label.Location = new System.Drawing.Point(1057, 50);
            this.Logout_Label.Name = "Logout_Label";
            this.Logout_Label.Size = new System.Drawing.Size(140, 30);
            this.Logout_Label.TabIndex = 11;
            this.Logout_Label.Click += new System.EventHandler(this.Logout_Label_Click);
            // 
            // Game2_Username_Label
            // 
            this.Game2_Username_Label.AutoSize = true;
            this.Game2_Username_Label.BackColor = System.Drawing.Color.Transparent;
            this.Game2_Username_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game2_Username_Label.Location = new System.Drawing.Point(1052, 28);
            this.Game2_Username_Label.Name = "Game2_Username_Label";
            this.Game2_Username_Label.Size = new System.Drawing.Size(149, 19);
            this.Game2_Username_Label.TabIndex = 10;
            this.Game2_Username_Label.Text = "Usernameddddd...";
            // 
            // Profile_images_Label
            // 
            this.Profile_images_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Profile_images_Label.Location = new System.Drawing.Point(982, 20);
            this.Profile_images_Label.Name = "Profile_images_Label";
            this.Profile_images_Label.Size = new System.Drawing.Size(64, 64);
            this.Profile_images_Label.TabIndex = 9;
            // 
            // Game2_ProgressBar
            // 
            this.Game2_ProgressBar.Location = new System.Drawing.Point(50, 540);
            this.Game2_ProgressBar.Name = "Game2_ProgressBar";
            this.Game2_ProgressBar.Size = new System.Drawing.Size(687, 55);
            this.Game2_ProgressBar.TabIndex = 12;
            this.Game2_ProgressBar.Visible = false;
            // 
            // Game2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.Game2_ProgressBar);
            this.Controls.Add(this.Logout_Label);
            this.Controls.Add(this.Game2_Username_Label);
            this.Controls.Add(this.Profile_images_Label);
            this.Controls.Add(this.Game1_Icon_Label);
            this.Controls.Add(this.Game2_Play_Label);
            this.Name = "Game2";
            this.Size = new System.Drawing.Size(1216, 670);
            this.Load += new System.EventHandler(this.Game2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Game2_Play_Label;
        private System.Windows.Forms.Label Game1_Icon_Label;
        private System.Windows.Forms.Label Logout_Label;
        private System.Windows.Forms.Label Game2_Username_Label;
        private System.Windows.Forms.Label Profile_images_Label;
        public System.Windows.Forms.ProgressBar Game2_ProgressBar;
    }
}
