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
    public partial class items : UserControl
    {
        public items()
        {
            InitializeComponent();
        }
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

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            openform(frm_productlist.getmain);
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_productsMovies frm=new frm_productsMovies();
            openform(frm);
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_storeprducts frm = new frm_storeprducts();
            openform(frm);
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_storesmovments frm = new frm_storesmovments();
            openform(frm);

        }
    }
}
