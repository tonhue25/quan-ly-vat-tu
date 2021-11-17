using DevExpress.Skins;
using DevExpress.UserSkins;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System;
using DevExpress.XtraEditors;

namespace QLVT
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static String connstr_publisher = "Data Source=DESKTOP-T9H6AK5\\SQLSERVER;Initial Catalog=QLVT;Integrated Security=True";

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";

        public static String database = "QLVT";
        public static String remotelogin = "HTKN";
        public static String remotepassword = "123";
        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mChiNhanh = 0;

        public static BindingSource bds_dspm = new BindingSource();
       
        public static frmMain frmChinh;
        public static subformKho subFormKho;
        public static subformCTDDH subFormCTDDH;
        public static subformCTPX subFormCTPX;
        public static subformChiTietPN subFormChiTietPN;
        public static frmChiTietSL frmChiTietSL;
        public static frmDDHChuaCoPN frmDDHChuaCoPN;
        public static frmHDNV formHDNV;
        public static frmTHNX formTHNX;

        public static int kt;
        public static String maKho = "";
        public static String maDDH = "";
        public static String maPN = "";
        public static String maPX = "";
        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myReader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            // kieu cau lenh
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myReader = sqlcmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String strLenh)
        {
            SqlCommand sqlcmd = new SqlCommand(strLenh, conn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
                conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excell.");
                else MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State;
            }
        }

        public static int ExecuteScalar(String cmd)
        {

            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.Connection = Program.conn;
            //sqlcmd.CommandText = cmd;
            SqlCommand sqlcmd = new SqlCommand(cmd, conn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 600; //Chỉ dùng cho cơ sở dữ liệu lớn

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                String ketQua = (String)sqlcmd.ExecuteScalar();
                if (ketQua == null) {
                    return 0;
                }
                else
                {
                    kt = int.Parse(ketQua);
                    return kt;
                }
            }
            catch (Exception ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new frmMain();
            Application.Run(frmChinh);
        }
    }
}
