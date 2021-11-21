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
    public partial class subformKho : Form
    {
        public delegate void SendData(String value);
        public SendData mydata;
        public subformKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_DH);
        }

        private void subformKho_Load(object sender, EventArgs e)
        {
            dS_DH.EnforceConstraints = false;
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS_DH.Kho);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Program.maKho = getDataRow(bdsKho, "MAKHO");
        }

        private void subformKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmChinh.Enabled = true;
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        // khi click vô hàng đó thì bên form gọi nó sẽ nhận đc mã kho gửi đi.
        private void btn_chon_Click(object sender, EventArgs e)
        {
            // lay ma kho , nhưng làm sao để mang mã kho qua bên kia, hiển thị dl mã kho lên txtMaKho.
            Program.maKho = getDataRow(bdsKho, "MAKHO");
            mydata(Program.maKho);

        }
    }
}
