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
    public partial class frm_cashierout : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int move_no;
        public frm_cashierout()
        {
            InitializeComponent();
            bindingaccounts();

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
        void clear_data()
        {
            txt_value.Text = "0";
            txt_date.Text = Convert.ToDateTime(DateTime.Today).ToShortDateString();
            cmb_accounts.EditValue = -1;
            txt_band.Text = string.Empty;
            txt_notes.Text = string.Empty;
            btn_ok.Tag = "0";
        }

        private void frm_cashieradd_Load(object sender, EventArgs e)
        {
            bindingcashier();
            cmb_cashier.ItemIndex = 0;
            bindingsearch();
            txt_date.Text = Convert.ToDateTime(DateTime.Today.ToShortDateString()).ToString("d");

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(btn_ok.Tag.ToString()=="0")
            {
                SqlParameter[] pa = new SqlParameter[10];
                pa[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                pa[1] = new SqlParameter("@move_type", "صادر");
                pa[2] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_accounts.Text) ? "0" : cmb_accounts.EditValue.ToString());
                pa[3] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                pa[4] = new SqlParameter("@creadit_value", Convert.ToDecimal(txt_value.Text));
                pa[5] = new SqlParameter("@notes", txt_notes.Text);
                pa[6] = new SqlParameter("@debit_value", Convert.ToDecimal("0"));
                pa[7] = new SqlParameter("@band", txt_band.Text);
                pa[8] = new SqlParameter("@user_id", connectiondata.user_id);
                pa[9] = new SqlParameter("@invoice_type", string.IsNullOrEmpty(cmb_accounts.Text) ? "مصروفات أخري" : "سداد مورد");
                cd.runproc("sp_cashieraddnew", pa);
            }
            else
            {
                SqlParameter[] p = new SqlParameter[10];
                p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                p[1] = new SqlParameter("@move_type", "صادر");
                p[2] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_accounts.EditValue.ToString()) ? int.Parse("0") : cmb_accounts.EditValue);
                p[3] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                p[4] = new SqlParameter("@debit_value", Convert.ToDecimal("0"));
                p[6] = new SqlParameter("@creadit_value", Convert.ToDecimal(txt_value.Text));
                p[9] = new SqlParameter("@invoice_type", string.IsNullOrEmpty(cmb_accounts.Text) ? "مصروفات أخري" : "سداد مورد");
                p[5] = new SqlParameter("@notes", txt_notes.Text);
                p[7] = new SqlParameter("@band", txt_band.Text);
                p[8] = new SqlParameter("@move_no", move_no);
                cd.runproc("sp_cashierupdate2", p);
            }
            clear_data();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            cmb_accounts.EditValue = -1;
        }

        private void lb_caption_Click(object sender, EventArgs e)
        {

        }
    }
}