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
using DevExpress.XtraGrid.Columns;
namespace ROSESONLY.forms
{
    public partial class frm_InvoicesReports : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        string move_type = "بيع";
        public frm_InvoicesReports()
        {
            InitializeComponent();
            bindingaccounts();
            bindingcashier();
            bindingstores();
            bindingusers();
            move_type = "بيع";
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
            cmb_storto.Properties.DataSource = dt;
            cmb_storto.Properties.DisplayMember = "store_name";
            cmb_storto.Properties.ValueMember = "store_id";
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
        public void bindingaccounts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingaccounts", null);
            cmb_accounts.Properties.DataSource = dt;
            cmb_accounts.Properties.DisplayMember = "account_name";
            cmb_accounts.Properties.ValueMember = "account_code";
        }
        public void bindingusers()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectuserss", null);
            cmb_users.Properties.DataSource = dt;
            cmb_users.Properties.DisplayMember = "full_name";
            cmb_users.Properties.ValueMember = "user_id";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            switch (move_type)
            {
                case "بيع":
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p[2] = new SqlParameter("@invoice_type","بيع");
            p[3] = new SqlParameter("@store", cmb_stores.Text);
            p[4] = new SqlParameter("@account",cmb_accounts.Text);
            p[5] = new SqlParameter("@user", cmb_users.Text);
            p[6] = new SqlParameter("@cashier", cmb_cashier.Text);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_salesinvoices", p);
            us_sales1.gridControl1.DataSource = dt;
             break; 
      
            case "مرتجع بيع":
            SqlParameter[] p1 = new SqlParameter[7];
            p1[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p1[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p1[2] = new SqlParameter("@invoice_type","مرتجع بيع");
            p1[3] = new SqlParameter("@store", cmb_stores.Text);
            p1[4] = new SqlParameter("@account",cmb_accounts.Text);
            p1[5] = new SqlParameter("@user", cmb_users.Text);
            p1[6] = new SqlParameter("@cashier", cmb_cashier.Text);
            DataTable dt1 = new DataTable();
            dt1 = cd.getdata("sp_salesinvoices", p1);
            us_sales1.gridControl1.DataSource = dt1;
            break;
            case "شراء":
            SqlParameter[] p2 = new SqlParameter[7];
            p2[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p2[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p2[2] = new SqlParameter("@invoice_type", "شراء");
            p2[3] = new SqlParameter("@store", cmb_stores.Text);
            p2[4] = new SqlParameter("@account", cmb_accounts.Text);
            p2[5] = new SqlParameter("@user", cmb_users.Text);
            p2[6] = new SqlParameter("@cashier", cmb_cashier.Text);
            DataTable dt2 = new DataTable();
            dt2 = cd.getdata("sp_salesinvoices", p2);
            us_parchase1.gridControl1.DataSource = dt2;
            break;
            case "مرتجع شراء":
            SqlParameter[] p3 = new SqlParameter[7];
            p3[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p3[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p3[2] = new SqlParameter("@invoice_type", "مرتجع شراء");
            p3[3] = new SqlParameter("@store", cmb_stores.Text);
            p3[4] = new SqlParameter("@account", cmb_accounts.Text);
            p3[5] = new SqlParameter("@user", cmb_users.Text);
            p3[6] = new SqlParameter("@cashier", cmb_cashier.Text);
            DataTable dt3 = new DataTable();
            dt3 = cd.getdata("sp_salesinvoices", p3);
            us_parchase1.gridControl1.DataSource = dt3;
            break;
            case "تحويل":
            SqlParameter[] p4 = new SqlParameter[6];
            p4[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p4[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p4[2] = new SqlParameter("@invoice_type", "تحويل");
            p4[3] = new SqlParameter("@store_in",cmb_stores.Text);
            p4[4] = new SqlParameter("@store_to",cmb_storto.Text);
            p4[5] = new SqlParameter("@user", cmb_users.Text);
            DataTable dt4 = new DataTable();
            dt4 = cd.getdata("sp_transferdata", p4);
            us_transfer1.gridControl1.DataSource = dt4;
            break;
            case "طلب":
            SqlParameter[] p5 = new SqlParameter[6];
            p5[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p5[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p5[2] = new SqlParameter("@invoice_type", "طلب");
            p5[3] = new SqlParameter("@store_in", cmb_stores.Text);
            p5[4] = new SqlParameter("@store_to", cmb_storto.Text);
            p5[5] = new SqlParameter("@user", cmb_users.Text);
            DataTable dt5 = new DataTable();
            dt5 = cd.getdata("sp_transferdata", p5);
            us_transfer1.gridControl1.DataSource = dt5;
            break;
            case "تسوية":
            SqlParameter[] p6 = new SqlParameter[4];
            p6[0] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p6[1] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            p6[2] = new SqlParameter("@store_name", cmb_stores.Text);
            p6[3] = new SqlParameter("@user_name", cmb_users.Text);
            DataTable dt6 = new DataTable();
            dt6 = cd.getdata("sp_adjustdata", p6);
            us_adjust1.gridControl1.DataSource = dt6;
            break;
            }
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            cmb_cashier.EditValue = -1;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            cmb_stores.EditValue = -1;

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            cmb_accounts.EditValue = -1;

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            cmb_users.EditValue = -1;

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

        }

        private void frm_InvoicesReports_Load(object sender, EventArgs e)
        {
            DateTime dd = DateTime.Today;
            txt_date1.Text=new DateTime(dd.Year,dd.Month,1).ToShortDateString();
            var firstdate = Convert.ToDateTime(txt_date1.Text);
            txt_date2.Text = firstdate.AddMonths(1).AddDays(-1).ToShortDateString();
            changcolor(labelControl3);

        }

        private void cmb_accounts_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void btn_select_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //int invoice_no = int.Parse(gridView1.GetFocusedRowCellValue("رقم الفاتورة").ToString());
            //string move_type = gridView1.GetFocusedRowCellValue("نوع الفاتورة").ToString();
            //SqlParameter[] p = new SqlParameter[2];
            //p[0] = new SqlParameter("@invoice_no", invoice_no);
            //p[1] = new SqlParameter("@move_type", move_type);
            //DataTable dt = new DataTable();
            //dt = cd.getdata("sp_invoiceDetails", p);
            //gridControl2.DataSource = dt;

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
           // line.Left = labelControl3.Left;
            move_type = labelControl3.Text;
            changcolor(labelControl3);
            us_sales1.BringToFront();
            btn_show_Click(null, null);
            if (us_sales1.gridView1.RowCount == 0) { return; }
            us_sales1.type = "sales";
            us_sales1.bindingselectedrow(int.Parse(us_sales1.gridView1.GetFocusedRowCellValue("move_no").ToString()));
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
          //  line.Left = labelControl8.Left;
            move_type = labelControl8.Text;
            changcolor(labelControl8);
            btn_show_Click(null, null);
            us_sales1.BringToFront();
            if (us_sales1.gridView1.RowCount == 0) { return; }
            us_sales1.type = "salesreturn";

            us_sales1.bindingselectedrow(int.Parse(us_sales1.gridView1.GetFocusedRowCellValue("move_no").ToString()));
        }
        void  changcolor(DevExpress.XtraEditors.LabelControl lb)
        {
            labelControl3.BackColor = System.Drawing.Color.White;
            labelControl8.BackColor = System.Drawing.Color.White;
            labelControl10.BackColor = System.Drawing.Color.White;
            labelControl11.BackColor = System.Drawing.Color.White;
            labelControl12.BackColor = System.Drawing.Color.White;
            labelControl13.BackColor = System.Drawing.Color.White;
            labelControl14.BackColor = System.Drawing.Color.White;
            lb.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
            labelControl3.ForeColor = System.Drawing.Color.Black;
            labelControl8.ForeColor = System.Drawing.Color.Black;
            labelControl10.ForeColor = System.Drawing.Color.Black;
            labelControl11.ForeColor = System.Drawing.Color.Black;
            labelControl12.ForeColor = System.Drawing.Color.Black;
            labelControl13.ForeColor = System.Drawing.Color.Black;
            labelControl14.ForeColor = System.Drawing.Color.Black;
            lb.ForeColor = System.Drawing.Color.White;

        }
        private void labelControl10_Click(object sender, EventArgs e)
        {
            //line.Left = labelControl10.Left;
            move_type = labelControl10.Text;
            changcolor(labelControl10);

            us_parchase1.BringToFront();
            btn_show_Click(null, null);
            if (us_parchase1.gridView1.RowCount == 0) { return; }
            us_parchase1.bindingselectedrow(int.Parse(us_parchase1.gridView1.GetFocusedRowCellValue("move_no").ToString()));
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {
            //line.Left = labelControl11.Left;
            move_type = labelControl11.Text;
            changcolor(labelControl11);

            us_parchase1.BringToFront();
            btn_show_Click(null, null);
            if (us_parchase1.gridView1.RowCount == 0) { return; }
            us_parchase1.bindingselectedrow(int.Parse(us_parchase1.gridView1.GetFocusedRowCellValue("move_no").ToString()));
        }

        private void labelControl12_Click(object sender, EventArgs e)
        {
            //line.Left = labelControl12.Left;
            move_type = labelControl12.Text;
            changcolor(labelControl12);
            us_transfer1.BringToFront();
            btn_show_Click(null, null);
            if (us_transfer1.gridView1.RowCount == 0) { return; }
            us_transfer1.bindingselectedrow(int.Parse(us_transfer1.gridView1.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {
            //line.Left = labelControl13.Left;
            move_type = labelControl13.Text;
            changcolor(labelControl13);
            us_adjust1.BringToFront();
            btn_show_Click(null, null);
            if (us_adjust1.gridView1.RowCount == 0) { return; }
            us_adjust1.bindingselectedrow(int.Parse(us_adjust1.gridView1.GetFocusedRowCellValue("move_no").ToString()));
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {
            //line.Left = labelControl14.Left;
            move_type = labelControl14.Text;
            changcolor(labelControl14);
            us_transfer1.BringToFront();
            btn_show_Click(null, null);
            if (us_transfer1.gridView1.RowCount == 0) { return; }
            us_transfer1.bindingselectedrow(int.Parse(us_transfer1.gridView1.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            cmb_storto.EditValue = -1;
        }

        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
        }
    }
}