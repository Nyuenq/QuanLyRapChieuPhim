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
using static QuanLyKhamBenhNgoaiTru.Ghe;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class DatVe : Form
    {
        TaiKhoanDTO taikhoan;
        public DatVe(TaiKhoanDTO tk)
        {
            InitializeComponent();
            LoadPhim();
            taikhoan = tk;
        }
        GheBLL gheBLL = new GheBLL();
        PhimBLL phimBLL = new PhimBLL();
        SuatChieuBLL suatchieuBLL = new SuatChieuBLL();
        List<GheDTO> dsGheChon = new List<GheDTO>();
        VeBLL veBLL = new VeBLL();
        public void VeGhe_Table(string maSuatChieu)
        {
            List<GheDTO> ds = gheBLL.DanhSachGhe(maSuatChieu);
            if (ds.Count == 0) return;
            int soHang = ds.Max(x => x.HangGhe[0] - 'A') + 1;
            int soCot = ds.Max(x => x.SoG);
            tlbGhe.Controls.Clear();
            tlbGhe.RowStyles.Clear();
            tlbGhe.ColumnStyles.Clear();
            tlbGhe.RowCount = soHang;
            tlbGhe.ColumnCount = soCot;
            for (int i = 0; i < soHang; i++)
            {
                tlbGhe.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100f / soHang)
                );
            }
            for (int i = 0; i < soCot; i++)
            {
                tlbGhe.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100f / soCot)
                );
            }
            foreach (GheDTO ghe in ds)
            {
                int row = ghe.HangGhe[0] - 'A';
                int col = ghe.SoG - 1;
                Ghe gheUI = new Ghe();
                gheUI.DuLieu(ghe);
                gheUI.Mode = CheDoGhe.DatVe;
                gheUI.OnChonGhe += GheUI_OnChonGhe;
                gheUI.ChoChMau = true;
                gheUI.Dock = DockStyle.Fill;
                gheUI.Margin = new Padding(5);
                tlbGhe.Controls.Add(gheUI, col, row);
                if (ghe.LoaiGhe == "Đôi")
                {
                    tlbGhe.SetColumnSpan(gheUI, 2);
                }
            }
        }
        private void GheUI_OnChonGhe(GheDTO ghe, bool dangChon)
        {
            if (dangChon)
            {
                dsGheChon.Add(ghe);
            }
            else
            {
                dsGheChon.Remove(ghe);
            }
            lblGheChon.Text = string.Join(", ",dsGheChon.Select(x => x.HangGhe + x.SoG));
            TinhTien();
        }
        private void TinhTien()
        {
            decimal tong = 0;

            string maSC = cbSuatChieu.SelectedValue.ToString();

            decimal giaGoc = veBLL.LayGiaVeGoc(maSC);

            foreach (var ghe in dsGheChon)
            {
                if (ghe.LoaiGhe == "Đôi")
                {
                    tong += (giaGoc * 2) + 20000;
                }
                else if (ghe.LoaiGhe == "VIP")
                {
                    tong += giaGoc + 10000;
                }
                else
                {
                    tong += giaGoc;
                }
            }

            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
            MaHD.TongTienGhe = tong;
        }
        

        
        private void LoadPhim()
        {
            cbPhim.DataSource = phimBLL.GetDanhSach();

            cbPhim.DisplayMember = "TenPhim";

            cbPhim.ValueMember = "MaPhim";

            cbPhim.SelectedIndex = -1;
        }
        void LoadPoster(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    ClearPoster();
                    return;
                }

                string path = Path.Combine(Application.StartupPath, "Poster", fileName);

                if (File.Exists(path))
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var oldImage = picPoster.Image;
                        picPoster.Image = Image.FromStream(fs);
                        if (oldImage != null) oldImage.Dispose();
                    }
                }
                else
                {
                    ClearPoster();
                }
            }
            catch
            {
                ClearPoster();
            }
        }
        private void ClearPoster()
        {
            var oldImage = picPoster.Image;
            picPoster.Image = null;
            if (oldImage != null) oldImage.Dispose();
        }

       

       

        private void cbSuatChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuatChieu.SelectedIndex == -1)
                return;

            if (cbSuatChieu.SelectedValue == null)
                return;

            if (!(cbSuatChieu.SelectedValue is string))
                return;

            string maSC = cbSuatChieu.SelectedValue.ToString();

            VeGhe_Table(maSC);
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPhim.SelectedIndex == -1)
                return;

            string maPhim = cbPhim.SelectedValue.ToString();

            cbSuatChieu.DataSource =
                suatchieuBLL.LaySuatChieuTheoPhim(maPhim);

            cbSuatChieu.DisplayMember = "HienThi";

            cbSuatChieu.ValueMember = "MaSuatChieu";

            cbSuatChieu.SelectedIndex = -1;

            tlbGhe.Controls.Clear();

            if (cbPhim.SelectedItem is PhimDTO phim)
            {
                LoadPoster(phim.Poster);
            }
        }

        private void btnTiepTuc_Click_1(object sender, EventArgs e)
        {

            if (dsGheChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ghế");
                return;
            }
            MaHD.GheDangChon = dsGheChon;
            MaHD.MaSuatChieu =
                cbSuatChieu.SelectedValue.ToString();
            if (cbPhim.SelectedItem is PhimDTO phim)
            {
                MaHD.TenPhim = phim.TenPhim;
            }

            // SUẤT CHIẾU
            SuatChieuDTO sc =
                cbSuatChieu.SelectedItem as SuatChieuDTO;

            if (sc != null)
            {
                MaHD.GioChieu = sc.GioChieu;

                MaHD.NgayChieu = DateTime.Today;

                MaHD.TenPhong = sc.TenPhong;
            }

            FrmDichVu f = new FrmDichVu();

            f.ShowDialog();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
