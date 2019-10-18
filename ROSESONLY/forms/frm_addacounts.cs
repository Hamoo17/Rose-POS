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
    public partial class frm_addacounts : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        bool validating;
      public  bool addnew=true;
      public string account_code;
        public frm_addacounts()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormCollection fm = Application.OpenForms;
            foreach (Form item in fm)
            {
                if (item.Text == "شراء")
                {
                    frm_purchase.get_main.bindingaccounts();
                    this.Close();
                    return;
                }
            }
            this.Close();
        }
        public void returndata(string account_code)
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@account_code", account_code);
            dt = cd.getdata("sp_ReturnAccounts", p);
            txt_name.Text = dt.Rows[0]["account_name"].ToString();
            txt_debit.Text = dt.Rows[0]["debit"].ToString();
            txt_creadit.Text = dt.Rows[0]["credit"].ToString();
            dt_firstbalance.Text = dt.Rows[0]["date_balance"].ToString();
            txt_phonenumber.Text = dt.Rows[0]["phone"].ToString();
            txt_email.Text = dt.Rows[0]["emial"].ToString();
            txt_adress.Text = dt.Rows[0]["adress"].ToString();
            radioGroup1.EditValue = dt.Rows[0]["account_type"];
        }
        private void frm_addacounts_Load(object sender, EventArgs e)
        {

        }
        void cleardata()
        {
            txt_name.Text = string.Empty;
            txt_creadit.Text = string.Empty;
            txt_debit.Text = string.Empty;
            dt_firstbalance.Text = string.Empty;
            txt_phonenumber.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_adress.Text = string.Empty;
            txt_name.Focus();
        }
        private void btn_saveexit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.SetError(txt_name, "يرجى أدخال أسم الحساب");
                return;
            }
            if(validating==false)
            {
                MSg.showmsg("يرجى التاكد من ادخال البيانات بشكل صحيح", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
          if(addnew==true)
          {
               
                SqlParameter[] p = new SqlParameter[10];
              p[0] = new SqlParameter("@account_name", txt_name.Text);
              p[1] = new SqlParameter("@account_type", radioGroup1.EditValue.ToString());
              p[2] = new SqlParameter("@debit", (string.IsNullOrEmpty(txt_debit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_debit.Text));
              p[3] = new SqlParameter("@credit", (string.IsNullOrEmpty(txt_creadit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_creadit.Text));
              p[4] = new SqlParameter("@date_balance", dt_firstbalance.Text);
              p[5] = new SqlParameter("@phone", txt_phonenumber.Text);
              p[6] = new SqlParameter("@emial", txt_email.Text);
              p[7] = new SqlParameter("@adress", txt_adress.Text);
              p[8] = new SqlParameter("@user_id", connectiondata.user_id);
              p[9] = new SqlParameter("@notes", txt_notes.Text);

              cd.runproc("sp_accountsInsert", p);
              frm_accounts.getmain.bindingaccounts();
              int focusedrow = frm_accounts.getmain.gridView1.LocateByValue("account_name", txt_name.Text, null);
              frm_accounts.getmain.gridView1.FocusedRowHandle = focusedrow;
          }
          else
          {
              SqlParameter[] p = new SqlParameter[10];
              p[0] = new SqlParameter("@account_name", txt_name.Text);
              p[1] = new SqlParameter("@account_type", radioGroup1.EditValue.ToString());
              p[2] = new SqlParameter("@debit", (string.IsNullOrEmpty(txt_debit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_debit.Text));
              p[3] = new SqlParameter("@credit", (string.IsNullOrEmpty(txt_creadit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_creadit.Text));
              p[4] = new SqlParameter("@date_balance", dt_firstbalance.Text);
              p[5] = new SqlParameter("@phone", txt_phonenumber.Text);
              p[6] = new SqlParameter("@emial", txt_email.Text);
              p[7] = new SqlParameter("@adress", txt_adress.Text);
              p[8] = new SqlParameter("@account_code", account_code);
              p[9] = new SqlParameter("@notes", txt_notes.Text);

              cd.runproc("sp_accountsUpdate", p);
              frm_accounts.getmain.bindingaccounts();
              int focusedrow = frm_accounts.getmain.gridView1.LocateByValue("account_name", txt_name.Text, null);
              frm_accounts.getmain.gridView1.FocusedRowHandle = focusedrow;
          }
          FormCollection fm = Application.OpenForms;
          foreach (Form item in fm)
          {
              if (item.Text == "شراء")
              {
                  frm_purchase.get_main.bindingaccounts();
                  this.Close();
                  return;
              }
          }
          this.Close();
        }
        bool validitingaccount_name()
        {
            if (addnew == true)
            {
                        DataTable dt = new DataTable();
                        SqlParameter[] p = new SqlParameter[1];
                        p[0] = new SqlParameter("@account_name", txt_name.Text);
                        dt = cd.getdata("sp_accountname_check", p);
                        if (dt.Rows[0][0].ToString() == "0")
                        {
                            validating = true;
                            errorProvider1.Dispose();
                            return true;
                        }
                        else
                        {
                            errorProvider1.SetError(txt_name, "برجاء تغير أسم الحساب هذا الاسم مسجل مسبقا");
                            validating = false;
                            return false;
                        }
            }
            else
            {
                DataTable dt = new DataTable();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@account_code", account_code);
                p[1]=new SqlParameter("@account_name",txt_name.Text);
                dt=cd.getdata("sp_accountnamealidating",p) ;
                if(dt.Rows[0][0].ToString()=="0")
                {
                    validating = true;
                    errorProvider1.Dispose();
                    return true;
                }else{
                    errorProvider1.SetError(txt_name, "برجاء تغير أسم الحساب هذا الاسم مسجل مسبقا");
                    validating = false;
                    return false;

                }
            }
        }

        private void txt_name_Validating(object sender, CancelEventArgs e)
        {
            validitingaccount_name();
        }

        private void btn_savenew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.SetError(txt_name, "يرجى أدخال أسم الحساب");
                return;
            }
            if (validating == false)
            {
                MSg.showmsg("يرجى التاكد من ادخال البيانات بشكل صحيح", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
           if(addnew==true)
           {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@account_name", txt_name.Text);
            p[1] = new SqlParameter("@account_type", radioGroup1.EditValue.ToString());
            p[2] = new SqlParameter("@debit", (string.IsNullOrEmpty(txt_debit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_debit.Text));
            p[3] = new SqlParameter("@credit", (string.IsNullOrEmpty(txt_creadit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_creadit.Text));
            p[4] = new SqlParameter("@date_balance", dt_firstbalance.Text);
            p[5] = new SqlParameter("@phone", txt_phonenumber.Text);
            p[6] = new SqlParameter("@emial", txt_email.Text);
            p[7] = new SqlParameter("@adress", txt_adress.Text);
            p[8] = new SqlParameter("@user_id", connectiondata.user_id);
            p[9] = new SqlParameter("@notes",txt_notes.Text);

            cd.runproc("sp_accountsInsert", p);
            frm_accounts.getmain.bindingaccounts();
            int focusedrow = frm_accounts.getmain.gridView1.LocateByValue("account_name", txt_name.Text, null);
            frm_accounts.getmain.gridView1.FocusedRowHandle = focusedrow;
            cleardata();
           }
           else
           {
               SqlParameter[] p = new SqlParameter[10];
               p[0] = new SqlParameter("@account_name", txt_name.Text);
               p[1] = new SqlParameter("@account_type", radioGroup1.EditValue.ToString());
               p[2] = new SqlParameter("@debit", (string.IsNullOrEmpty(txt_debit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_debit.Text));
               p[3] = new SqlParameter("@credit", (string.IsNullOrEmpty(txt_creadit.Text)) ? Convert.ToDecimal(0) : Convert.ToDecimal(txt_creadit.Text));
               p[4] = new SqlParameter("@date_balance", dt_firstbalance.Text);
               p[5] = new SqlParameter("@phone", txt_phonenumber.Text);
               p[6] = new SqlParameter("@emial", txt_email.Text);
               p[7] = new SqlParameter("@adress", txt_adress.Text);
               p[8] = new SqlParameter("@account_code", account_code);
               p[9] = new SqlParameter("@notes", txt_notes.Text);

               cd.runproc("sp_accountsUpdate", p);
               frm_accounts.getmain.bindingaccounts();
               int focusedrow = frm_accounts.getmain.gridView1.LocateByValue("account_name", txt_name.Text, null);
               frm_accounts.getmain.gridView1.FocusedRowHandle = focusedrow;
               cleardata();
               addnew = true;
           }
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frm_accounts.getmain.gridView1.MoveNext();
                int rowindex = frm_accounts.getmain.gridView1.FocusedRowHandle;
                string _account_code = frm_accounts.getmain.gridView1.GetRowCellValue(rowindex, "acount_code").ToString();
                returndata(_account_code);
                addnew = false;

            }
            catch (Exception)
            {
                
              
            }

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            try 
	            {	        
		            frm_accounts.getmain.gridView1.MovePrev();
                    int rowindex = frm_accounts.getmain.gridView1.FocusedRowHandle;
                    string _account_code = frm_accounts.getmain.gridView1.GetRowCellValue(rowindex, "acount_code").ToString();
                    returndata(_account_code);
                    addnew = false;

	            }
	            catch (Exception)
	            {
		
	            }       
            

        }
    }
}