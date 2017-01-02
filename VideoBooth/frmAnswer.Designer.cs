namespace VideoBooth
{
    partial class frmAnswer
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
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblLook = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.panPreview = new System.Windows.Forms.Panel();
            this.lblNow = new System.Windows.Forms.Label();
            this.picArrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCountdown
            // 
            this.lblCountdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(175, 29);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(334, 32);
            this.lblCountdown.TabIndex = 20;
            this.lblCountdown.Text = "Get ready to answer in...";
            this.lblCountdown.Visible = false;
            // 
            // lblLook
            // 
            this.lblLook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLook.AutoSize = true;
            this.lblLook.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLook.Location = new System.Drawing.Point(232, 418);
            this.lblLook.Name = "lblLook";
            this.lblLook.Size = new System.Drawing.Size(219, 20);
            this.lblLook.TabIndex = 18;
            this.lblLook.Text = "Don\'t forget to look at the camera!";
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(308, 75);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(68, 75);
            this.lblCounter.TabIndex = 21;
            this.lblCounter.Text = "5";
            this.lblCounter.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackColor = System.Drawing.Color.White;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRestart.Location = new System.Drawing.Point(132, 193);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(421, 75);
            this.btnRestart.TabIndex = 19;
            this.btnRestart.Text = "Start Over";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(132, 288);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(421, 111);
            this.btnDone.TabIndex = 17;
            this.btnDone.Text = "DONE!";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Visible = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // panPreview
            // 
            this.panPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panPreview.Location = new System.Drawing.Point(630, 441);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(35, 32);
            this.panPreview.TabIndex = 22;
            this.panPreview.Visible = false;
            // 
            // lblNow
            // 
            this.lblNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNow.AutoSize = true;
            this.lblNow.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNow.Location = new System.Drawing.Point(130, 44);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(424, 75);
            this.lblNow.TabIndex = 23;
            this.lblNow.Text = "Starting up...";
            // 
            // picArrow
            // 
            this.picArrow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.picArrow.ImageLocation = "";
            this.picArrow.Location = new System.Drawing.Point(326, 441);
            this.picArrow.Name = "picArrow";
            this.picArrow.Size = new System.Drawing.Size(33, 50);
            this.picArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picArrow.TabIndex = 24;
            this.picArrow.TabStop = false;
            // 
            // frmAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 492);
            this.Controls.Add(this.picArrow);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.lblLook);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblNow);
            this.Name = "frmAnswer";
            this.Text = "Respond";
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblLook;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.PictureBox picArrow;
    }
}