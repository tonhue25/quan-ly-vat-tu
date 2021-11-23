using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    public partial class frmNhanVien : Form
    {
        String macn = "";
        int vitri = 0;
        int them = 0;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // giu lai de dung trong phuc hoi.
            vitri = bdsNV.Position;
            // cho khung nhap lieu sang len de nhap.
            txtMaNV.Enabled = true;
            groupBox1.Enabled = true;
            bdsNV.AddNew();
            txtChiNhanh.Text = macn;
            dtpNgaySinh.EditValue = "";
            txtTTX.Checked = false;

            // them moi thi chi cho luu va undo thoi.
            // tat luoi
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled= btn_InDSNV.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled  = btnThoat.Enabled = true;
            gcNhanVien.Enabled = false;
            them = 1;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if (txtLuong.Text.Trim() == "")
            {
                MessageBox.Show("Lương nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return;
            }
            if (float.Parse(txtLuong.Text) < 4000000)
            {
                MessageBox.Show("Lương nhân viên phải >= 4.000.000!!!", "", MessageBoxButtons.OK);
                txtLuong.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (dtpNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                dtpNgaySinh.Focus();
                return;
            }
            if (DateTime.Now.Year - dtpNgaySinh.DateTime.Year < 18)
            {
                MessageBox.Show("Nhân viên phải từ 18 tuổi trở lên!", "Thông báo lỗi",
                    MessageBoxButtons.OK);
                dtpNgaySinh.Focus();
                return;
            }
            if (them == 1)
            {
                {
                    // khi thêm nhân viên thì chỉ thêm mà ko tạo thêm login, username gì hết, sau đó
                    // mới lấy nv chưa có login để tạo thêm login.
                    String strLenh = "EXECUTE dbo.SP_KT_ID N'" + txtMaNV.Text + "',MANV";
                    int kt = Program.ExecuteScalar(strLenh);
                    if (kt == 0)
                    {
                        try
                        {
                            this.bdsNV.EndEdit();
                            bdsNV.ResetCurrentItem();
                            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                            this.nhanVienTableAdapter.Update(this.DS_NhanVien.NhanVien);//Ghi vào CSDL
                            MessageBox.Show("Thêm nhân viên thành công!!!!");
                            gcNhanVien.Enabled = true;
                            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btn_InDSNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
                            btnGhi.Enabled = btnUndo.Enabled = false;
                            groupBox1.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi ghi nhân viên \n" + ex.Message, "", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else if (kt == 1)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại trong cùng chi nhánh!!", "", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi ghi nhân viên \nMã Nhân viên tồn tại ở chi nhánh khác", "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                this.bdsNV.EndEdit();
                bdsNV.ResetCurrentItem();
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.DS_NhanVien.NhanVien);//Ghi vào CSDL
                MessageBox.Show("Sửa nhân viên thành công!!!!");
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã nhân viên đã lập đơn đặt hàng!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã nhân viên đã lập phiếu nhập!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã nhân viên đã lập phiếu xuất!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (txtTTX.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa!!!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này???", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    int manv = int.Parse(txtMaNV.Text);

                    if (Program.KetNoi() == 0) return;
                    String strLenh = "EXECUTE dbo.Xoa_login N'" + manv + "'";
                    Program.myReader = Program.ExecSqlDataReader(strLenh);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();
                    MessageBox.Show("Xóa nhân viên thành công!!!", " ", MessageBoxButtons.OK);

                    Program.myReader.Close();
                    Program.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xóa nhân viên \n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // them => bo them.
            // sua => bo sua.
            bdsNV.CancelEdit();
            // luc nay them roi, thi lay vi tri do luu lai
            if (btnThem.Enabled == false) bdsNV.Position = vitri;
            gcNhanVien.Enabled = true;
            groupBox1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btn_InDSNV.Enabled = btnReload.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS_NhanVien.NhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xrpt_InDanhSachNhanVien rpt = new Xrpt_InDanhSachNhanVien();
            rpt.xrLabel_tenCN.Text = cmbChiNhanh.Text.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            DS_NhanVien.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS_NhanVien.NhanVien);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS_NhanVien.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS_NhanVien.PhieuNhap);
           
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS_NhanVien.PhieuXuat);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                // chi có công ty mới chuyển chi nhánh của nhân viên.
                cmbChiNhanh.Enabled= btn_ChuyenCN.Enabled = btn_InDSNV.Enabled = true;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
                cmbChiNhanh.Enabled = btn_ChuyenCN.Enabled  = btn_InDSNV.Enabled = false;
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_NhanVien);
        }

        private void nhanVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_NhanVien);
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if(cmbChiNhanh.SelectedIndex!= Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if(Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối chi nhánh mới!","",MessageBoxButtons.OK);
            }
            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS_NhanVien.NhanVien);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS_NhanVien.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS_NhanVien.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS_NhanVien.PhieuXuat);
            }
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public static String serverMoi = "";

        private void btn_ChuyenCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int viTriHT = bdsNV.Position;
            int trangThaiXoa = int.Parse(((DataRowView)(bdsNV[viTriHT]))["TrangThaiXoa"].ToString());
            string maNV = ((DataRowView)(bdsNV[viTriHT]))["MANV"].ToString();

            if (maNV == Program.username)
            {
                MessageBox.Show("Không thể chuyển chính người đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trangThaiXoa == 1)
            {
                MessageBox.Show("Nhân viên này không có ở chi nhánh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form f = this.CheckExists(typeof(frmChuyenCN));
            if (f != null)
            {
                f.Activate();
            }
            frmChuyenCN form = new frmChuyenCN();
            form.ShowDialog();
            if (!serverMoi.Equals(""))
                chuyenCN(serverMoi);
        }

        public void chuyenCN(String server)
        {
            String maChiNhanhMoi = "";
            if (server.Contains("1"))
                maChiNhanhMoi = "CN1";

            else if (server.Contains("2"))
                maChiNhanhMoi = "CN2";

            else
            {
                MessageBox.Show("Mã chi nhánh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int position = bdsNV.Position;
            String maNV = ((DataRowView)bdsNV[position])["MANV"].ToString();

            String strLenh = "EXEC SP_ChuyenCN " + maNV + ",'" + maChiNhanhMoi + "'";
            int n = Program.ExecSqlNonQuery(strLenh);
            if (n == 0)
            {

                MessageBox.Show("Chuyển chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.nhanVienTableAdapter.Fill(this.DS_NhanVien.NhanVien);
                return;
            }
        }

        private void btn__Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            if (((DataRowView)bdsNV[vitri])["TrangThaiXoa"].ToString().Contains("1")){
                MessageBox.Show("Nhân viên đã xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else {
                gcNhanVien.Enabled = txtMaNV.Enabled = false;
                groupBox1.Enabled = true;

                btn_ChuyenCN.Enabled = btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                btnGhi.Enabled = btnUndo.Enabled = true;
            }
            //txtMaNV.Enabled = false;
        }
    }
}
