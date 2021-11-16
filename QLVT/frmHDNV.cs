using DevExpress.XtraReports.UI;
using System;
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
   
    public partial class frmHDNV : Form
    {
        public static int manv = 0;
        public static String tenNV;
        public static String ngaySinh;
        public static String diaChi;
        public static int luong;
        public static String maCN;
        public frmHDNV()
        {
            InitializeComponent();
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
                this.nhanVienTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter1.Fill(this.dS_NhanVien.NhanVien);
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS_TraCuuNV.NhanVien);
            }
        }

        private void frmHDNV_Load(object sender, EventArgs e)
        {
            dS_NhanVien.EnforceConstraints = false;
            dS_TraCuuNV.EnforceConstraints = false;
            this.nhanVienTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter1.Fill(this.dS_NhanVien.NhanVien);

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS_TraCuuNV.NhanVien);

            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;

            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
            }
        }

        private void hOTENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHoTen.SelectedValue!=null)
            {
                manv = int.Parse(cmbHoTen.SelectedValue.ToString());
                String strLenh = "EXEC SP_ThongTinNhanVien '" + manv + "'";

                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                //manv = int.Parse(Program.myReader.GetValue(0).ToString());
                tenNV = Program.myReader.GetValue(1).ToString();
                ngaySinh = Program.myReader.GetValue(2).ToString();
                diaChi = Program.myReader.GetValue(3).ToString();
                luong = int.Parse(Program.myReader.GetValue(4).ToString());
                maCN = Program.myReader.GetValue(5).ToString();
                // phải đóng kết nối, không là lỗi
                Program.myReader.Close();
            }
            else
            {
                return;
            }
        }

        private void frmHDNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Program.frmChinh.Enabled = true;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Program.frmChinh.Enabled = true;
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            String type = (rbNhap.Checked) ? "N" : "X";

            Xrpt_HoatDongNhanVien rpt = new Xrpt_HoatDongNhanVien(manv, dateEdit1.DateTime, dateEdit2.DateTime, type);
            rpt.txtMaNV.Text = manv.ToString().Trim();
            rpt.txtTenNV.Text = tenNV;
            rpt.txtNS.Text = ngaySinh;
            rpt.txtDC.Text = diaChi;
            rpt.txtLuong.Text = luong.ToString().Trim();
            rpt.txtMaCN.Text = maCN;
            rpt.txt.Text = "BẢNG KÊ CHỨNG TỪ PHIẾU ";
            rpt.txt.Text += (type == "N") ? "NHẬP" : "XUẤT";

            ReportPrintTool print = new ReportPrintTool(rpt);
            rpt.ShowPreviewDialog();
        }
    }
}
