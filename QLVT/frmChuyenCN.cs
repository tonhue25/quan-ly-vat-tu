using DevExpress.XtraEditors;
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
    public partial class frmChuyenCN : Form
    {
        public frmChuyenCN()
        {
            InitializeComponent();
        }

        private void chiNhanhBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.chiNhanhBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void frmChuyenCN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_DH.ChiNhanh' table. You can move, or remove it, as needed.
            this.chiNhanhTableAdapter.Fill(this.dS_DH.ChiNhanh);
            cmbChiNhanh1.DataSource = Program.bds_dspm.DataSource;
            cmbChiNhanh1.DisplayMember = "TENCN";
            cmbChiNhanh1.ValueMember = "TENSERVER";
            cmbChiNhanh1.SelectedIndex = Program.mChiNhanh;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (cmbChiNhanh1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmNhanVien.serverMoi = cmbChiNhanh1.SelectedValue.ToString();
            // Chi nhánh được chọn là chi nhánh đang đăng nhập
            if (frmNhanVien.serverMoi.Equals(Program.servername))
            {
                MessageBox.Show("Hãy chọn chi nhánh khác chi nhánh bạn đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Hành động này không thế hoàn tác.\nBạn có chắc chắn muốn chuyển nhân viên này không?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr != DialogResult.OK) return;

            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
