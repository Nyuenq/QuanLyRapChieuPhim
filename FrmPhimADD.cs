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

namespace QuanLyRapChieuPhim
{
    public partial class FrmPhimADD : Form
    {
        public FrmPhimADD()
        {
            InitializeComponent();
        }
        PhimBLL bll = new PhimBLL();
        string maPhim = null;
        public FrmPhimADD(string ma)
        {
            InitializeComponent();
            maPhim = ma;
            this.Load += PhimADD_Load;
        }

        private void PhimADD_Load(object sender, EventArgs e)
        {
            if (maPhim != null)
            {
                PhimDTO p = bll.GetById(maPhim);

                if (p != null)
                {
                    txtTen.Text = p.TenPhim;
                    cbTheLoai.Text = p.TheLoai;
                    txtThoiLuong.Text = p.ThoiLuong.ToString();
                    txtGia.Text = p.GiaVe.ToString();
                    dtNgay.Value = p.Ngay;
                    cboTrangThai.Text = p.TrangThai;
                    txtPoster.Text = p.Poster;
                    string path = Path.Combine(Application.StartupPath, "Poster", p.Poster);
                    if (File.Exists(path)) picPreview.ImageLocation = path;
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên phim không được để trống");
                return;
            }

            if(!int.TryParse(txtThoiLuong.Text, out int thoiLuong))
            {
                MessageBox.Show("Thời lượng không hợp lệ");
                return;
            }
            if(!decimal.TryParse(txtGia.Text, out decimal gia))
            {
                MessageBox.Show("Giá tiền không hợp lệ");
                return;
            }

            PhimDTO p = new PhimDTO()
            {
                TenPhim = txtTen.Text,
                TheLoai = cbTheLoai.Text,
                ThoiLuong = thoiLuong,
                GiaVe = gia,
                Ngay = dtNgay.Value,
                TrangThai = cboTrangThai.Text,
                Poster = txtPoster.Text 
            };
            try
            {
                bool kq;
                if (maPhim == null)
                {
                    kq = bll.Them(p);
                }
                else
                {
                    p.MaPhim = maPhim;
                    kq = bll.Sua(p);
                }

                if (kq)
                {
                    MessageBox.Show("Thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
       

        private void btnChonAnh_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(dialog.FileName);
                    string folder = Path.Combine(Application.StartupPath, "Poster");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string destPath = Path.Combine(folder, fileName);
                    if (!File.Exists(destPath))
                    {
                        File.Copy(dialog.FileName, destPath);
                    }
                    picPreview.ImageLocation = destPath;
                    txtPoster.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThoiLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
