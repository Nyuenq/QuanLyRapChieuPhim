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
    public partial class UCQuanLyDichVu : UserControl
    {
      
        public UCQuanLyDichVu()
        {
            InitializeComponent();
            LoadDanhSachDichVu();
        }
        DichVuBLL bll = new DichVuBLL();
        DichVuDTO SpDangChon;
       
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
            lbTen.Text = dv.TenDichVu;
            lbSoLuong.Text = dv.SoLuong.ToString();
            lbGia.Text = dv.Gia.ToString("N0") + " VNĐ";
            picAnh.ImageLocation = Path.Combine(Application.StartupPath, "Poster", dv.Anh);
            

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DichVuADD dvADD = new DichVuADD();
            if(dvADD.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachDichVu();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (SpDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            DichVuADD f = new DichVuADD(SpDangChon.MaDichVu);
            if (f.ShowDialog() == DialogResult.OK)
            {
                SpDangChon = null;
                picAnh.Image = null;
                lbTen.Text = "";
                lbSoLuong.Text = "";
                lbGia.Text = "";

                LoadDanhSachDichVu();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (SpDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }
            if (MessageBox.Show("Xóa dịch vụ này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bll.Xoa(SpDangChon.MaDichVu))
                {
                    MessageBox.Show("Đã xóa!");

                    SpDangChon = null;

                    picAnh.Image = null;
                    lbTen.Text = "";
                    lbSoLuong.Text = "";
                    lbGia.Text = "";

                   LoadDanhSachDichVu();
                }
            }
        }
        
    }
}
