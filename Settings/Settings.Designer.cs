namespace Launcher.Settings
{
    partial class Settings
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
            this.Launcher_Version_Label = new System.Windows.Forms.Label();
            this.test_btn = new System.Windows.Forms.Button();
            this.test_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Launcher_Version_Label
            // 
            this.Launcher_Version_Label.AutoSize = true;
            this.Launcher_Version_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Launcher_Version_Label.Location = new System.Drawing.Point(25, 629);
            this.Launcher_Version_Label.Name = "Launcher_Version_Label";
            this.Launcher_Version_Label.Size = new System.Drawing.Size(185, 18);
            this.Launcher_Version_Label.TabIndex = 0;
            this.Launcher_Version_Label.Text = "Game Launcher version : ";
            // 
            // test_btn
            // 
            this.test_btn.Location = new System.Drawing.Point(28, 544);
            this.test_btn.Name = "test_btn";
            this.test_btn.Size = new System.Drawing.Size(179, 69);
            this.test_btn.TabIndex = 1;
            this.test_btn.Text = "test";
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // test_label
            // 
            this.test_label.AutoSize = true;
            this.test_label.Location = new System.Drawing.Point(213, 572);
            this.test_label.Name = "test_label";
            this.test_label.Size = new System.Drawing.Size(36, 13);
            this.test_label.TabIndex = 2;
            this.test_label.Text = "<- test";
            // 
            // Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.test_label);
            this.Controls.Add(this.test_btn);
            this.Controls.Add(this.Launcher_Version_Label);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1216, 670);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Launcher_Version_Label;
        private System.Windows.Forms.Button test_btn;
        private System.Windows.Forms.Label test_label;
    }
}
