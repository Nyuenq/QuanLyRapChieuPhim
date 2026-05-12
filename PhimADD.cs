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
    public partial class PhimADD : Form
    {
        public PhimADD()
        {
            InitializeComponent();
        }
        PhimBLL bll = new PhimBLL();
        string maPhim = null;
        public PhimADD(string ma)
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

                    // hiển thị ảnh luôn
                    string path = Path.Combine(Application.StartupPath, "Poster", p.Poster);
                    if (File.Exists(path))
                        picPreview.ImageLocation = path;
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

            int.TryParse(txtThoiLuong.Text, out int thoiLuong);
            decimal.TryParse(txtGia.Text, out decimal gia);

            PhimDTO p = new PhimDTO()
            {
                TenPhim = txtTen.Text,
                TheLoai = cbTheLoai.Text,
                ThoiLuong = thoiLuong,
                GiaVe = gia,
                Ngay = dtNgay.Value,
                TrangThai = cboTrangThai.Text,
                Poster = txtPoster.Text // chỉ lưu tên file
            };

            bool kq;

            if (maPhim == null)
            {
                // ➕ THÊM
                kq = bll.Them(p);
            }
            else
            {
                // ✏️ SỬA
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
       
       

        private void btnChonAnh_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(dialog.FileName);

                    // thư mục lưu ảnh
                    string folder = Path.Combine(Application.StartupPath, "Poster");

                    // nếu chưa có thì tạo
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string destPath = Path.Combine(folder, fileName);

                    // copy ảnh vào project nếu chưa có
                    if (!File.Exists(destPath))
                    {
                        File.Copy(dialog.FileName, destPath);
                    }

                    // 👉 hiển thị preview
                    picPreview.ImageLocation = destPath;

                    // 👉 lưu vào textbox (QUAN TRỌNG)
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
    }
}
