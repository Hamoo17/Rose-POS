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
using DevExpress.XtraCharts;

namespace ROSESONLY.forms
{
    public partial class frm_expensesAnalyze : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_expensesAnalyze()
        {
            InitializeComponent();
            bindingcashier();
        }
        void bindingcashier()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@user_id", connectiondata.user_id);

            dt = cd.getdata("sp_bindingcashier", p);
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
            dt = cd.getdata("sp_expensesAnalyzing", p);
            gridControl1.DataSource = dt;
        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            bindingdata();
            binding_expesnsesband();
            binding_bandchart();
            binding_supllierspays();
        }
        void binding_supllierspays()
        {
            chartControl2.Series.Clear();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@cashier_name", cmb_cashier.Text);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_Supllierspays", p);
            //chartControl3.DataSource = dt;
            DevExpress.XtraCharts.Series sales = new DevExpress.XtraCharts.Series("Suppliers analyzing", DevExpress.XtraCharts.ViewType.Doughnut);
            sales.DataSource = dt;
            sales.ArgumentDataMember = "المورد";
            sales.ValueDataMembersSerializable = "القيمة";
            sales.ValueDataMembers.AddRange(new string[] { "القيمة" });
            sales.ShowInLegend = true;
            chartControl2.Series.Add(sales);
            sales.Label.TextPattern = "{VP:p0} ({V:.##}LE)";
            sales.LegendTextPattern = "{A}";
            // Adjust the position of series labels.  
            ((PieSeriesLabel)sales.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels. 
            ((PieSeriesLabel)sales.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series. 
            PieSeriesView myView = (PieSeriesView)sales.View;

            // Specify a data filter to explode points. 
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 5;
            myView.RuntimeExploding = true;

            // Customize the legend. 
            chartControl2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

        }
        void binding_bandchart()
        {
            chartControl1.Series.Clear();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@cashier_name", cmb_cashier.Text);

            DataTable dt = new DataTable();
            dt = cd.getdata("sp_expensesBandchart", p);
            //chartControl3.DataSource = dt;
            DevExpress.XtraCharts.Series sales = new DevExpress.XtraCharts.Series("band analyzing", DevExpress.XtraCharts.ViewType.Doughnut);
            sales.DataSource = dt;
            sales.ArgumentDataMember = "البند";
            sales.ValueDataMembersSerializable = "القيمة";
            sales.ValueDataMembers.AddRange(new string[] { "القيمة" });
            sales.ShowInLegend = true;
            chartControl1.Series.Add(sales);
            sales.Label.TextPattern = "{VP:p0} ({V:.##}LE)";
            sales.LegendTextPattern = "{A}";
            // Adjust the position of series labels.  
            ((PieSeriesLabel)sales.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels. 
            ((PieSeriesLabel)sales.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series. 
            PieSeriesView myView = (PieSeriesView)sales.View;

            // Specify a data filter to explode points. 
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 5;
            myView.RuntimeExploding = true;

            // Customize the legend. 
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }

        void binding_expesnsesband()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@cashier_name", cmb_cashier.Text);
            dt = cd.getdata("sp_expensesBand", p);
            gridControl2.DataSource = dt;
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