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
    public partial class frmTaoTaiKhoan : Form
    {
        String macn = "";
        int manv = 0;
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            dS_NhanVien.EnforceConstraints = false;
            dS_DSNVChuaTaoLogin.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS_NhanVien.NhanVien);

            this.NVChuaTaoLoginTableAdapter.Connection.ConnectionString = Program.connstr;
            this.NVChuaTaoLoginTableAdapter.Fill(this.dS_DSNVChuaTaoLogin.NhanVien);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                // công ty được tạo login nhóm công ty
                cmbChiNhanh.Enabled = true;
                rbCT.Enabled = true;
                rbCN.Enabled = rbU.Enabled = false;
            }
            if (Program.mGroup == "CHINHANH")
            {
                // chi nhánh được tạo login nhóm chi nhánh và user
                rbCT.Enabled = false;
                cmbChiNhanh.Enabled = false;
                rbCN.Enabled = rbU.Enabled = true;
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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS_NhanVien.NhanVien);

                this.NVChuaTaoLoginTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NVChuaTaoLoginTableAdapter.Fill(this.dS_DSNVChuaTaoLogin.NhanVien);

                //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHoTen.SelectedValue != null)
            {
                manv = int.Parse(cmbHoTen.SelectedValue.ToString());
            }
            else
            {
                return;
            }
        }

        private void btn_TaoTK_Click(object sender, EventArgs e)
        {
            if (cmbHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên nhân viên không được trống!!!", "", MessageBoxButtons.OK);
                cmbHoTen.Focus();
                return;
            }
            if (txtTK.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được trống!!!", "", MessageBoxButtons.OK);
                txtTK.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được trống!!!", "", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            if (rbCN.Checked != true && rbU.Checked != true && rbCT.Checked != true)
            {
                MessageBox.Show("Chưa chọn nhóm quyền!!!", "", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            else
            {
                String type = "";
                if (rbCT.Checked == true)
                {
                    type = "CONGTY";
                }
                else if (rbCN.Checked == true)
                {
                    type = "CHINHANH";
                }
                else if (rbU.Checked == true)
                {
                    type = "USER";
                }
                int manv = int.Parse(cmbHoTen.SelectedValue.ToString());
                    String loginName = txtTK.Text;
                    String pass = txtPass.Text;
                
                if (Program.KetNoi() == 0) return;
                String strLenh = "EXECUTE dbo.SP_TAOLOGIN N'" + loginName + "',N'" + pass + "',N'" + manv + "',N'" + type + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                MessageBox.Show("Tạo tài khoản thành công", " ", MessageBoxButtons.OK);

                Program.myReader.Close();
                Program.conn.Close();
                
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
