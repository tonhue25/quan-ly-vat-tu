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
    public partial class subformCTPN : Form
    {
        public subformCTPN()
        {
            InitializeComponent();
        }

        private void subformCTPN_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS_DH.CTPN);

            this.sP_CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_CTDDHTableAdapter.Fill(this.dS_CTDDH.SP_CTDDH, Program.maDDH);
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
            if (int.Parse(txtSL.Text.Trim()) <= 0)
            {
                MessageBox.Show("Số lượng > 0", "", MessageBoxButtons.OK);
                txtSL.Focus();
                return;
            }
            if (int.Parse(txtSL.Text.Trim()) > int.Parse(getDataRow(bds_SPCTDDH, "SOLUONG")))
            {
                MessageBox.Show("Không được nhập quá số lượng đặt", "", MessageBoxButtons.OK);
                txtSL.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Đơn giá không được để trống", "", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return;
            }
            if (float.Parse(txtDonGia.Text.Trim()) < 0)
            {
                MessageBox.Show("Đơn giá >= 0", "", MessageBoxButtons.OK);
                txtDonGia.Focus();
                return;
            }
            else
            {
                String strLenh = "EXECUTE dbo.SP_KT_ID_MACT N'" + txtMaPN.Text + "'," + txtMaVT.Text + ",MACTPN";
                int kt = Program.ExecuteScalar(strLenh);
                if (kt == 0)
                {
                    try
                    {
                        string maVT = txtMaVT.Text;
                        int soLuong = int.Parse(txtSL.Text.ToString());

                        bdsCTPN.EndEdit();
                        bdsCTPN.ResetCurrentItem();

                        this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.cTPNTableAdapter.Update(this.dS_DH.CTPN);

                        MessageBox.Show("Thêm chi tiết phiếu nhập " + Program.maPN + "thành công !!!");
                        // thêm phiếu nhập thì cần update số lượng.
                        String strLenh2 = "EXECUTE dbo.SP_UpdateSLVatTu N'" + maVT + "'," + soLuong + ",IMPORT";
                        int kt2 = Program.ExecuteScalar(strLenh2);
                        if (kt2 == 1)
                        {
                            MessageBox.Show("Cập nhập số lượng vật tư thành công !!!");
                        }
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
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaPN.Text = Program.maPN;
            txtMaVT.Text = getDataRow(bds_SPCTDDH, "MAVT");
            txtSL.Text = getDataRow(bds_SPCTDDH, "SOLUONG");
            txtDonGia.Text = getDataRow(bds_SPCTDDH, "DONGIA");
        }

        private void subformCTPN_FormClosing(object sender, FormClosingEventArgs e)
        {
            bds_SPCTDDH.CancelEdit();
            Program.frmChinh.Enabled = true;
        }

        private void subformCTPN_Shown(object sender, EventArgs e)
        {
            if (bds_SPCTDDH.Count == 0)
            {
                MessageBox.Show("Đơn đặt hàng đã được lập phiếu nhập !!!!");
                this.Close();
                return;
            }
            else
            {
                this.bdsCTPN.AddNew();
                txtMaPN.Text = Program.maPN;
                txtMaVT.Text = getDataRow(bds_SPCTDDH, "MAVT");
                txtSL.Text = getDataRow(bds_SPCTDDH, "SOLUONG");
                txtDonGia.Text = getDataRow(bds_SPCTDDH, "DONGIA");
            }
        }
    }
}
