namespace ROSESONLY.forms
{
    partial class frm_purchasepay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_purchasepay));
            this.txt_remain = new DevExpress.XtraEditors.TextEdit();
            this.btn_pay = new DevExpress.XtraEditors.SimpleButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl4 = new DevExpress.XtraEditors.SeparatorControl();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.txt_paid = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_remain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_remain
            // 
            this.txt_remain.EditValue = "0.00";
            this.txt_remain.Location = new System.Drawing.Point(12, 197);
            this.txt_remain.Name = "txt_remain";
            this.txt_remain.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_remain.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remain.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.txt_remain.Properties.Appearance.Options.UseBackColor = true;
            this.txt_remain.Properties.Appearance.Options.UseFont = true;
            this.txt_remain.Properties.Appearance.Options.UseForeColor = true;
            this.txt_remain.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_remain.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_remain.Properties.AutoHeight = false;
            this.txt_remain.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_remain.Properties.ReadOnly = true;
            this.txt_remain.Properties.UseReadOnlyAppearance = false;
            this.txt_remain.Size = new System.Drawing.Size(459, 139);
            this.txt_remain.TabIndex = 1;
            // 
            // btn_pay
            // 
            this.btn_pay.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_pay.Appearance.Font = new System.Drawing.Font("splart-h-ikhlas-bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.btn_pay.Appearance.Options.UseBackColor = true;
            this.btn_pay.Appearance.Options.UseFont = true;
            this.btn_pay.Appearance.Options.UseForeColor = true;
            this.btn_pay.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_pay.AppearanceHovered.Font = new System.Drawing.Font("splart-h-ikhlas-bold", 20.25F, System.Drawing.FontStyle.Bold);
            this.btn_pay.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_pay.AppearanceHovered.Options.UseBackColor = true;
            this.btn_pay.AppearanceHovered.Options.UseFont = true;
            this.btn_pay.AppearanceHovered.Options.UseForeColor = true;
            this.btn_pay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_pay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pay.Image = ((System.Drawing.Image)(resources.GetObject("btn_pay.Image")));
            this.btn_pay.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btn_pay.Location = new System.Drawing.Point(477, 197);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(202, 139);
            this.btn_pay.TabIndex = 2;
            this.btn_pay.Text = "سداد";
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("splart-h-ikhlas-bold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Location = new System.Drawing.Point(506, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(173, 37);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "المبلغ المدفوع:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // separatorControl4
            // 
            this.separatorControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.separatorControl4.Location = new System.Drawing.Point(12, 172);
            this.separatorControl4.LookAndFeel.SkinName = "Seven Classic";
            this.separatorControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.separatorControl4.Name = "separatorControl4";
            this.separatorControl4.Size = new System.Drawing.Size(667, 19);
            this.separatorControl4.TabIndex = 93;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(12, 12);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(32, 24);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 94;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // txt_paid
            // 
            this.txt_paid.EditValue = "0.00";
            this.txt_paid.Location = new System.Drawing.Point(12, 48);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Properties.Appearance.BackColor = System.Drawing.Color.Teal;
            this.txt_paid.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.txt_paid.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paid.Properties.Appearance.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txt_paid.Properties.Appearance.Options.UseBackColor = true;
            this.txt_paid.Properties.Appearance.Options.UseBorderColor = true;
            this.txt_paid.Properties.Appearance.Options.UseFont = true;
            this.txt_paid.Properties.Appearance.Options.UseForeColor = true;
            this.txt_paid.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_paid.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_paid.Properties.AutoHeight = false;
            this.txt_paid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txt_paid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paid.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_paid.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_paid.Size = new System.Drawing.Size(477, 85);
            this.txt_paid.TabIndex = 0;
            this.txt_paid.EditValueChanged += new System.EventHandler(this.txt_paid_EditValueChanged);
            this.txt_paid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_paid_KeyDown);
            // 
            // frm_purchasepay
            // 
            this.Appearance.BackColor = System.Drawing.Color.Teal;
            this.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 348);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.separatorControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_pay);
            this.Controls.Add(this.txt_remain);
            this.Controls.Add(this.txt_paid);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_purchasepay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`2";
            this.Load += new System.EventHandler(this.frm_purchasepay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_remain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_pay;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl4;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        public DevExpress.XtraEditors.TextEdit txt_remain;
        public DevExpress.XtraEditors.CalcEdit txt_paid;
    }
}