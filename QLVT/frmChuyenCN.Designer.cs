
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
            System.Windows.Forms.Label mANVLabel;
            this.cmChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Chuyen = new System.Windows.Forms.Button();
            this.dS_DH = new QLVT.DS_DH();
            this.bdsCN = new System.Windows.Forms.BindingSource(this.components);
            this.chiNhanhTableAdapter = new QLVT.DS_DHTableAdapters.ChiNhanhTableAdapter();
            this.tableAdapterManager = new QLVT.DS_DHTableAdapters.TableAdapterManager();
            this.btn_Huy = new System.Windows.Forms.Button();
            mANVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS_DH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCN)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(29, 75);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(0, 13);
            mANVLabel.TabIndex = 5;
            // 
            // cmChiNhanh
            // 
            this.cmChiNhanh.FormattingEnabled = true;
            this.cmChiNhanh.Location = new System.Drawing.Point(117, 29);
            this.cmChiNhanh.Name = "cmChiNhanh";
            this.cmChiNhanh.Size = new System.Drawing.Size(163, 21);
            this.cmChiNhanh.TabIndex = 3;
            this.cmChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // btn_Chuyen
            // 
            this.btn_Chuyen.Location = new System.Drawing.Point(72, 70);
            this.btn_Chuyen.Name = "btn_Chuyen";
            this.btn_Chuyen.Size = new System.Drawing.Size(75, 23);
            this.btn_Chuyen.TabIndex = 4;
            this.btn_Chuyen.Text = "Chọn";
            this.btn_Chuyen.UseVisualStyleBackColor = true;
            this.btn_Chuyen.Click += new System.EventHandler(this.btn_Chuyen_Click);
            // 
            // dS_DH
            // 
            this.dS_DH.DataSetName = "DS_DH";
            this.dS_DH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsCN
            // 
            this.bdsCN.DataMember = "ChiNhanh";
            this.bdsCN.DataSource = this.dS_DH;
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
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(205, 70);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(75, 23);
            this.btn_Huy.TabIndex = 6;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // frmChuyenCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 117);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(mANVLabel);
            this.Controls.Add(this.btn_Chuyen);
            this.Controls.Add(this.cmChiNhanh);
            this.Controls.Add(this.label1);
            this.Name = "frmChuyenCN";
            this.Text = "Chuyển chi nhánh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChuyenCN_FormClosing);
            this.Load += new System.EventHandler(this.frmChuyenCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_DH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Chuyen;
        private DS_DH dS_DH;
        private System.Windows.Forms.BindingSource bdsCN;
        private DS_DHTableAdapters.ChiNhanhTableAdapter chiNhanhTableAdapter;
        private DS_DHTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btn_Huy;
    }
}