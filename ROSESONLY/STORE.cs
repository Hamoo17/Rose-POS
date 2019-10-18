using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using ROSESONLY.forms;

namespace ROSESONLY
{
    public partial class STORE : UserControl
    {
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

        public STORE()
        {
            InitializeComponent();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_InvoicesReports frm = new frm_InvoicesReports();
            openform(frm);
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
             openform(frm_purchaseReturn.get_main);

        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_SalesInvoice.get_main);
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_salesreturn.get_main);
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_storeTransfer.get_main);
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_adjustment.get_main);
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_orders.get_main);
        }
    }
}
