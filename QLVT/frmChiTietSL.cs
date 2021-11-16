using DevExpress.XtraReports.UI;
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
    public partial class frmChiTietSL : Form
    {
        String loaiPhieu = "";
        String bd = "";
        String kt = "";
        int loai = 0;
        String role = Program.mGroup;
        public frmChiTietSL()
        {
            InitializeComponent();
        }

        private void formSupport1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.frmChinh.Enabled = true;
        }

        // lay duoc loai phieu
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loai = cmbChon.SelectedIndex;
            // 0 nhap
            // 1 xuat
            if(loai == 0)
            {
                loaiPhieu = "NHAP";
            }else
            {
                loaiPhieu = "XUAT";
            }
        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            String[] string1 = dayBD.Text.Split('/');
            String[] string2 = dayKT.Text.Split('/');
           
            XrptChiTietSLTG report = new XrptChiTietSLTG(role,loaiPhieu, int.Parse(string1[0]), int.Parse(string1[1]), int.Parse(string2[0]), int.Parse(string2[1]));
            report.label1.Text = "BẢNG KÊ CHI TIẾT SỐ LƯỢNG - TRỊ GIÁ HÀNG ";
            report.label1.Text += (loai == 0) ? "NHẬP" : "XUẤT";

            ReportPrintTool printTool_TonghopNhapXuat = new ReportPrintTool(report);
            printTool_TonghopNhapXuat.ShowPreviewDialog();
        }
    }
}
