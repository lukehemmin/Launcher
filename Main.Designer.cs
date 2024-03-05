namespace Launcher
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.Main_Label = new System.Windows.Forms.Label();
            this.Close_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainScreen_Label = new System.Windows.Forms.Label();
            this.owner_game_refresh = new System.Windows.Forms.Timer(this.components);
            this.Left_Dock = new System.Windows.Forms.Panel();
            this.Setting_Label = new System.Windows.Forms.Label();
            this.GameList2_Label = new System.Windows.Forms.Label();
            this.GameList1_Label = new System.Windows.Forms.Label();
            this.timerSlidingOpen = new System.Windows.Forms.Timer(this.components);
            this.timerSlidingClose = new System.Windows.Forms.Timer(this.components);
            this.Left_Dock.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Label
            // 
            this.Main_Label.BackColor = System.Drawing.Color.Black;
            this.Main_Label.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Main_Label.ForeColor = System.Drawing.Color.White;
            this.Main_Label.Location = new System.Drawing.Point(0, 0);
            this.Main_Label.Name = "Main_Label";
            this.Main_Label.Size = new System.Drawing.Size(1280, 50);
            this.Main_Label.TabIndex = 0;
            this.Main_Label.Text = "  Launcher_Name";
            this.Main_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Close_Label
            // 
            this.Close_Label.AutoSize = true;
            this.Close_Label.BackColor = System.Drawing.Color.Black;
            this.Close_Label.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Label.ForeColor = System.Drawing.Color.White;
            this.Close_Label.Location = new System.Drawing.Point(1244, 13);
            this.Close_Label.Name = "Close_Label";
            this.Close_Label.Size = new System.Drawing.Size(24, 24);
            this.Close_Label.TabIndex = 1;
            this.Close_Label.Text = "X";
            this.Close_Label.Click += new System.EventHandler(this.Close_Label_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1212, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "--";
            // 
            // MainScreen_Label
            // 
            this.MainScreen_Label.Location = new System.Drawing.Point(64, 50);
            this.MainScreen_Label.Name = "MainScreen_Label";
            this.MainScreen_Label.Size = new System.Drawing.Size(1216, 670);
            this.MainScreen_Label.TabIndex = 3;
            // 
            // owner_game_refresh
            // 
            this.owner_game_refresh.Interval = 3000;
            this.owner_game_refresh.Tick += new System.EventHandler(this.owner_game_refresh_Tick);
            // 
            // Left_Dock
            // 
            this.Left_Dock.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Left_Dock.Controls.Add(this.Setting_Label);
            this.Left_Dock.Controls.Add(this.GameList2_Label);
            this.Left_Dock.Controls.Add(this.GameList1_Label);
            this.Left_Dock.Location = new System.Drawing.Point(0, 50);
            this.Left_Dock.Name = "Left_Dock";
            this.Left_Dock.Size = new System.Drawing.Size(200, 670);
            this.Left_Dock.TabIndex = 4;
            // 
            // Setting_Label
            // 
            this.Setting_Label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Setting_Label.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Setting_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Setting_Label.Location = new System.Drawing.Point(0, 606);
            this.Setting_Label.Name = "Setting_Label";
            this.Setting_Label.Size = new System.Drawing.Size(200, 64);
            this.Setting_Label.TabIndex = 7;
            this.Setting_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameList2_Label
            // 
            this.GameList2_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameList2_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GameList2_Label.Location = new System.Drawing.Point(0, 64);
            this.GameList2_Label.Name = "GameList2_Label";
            this.GameList2_Label.Size = new System.Drawing.Size(200, 64);
            this.GameList2_Label.TabIndex = 6;
            this.GameList2_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameList1_Label
            // 
            this.GameList1_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameList1_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GameList1_Label.Location = new System.Drawing.Point(0, 0);
            this.GameList1_Label.Name = "GameList1_Label";
            this.GameList1_Label.Size = new System.Drawing.Size(200, 64);
            this.GameList1_Label.TabIndex = 5;
            this.GameList1_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSlidingOpen
            // 
            this.timerSlidingOpen.Interval = 10;
            this.timerSlidingOpen.Tick += new System.EventHandler(this.timerSlidingOpen_Tick);
            // 
            // timerSlidingClose
            // 
            this.timerSlidingClose.Interval = 10;
            this.timerSlidingClose.Tick += new System.EventHandler(this.timerSlidingClose_Tick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.Left_Dock);
            this.Controls.Add(this.MainScreen_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Close_Label);
            this.Controls.Add(this.Main_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Left_Dock.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Main_Label;
        private System.Windows.Forms.Label Close_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MainScreen_Label;
        private System.Windows.Forms.Timer owner_game_refresh;
        private System.Windows.Forms.Panel Left_Dock;
        private System.Windows.Forms.Label GameList1_Label;
        private System.Windows.Forms.Label GameList2_Label;
        private System.Windows.Forms.Label Setting_Label;
        private System.Windows.Forms.Timer timerSlidingOpen;
        private System.Windows.Forms.Timer timerSlidingClose;
    }
}