using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class FrmDichVu : Form
    {
        DichVuBLL bll = new DichVuBLL();
        DichVuDTO SpDangChon ;
        string maHD = MaHD.MaHoaDon;
        public FrmDichVu()
        {
            InitializeComponent();
            LoadDanhSachDichVu();
        }
        private void LoadDanhSachDichVu()
        {
            List<DichVuDTO> ds = bll.GetAll();
            flpDichVu.Controls.Clear();

            foreach (DichVuDTO dv in ds)
            {
                Phim phim = new Phim();
                phim.DataDV(dv);

                phim.ClickDichVu += (y) =>
                {
                    HienThiChiTiet(y);
                };

                phim.Margin = new Padding(10);
                flpDichVu.Controls.Add(phim);
            }
        }
        private void HienThiChiTiet(DichVuDTO dv)
        {
            SpDangChon = dv;
            picAnh.ImageLocation = Path.Combine(Application.StartupPath, "Poster", dv.Anh);

            lbTen.Text = dv.TenDichVu;
            udSoLuong.Items.Clear();
            for (int i = 0; i <= dv.SoLuong; i++)
            {
                udSoLuong.Items.Add(i.ToString());
            }
            udSoLuong.SelectedIndex = 0;
            //lbGia.Text = "0 VND";

        }

        private void udSoLuong_SelectedItemChanged(object sender, EventArgs e)
        {
            //int soLg = 0;

            //int.TryParse(udSoLuong.Text, out soLg);

            //decimal tongTien = soLg * SpDangChon.Gia ;

            //lbGia.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        List<GioHangDTO> gioHang = new List<GioHangDTO>();
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (SpDangChon == null) return;

            int soLuong = int.Parse(udSoLuong.Text);

            if (soLuong <= 0) return;

            var item = gioHang.FirstOrDefault(x => x.MaDV == SpDangChon.MaDichVu);

            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                gioHang.Add(new GioHangDTO
                {
                    MaDV = SpDangChon.MaDichVu,
                    TenDV = SpDangChon.TenDichVu,
                    Gia = SpDangChon.Gia,
                    SoLuong = soLuong
                });
            }

            HienThiGioHang();
        }
        private void HienThiGioHang()
        {
            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = gioHang;
            dgvSanPham.Columns["MaDV"].Visible = false;
            lbTongTien.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0") + " VNĐ";
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

            lbTen.Text = row.Cells["TenDV"].Value.ToString();


            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

            udSoLuong.Text = soLuong.ToString();

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MaHD.GioHang = gioHang;
            MaHD.TongTienDichVu = gioHang.Sum(x => x.ThanhTien);

            FrmThanhToan ttoan = new FrmThanhToan(MaHD.MaHoaDon, gioHang);

            this.Hide();
            ttoan.ShowDialog();
            this.Show();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            string maDV = dgvSanPham.CurrentRow.Cells["MaDV"].Value.ToString();

            var item = gioHang.FirstOrDefault(x => x.MaDV == maDV);

            if (item != null)
            {
                item.SoLuong--;

                if (item.SoLuong <= 0)
                {
                    gioHang.Remove(item);
                }

                HienThiGioHang();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
