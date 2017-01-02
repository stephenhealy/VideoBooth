namespace VideoBooth
{
    partial class frmEvent
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
            this.lblOptions = new System.Windows.Forms.Label();
            this.btnStartOver = new System.Windows.Forms.Button();
            this.lblSaved = new System.Windows.Forms.Label();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(12, 20);
            this.lblOptions.MaximumSize = new System.Drawing.Size(650, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(196, 22);
            this.lblOptions.TabIndex = 10;
            this.lblOptions.Text = "Here are the options...";
            // 
            // btnStartOver
            // 
            this.btnStartOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStartOver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartOver.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartOver.ForeColor = System.Drawing.Color.White;
            this.btnStartOver.Location = new System.Drawing.Point(522, 500);
            this.btnStartOver.Name = "btnStartOver";
            this.btnStartOver.Size = new System.Drawing.Size(150, 50);
            this.btnStartOver.TabIndex = 16;
            this.btnStartOver.Text = "Start Over";
            this.btnStartOver.UseVisualStyleBackColor = false;
            this.btnStartOver.Click += new System.EventHandler(this.btnStartOver_Click);
            // 
            // lblSaved
            // 
            this.lblSaved.AutoSize = true;
            this.lblSaved.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaved.Location = new System.Drawing.Point(108, 180);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(468, 37);
            this.lblSaved.TabIndex = 17;
            this.lblSaved.Text = "Your videos have been saved.";
            this.lblSaved.Visible = false;
            // 
            // lblThanks
            // 
            this.lblThanks.AutoSize = true;
            this.lblThanks.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanks.Location = new System.Drawing.Point(203, 94);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(279, 75);
            this.lblThanks.TabIndex = 18;
            this.lblThanks.Text = "Thanks!";
            this.lblThanks.Visible = false;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.Location = new System.Drawing.Point(21, 288);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(642, 21);
            this.lblInformation.TabIndex = 19;
            this.lblInformation.Text = "To reserve your video booth, check us out online at http://www.video-booth.com";
            this.lblInformation.Visible = false;
            // 
            // frmEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.lblThanks);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.btnStartOver);
            this.Controls.Add(this.lblOptions);
            this.Name = "frmEvent";
            this.Text = "Welcome to Video Booth!";
            this.Load += new System.EventHandler(this.frmEvent_Load);
            this.Resize += new System.EventHandler(this.frmEvent_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Button btnStartOver;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblInformation;
    }
}