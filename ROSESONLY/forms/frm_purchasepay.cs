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
using ROSESONLY.DLL;
namespace ROSESONLY.forms
{
    public partial class frm_purchasepay : DevExpress.XtraEditors.XtraForm
    {
        public decimal total;
        public frm_purchasepay()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_purchasepay_Load(object sender, EventArgs e)
        {
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_paid.Text)) { return; }
            if(frm_purchase.get_main.radioGroup1.EditValue.ToString()=="نقدى")
            {
                if (Convert.ToDecimal(txt_remain.Text)!=0)
                {
                    MSg.showmsg("يرجى سداد المبلغ بالكامل", MSg.msgbutton.ok, MSg.msgicon.information);
                    return;
                }
            }

         //   frm_purchase.get_main.txt_paidvalue.Text = txt_paid.Text;
            this.Close();
        }

        private void txt_paid_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_paid.Text)) { return; }
            txt_remain.Text = ((total) -(string.IsNullOrEmpty(txt_paid.Text)? Convert.ToDecimal("0"):Convert.ToDecimal(txt_paid.Text))).ToString();
        }

        private void txt_paid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_paid.Text)) { return; }
                if (frm_purchase.get_main.radioGroup1.EditValue.ToString() == "نقدى")
                {
                    if (Convert.ToDecimal(txt_remain.Text) != 0)
                    {
                        MSg.showmsg("يرجى سداد المبلغ بالكامل", MSg.msgbutton.ok, MSg.msgicon.information);
                        return;
                    }
                }

            //    frm_purchase.get_main.txt_paidvalue.Text = txt_paid.Text;
                this.Close();

            }
        }
    }
}