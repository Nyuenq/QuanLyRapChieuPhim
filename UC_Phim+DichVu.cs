using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{

    public partial class PhimVaDichVu : UserControl
    {
        public PhimDTO Data;
        public DichVuDTO duDV;
        public PhimVaDichVu()
        {
            InitializeComponent();
            
            this.Padding = new Padding(5);
            this.Click += ClickAll;
            pbPoster.Click += ClickAll;
            lblTen.Click += ClickAll;
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += (s, e) => this.OnMouseEnter(e);
                c.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
        }
       
        public void DuLieu(PhimDTO p)
        {
            Data = p;
            lblTen.Text = p.TenPhim;
            duDV = null;
            if (!string.IsNullOrEmpty(p.Poster))
            {
                pbPoster.ImageLocation = Path.Combine(Application.StartupPath, "Poster", p.Poster);
            }
        }
        public void DataDV(DichVuDTO dv)
        {
            duDV = dv;
            lblTen.Text = dv.TenDichVu;
            Data = null;
            if (!string.IsNullOrEmpty(dv.Anh))
            {
                pbPoster.ImageLocation = Path.Combine(Application.StartupPath, "Poster", dv.Anh);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
           
        }
        protected override void OnMouseLeave(EventArgs e)
        {
          
        }
        public event Action<PhimDTO> ClickPhim;
        public event Action<DichVuDTO> ClickDichVu;
        void ClickAll(object sender, EventArgs e)
        {
            if (Data != null)
                ClickPhim?.Invoke(Data);
            else if (duDV != null)
                ClickDichVu?.Invoke(duDV);

        }
        
    }
}
