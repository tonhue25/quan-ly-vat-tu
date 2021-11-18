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
    public partial class frmPhieuXuat : Form
    {
        String macn = "";
        int vitri = 0;
        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);
        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_DH.Kho' table. You can move, or remove it, as needed.
            
            dS_DH.EnforceConstraints = false;

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.dS_DH.PhieuXuat);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dS_DH.CTPX);

            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS_DH.Kho);

            macn = ((DataRowView)bdsCN[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;

            dptNgay.EditValue = DateTime.Now;
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Program.maPX = txtMaPX.Text;
            Program.subFormCTPX = new subformCTPX();
            Program.subFormCTPX.Show();
            Program.frmChinh.Enabled = false;
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
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.dS_DH.PhieuXuat);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.dS_DH.CTPX);

                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);

                macn = ((DataRowView)bdsCN[0])["MACN"].ToString();
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Fill(this.dS_DH.PhieuXuat);
                this.cTPXTableAdapter.Fill(this.dS_DH.CTPX);
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
            vitri = bdsPX.Position;
            // cho khung nhap lieu sang len de nhap.
            // tam thoi cho tu nhap lieu ma kho vo da, khi nao ranh thi cho lm cach khac hay hon.
            pnNhap.Enabled = true;
            bdsPX.AddNew();
            dptNgay.EditValue = DateTime.Now;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }

        // phai nhan vo nut them roi fill dl
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaPX.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu xuất không được trống!!!", "", MessageBoxButtons.OK);
                txtMaPX.Focus();
                return;
            }
            if (dptNgay.Text.Trim() == "")
            {
                MessageBox.Show("Ngày tạo đơn đặt hàng không được trống!!!", "", MessageBoxButtons.OK);
                dptNgay.Focus();
                return;
            }
            if (txtHoTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên khách hàng không được trống!!!", "", MessageBoxButtons.OK);
                txtHoTenKH.Focus();
                return;
            }
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được trống!!!", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            else
            {
                ((DataRowView)bdsPX[bdsPX.Position])["MANV"] = Program.username;
                String strLenh = "EXECUTE dbo.SP_KT_ID N'" + txtMaPX.Text + "',MAPX";
                int kt = Program.ExecuteScalar(strLenh);
                if (kt == 0)
                {
                    try
                    {
                        this.bdsPX.EndEdit();
                        bdsPX.ResetCurrentItem();

                        this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.phieuXuatTableAdapter.Update(this.dS_DH.PhieuXuat);

                        MessageBox.Show("Thêm phiếu xuất thành công!!!!");

                        gcPX.Enabled = true;
                        btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btn_InDSNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnUndo.Enabled = false;
                        pnNhap.Enabled = false;
                        gcCTPX.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi phiếu xuất \n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (kt == 2)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất \n Mã phiếu xuất đã tồn tại ở chi nhánh khác", "", MessageBoxButtons.OK);
                    return;
                }
                else 
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất \n Mã phiếu xuất đã tồn tại", "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.subFormKho = new subformKho();
            Program.subFormKho.Show();
            Program.frmChinh.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu vì đã đã lập chi tiết phiếu!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn phiếu này", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapn = ((DataRowView)bdsPX[bdsPX.Position])["MAPX"].ToString();
                    if (Program.KetNoi() == 0) return;
                    String strLenh = "EXECUTE dbo.SP_XOAPHIEUXUAT N'" + mapn + "'";

                    int kq = Program.ExecSqlNonQuery(strLenh);
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa phiếu thành công");
                    }
                    bdsPX.RemoveCurrent();
                    Program.myReader.Close();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuXuatTableAdapter.Fill(this.dS_DH.PhieuXuat);
                    return;
                }
            }
            if (bdsPX.Count == 0) btnXoa.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // them => bo them.
            // sua => bo sua.
            bdsPX.CancelEdit();
            // luc nay them roi, thi lay vi tri do luu lai
            if (btnThem.Enabled == false) bdsPX.Position = vitri;
            gcPX.Enabled = true;
            pnNhap.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }
    }
}
