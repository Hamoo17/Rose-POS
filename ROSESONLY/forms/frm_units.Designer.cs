namespace ROSESONLY.forms
{
    partial class frm_units
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_units));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_parcode = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ck_buy = new DevExpress.XtraEditors.CheckEdit();
            this.ck_sell = new DevExpress.XtraEditors.CheckEdit();
            this.txt_count = new DevExpress.XtraEditors.CalcEdit();
            this.txt_buyprice = new DevExpress.XtraEditors.CalcEdit();
            this.txt_sellprice = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_parcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_buy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_sell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_count.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_buyprice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sellprice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(191, 92);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 15);
            this.labelControl7.TabIndex = 59;
            this.labelControl7.Text = "باركود الوحدة:";
            // 
            // btn_save
            // 
            this.btn_save.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_save.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_save.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_save.Appearance.Options.UseBackColor = true;
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Appearance.Options.UseForeColor = true;
            this.btn_save.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btn_save.AppearanceHovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btn_save.AppearanceHovered.Options.UseForeColor = true;
            this.btn_save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_save.Location = new System.Drawing.Point(20, 334);
            this.btn_save.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_save.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(239, 44);
            this.btn_save.TabIndex = 6;
            this.btn_save.Tag = "0";
            this.btn_save.Text = "حفظ";
            this.btn_save.ToolTip = "حفظ البيانات";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_parcode
            // 
            this.txt_parcode.EnterMoveNextControl = true;
            this.txt_parcode.Location = new System.Drawing.Point(38, 116);
            this.txt_parcode.Name = "txt_parcode";
            this.txt_parcode.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_parcode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_parcode.Properties.Appearance.Options.UseFont = true;
            this.txt_parcode.Properties.Appearance.Options.UseForeColor = true;
            this.txt_parcode.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_parcode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_parcode.Properties.AutoHeight = false;
            this.txt_parcode.Size = new System.Drawing.Size(215, 27);
            this.txt_parcode.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(14, 116);
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(18, 27);
            this.simpleButton2.TabIndex = 60;
            this.simpleButton2.ToolTip = "أنشاء باركود للوحده";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(203, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 15);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "أسم الوحدة:";
            // 
            // txt_name
            // 
            this.txt_name.EnterMoveNextControl = true;
            this.txt_name.Location = new System.Drawing.Point(38, 56);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Properties.Appearance.Options.UseForeColor = true;
            this.txt_name.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_name.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_name.Properties.AutoHeight = false;
            this.txt_name.Properties.NullValuePrompt = "مطلوب";
            this.txt_name.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_name.Size = new System.Drawing.Size(215, 27);
            this.txt_name.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(152, 146);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 15);
            this.labelControl2.TabIndex = 64;
            this.labelControl2.Text = "عدد الصنف داخل الوحده";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(198, 212);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 15);
            this.labelControl3.TabIndex = 66;
            this.labelControl3.Text = "سعر الشراء:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(96, 212);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 15);
            this.labelControl4.TabIndex = 68;
            this.labelControl4.Text = "سعر البيع";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(141, 173);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(19, 27);
            toolTipItem1.Text = resources.GetString("toolTipItem1.Text");
            superToolTip1.Items.Add(toolTipItem1);
            this.pictureEdit1.SuperTip = superToolTip1;
            this.pictureEdit1.TabIndex = 70;
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
            // ck_buy
            // 
            this.ck_buy.Location = new System.Drawing.Point(35, 282);
            this.ck_buy.Name = "ck_buy";
            this.ck_buy.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_buy.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ck_buy.Properties.Appearance.Options.UseFont = true;
            this.ck_buy.Properties.Appearance.Options.UseForeColor = true;
            this.ck_buy.Properties.Caption = "إفتراضى للشراء";
            this.ck_buy.Properties.LookAndFeel.SkinName = "Blue";
            this.ck_buy.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ck_buy.Size = new System.Drawing.Size(103, 19);
            this.ck_buy.TabIndex = 71;
            this.ck_buy.Click += new System.EventHandler(this.ck_buy_Click);
            // 
            // ck_sell
            // 
            this.ck_sell.Location = new System.Drawing.Point(160, 282);
            this.ck_sell.Name = "ck_sell";
            this.ck_sell.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_sell.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ck_sell.Properties.Appearance.Options.UseFont = true;
            this.ck_sell.Properties.Appearance.Options.UseForeColor = true;
            this.ck_sell.Properties.Caption = "إفتراضى للبيع";
            this.ck_sell.Properties.LookAndFeel.SkinName = "Blue";
            this.ck_sell.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ck_sell.Size = new System.Drawing.Size(93, 19);
            this.ck_sell.TabIndex = 72;
            // 
            // txt_count
            // 
            this.txt_count.EnterMoveNextControl = true;
            this.txt_count.Location = new System.Drawing.Point(166, 173);
            this.txt_count.Name = "txt_count";
            this.txt_count.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_count.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_count.Properties.Appearance.Options.UseFont = true;
            this.txt_count.Properties.Appearance.Options.UseForeColor = true;
            this.txt_count.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_count.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_count.Properties.AutoHeight = false;
            this.txt_count.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_count.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_count.Properties.NullValuePrompt = "مطلوب";
            this.txt_count.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_count.Size = new System.Drawing.Size(87, 27);
            this.txt_count.TabIndex = 2;
            this.txt_count.EditValueChanged += new System.EventHandler(this.txt_count_EditValueChanged);
            // 
            // txt_buyprice
            // 
            this.txt_buyprice.EnterMoveNextControl = true;
            this.txt_buyprice.Location = new System.Drawing.Point(153, 238);
            this.txt_buyprice.Name = "txt_buyprice";
            this.txt_buyprice.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buyprice.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_buyprice.Properties.Appearance.Options.UseFont = true;
            this.txt_buyprice.Properties.Appearance.Options.UseForeColor = true;
            this.txt_buyprice.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_buyprice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_buyprice.Properties.AutoHeight = false;
            this.txt_buyprice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_buyprice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_buyprice.Properties.NullValuePrompt = "مطلوب";
            this.txt_buyprice.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_buyprice.Size = new System.Drawing.Size(100, 27);
            this.txt_buyprice.TabIndex = 3;
            // 
            // txt_sellprice
            // 
            this.txt_sellprice.EnterMoveNextControl = true;
            this.txt_sellprice.Location = new System.Drawing.Point(38, 238);
            this.txt_sellprice.Name = "txt_sellprice";
            this.txt_sellprice.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sellprice.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_sellprice.Properties.Appearance.Options.UseFont = true;
            this.txt_sellprice.Properties.Appearance.Options.UseForeColor = true;
            this.txt_sellprice.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_sellprice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_sellprice.Properties.AutoHeight = false;
            this.txt_sellprice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_sellprice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_sellprice.Properties.NullValuePrompt = "مطلوب";
            this.txt_sellprice.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_sellprice.Size = new System.Drawing.Size(100, 27);
            this.txt_sellprice.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl5.AppearanceHovered.Options.UseBackColor = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl5.Location = new System.Drawing.Point(2, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 25);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "X";
            this.labelControl5.Click += new System.EventHandler(this.labelControl5_Click);
            // 
            // frm_units
            // 
            this.ActiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 399);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.ck_sell);
            this.Controls.Add(this.ck_buy);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_parcode);
            this.Controls.Add(this.txt_count);
            this.Controls.Add(this.txt_buyprice);
            this.Controls.Add(this.txt_sellprice);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frm_units";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_units";
            this.Load += new System.EventHandler(this.frm_units_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_parcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_buy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_sell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_count.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_buyprice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sellprice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.TextEdit txt_parcode;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.CheckEdit ck_sell;
        private DevExpress.XtraEditors.CheckEdit ck_buy;
        private DevExpress.XtraEditors.CalcEdit txt_count;
        private DevExpress.XtraEditors.CalcEdit txt_buyprice;
        private DevExpress.XtraEditors.CalcEdit txt_sellprice;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}