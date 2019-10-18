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
    public partial class frm_cashierconvert : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int transfer_code = 0;
        public frm_cashierconvert()
        {
            InitializeComponent();
        }
        void bindingcashier()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectxcashier", null);
            cmb_cashier1.Properties.DataSource = dt;
            cmb_cashier1.Properties.DisplayMember = "cashier_name";
            cmb_cashier1.Properties.ValueMember = "cashier_id";
            cmb_cashier2.Properties.DataSource = dt;
            cmb_cashier2.Properties.DisplayMember = "cashier_name";
            cmb_cashier2.Properties.ValueMember = "cashier_id";
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_cashierconvert_Load(object sender, EventArgs e)
        {
            bindingcashier();
            if(btn_saveexit.Tag=="0")
            {
            cmb_cashier1.ItemIndex = 0;
            cmb_cashier2.ItemIndex = 1;
            txt_date.Text = Convert.ToDateTime(DateTime.Today.ToShortDateString()).ToString("d");
            }

        }

        private void btn_saveexit_Click(object sender, EventArgs e)
        {
            //validating
            if(string.IsNullOrEmpty(txt_date.Text))
            {
                errorProvider1.SetError(txt_date, "أدخل تاريخ التحويل");
                return;
            }
            if (string.IsNullOrEmpty(txt_value.Text)||txt_value.Text=="0")
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(txt_value, "أدخل قيمه التحويل");
                return;
            }
            if (string.IsNullOrEmpty(cmb_cashier1.Text))
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(cmb_cashier1, "أدخل الخزينه المحول منها");
                return;
            }
            if (string.IsNullOrEmpty(cmb_cashier2.Text))
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(cmb_cashier2, "ادخل الخزينة المحول اليها");
                return;
            }
            if(cmb_cashier1.Text==cmb_cashier2.Text)
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(cmb_cashier2, "يرجي تغير الخزينه المحول اليها");
                return;
            }
            //check balance of ccashier
            DataTable dt = new DataTable();
            SqlParameter[] pa = new SqlParameter[3];
            pa[0] = new SqlParameter("@cashier_code", cmb_cashier1.EditValue);
            pa[1] = new SqlParameter("@first", Convert.ToDateTime(txt_date.Text));
            pa[2] = new SqlParameter("@last", Convert.ToDateTime(txt_date.Text));
            dt = cd.getdata("sp_cashierbalance", pa);
            decimal balance = Convert.ToDecimal(dt.Rows[0][1].ToString());
            
            if(Convert.ToDecimal(txt_value.Text)>balance)
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(cmb_cashier1, "رصيد الخزينه أقل من المبلغ المطلوب" + " " + balance.ToString());
                return;
            }
            if(btn_saveexit.Tag=="0")
            {
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                p[1] = new SqlParameter("@value", Convert.ToDecimal(txt_value.Text));
                p[2] = new SqlParameter("@cashier1", cmb_cashier1.EditValue);
                p[3] = new SqlParameter("@cashier2", cmb_cashier2.EditValue);
                p[4] = new SqlParameter("@user_code", connectiondata.user_id);
                p[5] = new SqlParameter("@cashier_name1", cmb_cashier1.Text);
                p[6] = new SqlParameter("@cashier_name2", cmb_cashier2.Text);
                cd.runproc("sp_cashiertransfer", p);
                this.Close();
                frm_cashierMovies.getmain.bindingcashierdata();
                frm_cashierMovies.getmain.bindingbalance();
            }
            else
            {
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                p[1] = new SqlParameter("@value", Convert.ToDecimal(txt_value.Text));
                p[2] = new SqlParameter("@cashier1", cmb_cashier1.EditValue);
                p[3] = new SqlParameter("@cashier2", cmb_cashier2.EditValue);
                p[4] = new SqlParameter("@transfer_code", transfer_code);
                cd.runproc("sp_trsferUpdate", p);
                this.Close();
                frm_cashierMovies.getmain.bindingcashierdata();
                frm_cashierMovies.getmain.bindingbalance();
            }
        }
    }
}