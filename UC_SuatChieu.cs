using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{
    public partial class UC_SuatChieu : UserControl
    {
        SuatChieuBLL scBLL = new SuatChieuBLL();
        PhongBLL phongBLL = new PhongBLL();
        PhimBLL phimBLL = new PhimBLL();

        string currentMaSC = null;

        bool isLoadingCombo = false;

        public UC_SuatChieu()
        {
            InitializeComponent();
            this.Load += UC_SuatChieu_Load;
        }

        private void UC_SuatChieu_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGio();
            LoadGrid();
        }

        void LoadCombo()
        {
            isLoadingCombo = true; 
            var dsPhim = phimBLL.GetDanhSach();
            cbPhim.DataSource = null;
            cbPhim.DisplayMember = "TenPhim"; 
            cbPhim.ValueMember = "MaPhim";    
            cbPhim.DataSource = dsPhim;       
            var dsPhong = phongBLL.DanhSachP();
            cbPhong.DataSource = null;
            cbPhong.DisplayMember = "TenP";
            cbPhong.ValueMember = "MaP";   
            cbPhong.DataSource = dsPhong;    
            isLoadingCombo = false;
            if (cbPhim.SelectedItem is PhimDTO phim)
            {
                LoadPoster(phim.Poster);
            }
        }

        void LoadGrid()
        {
            dgvSuatChieu.DataSource = scBLL.GetAll();

            if (dgvSuatChieu.Columns.Contains("MaPhim")) dgvSuatChieu.Columns["MaPhim"].Visible = false;
            if (dgvSuatChieu.Columns.Contains("MaPhong")) dgvSuatChieu.Columns["MaPhong"].Visible = false;
            if (dgvSuatChieu.Columns.Contains("MaSuatChieu")) dgvSuatChieu.Columns["MaSuatChieu"].Visible = false;
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

        void LoadGio()
        {
            cbGio.Items.Clear();
            cbGio.Items.AddRange(new object[] { "08:00", "10:00", "13:00", "15:00", "18:00", "20:00","23:30","23:55" });
            cbGio.SelectedIndex = 0;
        }
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            if (currentMaSC == null)
            {
                MessageBox.Show("Chọn suất chiếu cần huỷ!");
                return;
            }
            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn huỷ suất chiếu này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (rs == DialogResult.No) return;
            string kq = scBLL.Huy(currentMaSC); 
            MessageBox.Show(kq);
            LoadGrid();
            dgvSuatChieu.ClearSelection();
            currentMaSC = null;
        }

        private void btnReSet_Click_1(object sender, EventArgs e)
        {
            currentMaSC = null;

            if (cbPhim.Items.Count > 0) cbPhim.SelectedIndex = -1;
            if (cbPhong.Items.Count > 0) cbPhong.SelectedIndex = -1;
            if (cbGio.Items.Count > 0) cbGio.SelectedIndex = -1;
            dtpNgay.Value = DateTime.Now;
            ClearPoster();
            dgvSuatChieu.ClearSelection();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime ngay = dtpNgay.Value.Date;
            TimeSpan gio = TimeSpan.Parse(cbGio.Text);
            DateTime thoiDiemChieu = ngay + gio;
            if (thoiDiemChieu <= now)
            {
                MessageBox.Show("Không thể tạo suất chiếu trong quá khứ!");
                return;
            }
            if (cbPhim.SelectedValue == null || cbPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ dữ liệu!");
                return;
            }
            SuatChieuDTO sc = new SuatChieuDTO
            {
                MaPhim = cbPhim.SelectedValue.ToString(),
                MaPhong = cbPhong.SelectedValue.ToString(),
                NgayChieu = ngay,
                GioChieu = gio,
                TrangThai = "Sắp chiếu"
            };
            string kq = scBLL.Them(sc);
            MessageBox.Show(kq);
            LoadGrid();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (currentMaSC == null)
            {
                MessageBox.Show("Chọn suất chiếu cần sửa!");
                return;
            }
            if (cbPhim.SelectedValue == null || cbPhong.SelectedValue == null)
            {
                MessageBox.Show("Dữ liệu Phim hoặc Phòng không hợp lệ!");
                return;
            }
            SuatChieuDTO sc = new SuatChieuDTO
            {
                MaSuatChieu = currentMaSC,
                MaPhim = cbPhim.SelectedValue.ToString(),
                MaPhong = cbPhong.SelectedValue.ToString(),
                NgayChieu = dtpNgay.Value.Date,
                GioChieu = TimeSpan.Parse(cbGio.Text)
            };
            DateTime now = DateTime.Now;
            DateTime ngay = dtpNgay.Value.Date;
            TimeSpan gio = TimeSpan.Parse(cbGio.Text);
            DateTime thoiDiemChieu = ngay + gio;
            if (thoiDiemChieu <= now)
            {
                MessageBox.Show("Không thể sửa suất chiếu trong quá khứ!");
                return;
            }
            string kq = scBLL.Sua(sc);
            MessageBox.Show(kq);

            LoadGrid();
        }

       

        private void dgvSuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSuatChieu.Rows[e.RowIndex];
                if (row.Cells["MaSuatChieu"].Value != null)
                    currentMaSC = row.Cells["MaSuatChieu"].Value.ToString();
                if (row.Cells["MaPhim"].Value != null)
                    cbPhim.SelectedValue = row.Cells["MaPhim"].Value.ToString();
                if (row.Cells["MaPhong"].Value != null)
                    cbPhong.SelectedValue = row.Cells["MaPhong"].Value.ToString();
                if (row.Cells["NgayChieu"].Value != null)
                    dtpNgay.Value = Convert.ToDateTime(row.Cells["NgayChieu"].Value);
                if (row.Cells["GioChieu"].Value != null && row.Cells["GioChieu"].Value != DBNull.Value)
                {
                    if (row.Cells["GioChieu"].Value is TimeSpan gio)
                    {
                        cbGio.Text = gio.ToString(@"hh\:mm");
                    }
                    else if (TimeSpan.TryParse(row.Cells["GioChieu"].Value.ToString(), out TimeSpan parsedGio))
                    {
                        cbGio.Text = parsedGio.ToString(@"hh\:mm");
                    }
                }
            }
        }

        private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingCombo || cbPhim.SelectedItem == null) return;

            if (cbPhim.SelectedItem is PhimDTO phim)
            {
                LoadPoster(phim.Poster);
            }
        }

        private void UC_SuatChieu_Load_1(object sender, EventArgs e)
        {

        }
    }

}
