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
    public partial class FrmTrangChuu : Form
    {
        TaiKhoanDTO taikhoan = new TaiKhoanDTO();
        public FrmTrangChuu(TaiKhoanDTO tk)
        {
            InitializeComponent();
            taikhoan = tk;
            PhanQuyen();
        }
        private void LoadUC(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }
        private void btnQlPhim_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_QlyPhim());
        }

        private void btnQlPhong_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_QlyPhong());
        }

        private void btnQlSuatChieu_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_SuatChieu());
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            DatVe datve = new DatVe(taikhoan);
            this.Hide();
            datve.ShowDialog();
            this.Show();
        }

        private void btnQlTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadUC(new UC_QuanLyTaiKhoan());
        }

        private void btnQlDichVu_Click(object sender, EventArgs e)
        {
            LoadUC(new UCQuanLyDichVu());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmDangNhap dangnhap =  new FrmDangNhap();
            dangnhap.ShowDialog();
            this.Close();
        }
        void PhanQuyen()
        {
            if (taikhoan.VaiTro == "Nhân Viên")
            {
                btnQlDichVu.Visible = false;
                btnQlPhim.Visible = false;
                btnQlPhong.Visible = false;
                btnQlTaiKhoan.Visible = false;
                btnDangKy.Visible = false;
            }
            lbTen.Text = taikhoan.HoTen ;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy dangKy = new FrmDangKy();
            dangKy.ShowDialog();
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FrmThongKe thongKe = new FrmThongKe(taikhoan);
            this.Hide();
            thongKe.ShowDialog();
            this.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
