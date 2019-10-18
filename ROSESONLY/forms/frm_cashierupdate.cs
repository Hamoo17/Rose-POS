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
    public partial class frm_cashierupdate : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public string move_no;
        public string move_type;
        public int rowindex;
        public frm_cashierupdate()
        {
            InitializeComponent();
        }
        void bindingsearch()
        {
            txt_band.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_band.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingBand", null);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt_band.MaskBox.AutoCompleteCustomSource.Add(dt.Rows[i][0].ToString());
            }
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

        private void labelControl7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_cashieradd_Load(object sender, EventArgs e)
        {
            bindingcashier();
            bindingaccounts();
            cmb_cashier.ItemIndex = 0;
            bindingsearch();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //validating............
            if(string.IsNullOrEmpty(txt_value.Text))
            {
                errorProvider1.SetError(txt_value, "يرجى أدخال قيمة الايصال");
                return;
            }
           //save data
                    SqlParameter[] p = new SqlParameter[10];
                    p[0]=new SqlParameter("@move_date",Convert.ToDateTime(txt_date.Text));
                    p[1]=new SqlParameter("@move_type",move_type);
                    p[2]=new SqlParameter("@account_code",string.IsNullOrEmpty(cmb_accounts.EditValue.ToString())?int.Parse("0"):cmb_accounts.EditValue);
                    p[3]=new SqlParameter("@cashier_code",cmb_cashier.EditValue);
                   if(move_type=="صادر")
                   {
                    p[4] = new SqlParameter("@debit_value",Convert.ToDecimal("0") );
                    p[6] = new SqlParameter("@creadit_value", Convert.ToDecimal(txt_value.Text));
                    p[9] = new SqlParameter("@invoice_type", string.IsNullOrEmpty(cmb_accounts.Text) ? "مصروفات أخري" : "سداد مورد");

                   }
                   else
                   {
                    p[4] = new SqlParameter("@debit_value", Convert.ToDecimal(txt_value.Text));
                    p[6] = new SqlParameter("@creadit_value", Convert.ToDecimal("0"));
                    p[9] = new SqlParameter("@invoice_type", string.IsNullOrEmpty(cmb_accounts.Text) ? "إيردات أخري" : "مقبوضات عميل");

                   }
                    p[5]=new SqlParameter("@notes",txt_notes.Text);
                    p[7]=new SqlParameter("@band",txt_band.Text);
                    p[8]=new SqlParameter("@move_no",move_no);
                    cd.runproc("sp_cashierupdate2", p);
            frm_cashierMovies.getmain.bindingcashierdata();
            frm_cashierMovies.getmain.bindingbalance();
            frm_cashierMovies.getmain.gridView1.FocusedRowHandle = rowindex;
            this.Close();

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            cmb_accounts.EditValue = -1;
        }
    }
}