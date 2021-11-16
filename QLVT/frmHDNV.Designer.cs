
namespace QLVT
{
    partial class frmHDNV
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
            this.dS_TraCuuNV = new QLVT.DS_TraCuuNV();
            this.bdsTCNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QLVT.DS_TraCuuNVTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT.DS_TraCuuNVTableAdapters.TableAdapterManager();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            this.dS_NhanVien = new QLVT.DS_NhanVien();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter1 = new QLVT.DS_NhanVienTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager1 = new QLVT.DS_NhanVienTableAdapters.TableAdapterManager();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.rbNhap = new System.Windows.Forms.RadioButton();
            this.rbXuat = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            hOTENLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS_TraCuuNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTCNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(50, 65);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(45, 13);
            hOTENLabel.TabIndex = 4;
            hOTENLabel.Text = "Họ tên :";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(130, 21);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(180, 21);
            this.cmbChiNhanh.TabIndex = 3;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // dS_TraCuuNV
            // 
            this.dS_TraCuuNV.DataSetName = "DS_TraCuuNV";
            this.dS_TraCuuNV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsTCNV
            // 
            this.bdsTCNV.DataMember = "NhanVien";
            this.bdsTCNV.DataSource = this.dS_TraCuuNV;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = QLVT.DS_TraCuuNVTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsTCNV, "HOTEN", true));
            this.cmbHoTen.DataSource = this.bdsTCNV;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(130, 62);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(180, 21);
            this.cmbHoTen.TabIndex = 5;
            this.cmbHoTen.ValueMember = "MANV";
            this.cmbHoTen.SelectedIndexChanged += new System.EventHandler(this.hOTENComboBox_SelectedIndexChanged);
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
            // nhanVienTableAdapter1
            // 
            this.nhanVienTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.DatHangTableAdapter = null;
            this.tableAdapterManager1.NhanVienTableAdapter = this.nhanVienTableAdapter1;
            this.tableAdapterManager1.PhieuNhapTableAdapter = null;
            this.tableAdapterManager1.PhieuXuatTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QLVT.DS_NhanVienTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến ngày";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(110, 160);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 8;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(288, 160);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 9;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(308, 216);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 15;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(191, 216);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 14;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(81, 216);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(75, 23);
            this.btn_Preview.TabIndex = 13;
            this.btn_Preview.Text = "Preview";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // rbNhap
            // 
            this.rbNhap.AutoSize = true;
            this.rbNhap.Location = new System.Drawing.Point(130, 114);
            this.rbNhap.Name = "rbNhap";
            this.rbNhap.Size = new System.Drawing.Size(51, 17);
            this.rbNhap.TabIndex = 16;
            this.rbNhap.TabStop = true;
            this.rbNhap.Text = "Nhập";
            this.rbNhap.UseVisualStyleBackColor = true;
            // 
            // rbXuat
            // 
            this.rbXuat.AutoSize = true;
            this.rbXuat.Location = new System.Drawing.Point(255, 114);
            this.rbXuat.Name = "rbXuat";
            this.rbXuat.Size = new System.Drawing.Size(47, 17);
            this.rbXuat.TabIndex = 17;
            this.rbXuat.TabStop = true;
            this.rbXuat.Text = "Xuất";
            this.rbXuat.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Loại";
            // 
            // frmHDNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 275);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbXuat);
            this.Controls.Add(this.rbNhap);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(hOTENLabel);
            this.Controls.Add(this.cmbHoTen);
            this.Controls.Add(this.cmbChiNhanh);
            this.Controls.Add(this.label1);
            this.Name = "frmHDNV";
            this.Text = "Hoạt động nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHDNV_FormClosing);
            this.Load += new System.EventHandler(this.frmHDNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_TraCuuNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTCNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DS_TraCuuNV dS_TraCuuNV;
        private System.Windows.Forms.BindingSource bdsTCNV;
        private DS_TraCuuNVTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DS_TraCuuNVTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbHoTen;
        private DS_NhanVien dS_NhanVien;
        private System.Windows.Forms.BindingSource bdsNV;
        private DS_NhanVienTableAdapters.NhanVienTableAdapter nhanVienTableAdapter1;
        private DS_NhanVienTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.RadioButton rbNhap;
        private System.Windows.Forms.RadioButton rbXuat;
        private System.Windows.Forms.Label label4;
    }
}