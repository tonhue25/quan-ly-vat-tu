﻿using System;
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
    public partial class subformCTDDH : Form
    {
        private bool updateSuccess = false;
        public subformCTDDH()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);

        }

        private void subformCTDDH_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.dS_DH.Vattu);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS_DH.CTDDH);
        }

        private void subformCTDDH_Shown(object sender, EventArgs e)
        {
            this.bdsCTDDH.AddNew();
            txtMaDDH.Text = Program.maDDH;
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
            txtSL.Value = 1;
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void subformCTDDH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updateSuccess == false) bdsCTDDH.CancelEdit();
            Program.frmChinh.Enabled = true;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }

        private void btn_Ghi_Click(object sender, EventArgs e)
        {
            // kiem tra dl trống.
            if (txtMaDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã đơn hàng không được để trống", "", MessageBoxButtons.OK);
                txtMaDDH.Focus();
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
            // kiểm tra maDDH + maVT => trùng ko
            String strLenh = "EXECUTE dbo.SP_KT_ID_MACTDDH N'" + txtMaDDH.Text + "',N'"+txtMaVT.Text + "'";
            Program.ExecSqlNonQuery(strLenh);
            if (Program.kt == 0)
            {
                try
                {
                    bdsCTDDH.EndEdit(); //ghi vào data set
                    bdsCTDDH.ResetCurrentItem();

                    // thêm vào chi tiết đặt hàng của đơn đặt hàng đó, chứ ko phải update vật tư nha.
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.dS_DH.CTDDH); //Ghi vào CSDL
                    MessageBox.Show("Thêm chi tiết đơn hàng "+Program.maDDH+ " thành công !!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng "+Program.maDDH+"\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                // them mà trùng thì ko vô được trường hợp này.
                    MessageBox.Show("Lỗi ghi chi tiết đơn đặt hàng "+Program.maDDH+"\n Mã đơn hàng và mã vật tư đã tồn tại", "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
