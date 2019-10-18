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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;


namespace ROSESONLY.forms
{
    public partial class frm_productsMovies : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();

        public frm_productsMovies()
        {
            InitializeComponent();
            bindingproducts();
            bindingstores();
            gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridView1_CustomUnboundColumnData);
            //DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.AddField("colRunningBalance");
            //col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //col.Visible = true;
            //col.Caption = "رصيد الصنف";
            //col.VisibleIndex = 15;
        }

        void bindingproducts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_productsSelect", null);
            txt_products.Properties.DataSource = dt;
            txt_products.Properties.DisplayMember = "product_name";
            txt_products.Properties.ValueMember = "product_code";
        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectstores", null);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";
            repositoryItemLookUpEdit1.DataSource = dt;
            repositoryItemLookUpEdit1.DisplayMember = "store_name";
            repositoryItemLookUpEdit1.ValueMember = "store_id";

            repositoryItemLookUpEdit2.DataSource = dt;
            repositoryItemLookUpEdit2.DisplayMember = "store_name";
            repositoryItemLookUpEdit2.ValueMember = "store_id";

        }
        public void bindingmovements(int product_code,string stroe,DateTime first,DateTime last,string move_type)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0]=new SqlParameter("@product_code",product_code);
            p[1] = new SqlParameter("@store_name", stroe);
            p[2] = new SqlParameter("@first", first);
            p[3] = new SqlParameter("@last", last);
            p[4] = new SqlParameter("@move_type", move_type);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_productsMovments", p);
            gridControl1.DataSource = dt;
        }
        private void frm_productsMovies_Load(object sender, EventArgs e)
        {
            DateTime date_=DateTime.Today;
            txt_date1.Text = new DateTime(date_.Year, date_.Month, 1).ToShortDateString();
            var firstdate = Convert.ToDateTime(txt_date1.Text);
            txt_date2.Text = firstdate.AddMonths(1).AddDays(-1).ToShortDateString();
          //  cmb_stores.ItemIndex = 0;
        }

        public void btn_show_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txt_products.Text))
            {
                MSg.showmsg("يرجى أختيار الصنف اولا", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            string move = "";
            if(cmb_move_type.Text=="جميع الحركات")
            {
                move = "";
            }
            else
            {
                move = cmb_move_type.Text;
            }
            bindingmovements(int.Parse(txt_products.EditValue.ToString()), cmb_stores.Text, Convert.ToDateTime(txt_date1.Text),
                Convert.ToDateTime(txt_date2.Text), move);
            product_name.Text = txt_products.Text;
            gridView1.ViewCaption = product_name.Text;
        }

        private void _2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void product_name_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cmb_stores.EditValue = -1;
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
                    total += Convert.ToDecimal(view.GetRowCellValue(i + 1, "qty_in"))-Convert.ToDecimal(view.GetRowCellValue(i+1,"qty_out"));
                }
                e.Value = total;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.ViewCaption = product_name.Text + "/     " +txt_date1.Text+" >>  "+ txt_date2.Text+ "................."+cmb_stores.Text;
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"'" + product_name.Text + "   " + cmb_stores.Text + "'.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);
        }
    }
}