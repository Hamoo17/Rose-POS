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
using System.Data.SqlClient;
using ROSESONLY.DLL;
using DevExpress.XtraBars.Docking2010.Views;

namespace ROSESONLY.forms
{
    public partial class frm_othermain : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        private static frm_othermain frm;
        public DataTable dt_invoicedata = new DataTable();
        private static void frm_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_othermain getmain
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_othermain();
                    frm.FormClosed += new FormClosedEventHandler(frm_closed);
                }
                return frm;
            }
        }

        public bool checkpermissions(int user_id, string screen_name, string col, int type)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_id", user_id);
            p[1] = new SqlParameter("@screen_name", screen_name);

            DataTable dt = new DataTable();
            dt = cd.getdata("sp_checkpermisions", p);

            if (Convert.ToBoolean(dt.Rows[0][col].ToString()) == true)
            {
                return true;
            }
            else
            {
                if (type == 1)
                {
                    MSg.showmsg("لا يمكنك الدخول الى هذه الشاشه ", MSg.msgbutton.ok, MSg.msgicon.information);
                }
                else
                {

                }
                return false;
            }
        }

        public frm_othermain()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHieght = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new System.Drawing.Size(screenWidth, screenHieght-40);
            lb_user_name.Text = connectiondata._username;
            dt_invoicedata.Columns.Add("invoice_no");
            dt_invoicedata.Columns.Add("invoice_date");
            dt_invoicedata.Columns.Add("accounts_name");
            dt_invoicedata.Columns.Add("store_name");
            dt_invoicedata.Columns.Add("discount");
            dt_invoicedata.Columns.Add("net_value");
            dt_invoicedata.Columns.Add("user_name");
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

        private void frm_othermain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            string path = Properties.Settings.Default.backup_path + "\\Rose" + DateTime.Now.ToShortDateString().Replace('/', '-')
+ " - " + DateTime.Now.ToShortTimeString().Replace(':', '-');
            string StrQuery = "Backup Database DB_ROSES to Disk='" + path + ".bak'";
            connectiondata cd = new connectiondata();
            SqlCommand cmd = new SqlCommand(StrQuery, cd.con);
            cd.opencnnection();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                FolderBrowserDialog op = new FolderBrowserDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.backup_path = op.SelectedPath;
                    Properties.Settings.Default.Save();
                }

            }
            cd.closconnection();
            cmd.Dispose();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraForm1.formclosing = true;

            this.Close();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الأصناف", "show_", 1) == true)
            {
                openform(frm_productlist.getmain);
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if(navBarControl1.Width==209)
            {
                navBarControl1.Width = 50;
                panelControl2.Width =50;
            }
            else
            {
                navBarControl1.Width = 209;
                panelControl2.Width =209;
            }
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            openform(frm_addproducts.getmain);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_category frm = new frm_category();
            frm.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "فواتير البيع", "show_", 1) == false) { return; }
            openform(frm_SalesInvoice.get_main);

        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "مرتجع البيع", "show_", 1) == false) { return; }

            openform(frm_salesreturn.get_main);
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الحسابات", "show_", 1) == false) { return; }
            openform(frm_accounts.getmain);

        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_addacounts frm = new frm_addacounts();
            openform(frm);
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "كشف حساب", "show_", 1) == false) { return; }

            frm_Account_recepit frm = new frm_Account_recepit();
            openform(frm);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركه الاصناف", "show_", 1) == false) { return; }

            frm_productsMovies frm = new frm_productsMovies();
            openform(frm);
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "فواتير الشراء", "show_", 1) == false) { return; }
            openform(frm_purchase.get_main);
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "مرتجع الشراء", "show_", 1) == false) { return; }

            openform(frm_purchaseReturn.get_main);
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_InvoicesReports frm = new frm_InvoicesReports();
            openform(frm);
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركة المخازن", "show_", 1) == false) { return; }

            frm_storesmovments frm = new frm_storesmovments();
            openform(frm);
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الخزينة", "show_", 1) == false) { return; }
            openform(frm_cashierMovies.getmain);
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "بضاعة مخزن", "show_", 1) == false) { return; }

            frm_storeprducts frm = new frm_storeprducts();
            openform(frm);

        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_SalesInvoice frm = new frm_SalesInvoice();
            openform(frm);
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "تحويل لمخزن", "show_", 1) == false) { return; }

            openform(frm_storeTransfer.get_main);
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "تسوية مخزن", "show_", 1) == false) { return; }

            openform(frm_adjustment.get_main);
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الأعدادات", "show_", 1) == true)
            {
                openform(frm_settings.get_main);
            }
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_parcodprint frm = new frm_parcodprint();
            openform(frm);
        }

        private void navBarItem7_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_productChangePrice frm = new frm_productChangePrice();
            openform(frm);
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_cashieradd frm = new frm_cashieradd();
            openform(frm);
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_cashierout frm = new frm_cashierout();
            openform(frm);
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_salesanlyzing frm = new frm_salesanlyzing();
            openform(frm);
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركة الفواتير", "show_", 1) == false) { return; }

            frm_InvoicesReports frm = new frm_InvoicesReports();
            openform(frm);
        }

        private void frm_othermain_Load(object sender, EventArgs e)
        {
            openform(XtraForm1.getmain);
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_productsMinmizing frm = new frm_productsMinmizing();
            openform(frm);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            openform(XtraForm1.getmain);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            XtraForm1.formclosing = true;
            Application.Restart();
        }

        private void navBarItem6_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_othersetting frm = new frm_othersetting();
            openform(frm);
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_revenueanaluzing frm = new frm_revenueanaluzing();
            openform(frm);
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_expensesAnalyze frm = new frm_expensesAnalyze();
            openform(frm);
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_Income frm = new frm_Income();
            openform(frm);
        }
    }
}