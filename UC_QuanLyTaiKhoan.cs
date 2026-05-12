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
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
            LoadData();
        }
        TaiKhoanBLL bll = new TaiKhoanBLL();
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                lbMaTK.Text = row.Cells["MaTK"].Value.ToString();
                lbUsername.Text = row.Cells["TenDN"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.MaTK = lbMaTK.Text;
            tk.MatKhau = txtMatKhau.Text;
            tk.HoTen = txtHoTen.Text;
            tk.VaiTro = cboVaiTro.Text;
            tk.TrangThai = cboTrangThai.Text;
            if (bll.SuaTaiKhoan(tk))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        void LoadData()
        {
            dgvTaiKhoan.DataSource = bll.DanhSachTaiKhoan();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
