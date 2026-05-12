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
    public partial class FrmThongKe : Form
    {
        TaiKhoanDTO taikhoan;
        public FrmThongKe(TaiKhoanDTO tk)
        {
            InitializeComponent();
            taikhoan = tk;
        }
        ThongKeBLL bll = new ThongKeBLL();
        void LoadThongKe()
        {
            lblDoanhThuNgay.Text = bll.DoanhThuNgay().ToString("N0") + " VNĐ";
            lblDoanhThuThang.Text = bll.DoanhThuThang().ToString("N0") + " VNĐ";
            lblTongDoanhThu.Text = bll.TongDoanhThu().ToString("N0") + " VNĐ";
            dgvTopPhim.DataSource = bll.Top5Phim();
            dgvDichVu.DataSource =bll.ThongKeDichVu();
            lblVe.Text = bll.VeBanHomNay().ToString("N0") + " Vé ";
            lblNhanVienSuatSac.Text = bll.NhanVienBanNhieuNhat();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
