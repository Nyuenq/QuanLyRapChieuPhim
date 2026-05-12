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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class FrmThanhToan : Form
    {
        List<GioHangDTO> gioHang;
        string maHD;
        public FrmThanhToan(string maHD, List<GioHangDTO> gioHang)
        {
            InitializeComponent();
            this.maHD = maHD;
            this.gioHang = gioHang;
        }
        HoaDonBLL hoadonBLL = new HoaDonBLL();
        VeBLL veBLL = new VeBLL();
        private void FrmThanhToan_Load_1(object sender, EventArgs e)
        {
            lbTenPhim.Text = MaHD.TenPhim;

            lbPhong.Text = MaHD.TenPhong;

            lbNgay.Text =
                MaHD.NgayChieu.ToString("dd/MM/yyyy");

            lbGio.Text =
                MaHD.GioChieu.ToString(@"hh\:mm");

            dgvVe.Rows.Clear();

            decimal giaGoc =
                veBLL.LayGiaVeGoc(MaHD.MaSuatChieu);
            if (MaHD.GheDangChon != null)
            {

                foreach (var ghe in MaHD.GheDangChon)
                {
                    decimal gia = giaGoc;
                    if (ghe.LoaiGhe == "VIP")
                    {
                        gia += 10000;
                    }
                    else if (ghe.LoaiGhe == "Đôi")
                    {
                        gia = (giaGoc * 2) + 20000;
                    }

                    dgvVe.Rows.Add(
                        ghe.HangGhe + ghe.SoG,
                        ghe.LoaiGhe,
                        gia.ToString("N0") + " VNĐ");
                }
            }

            dgvDichVu.Rows.Clear();

            if (MaHD.GioHang != null)
            {
                foreach (var item in MaHD.GioHang)
                {
                    dgvDichVu.Rows.Add(
                        item.TenDV,
                        item.SoLuong,
                        item.Gia.ToString("N0"),
                        item.ThanhTien.ToString("N0")
                    );
                }
            }


            lbTienVe.Text =
                MaHD.TongTienGhe.ToString("N0") + " VNĐ";

            lbTienDV.Text =
                MaHD.TongTienDichVu.ToString("N0") + " VNĐ";


            lbTongTien.Text =
               MaHD.TongTien.ToString("N0") + " VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = false;
            string maHDTuDong = hoadonBLL.TaoMaHoaDon();
            bool kq = veBLL.DatVe(maHDTuDong, MaHD.MaTaiKhoan, MaHD.MaSuatChieu, MaHD.GheDangChon, MaHD.GioHang);

            if (kq)
            {
                MessageBox.Show("Thanh toán thành công");
                FrmHoaDon frmHoaDon = new FrmHoaDon(maHDTuDong);
                frmHoaDon.ShowDialog();

                MaHD.Reset();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
                btnThanhToan.Enabled = true;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
