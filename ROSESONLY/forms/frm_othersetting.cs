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
using System.Management;
using System.Data.SqlClient;
using ROSESONLY.DLL;
namespace ROSESONLY.forms
{
    public partial class frm_othersetting : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public frm_othersetting()
        {
            InitializeComponent();
        }
       void binding_printer()
        {
            ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
            objScope.Connect();

            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            foreach (ManagementObject mo in MOC)
            {
                cmb_salesprinter.Properties.Items.Add(mo["Name"].ToString());
                cmb_salesreturnprinter.Properties.Items.Add(mo["Name"].ToString());
                cmb_purcashereturnprinter.Properties.Items.Add(mo["Name"].ToString());
                cmb_purchaseprinter.Properties.Items.Add(mo["Name"].ToString());
            }

        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectstores", null);
            cmb_mainstore.Properties.DataSource = dt;
            cmb_mainstore.Properties.DisplayMember = "store_name";
            cmb_mainstore.Properties.ValueMember = "store_id";
        }
        void bindingcashier()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_selectxcashier", null);
            cmb_maincashier.Properties.DataSource = dt;
            cmb_maincashier.Properties.DisplayMember = "cashier_name";
            cmb_maincashier.Properties.ValueMember = "cashier_id";
        }
        public void bindingaccounts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingaccounts", null);
            cmb_mainaccount.Properties.DataSource = dt;
            cmb_mainaccount.Properties.DisplayMember = "account_name";
            cmb_mainaccount.Properties.ValueMember = "account_code";
        }

        private void frm_othersetting_Load(object sender, EventArgs e)
        {
            binding_printer();
            bindingaccounts();
            bindingcashier();
            bindingstores();
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_getsetting", null);
            if (dt.Rows.Count == 0) { return; }
            cmb_mainaccount.EditValue = Properties.Settings.Default.mainaccount; 
            cmb_mainstore.EditValue = Properties.Settings.Default.main_store;
            cmb_maincashier.EditValue = Properties.Settings.Default.main_cashier;
            cmb_salesprinter.Text = Properties.Settings.Default.sales_printer;
            cmb_salesreturnprinter.Text = Properties.Settings.Default.sales_returnprinter;
            cmb_purchaseprinter.Text = Properties.Settings.Default.pur_printer;
            cmb_purcashereturnprinter.Text = Properties.Settings.Default.pur_returnprintre;
            sales_type.EditValue = Properties.Settings.Default.sales_paper;
            sales_returntype.EditValue = Properties.Settings.Default.sales_returnpaper;
            purchase_type.EditValue = Properties.Settings.Default.pur_paper;
            purchaseruturntype.EditValue = Properties.Settings.Default.pur_returnpaper;
            auto_add.EditValue = Properties.Settings.Default.auto_add; 
            product_repaet.EditValue = Properties.Settings.Default.repeate;
            use_barcode.EditValue = Properties.Settings.Default.use_barcode;
            change_price.EditValue = Properties.Settings.Default.change_price;
            txt_notes.Text = Properties.Settings.Default.invoice_notes;
            txt_backup.Text = Properties.Settings.Default.backup_path;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cmb_mainaccount.Text))
            {
                MSg.showmsg("يرجى أختيار الحساب المباشر", MSg.msgbutton.ok, MSg.msgicon.delete);
                return;
            }
            if (string.IsNullOrEmpty(cmb_maincashier.Text))
            {
                MSg.showmsg("يرجى أختيار الخزينة المباشرة", MSg.msgbutton.ok, MSg.msgicon.delete);
                return;
            }
            if (string.IsNullOrEmpty(cmb_mainstore.Text))
            {
                MSg.showmsg("يرجى أختيار المخزن المباشر", MSg.msgbutton.ok, MSg.msgicon.delete);
                return;
            }
            if (string.IsNullOrEmpty(txt_backup.Text))
            {
                MSg.showmsg("يرجى أختيار مسار حفظ النسخة الأحتياطية", MSg.msgbutton.ok, MSg.msgicon.delete);
                return;
            }
            Properties.Settings.Default.backup_path = txt_backup.Text;
            Properties.Settings.Default.mainaccount =int.Parse(cmb_mainaccount.EditValue.ToString());
            Properties.Settings.Default.main_cashier = int.Parse(cmb_maincashier.EditValue.ToString());
            Properties.Settings.Default.main_store = int.Parse(cmb_mainstore.EditValue.ToString());
            Properties.Settings.Default.sales_paper = sales_type.EditValue.ToString();
            Properties.Settings.Default.sales_returnpaper = sales_returntype.EditValue.ToString();
            Properties.Settings.Default.pur_paper = purchase_type.EditValue.ToString();
            Properties.Settings.Default.pur_returnpaper = purchaseruturntype.EditValue.ToString();
            Properties.Settings.Default.sales_printer = cmb_salesprinter.Text;
            Properties.Settings.Default.sales_returnprinter =cmb_salesreturnprinter.Text;
            Properties.Settings.Default.pur_printer = cmb_purchaseprinter.Text;
            Properties.Settings.Default.pur_returnprintre =cmb_purcashereturnprinter.Text;
            Properties.Settings.Default.invoice_notes = txt_notes.Text;
            Properties.Settings.Default.auto_add =Convert.ToBoolean(auto_add.EditValue);
            Properties.Settings.Default.use_barcode = Convert.ToBoolean(use_barcode.EditValue);
            Properties.Settings.Default.repeate = Convert.ToBoolean(product_repaet.EditValue);
            Properties.Settings.Default.change_price = Convert.ToBoolean(change_price.EditValue);
            Properties.Settings.Default.Save();

            //SqlParameter[] p = new SqlParameter[17];
            //p[0] = new SqlParameter("@main_account",cmb_mainaccount.EditValue);
            //p[1] = new SqlParameter("@main_store",cmb_mainstore.EditValue);
            //p[2] = new SqlParameter("@main_cashier",cmb_maincashier.EditValue);
            //p[3] = new SqlParameter("@auto_add",auto_add.EditValue);
            //p[4] = new SqlParameter("@use_barcode",use_barcode.EditValue);
            //p[5] = new SqlParameter("@product_repeat",product_repaet.EditValue);
            //p[6] = new SqlParameter("@sales_type",sales_type.EditValue.ToString());
            //p[7] = new SqlParameter("@sales_Rtype",sales_returntype.EditValue.ToString());
            //p[8] = new SqlParameter("@purchase_type",purchase_type.EditValue.ToString());
            //p[9] = new SqlParameter("@purchase_Rtype",purchaseruturntype.EditValue.ToString());
            //p[10] = new SqlParameter("@sales_printer",cmb_salesprinter.Text);
            //p[11] = new SqlParameter("@sales_Rprinter",cmb_salesreturnprinter.Text);
            //p[12] = new SqlParameter("@purchase_printer",cmb_purchaseprinter.Text);
            //p[13] = new SqlParameter("@purcahse_Rprinter", cmb_purcashereturnprinter.Text);
            //p[14] = new SqlParameter("@change_price", change_price.EditValue);
            //p[15] = new SqlParameter("@recipet_notes", txt_notes.Text);
            //p[16] = new SqlParameter("@backup_path", txt_backup.Text);
            //cd.runproc("sp_updatesetting", p);
            MSg.showmsg("تم حفظ الأعدادات", MSg.msgbutton.ok, MSg.msgicon.information);
            XtraForm1.getmain.dt_setting = cd.getdata("sp_getsetting", null);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            if(op.ShowDialog()==DialogResult.OK)
            {
                txt_backup.Text = op.SelectedPath;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_restore.Text == string.Empty) {
                    errorProvider1.SetError(txt_restore, "يرجى أختيار ملف النسخة الاحتياطية");
                    return; }
                SqlConnection conn = new SqlConnection("Data Source=.;initial catalog=master;Integrated Security=True");
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("ALTER DATABASE DB_ROSES SET SINGLE_USER WITH ROLLBACK IMMEDIATE", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("RESTORE DATABASE DB_ROSES from disk='" + txt_restore.Text + "' WITH REPLACE",conn);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("ALTER  DATABASE DB_ROSES  SET MULTI_USER", conn);
                cmd3.ExecuteNonQuery();
                conn.Close();
                XtraMessageBox.Show("تم استرجاع النسخه بنجاح", "استرجاع النسخه الاحتياطيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "backupFiles(*.bak)|*.bak";
            if(op.ShowDialog()==DialogResult.OK)
            {
                txt_restore.Text = op.FileName;
            }
        }
    }
}