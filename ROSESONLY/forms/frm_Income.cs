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
namespace ROSESONLY.forms
{
    public partial class frm_Income : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        
        public frm_Income()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@first", Convert.ToDateTime(textEdit1.Text));
            p[1] = new SqlParameter("@last", Convert.ToDateTime(dateEdit1.Text));

            DataTable dt = new DataTable();
            dt = cd.getdata("sp_netsales", p);
            txt_sales.Text = dt.Rows[0]["total_value"].ToString();
            txt_cost.Text = dt.Rows[0]["total_cost"].ToString();
            txt_profit.Text= dt.Rows[0]["profit"].ToString();

            SqlParameter[] pa = new SqlParameter[2];
            pa[0] = new SqlParameter("@first", Convert.ToDateTime(textEdit1.Text));
            pa[1] = new SqlParameter("@last", Convert.ToDateTime(dateEdit1.Text));
            DataTable dt1 = new DataTable();
            dt1 = cd.getdata("sp_totalexpenses", pa);
            txt_expenses.Text = dt1.Rows[0][0].ToString();
            txt_netprofit.Text =
               (Convert.ToDecimal(txt_profit.Text) - Convert.ToDecimal(txt_expenses.Text)).ToString();

        }

        private void frm_Income_Load(object sender, EventArgs e)
        {
            DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            textEdit1.Text = first.ToString("d");
            dateEdit1.Text = first.AddMonths(1).AddDays(-1).ToString("d");
        }
    }
}