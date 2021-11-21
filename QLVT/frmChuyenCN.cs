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
    public partial class frmChuyenCN : Form
    {
        public frmChuyenCN()
        {
            InitializeComponent();
        }
       
        private void btn_Chuyen_Click(object sender, EventArgs e)
        {
            String macn = ((DataRowView)bdsCN[0])["MACN"].ToString();
            MessageBox.Show(macn);
        }

        private void frmChuyenCN_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;
            this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
            this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);

            cmChiNhanh.DataSource = Program.bds_dspm;
            cmChiNhanh.DisplayMember = "TENCN";
            cmChiNhanh.ValueMember = "TENSERVER";
            cmChiNhanh.SelectedIndex = Program.mChiNhanh;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            Program.servername = cmChiNhanh.SelectedValue.ToString();
            if (cmChiNhanh.SelectedIndex != Program.mChiNhanh)
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
                this.chiNhanhTableAdapter.Connection.ConnectionString = Program.connstr;
                this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);
            }
        }

        private void frmChuyenCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmChinh.Enabled = true;
        }

        private void chiNhanhBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
