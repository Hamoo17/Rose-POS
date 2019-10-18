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
    public partial class frm_productsMinmizing : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_productsMinmizing()
        {
            InitializeComponent();
        }

        private void frm_productsMinmizing_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_ProductsMinmizieQty", null);
            gridControl1.DataSource = dt;
        }

        private void frm_productsMinmizing_Activated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_ProductsMinmizieQty", null);
            gridControl1.DataSource = dt;

        }

        private void btn_productmoves_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            string product_name = gridView1.GetFocusedRowCellValue("product_name").ToString();
            int product_code_ = int.Parse(gridView1.GetFocusedRowCellValue("product_code").ToString());
            frm_productsMovies frm = new frm_productsMovies();
            frm.product_name.Text = product_name;
            frm.Text += " " + product_name;
            frm.txt_products.EditValue = product_code_;
            frm_othermain.getmain.openform(frm);
            frm.btn_show_Click(null, null);

        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

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

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "[product_name] +[product_code]+[parcode] like '%" + searchControl1.Text + "%'";

        }
    }
}