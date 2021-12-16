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
    public partial class frmPhieuNhap : Form
    {
        String macn = "";
        int vitri = 0;

        //String maPN = "";
        public delegate void SendData(String value);
        public SendData mydata;

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.dS_DH.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS_DH.PhieuNhap);
           
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS_DH.CTPN);

            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);

            macn = ((DataRowView)bdsCN[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = btn_InDSNV.Enabled = true;
                // khong duoc them xoa sua, => ko can phuc hoi
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                // nhom khac
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

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS_DH.PhieuNhap);

                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS_DH.CTPN);

                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);

            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // 1 đơn đặt hàng chỉ có 1 phiếu nhập!!
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Đã có phiếu nhập!!!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                vitri = bdsPN.Position;
                pnNhap.Enabled = true;
                bdsPN.AddNew();
                dptNgay.EditValue = DateTime.Now;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                btnGhi.Enabled = btnUndo.Enabled = true;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dptNgay.Text.Trim() == "")
            {
                MessageBox.Show("Ngày tạo đơn đặt hàng không được trống!!!", "", MessageBoxButtons.OK);
                dptNgay.Focus();
                return;
            }
            if (txtMaPN.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu nhập không được trống!!!", "", MessageBoxButtons.OK);
                txtMaPN.Focus();
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
                ((DataRowView)bdsPN[bdsPN.Position])["MANV"] = Program.username;
                String strLenh = "EXECUTE dbo.SP_KT_ID N'" + txtMaPN.Text + "',MAPN";
                int kt = Program.ExecuteScalar(strLenh);
                if (kt == 0)
                {
                    try
                    {
                        this.bdsPN.EndEdit();
                        bdsPN.ResetCurrentItem();

                        this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.phieuNhapTableAdapter.Update(this.dS_DH.PhieuNhap);

                        MessageBox.Show("Thêm phiếu nhập thành công!!!!");

                        gcDH.Enabled = true;
                        btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnUndo.Enabled = false;
                        pnNhap.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi phiếu nhập \n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (kt == 2)
                {
                    MessageBox.Show("Lỗi ghi phiếu nhập \n Mã phiếu nhập đã tồn tại ở chi nhánh khác", "", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi ghi phiếu nhập \n Mã phiếu nhập đã tồn tại", "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu vì đã đã lập chi tiết phiếu!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn phiếu này", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mapn = ((DataRowView)bdsPN[bdsPN.Position])["MAPN"].ToString();
                    if (Program.KetNoi() == 0) return;
                    String strLenh = "EXECUTE dbo.SP_XOAPHIEUNHAP N'" + mapn + "'";

                    int kq = Program.ExecSqlNonQuery(strLenh);
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa phiếu thành công");
                    }
                    bdsPN.RemoveCurrent();
                    Program.myReader.Close();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuNhapTableAdapter.Fill(this.dS_DH.PhieuNhap);
                    return;
                }
            }
            if (bdsPN.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(this.dS_DH.DatHang);
                this.phieuNhapTableAdapter.Fill(this.dS_DH.PhieuNhap);
                this.cTPNTableAdapter.Fill(this.dS_DH.CTPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btn_ThemCTPN_Click(object sender, EventArgs e)
        {
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Phiếu đã được lập chi tiết!!!", "", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Program.maPN = txtMaPN.Text;
                Program.maDDH = getDataRow(bdsDH, "MasoDDH");

                subformCTPN f = new subformCTPN();
                f.Show();
                Program.frmChinh.Enabled = false;
            }
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Program.maPN = txtMaPN.Text;
            Program.maDDH = getDataRow(bdsDH, "MasoDDH");
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsPN.CancelEdit();
            if (btnThem.Enabled == false) bdsPN.Position = vitri;
            gcPN.Enabled = true;
            pnNhap.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }

        // lấy data từ delegate.
        public void GetData(String data)
        {
            txtMaKho.Text = "";
            txtMaKho.Text = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.subFormKho = new subformKho();
            Program.subFormKho.Show();
            Program.frmChinh.Enabled = false;
            Program.subFormKho.mydata = new subformKho.SendData(GetData);
        }
    }
}
