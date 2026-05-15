using BLL;
using QuanLyKhamBenhNgoaiTru;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{
    public partial class FrmHoaDon : Form
    {
        string maHD;

        public FrmHoaDon( string MaHD)
        {
            InitializeComponent();
            maHD = MaHD;
        }
        HoaDonBLL bll = new HoaDonBLL();

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bll.InHoaDon(maHD);
                InHoaDon rpt = new InHoaDon();
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message
                );
            }
        }
    }
}
