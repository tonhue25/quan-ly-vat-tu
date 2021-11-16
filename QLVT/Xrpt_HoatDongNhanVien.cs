using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT
{
    public partial class Xrpt_HoatDongNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_HoatDongNhanVien(int manv, DateTime dateEdit1, DateTime dateEdit2,String type)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = manv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dateEdit1;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dateEdit2;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = type;
            this.sqlDataSource1.Fill();
        }

    }
}
