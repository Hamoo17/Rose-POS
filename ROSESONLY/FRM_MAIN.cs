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
using DevExpress.XtraBars.Docking2010.Views;
using ROSESONLY.forms;
using ROSESONLY.DLL;
using System.Data.SqlClient;
namespace ROSESONLY
{
    public partial class FRM_MAIN : DevExpress.XtraEditors.XtraForm
    {
        ResizeDemoCS.Resizer MyResizer = new ResizeDemoCS.Resizer();

        private static FRM_MAIN frm;
        private static void frm_closed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_MAIN getmain
        {
            get
            {
                if(frm==null)
                {
                    frm=new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_closed);
                }
                return frm;
            }
        }
        public FRM_MAIN()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
        }
        public bool checkopenedform(Form frm)
        {
            foreach (BaseDocument item in this.documentManager1.View.Documents)
            {
                if (item.Caption == frm.Text)
                {
                    documentManager1.View.ActivateDocument(item.Form);
                    return true;
                }
            }
            return false;
        }//check form open 
        public void openform(Form frm)
        {
            if (checkopenedform(frm) == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }


        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }


        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            lb_username.Text = connectiondata._username;
            lb_date .Text= DateTime.Today.ToShortDateString();

            connectiondata.screenWidth = Screen.PrimaryScreen.Bounds.Width;
            connectiondata.screenHieght = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new System.Drawing.Size(connectiondata.screenWidth, connectiondata.screenHieght - 40);
            frm_mainpage frm = new frm_mainpage();
            openform(frm);
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            frm_mainpage frm = new frm_mainpage();
            openform(frm);
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = Convert.ToDateTime(DateTime.Now).ToLongTimeString();
        }

        private void btn_logof_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        void backup()
        {

        }
        private void FRM_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {


                
        }
    }
}