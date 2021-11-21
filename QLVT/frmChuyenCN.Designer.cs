
namespace QLVT
{
    partial class frmChuyenCN
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
            this.label1 = new System.Windows.Forms.Label();
            this.dS_DH = new QLVT.DS_DH();
            this.chiNhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chiNhanhTableAdapter = new QLVT.DS_DHTableAdapters.ChiNhanhTableAdapter();
            this.tableAdapterManager = new QLVT.DS_DHTableAdapters.TableAdapterManager();
            this.cmbChiNhanh1 = new System.Windows.Forms.ComboBox();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dS_DH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // dS_DH
            // 
            this.dS_DH.DataSetName = "DS_DH";
            this.dS_DH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chiNhanhBindingSource
            // 
            this.chiNhanhBindingSource.DataMember = "ChiNhanh";
            this.chiNhanhBindingSource.DataSource = this.dS_DH;
            // 
            // chiNhanhTableAdapter
            // 
            this.chiNhanhTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = this.chiNhanhTableAdapter;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT.DS_DHTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cmbChiNhanh1
            // 
            this.cmbChiNhanh1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chiNhanhBindingSource, "MACN", true));
            this.cmbChiNhanh1.FormattingEnabled = true;
            this.cmbChiNhanh1.Location = new System.Drawing.Point(120, 48);
            this.cmbChiNhanh1.Name = "cmbChiNhanh1";
            this.cmbChiNhanh1.Size = new System.Drawing.Size(147, 21);
            this.cmbChiNhanh1.TabIndex = 5;
            // 
            // btnChuyen
            // 
            this.btnChuyen.Location = new System.Drawing.Point(49, 108);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(75, 23);
            this.btnChuyen.TabIndex = 6;
            this.btnChuyen.Text = "Chọn";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmChuyenCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 183);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.cmbChiNhanh1);
            this.Controls.Add(this.label1);
            this.Name = "frmChuyenCN";
            this.Text = "Chọn chi nhánh ";
            this.Load += new System.EventHandler(this.frmChuyenCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_DH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DS_DH dS_DH;
        private System.Windows.Forms.BindingSource chiNhanhBindingSource;
        private DS_DHTableAdapters.ChiNhanhTableAdapter chiNhanhTableAdapter;
        private DS_DHTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbChiNhanh1;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.Button button1;
    }
}