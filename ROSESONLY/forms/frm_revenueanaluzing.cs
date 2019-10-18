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
using DevExpress.XtraPrinting;
namespace ROSESONLY.forms
{
    public partial class frm_revenueanaluzing : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_revenueanaluzing()
        {
            InitializeComponent();
            bindingcashier();
        }
        void bindingcashier()
        {
            DataTable dt = new DataTable();

            dt = cd.getdata("sp_selectxcashier", null);
            cmb_cashier.Properties.DataSource = dt;
            cmb_cashier.Properties.DisplayMember = "cashier_name";
            cmb_cashier.Properties.ValueMember = "cashier_id";
        }

        void bindingdata()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@cashier_name", cmb_cashier.Text);
            dt = cd.getdata("sp_revenueAnalyzing", p);
            gridControl1.DataSource = dt;
        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            bindingdata();
            
        }

        private void frm_revenueanaluzing_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            txt_date1.Text = new DateTime(dt.Year, dt.Month, 1).ToShortDateString();
            var first = Convert.ToDateTime(txt_date1.Text);
            txt_date2.Text = first.AddMonths(1).AddDays(-1).ToShortDateString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            cmb_cashier.EditValue = -1;
        }
    }
}