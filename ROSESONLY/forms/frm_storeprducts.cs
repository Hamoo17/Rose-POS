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
using DevExpress.XtraPrinting;
namespace ROSESONLY.forms
{
    public partial class frm_storeprducts : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_storeprducts()
        {
            InitializeComponent();
            bindingstores();
        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectstores", null);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frm_storeprducts_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_stores.Text)) { return; }
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@store_code", cmb_stores.EditValue);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_storeproducts", p);
            gridControl1.DataSource = dt;
;
        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "[product_name] +[product_code] like '%" + searchControl1.Text + "%'"; 

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.RightMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.Landscape = true;

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }
    }
}