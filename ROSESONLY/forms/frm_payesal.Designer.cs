namespace ROSESONLY.forms
{
    partial class frm_payesal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_payesal));
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paid = new DevExpress.XtraEditors.TextEdit();
            this.lb_total = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl9.Location = new System.Drawing.Point(12, 12);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(14, 23);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "X";
            this.labelControl9.ToolTip = "اغلاق";
            this.labelControl9.Click += new System.EventHandler(this.labelControl9_Click);
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
            // btn_save
            // 
            this.btn_save.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_save.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_save.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_save.Appearance.Options.UseBackColor = true;
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Appearance.Options.UseForeColor = true;
            this.btn_save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_save.Location = new System.Drawing.Point(21, 174);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(258, 53);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "حفظ";
            this.btn_save.ToolTip = "اضافه سداد للفاتورة";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("splart-h-ikhlas-bold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(215, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(187, 16);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "أدخل المبلغ المسدد من قيمة الفاتورة";
            // 
            // txt_paid
            // 
            this.txt_paid.EditValue = "0.0";
            this.txt_paid.Location = new System.Drawing.Point(21, 68);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Properties.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.txt_paid.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paid.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_paid.Properties.Appearance.Options.UseBorderColor = true;
            this.txt_paid.Properties.Appearance.Options.UseFont = true;
            this.txt_paid.Properties.Appearance.Options.UseForeColor = true;
            this.txt_paid.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_paid.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_paid.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_paid.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txt_paid.Properties.AutoHeight = false;
            this.txt_paid.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_paid.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_paid.Size = new System.Drawing.Size(258, 49);
            this.txt_paid.TabIndex = 0;
            this.txt_paid.ToolTip = "المبلغ المدفوع";
            this.txt_paid.EditValueChanged += new System.EventHandler(this.txt_paid_EditValueChanged);
            this.txt_paid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_paid_KeyDown);
            // 
            // lb_total
            // 
            this.lb_total.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb_total.Appearance.Options.UseFont = true;
            this.lb_total.Appearance.Options.UseForeColor = true;
            this.lb_total.Location = new System.Drawing.Point(37, 144);
            this.lb_total.Name = "lb_total";
            this.lb_total.Size = new System.Drawing.Size(31, 24);
            this.lb_total.TabIndex = 25;
            this.lb_total.Text = "0.0";
            this.lb_total.ToolTip = "اجمالى قيمة الفاتورة";
            this.lb_total.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(205, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 18);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "المبلغ المدفوع:";
            // 
            // frm_payesal
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 268);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lb_total);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_paid);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frm_payesal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_payesal";
            this.Load += new System.EventHandler(this.frm_payesal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_paid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        public DevExpress.XtraEditors.TextEdit txt_paid;
        public DevExpress.XtraEditors.LabelControl lb_total;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}