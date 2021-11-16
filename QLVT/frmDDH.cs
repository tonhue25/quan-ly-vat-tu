using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmDDH : Form
    {
        String macn = "";
        // dung trong them va phuc hoi
        int vitri = 0;

        public frmDDH()
        {
            InitializeComponent();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void frmDDH_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS_DH.DatHang);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS_DH.CTDDH);

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS_DH.Vattu);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS_DH.Kho);

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS_DH.NhanVien);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = btn_InDSNV.Enabled = true;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
                cmbChiNhanh.Enabled = btn_InDSNV.Enabled = false;
            }
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối chi nhánh mới!", "", MessageBoxButtons.OK);
            }
            else
            {
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.dS_DH.DatHang);

                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.dS_DH.CTDDH);

                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.dS_DH.Vattu);

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.dS_DH.Kho);

                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS_DH.NhanVien);

                macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(this.dS_DH.DatHang);
                this.cTDDHTableAdapter.Fill(this.dS_DH.CTDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // giu lai de dung trong phuc hoi.
            vitri = bdsDH.Position;
            // cho khung nhap lieu sang len de nhap.
            // tam thoi cho tu nhap lieu ma kho vo da, khi nao ranh thi cho lm cach khac hay hon.
            pnNhap.Enabled = true;
            bdsDH.AddNew();
            dptNgay.EditValue = DateTime.Now;
            txtMaKho.Text = Program.maKho;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.subFormKho = new subformKho();
            Program.subFormKho.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // trong do  :hien tai ma kho tu nhap, sau do se cai tien , thanh cho chon.
            if (txtMaDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được trống!!!", "", MessageBoxButtons.OK);
                txtMaDDH.Focus();
                return;
            }
            if (dptNgay.Text.Trim() == "")
            {
                MessageBox.Show("Ngày tạo đơn đặt hàng không được trống!!!", "", MessageBoxButtons.OK);
                dptNgay.Focus();
                return;
            }
            if (txtNhaCC.Text.Trim() == "")
            {
                MessageBox.Show("Nhà cung cập hàng không được trống!!!", "", MessageBoxButtons.OK);
                txtNhaCC.Focus();
                return;
            }
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được trống!!!", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            ((DataRowView)bdsDH[bdsDH.Position])["MANV"] = Program.username;
            String strLenh = "EXECUTE dbo.SP_KT_ID_MADDH N'" + txtMaDDH.Text + "'";
            Program.ExecSqlNonQuery(strLenh);
            if (Program.kt == 0)
            {
                try
                {
                    this.bdsDH.EndEdit();
                    bdsDH.ResetCurrentItem();

                    this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.datHangTableAdapter.Update(this.dS_DH.DatHang);

                    MessageBox.Show("Thêm đơn đặt hàng thành công!!!!");
                    
                    gcDH.Enabled = true;
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btn_InDSNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                    btnGhi.Enabled = btnUndo.Enabled = false;
                    pnNhap.Enabled = false;
                    gcCTDDH.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            } 
            else
            {
                MessageBox.Show("Lỗi ghi đơn đặt hàng \n Mã đơn tồn tại ở chi nhánh khác", "", MessageBoxButtons.OK);
                return;
            };

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // dơn đặt hàng này đã có chi tiết đơn đặthàng chưa, nếu chưa thì mới được xóa.
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa đơn hàng vì đã lập đơn!!!", "", MessageBoxButtons.OK);
                return;
            }
            // xoa thi de sau di.
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // them => bo them.
            // sua => bo sua.
            bdsDH.CancelEdit();
            // luc nay them roi, thi lay vi tri do luu lai
            if (btnThem.Enabled == false) bdsDH.Position = vitri;
            gcDH.Enabled = true;
            pnNhap.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled =  btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
            gcCTDDH.Enabled = false;
        }

        private void themCTDDH_Click(object sender, EventArgs e)
        {
            // lấy mã đơn đặt hàng, để có thể lưu vô.
            Program.maDDH = txtMaDDH.Text;
            Program.subFormCTDDH = new subformCTDDH();
            Program.subFormCTDDH.Show();
            Program.frmChinh.Enabled = false;
        }
    }
    
}
