namespace ROSESONLY.forms
{
    partial class frm_changeqty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_changeqty));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txt_productname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_unit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_qty = new DevExpress.XtraEditors.SpinEdit();
            this.txt_price = new DevExpress.XtraEditors.SpinEdit();
            this.btn_change = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_productname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_price.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(265, 152);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "الكمية:";
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
            // txt_productname
            // 
            this.txt_productname.Location = new System.Drawing.Point(32, 46);
            this.txt_productname.Name = "txt_productname";
            this.txt_productname.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_productname.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_productname.Properties.Appearance.Options.UseFont = true;
            this.txt_productname.Properties.Appearance.Options.UseForeColor = true;
            this.txt_productname.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_productname.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_productname.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_productname.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txt_productname.Properties.AutoHeight = false;
            this.txt_productname.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_productname.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_productname.Properties.ReadOnly = true;
            this.txt_productname.Size = new System.Drawing.Size(267, 32);
            this.txt_productname.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(259, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 17);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "الصنف:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(261, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 17);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "الوحدة:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(134, 152);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 17);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "السعر";
            // 
            // cmb_unit
            // 
            this.cmb_unit.Location = new System.Drawing.Point(32, 114);
            this.cmb_unit.Name = "cmb_unit";
            this.cmb_unit.Properties.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.cmb_unit.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_unit.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cmb_unit.Properties.Appearance.Options.UseBorderColor = true;
            this.cmb_unit.Properties.Appearance.Options.UseFont = true;
            this.cmb_unit.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_unit.Properties.Appearance.Options.UseTextOptions = true;
            this.cmb_unit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmb_unit.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmb_unit.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.cmb_unit.Properties.AutoHeight = false;
            this.cmb_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_unit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cmb_unit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmb_unit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_unit.Size = new System.Drawing.Size(267, 32);
            this.cmb_unit.TabIndex = 11;
            this.cmb_unit.SelectedIndexChanged += new System.EventHandler(this.cmb_unit_SelectedIndexChanged);
            // 
            // txt_qty
            // 
            this.txt_qty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_qty.Location = new System.Drawing.Point(169, 173);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Properties.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.txt_qty.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_qty.Properties.Appearance.Options.UseBorderColor = true;
            this.txt_qty.Properties.Appearance.Options.UseFont = true;
            this.txt_qty.Properties.Appearance.Options.UseForeColor = true;
            this.txt_qty.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_qty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_qty.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_qty.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txt_qty.Properties.AutoHeight = false;
            this.txt_qty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_qty.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt_qty.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_qty.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_qty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_qty.Size = new System.Drawing.Size(130, 32);
            this.txt_qty.TabIndex = 0;
            this.txt_qty.Enter += new System.EventHandler(this.txt_qty_Enter);
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            // 
            // txt_price
            // 
            this.txt_price.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_price.Location = new System.Drawing.Point(32, 173);
            this.txt_price.Name = "txt_price";
            this.txt_price.Properties.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.txt_price.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_price.Properties.Appearance.Options.UseBorderColor = true;
            this.txt_price.Properties.Appearance.Options.UseFont = true;
            this.txt_price.Properties.Appearance.Options.UseForeColor = true;
            this.txt_price.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_price.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_price.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_price.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txt_price.Properties.AutoHeight = false;
            this.txt_price.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_price.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt_price.Properties.LookAndFeel.SkinName = "Office 2010 Silver";
            this.txt_price.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt_price.Size = new System.Drawing.Size(130, 32);
            this.txt_price.TabIndex = 1;
            this.txt_price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_price_KeyDown);
            // 
            // btn_change
            // 
            this.btn_change.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(199)))), ((int)(((byte)(16)))));
            this.btn_change.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_change.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_change.Appearance.Options.UseBackColor = true;
            this.btn_change.Appearance.Options.UseFont = true;
            this.btn_change.Appearance.Options.UseForeColor = true;
            this.btn_change.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_change.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_change.ImageOptions.Image")));
            this.btn_change.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btn_change.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_change.Location = new System.Drawing.Point(32, 225);
            this.btn_change.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_change.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(267, 47);
            this.btn_change.TabIndex = 2;
            this.btn_change.Text = "حفظ";
            this.btn_change.ToolTip = "تحديث البيانات";
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // frm_changeqty
            // 
            this.ActiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 294);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_productname);
            this.Controls.Add(this.cmb_unit);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.txt_price);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frm_changeqty";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_changeqty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_productname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_qty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_price.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_change;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txt_productname;
        public DevExpress.XtraEditors.ComboBoxEdit cmb_unit;
        public DevExpress.XtraEditors.SpinEdit txt_qty;
        public DevExpress.XtraEditors.SpinEdit txt_price;
    }
}