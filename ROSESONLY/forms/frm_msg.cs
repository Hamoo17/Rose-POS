using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ROSESONLY.DLL
{
    public partial class frm_msg : DevExpress.XtraEditors.XtraForm
    {
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private IContainer components;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        public SimpleButton btn_cancel;
        public SimpleButton btn_ok;
        public LabelControl lb_msgtxt;
        public PictureEdit msg_icon;
        public Timer timer1;
        private static frm_msg frmmsg;
        public static string status { set; get; }//this properties for msg buttons yes or cancel
        static void frm_formclosed(object sender, FormClosedEventArgs e)
        {
            frmmsg = null;
        }
        public static frm_msg getmain
        {
            get
            {
                if (frmmsg == null)
                {
                    frmmsg = new frm_msg();
                    frmmsg.FormClosed += new FormClosedEventHandler(frm_formclosed);
                }
                return frmmsg;
            }
        }
        public void changlocation()
        {
          //  btn_ok.Location = new Point(122,91);
        }

        public frm_msg()
        {
            InitializeComponent();
            //panel1.BackColor = Properties.Settings.Default.item_color;
            //btn_cancel.Appearance.BackColor = Properties.Settings.Default.item_color;
            //btn_ok.Appearance.BackColor = Properties.Settings.Default.item_color;
        }



        private void frm_msg_Load(object sender, EventArgs e)
        {
            if (frmmsg == null) { frmmsg = this; }

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_msg));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.lb_msgtxt = new DevExpress.XtraEditors.LabelControl();
            this.msg_icon = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.msg_icon.Properties)).BeginInit();
            this.SuspendLayout();
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
            // btn_cancel
            // 
            this.btn_cancel.AllowFocus = false;
            this.btn_cancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Appearance.Options.UseBackColor = true;
            this.btn_cancel.Appearance.Options.UseFont = true;
            this.btn_cancel.Appearance.Options.UseForeColor = true;
            this.btn_cancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btn_cancel.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.AppearanceHovered.Options.UseBackColor = true;
            this.btn_cancel.AppearanceHovered.Options.UseFont = true;
            this.btn_cancel.AppearanceHovered.Options.UseForeColor = true;
            this.btn_cancel.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btn_cancel.AppearancePressed.Options.UseBorderColor = true;
            this.btn_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.ImageOptions.Image")));
            this.btn_cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(104, 41);
            this.btn_cancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_cancel.Size = new System.Drawing.Size(38, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "الغاء";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Appearance.Options.UseBackColor = true;
            this.btn_ok.Appearance.Options.UseFont = true;
            this.btn_ok.Appearance.Options.UseForeColor = true;
            this.btn_ok.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btn_ok.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btn_ok.AppearanceHovered.Options.UseBackColor = true;
            this.btn_ok.AppearanceHovered.Options.UseFont = true;
            this.btn_ok.AppearanceHovered.Options.UseForeColor = true;
            this.btn_ok.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btn_ok.AppearancePressed.Options.UseBorderColor = true;
            this.btn_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.ImageOptions.Image")));
            this.btn_ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_ok.Location = new System.Drawing.Point(143, 41);
            this.btn_ok.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_ok.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_ok.Size = new System.Drawing.Size(35, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.ToolTip = "موافق";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lb_msgtxt
            // 
            this.lb_msgtxt.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(45)))));
            this.lb_msgtxt.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lb_msgtxt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_msgtxt.Appearance.Options.UseBackColor = true;
            this.lb_msgtxt.Appearance.Options.UseFont = true;
            this.lb_msgtxt.Appearance.Options.UseForeColor = true;
            this.lb_msgtxt.Appearance.Options.UseTextOptions = true;
            this.lb_msgtxt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_msgtxt.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lb_msgtxt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_msgtxt.Location = new System.Drawing.Point(3, 9);
            this.lb_msgtxt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lb_msgtxt.Name = "lb_msgtxt";
            this.lb_msgtxt.Size = new System.Drawing.Size(281, 24);
            this.lb_msgtxt.TabIndex = 10;
            this.lb_msgtxt.Text = "أدخل نص الرسالة";
            this.lb_msgtxt.Click += new System.EventHandler(this.lb_msgtxt_Click_1);
            // 
            // msg_icon
            // 
            this.msg_icon.Location = new System.Drawing.Point(22, 42);
            this.msg_icon.Name = "msg_icon";
            this.msg_icon.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.msg_icon.Size = new System.Drawing.Size(37, 24);
            this.msg_icon.TabIndex = 11;
            this.msg_icon.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_msg
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(37)))), ((int)(((byte)(45)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(98)))), ((int)(((byte)(164)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(289, 74);
            this.Controls.Add(this.msg_icon);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.lb_msgtxt);
            this.Controls.Add(this.btn_ok);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frm_msg";
            this.Opacity = 0.92D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_msg_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.msg_icon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void frm_msg_Load_1(object sender, EventArgs e)
        {
        }

        private void lb_msgtxt_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            status = "OK";
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            status = "CANCEL";
            this.Close();

        }

        private void lb_msgtxt_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}