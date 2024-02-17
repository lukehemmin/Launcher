namespace Launcher.MainScreen
{
    partial class None
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
            this.label1 = new System.Windows.Forms.Label();
            this.None_Redeem_btn = new System.Windows.Forms.Button();
            this.Redeem_Textbox = new System.Windows.Forms.TextBox();
            this.Alert_Message_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(550, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "um... Library Empty.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // None_Redeem_btn
            // 
            this.None_Redeem_btn.Location = new System.Drawing.Point(554, 348);
            this.None_Redeem_btn.Name = "None_Redeem_btn";
            this.None_Redeem_btn.Size = new System.Drawing.Size(196, 33);
            this.None_Redeem_btn.TabIndex = 1;
            this.None_Redeem_btn.Text = "Redeem";
            this.None_Redeem_btn.UseVisualStyleBackColor = true;
            this.None_Redeem_btn.Click += new System.EventHandler(this.None_Redeem_btn_Click);
            // 
            // Redeem_Textbox
            // 
            this.Redeem_Textbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Redeem_Textbox.Location = new System.Drawing.Point(554, 320);
            this.Redeem_Textbox.Name = "Redeem_Textbox";
            this.Redeem_Textbox.Size = new System.Drawing.Size(196, 22);
            this.Redeem_Textbox.TabIndex = 0;
            this.Redeem_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Alert_Message_Label
            // 
            this.Alert_Message_Label.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alert_Message_Label.Location = new System.Drawing.Point(551, 406);
            this.Alert_Message_Label.Name = "Alert_Message_Label";
            this.Alert_Message_Label.Size = new System.Drawing.Size(199, 23);
            this.Alert_Message_Label.TabIndex = 2;
            this.Alert_Message_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // None
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Alert_Message_Label);
            this.Controls.Add(this.Redeem_Textbox);
            this.Controls.Add(this.None_Redeem_btn);
            this.Controls.Add(this.label1);
            this.Name = "None";
            this.Size = new System.Drawing.Size(1280, 670);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button None_Redeem_btn;
        private System.Windows.Forms.TextBox Redeem_Textbox;
        private System.Windows.Forms.Label Alert_Message_Label;
    }
}
