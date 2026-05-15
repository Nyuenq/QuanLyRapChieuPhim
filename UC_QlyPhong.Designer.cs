namespace QuanLyRapChieuPhim
{
    partial class UC_QlyPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXoaGhe = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuaGhe = new Guna.UI2.WinForms.Guna2Button();
            this.cboLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tlbGhe = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPhong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnXoaPh = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXemGhe = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoaGhe
            // 
            this.btnXoaGhe.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaGhe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.btnXoaGhe.BorderRadius = 10;
            this.btnXoaGhe.BorderThickness = 2;
            this.btnXoaGhe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaGhe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaGhe.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaGhe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.btnXoaGhe.Location = new System.Drawing.Point(325, 646);
            this.btnXoaGhe.Name = "btnXoaGhe";
            this.btnXoaGhe.Size = new System.Drawing.Size(168, 58);
            this.btnXoaGhe.TabIndex = 9;
            this.btnXoaGhe.Text = "Xoá";
            this.btnXoaGhe.Click += new System.EventHandler(this.btnXoaGhe_Click_1);
            // 
            // btnSuaGhe
            // 
            this.btnSuaGhe.BackColor = System.Drawing.Color.Transparent;
            this.btnSuaGhe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnSuaGhe.BorderRadius = 10;
            this.btnSuaGhe.BorderThickness = 2;
            this.btnSuaGhe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaGhe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaGhe.FillColor = System.Drawing.Color.Transparent;
            this.btnSuaGhe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSuaGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnSuaGhe.Location = new System.Drawing.Point(61, 646);
            this.btnSuaGhe.Name = "btnSuaGhe";
            this.btnSuaGhe.Size = new System.Drawing.Size(168, 58);
            this.btnSuaGhe.TabIndex = 10;
            this.btnSuaGhe.Text = "Sửa";
            this.btnSuaGhe.Click += new System.EventHandler(this.btnSuaGhe_Click_1);
            // 
            // cboLoai
            // 
            this.cboLoai.BackColor = System.Drawing.Color.Transparent;
            this.cboLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(46)))));
            this.cboLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoai.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboLoai.ForeColor = System.Drawing.Color.Cyan;
            this.cboLoai.ItemHeight = 30;
            this.cboLoai.Items.AddRange(new object[] {
            "Thường",
            "VIP"});
            this.cboLoai.Location = new System.Drawing.Point(214, 531);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(209, 36);
            this.cboLoai.TabIndex = 11;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(46)))));
            this.cboTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboTrangThai.ForeColor = System.Drawing.Color.Cyan;
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Hoạt động ",
            "Hỏng"});
            this.cboTrangThai.Location = new System.Drawing.Point(214, 589);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(209, 36);
            this.cboTrangThai.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Location = new System.Drawing.Point(92, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Loại ghế";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label3.Location = new System.Drawing.Point(92, 604);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Trạng thái";
            // 
            // tlbGhe
            // 
            this.tlbGhe.ColumnCount = 2;
            this.tlbGhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlbGhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlbGhe.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbGhe.Location = new System.Drawing.Point(0, 0);
            this.tlbGhe.Name = "tlbGhe";
            this.tlbGhe.RowCount = 2;
            this.tlbGhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlbGhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlbGhe.Size = new System.Drawing.Size(573, 463);
            this.tlbGhe.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlbGhe);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboTrangThai);
            this.panel1.Controls.Add(this.cboLoai);
            this.panel1.Controls.Add(this.btnSuaGhe);
            this.panel1.Controls.Add(this.btnXoaGhe);
            this.panel1.Location = new System.Drawing.Point(583, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 746);
            this.panel1.TabIndex = 3;
            // 
            // dgvPhong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPhong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhong.ColumnHeadersHeight = 20;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhong.Location = new System.Drawing.Point(1, 39);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.RowTemplate.Height = 24;
            this.dgvPhong.Size = new System.Drawing.Size(547, 535);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPhong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPhong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPhong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPhong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPhong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvPhong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPhong.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvPhong.ThemeStyle.ReadOnly = true;
            this.dgvPhong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvPhong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvPhong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick_1);
            // 
            // btnXoaPh
            // 
            this.btnXoaPh.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaPh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.btnXoaPh.BorderRadius = 10;
            this.btnXoaPh.BorderThickness = 2;
            this.btnXoaPh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaPh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaPh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaPh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaPh.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaPh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaPh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.btnXoaPh.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnXoaPh.Location = new System.Drawing.Point(288, 595);
            this.btnXoaPh.Name = "btnXoaPh";
            this.btnXoaPh.Size = new System.Drawing.Size(137, 42);
            this.btnXoaPh.TabIndex = 3;
            this.btnXoaPh.Text = "Xoá";
            this.btnXoaPh.Click += new System.EventHandler(this.btnXoaPh_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(157, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách phòng chiếu";
            // 
            // btnXemGhe
            // 
            this.btnXemGhe.BackColor = System.Drawing.Color.Transparent;
            this.btnXemGhe.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnXemGhe.BorderRadius = 10;
            this.btnXemGhe.BorderThickness = 2;
            this.btnXemGhe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemGhe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemGhe.FillColor = System.Drawing.Color.Transparent;
            this.btnXemGhe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXemGhe.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnXemGhe.Location = new System.Drawing.Point(34, 595);
            this.btnXemGhe.Name = "btnXemGhe";
            this.btnXemGhe.Size = new System.Drawing.Size(137, 42);
            this.btnXemGhe.TabIndex = 6;
            this.btnXemGhe.Text = "Xem Ghế";
            this.btnXemGhe.Click += new System.EventHandler(this.btnXemGhe_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXemGhe);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnXoaPh);
            this.panel2.Controls.Add(this.dgvPhong);
            this.panel2.Location = new System.Drawing.Point(2, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 746);
            this.panel2.TabIndex = 4;
            // 
            // UC_QlyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_QlyPhong";
            this.Size = new System.Drawing.Size(1159, 780);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnXoaGhe;
        private Guna.UI2.WinForms.Guna2Button btnSuaGhe;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlbGhe;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhong;
        private Guna.UI2.WinForms.Guna2Button btnXoaPh;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnXemGhe;
        private System.Windows.Forms.Panel panel2;
    }
}
