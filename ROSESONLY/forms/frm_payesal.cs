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
    public partial class frm_payesal : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public string form_name;
        decimal total_value;
        public frm_payesal()
        {
            InitializeComponent();
            total_value = Convert.ToDecimal(lb_total.Text);
        }

        private void frm_payesal_Load(object sender, EventArgs e)
        {
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_paid.Text)){return;}
            switch (form_name)
            {
                case "purchase":
                    SqlParameter[]p=new SqlParameter[7];
                    p[0]=new SqlParameter("@move_date",Convert.ToDateTime(frm_purchase.get_main.txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(frm_purchase.get_main.cmb_vendors.Text) ? int.Parse("0") : frm_purchase.get_main.cmb_vendors.EditValue);
                    p[2]=new SqlParameter("@cashier_code",frm_purchase.get_main.cmb_cashier.EditValue);
                    p[3]=new SqlParameter("@value_",Convert.ToDecimal(txt_paid.Text));
                    p[4]=new SqlParameter("@user_id",connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", frm_purchase.get_main.txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "شراء");
                    cd.runproc("sp_cashermoveInser", p);
                    break;
                case "sales":
                    SqlParameter[]pa=new SqlParameter[7];
                    pa[0]=new SqlParameter("@move_date",Convert.ToDateTime(frm_SalesInvoice.get_main.txt_date.Text));
                    pa[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(frm_SalesInvoice.get_main.cmb_vendors.Text) ? int.Parse("0") : frm_SalesInvoice.get_main.cmb_vendors.EditValue);
                    pa[2] = new SqlParameter("@cashier_code", frm_SalesInvoice.get_main.cmb_cashier.EditValue);
                    pa[3]=new SqlParameter("@value_",Convert.ToDecimal(txt_paid.Text));
                    pa[4]=new SqlParameter("@user_id",connectiondata.user_id);
                    pa[5] = new SqlParameter("@invoice_no", frm_SalesInvoice.get_main.txt_invice_no.Text);
                    pa[6] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_salesmoveInser", pa);
                    break;
                case "sales_return":
                    SqlParameter[]par=new SqlParameter[7];
                    par[0]=new SqlParameter("@move_date",Convert.ToDateTime(frm_salesreturn.get_main.txt_date.Text));
                    par[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(frm_salesreturn.get_main.cmb_vendors.Text) ? int.Parse("0") : frm_salesreturn.get_main.cmb_vendors.EditValue);
                    par[2] = new SqlParameter("@cashier_code", frm_salesreturn.get_main.cmb_cashier.EditValue);
                    par[3]=new SqlParameter("@value_",Convert.ToDecimal(txt_paid.Text));
                    par[4]=new SqlParameter("@user_id",connectiondata.user_id);
                    par[5] = new SqlParameter("@invoice_no", frm_salesreturn.get_main.txt_invice_no.Text);
                    par[6] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_cashermoveInser", par);
                    break;
                case "purchase_return":
                    SqlParameter[] parm = new SqlParameter[7];
                    parm[0] = new SqlParameter("@move_date", Convert.ToDateTime(frm_purchaseReturn.get_main.txt_date.Text));
                    parm[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(frm_purchaseReturn.get_main.cmb_vendors.Text) ? int.Parse("0") : frm_purchaseReturn.get_main.cmb_vendors.EditValue);
                    parm[2] = new SqlParameter("@cashier_code", frm_purchaseReturn.get_main.cmb_cashier.EditValue);
                    parm[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_paid.Text));
                    parm[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    parm[5] = new SqlParameter("@invoice_no", frm_purchaseReturn.get_main.txt_invice_no.Text);
                    parm[6] = new SqlParameter("@invoice_type", "مرتجع شراء");
                    cd.runproc("sp_salesmoveInser", parm);
                    break;
            }
            this.Close();

        }

        private void txt_paid_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_paid.Text)) { return; }
            lb_total.Text = (total_value - Convert.ToDecimal(txt_paid.Text)).ToString();
        }

        private void txt_paid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save_Click(null, null);
            }

        }
    }
}