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
    public partial class DichVuADD : Form
    {
        public DichVuADD()
        {
            InitializeComponent();
        }
        DichVuBLL bll = new DichVuBLL();
        string MaDV = null;
        public DichVuADD(string ma)
        {
            InitializeComponent();
            MaDV = ma;
            this.Load += DichVuADD_Load;
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống");
                return;
            }

            decimal.TryParse(txtGia.Text, out decimal gia);
            int soLuong = (int)udSoLuong.Value;

            DichVuDTO dv = new DichVuDTO()
            {
                TenDichVu = txtTen.Text,
                Gia = gia,
                SoLuong = soLuong,
                Anh = txtPoster.Text
            };

            bool kq;

            if (MaDV == null)
            {
                kq = bll.Them(dv);
            }
            else
            {
                dv.MaDichVu = MaDV;
                kq = bll.Sua(dv);
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

        private void btnChonAnh_Click(object sender, EventArgs e)
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

        private void DichVuADD_Load(object sender, EventArgs e)
        {

            if (MaDV != null)
            {
                DichVuDTO dv = bll.Tim(MaDV);

                if (dv != null)
                {
                    txtTen.Text = dv.TenDichVu;
                    txtGia.Text = dv.Gia.ToString();
                    udSoLuong.Minimum = 0;
                    udSoLuong.Maximum = 10000;
                    udSoLuong.Value = dv.SoLuong;
                    txtPoster.Text = dv.Anh;

                    string path = Path.Combine(Application.StartupPath, "Poster", dv.Anh);
                    if (File.Exists(path))
                        picPreview.ImageLocation = path;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
