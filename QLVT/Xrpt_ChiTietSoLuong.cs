using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
    public partial class Xrpt_ChiTietSoLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_ChiTietSoLuong(String role,string loai,DateTime from, DateTime to)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = role;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = from.ToString("yyyy-MM-dd"); 
            this.sqlDataSource1.Queries[0].Parameters[3].Value = to.ToString("yyyy-MM-dd"); 
        }

    }
}
