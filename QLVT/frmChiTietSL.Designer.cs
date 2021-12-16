
namespace QLVT
{
    partial class frmChiTietSL
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
            this.cmbChon = new System.Windows.Forms.ComboBox();
            this.dayBD = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dayKT = new DevExpress.XtraEditors.DateEdit();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayKT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayKT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChon
            // 
            this.cmbChon.FormattingEnabled = true;
            this.cmbChon.Items.AddRange(new object[] {
            "Bảng kê chi tiết SL -  trị giá hàng nhập",
            "Bảng kê chi tiết SL -  trị giá hàng xuất"});
            this.cmbChon.Location = new System.Drawing.Point(157, 45);
            this.cmbChon.Name = "cmbChon";
            this.cmbChon.Size = new System.Drawing.Size(268, 21);
            this.cmbChon.TabIndex = 0;
            this.cmbChon.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dayBD
            // 
            this.dayBD.EditValue = null;
            this.dayBD.Location = new System.Drawing.Point(157, 103);
            this.dayBD.Name = "dayBD";
            this.dayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dayBD.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dayBD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dayBD.Properties.EditFormat.FormatString = "MM/yyyy";
            this.dayBD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dayBD.Properties.Mask.EditMask = "MM/yyyy";
            this.dayBD.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.dayBD.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.dayBD.Size = new System.Drawing.Size(100, 20);
            this.dayBD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loại :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tháng / năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "----";
            // 
            // dayKT
            // 
            this.dayKT.EditValue = null;
            this.dayKT.Location = new System.Drawing.Point(325, 103);
            this.dayKT.Name = "dayKT";
            this.dayKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dayKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dayKT.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dayKT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dayKT.Properties.EditFormat.FormatString = "MM/yyyy";
            this.dayKT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dayKT.Properties.Mask.EditMask = "MM/yyyy";
            this.dayKT.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.dayKT.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.dayKT.Size = new System.Drawing.Size(100, 20);
            this.dayKT.TabIndex = 7;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(301, 143);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 15;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_Preview
            // 
            this.btn_Preview.Location = new System.Drawing.Point(157, 143);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(75, 23);
            this.btn_Preview.TabIndex = 13;
            this.btn_Preview.Text = "Preview";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // frmChiTietSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 192);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.dayKT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dayBD);
            this.Controls.Add(this.cmbChon);
            this.Name = "frmChiTietSL";
            this.Text = "Bảng kê chi tiết SL - trị giá hàng nhập / xuất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSupport1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayKT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.DateEdit dayBD;
        public DevExpress.XtraEditors.DateEdit dayKT;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Preview;
    }
}