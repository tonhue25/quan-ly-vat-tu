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
    public partial class frmTHNX : Form
    {
        String macn = "";
        public frmTHNX()
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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS_NhanVien.NhanVien);

                macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_NhanVien);

        }

        private void formTHNX_Load(object sender, EventArgs e)
        {
            dS_NhanVien.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS_NhanVien.NhanVien);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
        }

        private void frmTHNX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmChinh.Enabled = true;
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            Xrpt_TongHopNhapXuat report_TonghopNhapXuat = new Xrpt_TongHopNhapXuat(dateEdit1.DateTime, dateEdit2.DateTime);
            report_TonghopNhapXuat.labelNgay.Text = "Từ ngày "+ dateEdit1.DateTime+" đến ngày "+ dateEdit2.DateTime;
            ReportPrintTool printTool_TonghopNhapXuat = new ReportPrintTool(report_TonghopNhapXuat);
            printTool_TonghopNhapXuat.ShowPreviewDialog();
        }
    }
}
