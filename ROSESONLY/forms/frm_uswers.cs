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
    
    public partial class frm_uswers : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int user_id=0;
        DataTable dt = new DataTable();
        public frm_uswers()
        {
            InitializeComponent();
            bindingcashier();
            bindingstores();
            generatdata();
        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectstores", null);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";
        }
        void bindingcashier()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectxcashier", null);
            cmb_cashier.Properties.DataSource = dt;
            cmb_cashier.Properties.DisplayMember = "cashier_name";
            cmb_cashier.Properties.ValueMember = "cashier_id";
        }

        void generatdata()
        {
            dt.Columns.Add("screen_name", typeof(string));
            dt.Columns.Add("show_", typeof(bool));
            dt.Columns.Add("add_new", typeof(bool));
            dt.Columns.Add("edit_", typeof(bool));
            dt.Columns.Add("delete_", typeof(bool));
            dt.Columns.Add("change_date", typeof(bool));
            dt.Columns.Add("nav_", typeof(bool));
            dt.Columns.Add("pr_changeprice", typeof(bool));
           string[]sc=new string[16];
            sc[0]="الأعدادات";
            sc[1]="فواتير البيع";
            sc[2]="فواتير الشراء";
            sc[3]="مرتجع البيع";
            sc[4]="مرتجع الشراء";
            sc[5]="تحويل لمخزن";
            sc[6]="تسوية مخزن";
            sc[7]="طلبات بضاعة";
            sc[8]="الأصناف";
            sc[9]="الخزينة";
            sc[10]="الحسابات";
            sc[11]="حركه الاصناف";
            sc[12]="حركة المخازن";
            sc[13]="بضاعة مخزن";
            sc[14]="كشف حساب";
            sc[15]="حركة الفواتير";

            DataRow _newr;
            for (int i = 0; i < sc.Length; i++)
            {
                _newr = dt.NewRow();
                _newr["screen_name"] = sc[i];
                _newr["show_"] = "False";
                _newr["add_new"] = "False";
                _newr["edit_"] = "False";
                _newr["delete_"] = "False";
                _newr["change_date"] = "False";
                _newr["pr_changeprice"] = "False";
                _newr["nav_"] = "False";
                dt.Rows.Add(_newr);
            }
            gridControl1.DataSource = dt;
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_uswers_Load(object sender, EventArgs e)
        {
            if(user_id!=0)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@user_id", user_id);
                DataTable dt_ = new DataTable();
                dt_ = cd.getdata("sp_usdata1", p);
                txt_user.Text = dt_.Rows[0]["user_name"].ToString();
                txt_pass.Text = dt_.Rows[0]["password"].ToString();
                cmb_cashier.EditValue = dt_.Rows[0]["cashier_code"].ToString();
                cmb_stores.EditValue = dt_.Rows[0]["branch_code"].ToString();
                txt_fulluser.Text = dt_.Rows[0]["full_name"].ToString();
                btn_cashier.Tag = 1;
                cmb_cashier.ShowPopup();
                cmb_cashier.ClosePopup();
                cmb_stores.ShowPopup();
                cmb_stores.ClosePopup();
                SqlParameter[] p1 = new SqlParameter[1];
                p1[0] = new SqlParameter("@user_id", user_id);
                dt = cd.getdata("sp_userper", p1);
                gridControl1.DataSource = dt;
            }
        }

        private void btn_cashier_Click(object sender, EventArgs e)
        {
            if(btn_cashier.Tag.ToString()=="0")
            {
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@user_name", txt_user.Text);
                p[1] = new SqlParameter("@password", txt_pass.Text);
                p[2] = new SqlParameter("@branch_code", cmb_stores.EditValue);
                p[3] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                p[4] = new SqlParameter("@dt", dt);
                p[5] = new SqlParameter("@full_name", txt_fulluser.Text);
                cd.runproc("sp_userinser", p);
                MSg.showmsg("تم حفظ بياتات المستخدم", MSg.msgbutton.ok, MSg.msgicon.information);
                frm_settings.get_main.bindinguser();
               
            }
            else
            {
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@user_name", txt_user.Text);
                p[1] = new SqlParameter("@password", txt_pass.Text);
                p[2] = new SqlParameter("@branch_code", cmb_stores.EditValue);
                p[3] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                p[4] = new SqlParameter("@dt", dt);
                p[5] = new SqlParameter("@user_id", user_id);
                p[6] = new SqlParameter("@full_name", txt_fulluser.Text);
                cd.runproc("sp_userupdate", p);
                MSg.showmsg("تم حفظ بياتات المستخدم", MSg.msgbutton.ok, MSg.msgicon.information);
                frm_settings.get_main.bindinguser();
            }
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void clear()
    {
        txt_pass.Text = string.Empty;
        txt_user.Text = string.Empty;
        cmb_cashier.EditValue = -1;
        cmb_stores.EditValue = -1;
        generatdata();

    }
        private void btn_reports_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
        }
    }
}