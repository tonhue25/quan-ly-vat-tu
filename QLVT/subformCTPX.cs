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
    public partial class subformCTPX : Form
    {
        private bool updateSuccess = false;
        public subformCTPX()
        {
            InitializeComponent();
        }

        private void subformCTPX_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS_DH.Vattu);
            
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.dS_DH.CTPX);
        }

        private void btn_ghi_Click(object sender, EventArgs e)
        {
            if (txtMaPX.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu xuât không được để trống", "", MessageBoxButtons.OK);
                txtMaPX.Focus();
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
            if (int.Parse(txtSL.Text.Trim())>0)
            {
                MessageBox.Show("Số lượng > 0 ", "", MessageBoxButtons.OK);
                txtSL.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Đơn giá không được để trống", "", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return;
            }
            if (float.Parse(txtDonGia.Text.Trim()) >= 0)
            {
                MessageBox.Show("Đơn giá >= 0", "", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return;
            }
            else
            {
                String strLenh = "EXECUTE dbo.SP_KT_ID_MACT N'" + txtMaPX.Text + "'," + txtMaVT.Text + ",MACTPX";
                int kt = Program.ExecuteScalar(strLenh);
                if (kt == 0)
                {
                    try
                    {
                        bdsCTPX.EndEdit(); //ghi vào data set
                        bdsCTPX.ResetCurrentItem();

                        this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.cTPXTableAdapter.Update(this.dS_DH.CTPX);

                        MessageBox.Show("Thêm chi tiết phiếu xuất " + Program.maPX + "thành công !!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi chi tiết phiếu xuất " + Program.maPX + "\n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng " + Program.maDDH + "\n Mã phiếu xuất và mã vật tư đã tồn tại", "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void subformCTPX_Shown(object sender, EventArgs e)
        {
            // phai co dong nay thi no moi la them moi
            // neu khong co thi la sua
            this.bdsCTPX.AddNew();
            txtMaPX.Text = Program.maPX;
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
            txtSL.Value = 1;
        }
        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void subformCTPX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTPX.CancelEdit();
            Program.frmChinh.Enabled = true;
        }


        private void vattuBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }
    }
}
