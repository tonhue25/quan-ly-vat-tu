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
    public partial class frmKho : Form
    {
        String macn = "";
        int vitri = 0;
        public frmKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_Kho);

        }

        private void Kho_Load(object sender, EventArgs e)
        {
            DS_Kho.EnforceConstraints = false;

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS_Kho.Kho);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS_Kho.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS_Kho.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS_Kho.PhieuXuat);

            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.DS_Kho.ChiNhanh);

            macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;
                // khong duoc them xoa sua, => ko can phuc hoi
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                // nhom khac
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
                cmbChiNhanh.Enabled = false;
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
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS_Kho.Kho);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS_Kho.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS_Kho.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS_Kho.PhieuXuat);

                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                this.chiNhanhTableAdapter.Fill(this.DS_Kho.ChiNhanh);

                //macn = ((DataRowView)bdsKho[0])["MACN"].ToString();
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
                this.khoTableAdapter.Fill(this.DS_Kho.Kho);
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
            bdsKho.CancelEdit();
            // luc nay them roi, thi lay vi tri do luu lai
            if (btnThem.Enabled == false) bdsKho.Position = vitri;
            gcKho.Enabled = true;
            pnKho.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKho.Position;
            // cho khung nhap lieu sang len de nhap.
            pnKho.Enabled = true;
            bdsKho.AddNew();
            txtMaCN.Text = macn;
            
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcKho.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được để trống", "", MessageBoxButtons.OK);
                txtMaKho.Focus();
                return;
            }
            if (txtTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Tên kho không được để trống", "", MessageBoxButtons.OK);
                txtTenKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (txtMaCN.Text.Trim() == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống", "", MessageBoxButtons.OK);
                txtMaCN.Focus();
                return;
            }
            else
            {
                String strLenh1 = "EXECUTE dbo.SP_KT_ID N'" + txtMaKho.Text + "',MAKHO";
                String strLenh2 = "EXECUTE dbo.SP_KT_ID N'" + txtTenKho.Text + "',TENKHO";
                int ktTrungMaKho = Program.ExecuteScalar(strLenh1);
                int ktTrungTenKho = Program.ExecuteScalar(strLenh2);
                if (ktTrungMaKho == 1)
                {
                    MessageBox.Show("Lỗi ghi kho\n Mã kho đã tồn tại trong chi nhánh!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (ktTrungMaKho == 2)
                {
                    MessageBox.Show("Lỗi ghi kho\n Mã kho tồn tại trong chi nhánh khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (ktTrungTenKho == 1)
                {
                    MessageBox.Show("Lỗi ghi kho\n Tên kho đã tồn tại trong chi nhánh!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (ktTrungTenKho == 2)
                {
                    MessageBox.Show("Lỗi ghi kho\n Tên kho tồn tại trong chi nhánh khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (ktTrungMaKho == 0 && ktTrungTenKho == 0)
                {
                    try
                    {
                        bdsKho.EndEdit();
                        bdsKho.ResetCurrentItem();

                        this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.khoTableAdapter.Update(this.DS_Kho.Kho);

                        btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                        btnGhi.Enabled = btnUndo.Enabled = false;
                        gcKho.Enabled = true;
                        pnKho.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi kho \n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã tồn tại đơn hàng của kho", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã tồn tại phiếu nhập của kho", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã tồn tạo phiếu xuất của kho", "", MessageBoxButtons.OK);
                return;
            } // kiểm tra coi có xóa được ko
            if (MessageBox.Show("Bạn có thật sự muốn kho này", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    String makho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
                    if (Program.KetNoi() == 0) return;
                    String strLenh = "EXECUTE dbo.SP_XOAKHO N'" + makho + "'";
                    int kq = Program.ExecSqlNonQuery(strLenh);
                    if (kq == 0)
                    {
                        MessageBox.Show("Xóa kho thành công");
                    }
                    bdsKho.RemoveCurrent();
                    Program.myReader.Close();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.khoTableAdapter.Fill(this.DS_Kho.Kho);
                    return;
                }
            }
            if (bdsKho.Count == 0) btnXoa.Enabled = false;
        }
    }
}
