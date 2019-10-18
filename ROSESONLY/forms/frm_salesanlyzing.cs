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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;

namespace ROSESONLY.forms
{
    public partial class frm_salesanlyzing : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_salesanlyzing()
        {
            InitializeComponent();
        }
        void binding_data()
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(dateEdit1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(dateEdit2.Text));
            p[2] = new SqlParameter("@store_name", cmb_stores.Text);
            p[3] = new SqlParameter("@account_name", cmb_vendors.Text);
            DataTable dt = new DataTable();

            switch (cmb_type.Text)
            {
                case "العميل ":
                    dt = cd.getdata("sp_SalesByAccount", p);
                    gridControl1.DataSource = dt;
                    break;
                case "المخزن":
                    dt = cd.getdata("sp_Salesstore", p);
                    gridControl1.DataSource = dt;
                    break;
                case "الصنف":
                    dt = cd.getdata("sp_Salesproduct", p);
                    gridControl1.DataSource = dt;
                    break;
                case "الايام":
                    dt = cd.getdata("sp_Salesdays", p);
                    gridControl1.DataSource = dt;
                    break;
                case "الشهور":
                    dt = cd.getdata("sp_Salesmonths", p);
                    gridControl1.DataSource = dt;
                    break;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(dateEdit1.Text)||string.IsNullOrEmpty(dateEdit2.Text))
            {
                MSg.showmsg("حدد الفترة اولا", MSg.msgbutton.ok, MSg.msgicon.delete);
                return;
            }
            binding_data();
        }

        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "current_")
            {
                decimal total_profit =Math.Round(Convert.ToDecimal(gridView2.Columns["total_profit"].SummaryItem.SummaryValue.ToString()),0);
                decimal profit =Math.Round(Convert.ToDecimal(gridView2.GetRowCellValue(e.RowHandle, "total_profit").ToString()),0);
                gridView2.SetRowCellValue(e.RowHandle, "current_",Math.Round((profit/total_profit)*100,2));
                RepositoryItemProgressBar rp = new RepositoryItemProgressBar();
                rp.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
                rp.ShowTitle = true;
                rp.PercentView = false;
                rp.Minimum = 0;
                rp.PercentView = true;
                rp.StartColor = Color.DarkOrange;
                rp.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                rp.LookAndFeel.UseDefaultLookAndFeel = false;
                rp.EndColor = Color.DarkOrange;
                rp.Maximum = 100;
                e.RepositoryItem = rp;
            }

        }

        private void frm_salesanlyzing_Load(object sender, EventArgs e)
        {
            dateEdit1.Text = new DateTime(DateTime.Today.Year, 1, 1).ToShortDateString();
            dateEdit2.Text = new DateTime(DateTime.Today.Year, 12, 1).ToShortDateString();

            DataTable dt = new DataTable();
                dt = cd.getdata("sp_bindingaccounts", null);
                cmb_vendors.Properties.DataSource = dt;
                cmb_vendors.Properties.DisplayMember = "account_name";
                cmb_vendors.Properties.ValueMember = "account_code";
            //.......................
            DataTable dt_ = new DataTable();
            dt_ = cd.getdata("sp_selectstores", null);
            cmb_stores.Properties.DataSource = dt_;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";

        }

        private void cmb_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_period.Text)
            {
                case "اليوم":
                    dateEdit1.Text = Convert.ToDateTime(DateTime.Today).ToShortDateString();
                    dateEdit2.Text = Convert.ToDateTime(DateTime.Today).ToShortDateString();
                    break;
                case "اليوم السابق":
                    dateEdit1.Text = Convert.ToDateTime(DateTime.Today.AddDays(-1)).ToShortDateString();
                    dateEdit2.Text = Convert.ToDateTime(DateTime.Today.AddDays(-1)).ToShortDateString();
                    break;
                case "اليوم التالى":
                    dateEdit1.Text = Convert.ToDateTime(DateTime.Today.AddDays(1)).ToShortDateString();
                    dateEdit2.Text = Convert.ToDateTime(DateTime.Today.AddDays(1)).ToShortDateString();
                    break;
                case "الشهر الحالى":
                    DateTime dd = DateTime.Today;
                    dateEdit1.Text = new DateTime(dd.Year, dd.Month, 1).ToShortDateString();
                    var firstdate = Convert.ToDateTime(dateEdit1.Text);
                    dateEdit2.Text = firstdate.AddMonths(1).AddDays(-1).ToShortDateString();
                    break;
                case "الاسبوع السابق":
                    dateEdit1.Text = Convert.ToDateTime(DateTime.Today.AddDays(-6)).ToShortDateString();
                    dateEdit2.Text = Convert.ToDateTime(DateTime.Today).ToShortDateString();
                    break;
                case "العام الحالى":
                    dateEdit1.Text = new DateTime(DateTime.Today.Year, 1, 1).ToShortDateString();
                    dateEdit2.Text = new DateTime(DateTime.Today.Year, 12, 1).ToShortDateString();
                    break;

            }
            DateTime first = Convert.ToDateTime(dateEdit1.Text);
            DateTime last = Convert.ToDateTime(dateEdit2.Text);

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            cmb_vendors.EditValue = -1;

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            cmb_stores.EditValue = -1;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }

        private void gridView2_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.RightMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.Landscape = true;

        }
    }
}