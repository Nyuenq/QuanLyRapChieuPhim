using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace QuanLyRapChieuPhim
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) ||string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống");
                return;
            }

            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();

            taiKhoanDTO.TenDN = txtTaiKhoan.Text.Trim();
            taiKhoanDTO.MatKhau = txtMatKhau.Text.Trim();

            TaiKhoanBLL bll = new TaiKhoanBLL();

            TaiKhoanDTO user = bll.DangNhap(taiKhoanDTO);

            if (user != null)
            {
                MaHD.MaTaiKhoan = user.MaTK;

                MessageBox.Show("Đăng nhập thành công");

                FrmTrangChuu trangChuu = new FrmTrangChuu(user);

                trangChuu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");

                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }

        }

        private void txtMatKhau_IconRightClick(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
        }
    }
}
