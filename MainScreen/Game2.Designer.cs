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
            this.label1 = new System.Windows.Forms.Label();
            this.Profile_images_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Game2_Play_Label
            // 
            this.Game2_Play_Label.BackColor = System.Drawing.Color.Transparent;
            this.Game2_Play_Label.Location = new System.Drawing.Point(850, 490);
            this.Game2_Play_Label.Name = "Game2_Play_Label";
            this.Game2_Play_Label.Size = new System.Drawing.Size(400, 150);
            this.Game2_Play_Label.TabIndex = 1;
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
            this.Logout_Label.Location = new System.Drawing.Point(1118, 49);
            this.Logout_Label.Name = "Logout_Label";
            this.Logout_Label.Size = new System.Drawing.Size(140, 30);
            this.Logout_Label.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1113, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usernameddddd...";
            // 
            // Profile_images_Label
            // 
            this.Profile_images_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Profile_images_Label.Location = new System.Drawing.Point(1043, 19);
            this.Profile_images_Label.Name = "Profile_images_Label";
            this.Profile_images_Label.Size = new System.Drawing.Size(64, 64);
            this.Profile_images_Label.TabIndex = 9;
            // 
            // Game2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.Logout_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Profile_images_Label);
            this.Controls.Add(this.Game1_Icon_Label);
            this.Controls.Add(this.Game2_Play_Label);
            this.Name = "Game2";
            this.Size = new System.Drawing.Size(1280, 670);
            this.Load += new System.EventHandler(this.Game2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Game2_Play_Label;
        private System.Windows.Forms.Label Game1_Icon_Label;
        private System.Windows.Forms.Label Logout_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Profile_images_Label;
    }
}
