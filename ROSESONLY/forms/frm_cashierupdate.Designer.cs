namespace ROSESONLY.forms
{
    partial class frm_cashierupdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cashierupdate));
            this.lb_caption = new DevExpress.XtraEditors.LabelControl();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_band = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_value = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_date = new DevExpress.XtraEditors.DateEdit();
            this.cmb_cashier = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_notes = new DevExpress.XtraEditors.MemoEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmb_accounts = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_band.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_value.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cashier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_notes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_accounts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_caption
            // 
            this.lb_caption.Appearance.Font = new System.Drawing.Font("GE SS Unique Light", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lb_caption.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_caption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_caption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_caption.Location = new System.Drawing.Point(223, 2);
            this.lb_caption.Name = "lb_caption";
            this.lb_caption.Size = new System.Drawing.Size(136, 38);
            this.lb_caption.TabIndex = 11;
            this.lb_caption.Text = "تعديل الايصالات";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Location = new System.Drawing.Point(249, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 15);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "تاريخ الأيصال:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl3.Location = new System.Drawing.Point(276, 173);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 15);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "الحساب:";
            // 
            // txt_band
            // 
            this.txt_band.Location = new System.Drawing.Point(67, 251);
            this.txt_band.Name = "txt_band";
            this.txt_band.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_band.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_band.Properties.Appearance.Options.UseFont = true;
            this.txt_band.Properties.Appearance.Options.UseForeColor = true;
            this.txt_band.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_band.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_band.Properties.AutoHeight = false;
            this.txt_band.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_band.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_band.Size = new System.Drawing.Size(245, 27);
            this.txt_band.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl4.Location = new System.Drawing.Point(290, 230);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 15);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "البند:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl5.Location = new System.Drawing.Point(276, 295);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 15);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "الخزينة:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl6.Location = new System.Drawing.Point(271, 360);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 15);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "ملاحظات:";
            // 
            // btn_ok
            // 
            this.btn_ok.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ok.Appearance.Font = new System.Drawing.Font("GE SS Unique Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_ok.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Appearance.Options.UseBackColor = true;
            this.btn_ok.Appearance.Options.UseFont = true;
            this.btn_ok.Appearance.Options.UseForeColor = true;
            this.btn_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProvider1.SetIconAlignment(this.btn_ok, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.btn_ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.Image")));
            this.btn_ok.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_ok.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btn_ok.Location = new System.Drawing.Point(63, 443);
            this.btn_ok.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btn_ok.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(249, 45);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Tag = "0";
            this.btn_ok.Text = "حفظ";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl7.Location = new System.Drawing.Point(12, 0);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(34, 32);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "X";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(67, 63);
            this.txt_value.Name = "txt_value";
            this.txt_value.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_value.Properties.Appearance.Options.UseFont = true;
            this.txt_value.Properties.Appearance.Options.UseForeColor = true;
            this.txt_value.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_value.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_value.Properties.AutoHeight = false;
            this.txt_value.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_value.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_value.Size = new System.Drawing.Size(245, 41);
            this.txt_value.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Location = new System.Drawing.Point(255, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 15);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "قيمة الأيصال:";
            // 
            // txt_date
            // 
            this.txt_date.EditValue = null;
            this.txt_date.Location = new System.Drawing.Point(67, 134);
            this.txt_date.Name = "txt_date";
            this.txt_date.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_date.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_date.Properties.Appearance.Options.UseFont = true;
            this.txt_date.Properties.Appearance.Options.UseForeColor = true;
            this.txt_date.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_date.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_date.Properties.AutoHeight = false;
            this.txt_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_date.Properties.EditFormat.FormatString = "";
            this.txt_date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_date.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_date.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_date.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt_date.Size = new System.Drawing.Size(245, 27);
            this.txt_date.TabIndex = 1;
            // 
            // cmb_cashier
            // 
            this.cmb_cashier.Location = new System.Drawing.Point(67, 322);
            this.cmb_cashier.Name = "cmb_cashier";
            this.cmb_cashier.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cashier.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmb_cashier.Properties.Appearance.Options.UseFont = true;
            this.cmb_cashier.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_cashier.Properties.Appearance.Options.UseTextOptions = true;
            this.cmb_cashier.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmb_cashier.Properties.AutoHeight = false;
            this.cmb_cashier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_cashier.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cashier_name", "الخزينة")});
            this.cmb_cashier.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cmb_cashier.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmb_cashier.Properties.NullText = "";
            this.cmb_cashier.Size = new System.Drawing.Size(245, 27);
            this.cmb_cashier.TabIndex = 4;
            // 
            // txt_notes
            // 
            this.txt_notes.Location = new System.Drawing.Point(67, 381);
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_notes.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_notes.Properties.Appearance.Options.UseFont = true;
            this.txt_notes.Properties.Appearance.Options.UseForeColor = true;
            this.txt_notes.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_notes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_notes.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_notes.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_notes.Size = new System.Drawing.Size(245, 46);
            this.txt_notes.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmb_accounts
            // 
            this.cmb_accounts.Location = new System.Drawing.Point(67, 194);
            this.cmb_accounts.Name = "cmb_accounts";
            this.cmb_accounts.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_accounts.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmb_accounts.Properties.Appearance.Options.UseFont = true;
            this.cmb_accounts.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_accounts.Properties.Appearance.Options.UseTextOptions = true;
            this.cmb_accounts.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmb_accounts.Properties.AutoHeight = false;
            this.cmb_accounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_accounts.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cmb_accounts.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmb_accounts.Properties.NullText = "";
            this.cmb_accounts.Properties.View = this.searchLookUpEdit1View;
            this.cmb_accounts.Size = new System.Drawing.Size(245, 27);
            this.cmb_accounts.TabIndex = 2;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "كود الحساب";
            this.gridColumn1.FieldName = "account_code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الحساب";
            this.gridColumn2.FieldName = "account_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.simpleButton5.Appearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("splart-h-ikhlas-bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.simpleButton5.Appearance.Options.UseBackColor = true;
            this.simpleButton5.Appearance.Options.UseBorderColor = true;
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Appearance.Options.UseForeColor = true;
            this.simpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton5.Location = new System.Drawing.Point(38, 194);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(23, 27);
            this.simpleButton5.TabIndex = 53;
            this.simpleButton5.ToolTip = "حذف البيانات";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // frm_cashierupdate
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 509);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.lb_caption);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_band);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.cmb_cashier);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.cmb_accounts);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_cashierupdate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cashieradd";
            this.Load += new System.EventHandler(this.frm_cashieradd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_band.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_value.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_cashier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_notes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_accounts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LabelControl lb_caption;
        public DevExpress.XtraEditors.SimpleButton btn_ok;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public DevExpress.XtraEditors.TextEdit txt_band;
        public DevExpress.XtraEditors.TextEdit txt_value;
        public DevExpress.XtraEditors.DateEdit txt_date;
        public DevExpress.XtraEditors.LookUpEdit cmb_cashier;
        public DevExpress.XtraEditors.MemoEdit txt_notes;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        public DevExpress.XtraEditors.SimpleButton simpleButton5;
        public DevExpress.XtraEditors.SearchLookUpEdit cmb_accounts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}