using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BLL;
namespace QuanLyRapChieuPhim
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }
        private void lamsach()
        {
            txtHoTen.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtMatKhaul2.Clear();
            cmbQuyen.SelectedIndex = -1;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO dto = new TaiKhoanDTO();
            dto.TenDN = txtTaiKhoan.Text;
            dto.HoTen = txtHoTen.Text;
            dto.MatKhau = txtMatKhau.Text;
            dto.VaiTro = cmbQuyen.Text;
            TaiKhoanBLL bll = new TaiKhoanBLL();           
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || string.IsNullOrWhiteSpace(txtMatKhaul2.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tài khoản, mật khẩu và họ tên không được để trống","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (txtMatKhau.Text != txtMatKhaul2.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhaul2.Focus();
                return;
            }

            if (txtMatKhau.TextLength < 6)
            {
                MessageBox.Show("Mật khẩu phải ≥ 6 ký tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (cmbQuyen.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quyền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bll.KiemTra(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            if (bll.DangKy(dto))
            {
                MessageBox.Show("Tạo tài khoản thành công", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            lamsach();
            txtTaiKhoan.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            frmDangNhap.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
