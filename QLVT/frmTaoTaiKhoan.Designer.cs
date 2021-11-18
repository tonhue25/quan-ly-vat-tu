
namespace QLVT
{
    partial class frmTaoTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label hOTENLabel;
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dS_DSNVChuaTaoLogin = new QLVT.DS_DSNVChuaTaoLogin();
            this.bdsNVChuaTaoLogin = new System.Windows.Forms.BindingSource(this.components);
            this.NVChuaTaoLoginTableAdapter = new QLVT.DS_DSNVChuaTaoLoginTableAdapters.NhanVienTableAdapter();
            this.NVChuaTaoLoginTableAdapterManager = new QLVT.DS_DSNVChuaTaoLoginTableAdapters.TableAdapterManager();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.dS_NhanVien = new QLVT.DS_NhanVien();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QLVT.DS_NhanVienTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT.DS_NhanVienTableAdapters.TableAdapterManager();
            this.rbCN = new System.Windows.Forms.RadioButton();
            this.rbU = new System.Windows.Forms.RadioButton();
            this.btn_TaoTK = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            hOTENLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS_DSNVChuaTaoLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVChuaTaoLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(54, 70);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(45, 13);
            hOTENLabel.TabIndex = 4;
            hOTENLabel.Text = "Họ tên :";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(143, 26);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(131, 21);
            this.cmbChiNhanh.TabIndex = 3;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // dS_DSNVChuaTaoLogin
            // 
            this.dS_DSNVChuaTaoLogin.DataSetName = "DS_DSNVChuaTaoLogin";
            this.dS_DSNVChuaTaoLogin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNVChuaTaoLogin
            // 
            this.bdsNVChuaTaoLogin.DataMember = "NhanVien";
            this.bdsNVChuaTaoLogin.DataSource = this.dS_DSNVChuaTaoLogin;
            // 
            // NVChuaTaoLoginTableAdapter
            // 
            this.NVChuaTaoLoginTableAdapter.ClearBeforeFill = true;
            // 
            // NVChuaTaoLoginTableAdapterManager
            // 
            this.NVChuaTaoLoginTableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.NVChuaTaoLoginTableAdapterManager.Connection = null;
            this.NVChuaTaoLoginTableAdapterManager.UpdateOrder = QLVT.DS_DSNVChuaTaoLoginTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsNVChuaTaoLogin, "HOTEN", true));
            this.cmbHoTen.DataSource = this.bdsNVChuaTaoLogin;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(143, 67);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(131, 21);
            this.cmbHoTen.TabIndex = 5;
            this.cmbHoTen.ValueMember = "MANV";
            this.cmbHoTen.SelectedIndexChanged += new System.EventHandler(this.cmbHoTen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tài khoản :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật mã :";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(143, 106);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(131, 20);
            this.txtTK.TabIndex = 8;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(143, 141);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(131, 20);
            this.txtPass.TabIndex = 9;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // dS_NhanVien
            // 
            this.dS_NhanVien.DataSetName = "DS_NhanVien";
            this.dS_NhanVien.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNV
            // 
            this.bdsNV.DataMember = "NhanVien";
            this.bdsNV.DataSource = this.dS_NhanVien;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT.DS_NhanVienTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // rbCN
            // 
            this.rbCN.AutoSize = true;
            this.rbCN.Location = new System.Drawing.Point(66, 182);
            this.rbCN.Name = "rbCN";
            this.rbCN.Size = new System.Drawing.Size(73, 17);
            this.rbCN.TabIndex = 10;
            this.rbCN.TabStop = true;
            this.rbCN.Text = "Chi nhánh";
            this.rbCN.UseVisualStyleBackColor = true;
            // 
            // rbU
            // 
            this.rbU.AutoSize = true;
            this.rbU.Location = new System.Drawing.Point(173, 182);
            this.rbU.Name = "rbU";
            this.rbU.Size = new System.Drawing.Size(47, 17);
            this.rbU.TabIndex = 11;
            this.rbU.TabStop = true;
            this.rbU.Text = "User";
            this.rbU.UseVisualStyleBackColor = true;
            // 
            // btn_TaoTK
            // 
            this.btn_TaoTK.Location = new System.Drawing.Point(66, 219);
            this.btn_TaoTK.Name = "btn_TaoTK";
            this.btn_TaoTK.Size = new System.Drawing.Size(94, 23);
            this.btn_TaoTK.TabIndex = 12;
            this.btn_TaoTK.Text = "Tạo tài khoản";
            this.btn_TaoTK.UseVisualStyleBackColor = true;
            this.btn_TaoTK.Click += new System.EventHandler(this.btn_TaoTK_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(199, 219);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(75, 23);
            this.btn_Huy.TabIndex = 13;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // frmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 275);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_TaoTK);
            this.Controls.Add(this.rbU);
            this.Controls.Add(this.rbCN);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(hOTENLabel);
            this.Controls.Add(this.cmbHoTen);
            this.Controls.Add(this.cmbChiNhanh);
            this.Controls.Add(this.label1);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "frmTaoTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_DSNVChuaTaoLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVChuaTaoLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DS_DSNVChuaTaoLogin dS_DSNVChuaTaoLogin;
        private System.Windows.Forms.BindingSource bdsNVChuaTaoLogin;
        private DS_DSNVChuaTaoLoginTableAdapters.NhanVienTableAdapter NVChuaTaoLoginTableAdapter;
        private DS_DSNVChuaTaoLoginTableAdapters.TableAdapterManager NVChuaTaoLoginTableAdapterManager;
        private System.Windows.Forms.ComboBox cmbHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtPass;
        private DS_NhanVien dS_NhanVien;
        private System.Windows.Forms.BindingSource bdsNV;
        private DS_NhanVienTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DS_NhanVienTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.RadioButton rbCN;
        private System.Windows.Forms.RadioButton rbU;
        private System.Windows.Forms.Button btn_TaoTK;
        private System.Windows.Forms.Button btn_Huy;
    }
}