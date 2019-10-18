namespace ROSESONLY.forms
{
    partial class frm_storeproducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_storeproducts));
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_stores = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_quantity = new DevExpress.XtraEditors.CalcEdit();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_stores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_quantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(6, 3);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(22, 24);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 51;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // btn_save
            // 
            this.btn_save.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_save.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_save.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_save.Appearance.Options.UseBackColor = true;
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Appearance.Options.UseForeColor = true;
            this.btn_save.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(230)))), ((int)(((byte)(157)))));
            this.btn_save.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_save.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btn_save.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btn_save.AppearanceHovered.Options.UseBackColor = true;
            this.btn_save.AppearanceHovered.Options.UseFont = true;
            this.btn_save.AppearanceHovered.Options.UseForeColor = true;
            this.btn_save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_save.Location = new System.Drawing.Point(23, 173);
            this.btn_save.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_save.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(168, 43);
            this.btn_save.TabIndex = 55;
            this.btn_save.Tag = "0";
            this.btn_save.Text = "حفظ";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_stores
            // 
            this.cmb_stores.Location = new System.Drawing.Point(25, 64);
            this.cmb_stores.Name = "cmb_stores";
            this.cmb_stores.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_stores.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmb_stores.Properties.Appearance.Options.UseFont = true;
            this.cmb_stores.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_stores.Properties.Appearance.Options.UseTextOptions = true;
            this.cmb_stores.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmb_stores.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_stores.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_stores.Properties.AutoHeight = false;
            this.cmb_stores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_stores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("store_name", "المخزن")});
            this.cmb_stores.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.cmb_stores.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmb_stores.Properties.NullText = "";
            this.cmb_stores.Properties.NullValuePrompt = "اختر المخزن";
            this.cmb_stores.Properties.NullValuePromptShowForEmptyValue = true;
            this.cmb_stores.Size = new System.Drawing.Size(167, 29);
            this.cmb_stores.TabIndex = 54;
            // 
            // txt_quantity
            // 
            this.txt_quantity.Location = new System.Drawing.Point(24, 124);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quantity.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_quantity.Properties.Appearance.Options.UseFont = true;
            this.txt_quantity.Properties.Appearance.Options.UseForeColor = true;
            this.txt_quantity.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_quantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_quantity.Properties.AutoHeight = false;
            this.txt_quantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_quantity.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_quantity.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_quantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_quantity.Properties.NullValuePrompt = "ادخل رصيد الصنف";
            this.txt_quantity.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_quantity.Size = new System.Drawing.Size(167, 29);
            this.txt_quantity.TabIndex = 57;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(157, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 15);
            this.labelControl1.TabIndex = 58;
            this.labelControl1.Text = "المخزن:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(157, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 15);
            this.labelControl2.TabIndex = 59;
            this.labelControl2.Text = "الرصيد:";
            // 
            // frm_storeproducts
            // 
            this.ActiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 237);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.cmb_stores);
            this.Controls.Add(this.txt_quantity);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frm_storeproducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_storeproducts";
            this.Load += new System.EventHandler(this.frm_storeproducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_stores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_quantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        public DevExpress.XtraEditors.SimpleButton btn_save;
        public DevExpress.XtraEditors.LookUpEdit cmb_stores;
        public DevExpress.XtraEditors.CalcEdit txt_quantity;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}