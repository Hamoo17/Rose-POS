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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
namespace ROSESONLY.forms
{
    public partial class frm_Account_recepit : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_Account_recepit()
        {
            InitializeComponent();
            bindingaccounts();
            DateTime date_ = DateTime.Today;
            txt_date1.Text = new DateTime(date_.Year, date_.Month, 1).ToShortDateString();
            var firstdate = Convert.ToDateTime(txt_date1.Text);
            txt_date2.Text = firstdate.AddMonths(1).AddDays(-1).ToShortDateString();
            gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridView1_CustomUnboundColumnData);

        }
        public void bindingaccounts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingaccounts", null);
            cmb_vendors.Properties.DataSource = dt;
            cmb_vendors.Properties.DisplayMember = "account_name";
            cmb_vendors.Properties.ValueMember = "account_code";
        }
        private void frm_Account_recepit_Load(object sender, EventArgs e)
        {
            simpleButton11_Click(null, null);

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_vendors.Text)) { return; }
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@code", cmb_vendors.EditValue);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_accountsrecepit", p);
            gridControl1.DataSource = dt;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column.FieldName == "balance" & e.IsGetData)
            {
                decimal total = 0m;
                int rHandle = view.GetRowHandle(e.ListSourceRowIndex);
                for (int i = -1; i <= rHandle - 1; i++)
                {
                    total += Convert.ToDecimal(view.GetRowCellValue(i + 1, "debit")) - Convert.ToDecimal(view.GetRowCellValue(i + 1, "credit"));
                }
                e.Value = total;
                
            }

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"'" + cmb_vendors.Text + "'.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "balance")
            {
                if (decimal.Parse(e.CellValue.ToString()) < 0)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }

        }
    }
}