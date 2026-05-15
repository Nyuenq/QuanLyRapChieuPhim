namespace QuanLyRapChieuPhim
{
    partial class PhimVaDichVu
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbPoster = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.pbPoster);
            this.guna2Panel1.Controls.Add(this.lblTen);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(186, 197);
            this.guna2Panel1.TabIndex = 0;
            // 
            // pbPoster
            // 
            this.pbPoster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.pbPoster.BorderRadius = 15;
            this.pbPoster.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPoster.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.pbPoster.ImageRotate = 0F;
            this.pbPoster.Location = new System.Drawing.Point(0, 0);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(186, 135);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 4;
            this.pbPoster.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTen.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTen.ForeColor = System.Drawing.Color.White;
            this.lblTen.Location = new System.Drawing.Point(0, 153);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(186, 44);
            this.lblTen.TabIndex = 3;
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Phim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Phim";
            this.Size = new System.Drawing.Size(186, 197);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox pbPoster;
        private System.Windows.Forms.Label lblTen;
    }
}
