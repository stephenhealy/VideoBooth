namespace VideoBooth
{
    partial class frmQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestion));
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnReady = new System.Windows.Forms.Button();
            this.plyMedia = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.plyMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSkip
            // 
            this.btnSkip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.Location = new System.Drawing.Point(483, 21);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(87, 40);
            this.btnSkip.TabIndex = 16;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(576, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 40);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(12, 28);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(175, 25);
            this.lblQuestion.TabIndex = 14;
            this.lblQuestion.Text = "Question # 1 of 13";
            // 
            // btnReady
            // 
            this.btnReady.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.Location = new System.Drawing.Point(286, 21);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(191, 40);
            this.btnReady.TabIndex = 13;
            this.btnReady.Text = "Ready to Respond";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // plyMedia
            // 
            this.plyMedia.Enabled = true;
            this.plyMedia.Location = new System.Drawing.Point(17, 70);
            this.plyMedia.Name = "plyMedia";
            this.plyMedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("plyMedia.OcxState")));
            this.plyMedia.Size = new System.Drawing.Size(640, 480);
            this.plyMedia.TabIndex = 17;
            // 
            // frmQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.plyMedia);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnReady);
            this.Name = "frmQuestion";
            this.Text = "Questions";
            ((System.ComponentModel.ISupportInitialize)(this.plyMedia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnReady;
        private AxWMPLib.AxWindowsMediaPlayer plyMedia;
    }
}