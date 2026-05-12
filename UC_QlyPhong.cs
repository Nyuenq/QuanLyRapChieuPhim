using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class UC_QlyPhong : UserControl
    {
        GheBLL g = new GheBLL();
        GheDTO gheDangChon = null;
        public UC_QlyPhong()
        {
            InitializeComponent();
            loadform();

        }
        PhongBLL bll = new PhongBLL();
        PhongDTO phongDangChon = null;

        public void VeGhe_Table(string maPhong)
        {
            List<GheDTO> ds = g.DanhSachG(maPhong);

            if (ds == null || ds.Count == 0)
            {
                tlbGhe.Controls.Clear();
                tlbGhe.Visible = false;
                MessageBox.Show("Phòng này chưa có ghế!");
                return;
            }
            tlbGhe.Visible = true;
            var phong = bll.GetById(maPhong);
            int soHang = phong.SoHang;
            int soCot = phong.SoCot;
            tlbGhe.Controls.Clear();
            tlbGhe.RowCount = soHang;
            tlbGhe.ColumnCount = soCot;
            tlbGhe.RowStyles.Clear();
            tlbGhe.ColumnStyles.Clear();
            tlbGhe.SuspendLayout();
            for (int i = 0; i < soHang; i++)
                tlbGhe.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / soHang));
            for (int j = 0; j < soCot; j++)
                tlbGhe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / soCot));
            foreach (var ghe in ds)
            {
                int row = ghe.HangGhe[0] - 'A';
                int col;
                if (ghe.LoaiGhe == "Đôi")
                {
                    int soCotDoi = soCot / 2;
                    int offset = (soCot - soCotDoi * 2) / 2;
                    col = offset + (ghe.SoG - 1) * 2;
                }
                else
                {
                    col = ghe.SoG - 1;
                }
                if (row < 0 || row >= soHang || col < 0 || col >= soCot)
                    continue;
                Ghe gheUI = new Ghe();
                gheUI.DuLieu(ghe);
                gheUI.Mode = Ghe.CheDoGhe.QuanLy;
                gheUI.ChoChMau = true;
                gheUI.Dock = DockStyle.Fill;
                gheUI.ClickG = (g) =>
                {
                    gheDangChon = g;
                    cboLoai.Text = g.LoaiGhe;
                    cboTrangThai.Text = g.TrangThai;
                };
                ToolTip tip = new ToolTip();
                tip.SetToolTip(gheUI, $"{ghe.HangGhe}{ghe.SoG} - {ghe.LoaiGhe}");
                tlbGhe.Controls.Add(gheUI, col, row);
                if (ghe.LoaiGhe == "Đôi")
                {
                    tlbGhe.SetColumnSpan(gheUI, 2);
                }
            }
            tlbGhe.ResumeLayout();
        }
        
        private void loadform()
        {
            List<PhongDTO> ph = bll.DanhSachP();
            dgvPhong.DataSource = ph;
            dgvPhong.Columns["MaP"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenP"].HeaderText = "Tên phòng";
            dgvPhong.Columns["SoHang"].HeaderText = "Số hàng";
            dgvPhong.Columns["SoCot"].HeaderText = "Số cột";

        }
       
        private void btnXoaPh_Click_1(object sender, EventArgs e)
        {
            if (phongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }
            if (MessageBox.Show("Xóa phòng này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bll.XoaPhong(phongDangChon.MaP))
                {
                    MessageBox.Show("Đã xóa!");
                    phongDangChon = null;
                    loadform();
                }
            }
        }

        private void btnXemGhe_Click_1(object sender, EventArgs e)
        {
            if (phongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trước!");
                return;
            }
            string maPhong = phongDangChon.MaP;
            VeGhe_Table(phongDangChon.MaP);
        }

        private void btnSuaGhe_Click_1(object sender, EventArgs e)
        {
            if (gheDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn ghế!");
                return;
            }
            if (gheDangChon.LoaiGhe == "Đôi" && cboLoai.Text != "Đôi")
            {
                MessageBox.Show("Không thể đổi ghế đôi sang loại ghế khác!");
                return;
            }
            gheDangChon.LoaiGhe = cboLoai.Text;
            gheDangChon.TrangThai = cboTrangThai.Text;
            bool kq = g.Sua(gheDangChon);

            if (kq)
            {
                MessageBox.Show("Sửa ghế thành công");
                VeGhe_Table(gheDangChon.MaP);
                gheDangChon = null;
            }
        }

        private void btnXoaGhe_Click_1(object sender, EventArgs e)
        {
            if (gheDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn ghế");
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có muốn xoá ghế?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                if (g.Xoa(gheDangChon.MaG))
                {
                    MessageBox.Show("Xóa thành công");
                    VeGhe_Table(gheDangChon.MaP);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void dgvPhong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
            phongDangChon = new PhongDTO()
            {
                MaP = row.Cells["MaP"].Value.ToString(),
                TenP = row.Cells["TenP"].Value.ToString(),
                SoHang = Convert.ToInt32(row.Cells["SoHang"].Value),
                SoCot = Convert.ToInt32(row.Cells["SoCot"].Value)
            };
            string maPhong = dgvPhong.Rows[e.RowIndex].Cells["MaP"].Value.ToString();
        }
    }
}
