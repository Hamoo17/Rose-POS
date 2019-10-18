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
    public partial class frm_storesmovments : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        connectiondata cd = new connectiondata();
        public frm_storesmovments()
        {
            InitializeComponent();
            bindingstores();
            generatedatatable();
        }
        void generatedatatable()
        {
            //dt.Columns.Add("id");
            //dt.Columns.Add("product_code");
            //dt.Columns.Add("product_name");
            //dt.Columns.Add("unit");
            //dt.Columns.Add("lastbalance",typeof(decimal));
            //dt.Columns.Add("purchase", typeof(decimal));
            //dt.Columns.Add("purchase_return", typeof(decimal));
            //dt.Columns.Add("sales", typeof(decimal));
            //dt.Columns.Add("sales_return", typeof(decimal));
            //dt.Columns.Add("convert_", typeof(decimal));
            //dt.Columns.Add("adjust", typeof(decimal));
            //dt.Columns.Add("balance", typeof(decimal));

            //for (int i = 0; i < 30; i++)
            //{
            //    DataRow newrow;
            //    newrow = dt.NewRow();
            //    newrow["id"] = i;
            //    dt.Rows.Add(newrow);
            //}
            //gridControl1.DataSource = dt;

        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@user_id", connectiondata.user_id);
            dt = cd.getdata("sp_bindingstores", p);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_storesmovments_Load(object sender, EventArgs e)
        {
            DateTime date_ = DateTime.Today;
            txt_date1.Text = new DateTime(date_.Year, date_.Month, 1).ToShortDateString();
            var firstdate = Convert.ToDateTime(txt_date1.Text);
            txt_date2.Text = firstdate.AddMonths(1).AddDays(-1).ToShortDateString();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@store_name", cmb_stores.Text);
            p[1] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[2] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            dt = cd.getdata("sp_storesMovments", p);
            //if(dt.Rows.Count<30)
            //{
            //    for (int i = dt.Rows.Count; i < (dt.Rows.Count) + (30 - dt.Rows.Count); i++)
            //    {
            //        DataRow addrows;
            //        addrows = dt.NewRow();
            //        dt.Rows.Add(addrows);
            //    }
            //}
            gridControl1.DataSource = dt;

        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "product_name like '%" + this.searchControl1.Text + "%'";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }

        private void txt_date2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cmb_stores.EditValue = -1;
        }
    }
}