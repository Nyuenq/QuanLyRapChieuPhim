using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhamBenhNgoaiTru
{
    public partial class Ghe : UserControl
    {
        public GheDTO ghe;
        public Action<GheDTO> ClickG;
        public bool ChoChMau = false;
        bool ChMau = false;
        Color mauMacDinh;
        public CheDoGhe Mode = CheDoGhe.QuanLy;
        public Action<GheDTO> ClickGhe;

        public enum CheDoGhe
        {
            QuanLy,
            DatVe
        }
        public Ghe()
        {
            InitializeComponent();
            this.Margin = new Padding(3);
            this.Click += (s, e) =>  ClickG?.Invoke(ghe);
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += (s, e) => this.OnMouseEnter(e);
                c.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
        }
        public void DuLieu(GheDTO gh)
        {
            ghe = gh;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;
            GraphicsPath path = GetPath(rect);
            Color MauGhe;
            if (DaChon)
            {
                MauGhe = Color.Aqua;
            }
            else
            {
                if (ghe.TrangThai == "Hỏng")
                {
                    MauGhe = Color.Gray;
                }
                else if (ghe.TrangThai == "Đã đặt")
                {
                    MauGhe = Color.Red;
                }
                else
                {
                    if (ghe.LoaiGhe == "VIP")
                    {
                        MauGhe = Color.Gold;
                        mauMacDinh = Color.Gold;
                    }
                    else if (ghe.LoaiGhe == "Đôi")
                    {
                        MauGhe = Color.Pink;
                        mauMacDinh = Color.Pink;
                    }
                    else
                    {
                        MauGhe = Color.Green;
                        mauMacDinh = Color.Green;
                    }
                }

                if (ChMau)
                    MauGhe = ControlPaint.Light(MauGhe);
            }
            g.FillPath(new SolidBrush(MauGhe), path);
            string ten = ghe.HangGhe + ghe.SoG;
            TextRenderer.DrawText(g,ten,this.Font,rect,this.ForeColor,TextFormatFlags.HorizontalCenter|TextFormatFlags.VerticalCenter);
        }
        private GraphicsPath GetPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, 10, 10, 180, 90);
            path.AddArc(Width - 10, 0, 10, 10, 270, 90);
            path.AddArc(Width - 10, Height - 10, 10, 10, 0, 90);
            path.AddArc(0, Height - 10, 10, 10, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (!ChoChMau) return;

            ChMau = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!ChoChMau) return;

            ChMau = false;
            this.Invalidate();
        }
        public bool DaChon = false;

        public event Action<GheDTO, bool> OnChonGhe;
       

        private void Ghe_Click_1(object sender, EventArgs e)
        {
            if (ghe == null) return;
            if (Mode == CheDoGhe.QuanLy)
            {
                ClickGhe?.Invoke(ghe);
                return;
            }
            if (Mode == CheDoGhe.DatVe)
            {
                if (ghe.TrangThai != "Còn trống")
                    return;

                DaChon = !DaChon;
                this.Invalidate();

                OnChonGhe?.Invoke(ghe, DaChon);
            }
        }
    }
}
