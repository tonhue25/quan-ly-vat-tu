using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
    public partial class XrptChiTietSLTG : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptChiTietSLTG()
        {
            InitializeComponent();
        }

    public XrptChiTietSLTG(String role , String loai,int td, int nd, int tc, int nc)
    {
        InitializeComponent();
        this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
        this.sqlDataSource1.Queries[0].Parameters[0].Value = role;
        this.sqlDataSource1.Queries[0].Parameters[1].Value = loai;
        this.sqlDataSource1.Queries[0].Parameters[2].Value = td;
        this.sqlDataSource1.Queries[0].Parameters[3].Value = nd;
        this.sqlDataSource1.Queries[0].Parameters[4].Value = tc;
        this.sqlDataSource1.Queries[0].Parameters[5].Value = nc;
        this.sqlDataSource1.Fill();
    }
}
}
