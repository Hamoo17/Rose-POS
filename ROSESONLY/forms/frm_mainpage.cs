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
using System.Data.SqlClient;
using ROSESONLY.DLL;
namespace ROSESONLY.forms
{
    public partial class frm_mainpage : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        ResizeDemoCS.Resizer MyResizer = new ResizeDemoCS.Resizer();
        public bool checkopenedform(Form frm)
        {
            foreach (BaseDocument item in FRM_MAIN.getmain.documentManager1.View.Documents)
            {
                if (item.Caption == frm.Text)
                {
                    FRM_MAIN.getmain.documentManager1.View.ActivateDocument(item.Form);
                    return true;
                }
            }
            return false;
        }//check form open 
        public void openform(Form frm)
        {
            if (checkopenedform(frm) == false)
            {
                frm.MdiParent = FRM_MAIN.getmain;
                frm.Show();
            }
        }
        public bool checkpermissions(int user_id, string screen_name,string col,int type)
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
                    if(type==1)
                    {
                        MSg.showmsg("لا يمكنك الدخول الى هذه الشاشه ", MSg.msgbutton.ok, MSg.msgicon.information);
                    }
                        return false;
                    }
        }

        public frm_mainpage()
        {
            InitializeComponent();
        }

        private void frm_mainpage_Load(object sender, EventArgs e)
        {

        }

        private void frm_mainpage_Resize(object sender, EventArgs e)
        {
            //MyResizer.ResizeAllControls(this);
        }

        private void tileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "فواتير البيع", "show_",1) == false) { return; }

           // openform(frm_sales.get_main);
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "فواتير الشراء", "show_",1) == false) { return; }

            openform(frm_purchase.get_main);
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "مرتجع البيع", "show_",1) == false) { return; }

            openform(frm_salesreturn.get_main);
        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
          if(checkpermissions(connectiondata.user_id,"الأعدادات","show_",1)==true)
          {
            openform(frm_settings.get_main);
          }
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الأصناف", "show_",1) == true)
            {
            //     openform(frm_prodcuts.getmain);
            }
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الخزينة", "show_",1) == false) { return; }
            openform(frm_cashierMovies.getmain);
        }

        private void tileItem13_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركه الاصناف", "show_",1) == false) { return; }

            frm_productsMovies frm = new frm_productsMovies();
            openform(frm);
        }

        private void tileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "الحسابات", "show_",1) == false) { return; }
            openform(frm_accounts.getmain);
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "مرتجع الشراء", "show_",1) == false) { return; }

            openform(frm_purchaseReturn.get_main);

        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "تسوية مخزن", "show_",1) == false) { return; }

            openform(frm_adjustment.get_main);

        }

        private void tileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "تحويل لمخزن", "show_",1) == false) { return; }

            openform(frm_storeTransfer.get_main);

        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "طلبات بضاعة", "show_",1) == false) { return; }

            openform(frm_orders.get_main);

        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "كشف حساب", "show_",1) == false) { return; }

            frm_Account_recepit frm = new frm_Account_recepit();
            openform(frm);

        }

        private void tileItem19_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركة الفواتير", "show_",1) == false) { return; }

            frm_InvoicesReports frm = new frm_InvoicesReports();
            openform(frm);
            
        }

        private void tileItem18_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "حركة المخازن", "show_",1) == false) { return; }

            frm_storesmovments frm = new frm_storesmovments();
            openform(frm);

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void tileItem20_ItemClick(object sender, TileItemEventArgs e)
        {
            if (checkpermissions(connectiondata.user_id, "بضاعة مخزن", "show_",1) == false) { return; }

            frm_storeprducts frm = new frm_storeprducts();
            openform(frm);
        }
    }
}