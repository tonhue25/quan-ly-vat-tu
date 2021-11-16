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
    public partial class frmDDHChuaCoPN : Form
    {
        String macn = "";
        public frmDDHChuaCoPN()
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

        private void btn_Xem_Click(object sender, EventArgs e)
        {

        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_NhanVien);
        }

        private void formSupport2_Load(object sender, EventArgs e)
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

        private void frmDDHChuaCoPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmChinh.Enabled = true;
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            XrptDDHChuaCoPN rpt = new XrptDDHChuaCoPN();
            //rpt.xrLabel_CN.Text = cmbChiNhanh.Text.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Program.frmChinh.Enabled = true;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            // chua bt in the nao, de sau di.
        }
    }
}
