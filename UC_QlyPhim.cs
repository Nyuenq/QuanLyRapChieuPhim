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
using System.Windows.Forms;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class UC_QlyPhim : UserControl
    {
        public UC_QlyPhim()
        {
            InitializeComponent();
            LoadDanhSachPhim();
            
        }
        
        PhimBLL bll = new PhimBLL();
        PhimDTO phimDangChon = null;
        private void LoadDanhSachPhim()
        {
            List<PhimDTO> ds = bll.GetDanhSach();
            flpPhim.Controls.Clear();

            foreach (PhimDTO p in ds)
            {
                Phim phim = new Phim();
                phim.DuLieu(p);

                phim.ClickPhim += (x) =>
                {
                    HienThiChiTiet(x);
                };

                phim.Margin = new Padding(10);
                flpPhim.Controls.Add(phim);
            }
        }


        private void HienThiChiTiet(PhimDTO p)
        {
            phimDangChon = p; 
            ptbPoster.ImageLocation = Path.Combine(Application.StartupPath, "Poster", p.Poster);

            lbTen.Text = p.TenPhim;
            lbTheLoai.Text = p.TheLoai;
            lbThoiLuong.Text = p.ThoiLuong + " phút";
            lbTrangThai.Text = p.TrangThai;
            lbNgay.Text = p.Ngay.ToString("dd/MM/yyyy");
            lbGia.Text = p.GiaVe + "VND";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (phimDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phim!");
                return;
            }

            if (MessageBox.Show("Xóa phim này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bll.Xoa(phimDangChon.MaPhim))
                {
                    MessageBox.Show("Đã xóa!");

                    phimDangChon = null; 

                    ptbPoster.Image = null;
                    lbTen.Text = "";
                    lbTheLoai.Text = "";
                    lbThoiLuong.Text = "";
                    lbTrangThai.Text = "";
                    lbNgay.Text = "";
                    lbGia.Text = "";

                    LoadDanhSachPhim();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (phimDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phim!");
                return;
            }

            PhimADD f = new PhimADD(phimDangChon.MaPhim);

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachPhim();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          
            PhimADD f = new PhimADD();

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachPhim();
            }
        }

        private void ptbPoster_Click(object sender, EventArgs e)
        {

        }
    }
}