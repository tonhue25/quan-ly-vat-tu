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
    public partial class subformChiTietPN : Form
    {
        private bool updateSuccess = false;
        public subformChiTietPN()
        {
            InitializeComponent();
        }

        private void cTDDHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTDDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void subformChiTietPN_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS_DH.CTDDH);

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS_DH.CTPN);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu nhập không được để trống", "", MessageBoxButtons.OK);
                txtMaPN.Focus();
                return;
            }
            if (txtMaVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được để trống", "", MessageBoxButtons.OK);
                txtMaVT.Focus();
                return;
            }
            if (txtSL.Text.Trim() == "")
            {
                MessageBox.Show("Số lượng không được để trống", "", MessageBoxButtons.OK);
                txtSL.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Đơn giá không được để trống", "", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return;
            }
            String strLenh = "EXECUTE dbo.SP_KT_ID_MACTPN N'" + txtMaPN.Text + "',N'" + txtMaVT.Text + "'";
            Program.ExecSqlNonQuery(strLenh);
            if (Program.kt == 0)
            {
                try
                {
                    bdsCTPN.EndEdit();
                    bdsCTPN.ResetCurrentItem();

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.dS_DH.CTPN); 

                    MessageBox.Show("Thêm chi tiết phiếu nhập " + Program.maPN + " thành công !!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết phiếu nhập " + Program.maPN + "\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Lỗi ghi chi tiết phiếu nhập " + Program.maDDH + "\n Mã phiếu nhập và mã vật tư đã tồn tại", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            int count = gridView1.RowCount;
            for (int i = 0; i < count; i++)
            {
                string maDDH = gridView1.GetRowCellValue(i, "MasoDDH").ToString().Trim();
                if (!maDDH.Equals(Program.maDDH))
                {
                    if (e.ListSourceRow == i)
                    {
                        e.Visible = false;
                        e.Handled = true;
                    }
                }
            }
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaPN.Text = Program.maPN;
            txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
            txtSL.Text = getDataRow(bdsCTDDH, "SOLUONG");
            txtDonGia.Text = getDataRow(bdsCTDDH, "DONGIA");
        }

        private void subformChiTietPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTDDH.CancelEdit();
            Program.frmChinh.Enabled = true;
        }

        // hien thông tin từ gv lên
        private void subformChiTietPN_Shown(object sender, EventArgs e)
        {
            this.bdsCTPN.AddNew();
            txtMaPN.Text = Program.maPN;
            txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
            txtSL.Text = getDataRow(bdsCTDDH, "SOLUONG");
            txtDonGia.Text = getDataRow(bdsCTDDH, "DONGIA");
        }
    }
}
