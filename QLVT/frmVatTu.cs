using DevExpress.XtraReports.UI;
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
    public partial class I : Form
    {
        int vitri = 0;
        int them = 0;
        public I()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_VT);

        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            DS_VT.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS_VT.Vattu);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS_VT.CTDDH);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS_VT.CTPN);

            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS_VT.CTPX);
            // phan quyen

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = btn_Sua.Enabled  =  btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                // nhom khac
                btnThem.Enabled = btn_Sua.Enabled  = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.vattuTableAdapter.Fill(this.DS_VT.Vattu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // them => bo them.
            // sua => bo sua.
            bdsVT.CancelEdit();
            // luc nay them roi, thi lay vi tri do luu lai
            if (btnThem.Enabled == false) bdsVT.Position = vitri;
            gcVatTu.Enabled = true;
            pnVatTu.Enabled = false;
            btnThem.Enabled = btn_Sua.Enabled =  btnXoa.Enabled = btnReload.Enabled  = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = btn_inds.Enabled = false;
        }

        // them la hien len cai man hinh trong de no nhan thong tin vo
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = 1;
            vitri = bdsVT.Position;
            txtMaVT.Enabled = true;
            this.bdsVT.AddNew();
            btnThem.Enabled = btn_Sua.Enabled = btnXoa.Enabled = gcVatTu.Enabled = btnReload.Enabled = btnUndo.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled  = pnVatTu.Enabled = btn_inds.Enabled = true;

            //Program.flagCloseFormVT = false; //Bật cờ lên để chặn tắt Form đột ngột khi nhập liệu
            txtSLT.Text = "0";
        }

        // THÊM OK
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được để trống", "", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return;
            }
            if (txtTenVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên vật tư không được để trống", "", MessageBoxButtons.OK);
                txtTenVT.Focus();
                return;
            }
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị tính không được để trống", "", MessageBoxButtons.OK);
                txtDVT.Focus();
                return;
            }
            if (txtSLT.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng tồn không được để trống", "", MessageBoxButtons.OK);
                txtSLT.Focus();
                return;
            }
            if(them == 1)
            {
                String strLenh1 = "EXECUTE dbo.SP_KT_ID N'" + txtMaVT.Text + "',MAVT";
               int kt1  = Program.ExecuteScalar(strLenh1);
                String strLenh2 = "EXECUTE dbo.SP_KT_ID N'" + txtTenVT.Text + "',TENVT";
                int kt2 = Program.ExecuteScalar(strLenh2);
                if (kt1 == 0 && kt2 == 0)
                {
                    try
                    {
                        bdsVT.EndEdit(); //ghi vào data set
                        bdsVT.ResetCurrentItem();

                        this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.vattuTableAdapter.Update(this.DS_VT.Vattu); //Ghi vào CSDL

                        btnThem.Enabled =  btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnUndo.Enabled = false;
                        gcVatTu.Enabled = true;
                        pnVatTu.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi Vật tư \n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if(kt1 == 1)
                {
                    MessageBox.Show("Lỗi ghi vật tư\n Mã vật tư đã tồn tại!!!", "", MessageBoxButtons.OK);
                    return;
                }
                else if (kt2 == 1)
                {
                    MessageBox.Show("Lỗi ghi vật tư\n Tên vật tư đã tồn tại!!!", "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                bdsVT.EndEdit(); //ghi vào data set
                bdsVT.ResetCurrentItem();

                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Update(this.DS_VT.Vattu); //Ghi vào CSDL
                MessageBox.Show("Sửa vật tư thành công!!!", "", MessageBoxButtons.OK);

                btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnUndo.Enabled = false;
                gcVatTu.Enabled = true;
                pnVatTu.Enabled = false;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDDH.Count + bdsCTPN.Count + bdsCTPX.Count > 0)
            {
                   MessageBox.Show("Không thể xóa vật tư đã lập phiếu", "", MessageBoxButtons.OK);
                   return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa vật tư này", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String mavt = ((DataRowView)bdsVT[bdsVT.Position])["MAVT"].ToString();
                    if (Program.KetNoi() == 0) return;
                    String strLenh = "EXECUTE dbo.SP_XOAVATTU N'" + mavt + "'";

                    int kq = Program.ExecSqlNonQuery(strLenh);
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa vật tư thành công");
                    }
                    bdsVT.RemoveCurrent();
                    Program.myReader.Close();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.vattuTableAdapter.Fill(this.DS_VT.Vattu);
                    return;
                }
            }
            if (bdsVT.Count == 0) btnXoa.Enabled = false;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xrpt_InDanhSachVatTu rpt = new Xrpt_InDanhSachVatTu();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btn_Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsVT.Position;

            gcVatTu.Enabled = txtMaVT.Enabled = false;
            pnVatTu.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btn_Sua.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }
    }
}
