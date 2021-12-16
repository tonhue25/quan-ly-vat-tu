using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        public void HienThiMenu()
        {
            MANV.Text = "Mã NV : " + Program.username;
            HOTEN.Text = "Họ tên nhân viên : " + Program.mHoten;
            NHOM.Text = "Nhóm : " + Program.mGroup;
            // phan quyen
            
            // tiep tuc if tren Program.mGroup de bat/ tat cac nut lệnh tương ứng trên menu chính
            // ex: công ty chỉ được quyền xem dữ liệu.
            if (Program.mGroup == "USER")
            {
                btn_TaoTK.Enabled = false;
                rib_DanhMuc.Visible = true;
            }
            else if (Program.mGroup == "CONGTY")
            {
                rib_BaoCao.Visible = rib_DanhMuc.Visible = true;
                btn_TaoTK.Enabled = true;
            }
            else if (Program.mGroup == "CHINHANH")
            {
                rib_DanhMuc.Visible = true;
                rib_BaoCao.Visible = true;
                btn_TaoTK.Enabled = true;
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                frmNhanVien f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(I));
            if (frm != null) frm.Activate();
            else
            {
                I f = new I();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_Kho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKho));
            if (frm != null) frm.Activate();
            else
            {
                frmKho f = new frmKho();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_LapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDDH));
            if (frm != null) frm.Activate();
            else
            {
                frmDDH f = new frmDDH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_PN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmPhieuNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmPhieuNhap f = new frmPhieuNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_PhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmPhieuXuat));
            if (frm != null) frm.Activate();
            else
            {
                frmPhieuXuat f = new frmPhieuXuat();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_CTSLNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.frmChiTietSL = new frmChiTietSL();
            Program.frmChiTietSL.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btn_DHKhongCoPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.frmDDHChuaCoPN = new frmDDHChuaCoPN();
            Program.frmDDHChuaCoPN.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btn_HDNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.formHDNV = new frmHDNV();
            Program.formHDNV.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btn_TongHopNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.formTHNX = new frmTHNX();
            Program.formTHNX.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btn_TaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoTaiKhoan));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            btn_TaoTK.Enabled = false;
        }
    }
}
