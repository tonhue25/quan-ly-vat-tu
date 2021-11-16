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
        // dung trong them va phuc hoi
        int vitri = 0;
        Stack undolist = new Stack();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // giu lai de dung trong phuc hoi.
            vitri = bdsNV.Position;
            // cho khung nhap lieu sang len de nhap.
            groupBox1.Enabled = true;
            bdsNV.AddNew();
            txtChiNhanh.Text = macn;
            dtpNgaySinh.EditValue = "";
            txtTTX.Checked = false;

            // them moi thi chi cho luu va undo thoi.
            // tat luoi
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled= btn_InDSNV.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
            gcNhanVien.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // trc khi ghi : kiem tra rang buoc cua bai toan (du lieu : null, sai dinh dang...)
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
            
            String strLenh = "EXECUTE dbo.SP_KT_ID_MANV N'" + txtMaNV.Text + "'";
            Program.ExecuteScalar(strLenh);

            // != 2 : tồn tại ở chi nhánh khác.
            // 0 = đc thêm
            // 1 = tồn tại ở chi nhánh hiện tại.
            // đối với nhân viên, kho : tìm ở site hiện tại, site tìm kiếm, site chủ.
            if (Program.kt == 0)
            {
                try
                {
                    this.Validate();
                    this.bdsNV.EndEdit();
                    bdsNV.ResetCurrentItem();

                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    
                    this.nhanVienTableAdapter.Update(this.DS_NhanVien.NhanVien);//Ghi vào CSDL
                    MessageBox.Show("Update successful");

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
            else
            {
                MessageBox.Show("Lỗi ghi nhân viên \n Mã Nhân viên tồn tại ở chi nhánh khác", "", MessageBoxButtons.OK);
                return;
            };
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // dau tien can kiem tra nhan vien nay co xoa duoc hay ko??? =>neu ok thi cho xoa.
            Int32 manv = 0;
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
                    String NV_info = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtChiNhanh.Text.Trim() + "#" +
                            dtpNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
                    Console.WriteLine(NV_info);
                    manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    bdsNV.RemoveCurrent();
                    btnUndo.Enabled = true;
                    undolist.Push(NV_info);
                    undolist.Push("DELETE");


                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);


                    Program.conn = new SqlConnection(Program.connstr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("Xoa_Login", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@USRNAME", manv));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.nhanVienTableAdapter.Update(this.DS_NhanVien.NhanVien);
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

                    this.nhanVienTableAdapter.Update(this.DS_NhanVien.NhanVien);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.nhanVienTableAdapter.Fill(this.DS_NhanVien.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", manv);
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

            //dong nay van tiem an loi, tu xu ly, xac xuat loi thap, nhung ma van co.
            // neu khong bat thi se dung chuong trinh.

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
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
            // phan quyen cho may nut lenh nho nho nua
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

                macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }
    }
}
