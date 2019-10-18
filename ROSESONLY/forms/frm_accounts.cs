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
using DevExpress.XtraPrinting;
using DevExpress.XtraBars.Docking2010.Views;
namespace ROSESONLY.forms
{
    public partial class frm_accounts : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        private static frm_accounts frm;
        static void form_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_accounts getmain
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_accounts();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                } return frm;
            }
        }

        public frm_accounts()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_addacounts frm = new frm_addacounts();
            frm.ShowDialog();
        }
        public void bindingaccounts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_accountsreturn", null);
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToDecimal(item["debit"].ToString()) > Convert.ToDecimal(item["credit"].ToString())) 
                {
                    item.BeginEdit();
                    item["debit"] = Convert.ToDecimal(item["debit"].ToString()) -( Convert.ToDecimal(item["credit"].ToString()));
                    item["credit"] = Convert.ToDecimal("0");
                    item.EndEdit();
                }
                else
                {
                    item.BeginEdit();
                    item["credit"] = Convert.ToDecimal(item["credit"].ToString())-(Convert.ToDecimal(item["debit"].ToString()));
                    item["debit"] = Convert.ToDecimal("0");
                    item.EndEdit();
                }
            }
            gridControl1.DataSource = dt;
        }
        private void frm_accounts_Load(object sender, EventArgs e)
        {
            bindingaccounts();
            gridView1.IndicatorWidth = 30;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            frm_addacounts frm = new frm_addacounts();
            frm_othermain.getmain.openform(frm);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) { return; }
            int index = gridView1.FocusedRowHandle;
            string account_code = gridView1.GetRowCellValue(index, "acount_code").ToString();
            frm_addacounts frm = new frm_addacounts();
            frm.addnew = false;
            frm.account_code = account_code;
            frm.returndata(account_code);
            frm_othermain.getmain.openform(frm);
        }

        private void frm_accounts_Activated(object sender, EventArgs e)
        {
            bindingaccounts();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }
            if (int.Parse(gridView1.GetFocusedRowCellValue("acount_code").ToString()) == 1) { return; }
            if (MSg.showmsg("حذف بيانات الحساب", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
               
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@account_code", int.Parse(gridView1.GetFocusedRowCellValue("acount_code").ToString()));
                cd.runproc("sp_accountdelete", p);
                bindingaccounts();
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            frm_cashieradd frm = new frm_cashieradd();
            frm.cmb_accounts.EditValue = gridView1.GetFocusedRowCellValue("acount_code").ToString();
           frm_othermain.getmain.openform(frm);

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            frm_cashieradd frm = new frm_cashieradd();
            frm.cmb_accounts.EditValue = gridView1.GetFocusedRowCellValue("acount_code").ToString();
            frm_othermain.getmain.openform(frm);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            frm_Account_recepit frm = new frm_Account_recepit();
            frm.cmb_vendors.EditValue = int.Parse(gridView1.GetFocusedRowCellValue("acount_code").ToString());
            frm_othermain.getmain.openform(frm);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //int rowindex = gridView1.FocusedRowHandle;
            //string account_code = gridView1.GetRowCellValue(rowindex, "acount_code").ToString();

            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@account_code", account_code);
            //DataTable dt = new DataTable();
            //dt = cd.getdata("sp_accountsMoves", p);
            //gridControl2.DataSource = dt;

            //SqlParameter[] p1 = new SqlParameter[1];
            //p1[0] = new SqlParameter("@account_code", account_code);
            //DataTable dt1 = new DataTable();
            //dt1 = cd.getdata("sp_accontscahiermovies", p1);
            //gridControl3.DataSource = dt1;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gridView1.RowCount == 0) { return; }
            //int rowindex = gridView1.FocusedRowHandle;
            //string account_code = gridView1.GetRowCellValue(rowindex, "acount_code").ToString();

            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@account_code", account_code);
            //DataTable dt = new DataTable();
            //dt = cd.getdata("sp_accountsMoves", p);
            //gridControl2.DataSource = dt;

            //SqlParameter[] p1 = new SqlParameter[1];
            //p1[0] = new SqlParameter("@account_code", account_code);
            //DataTable dt1 = new DataTable();
            //dt1 = cd.getdata("sp_accontscahiermovies", p1);
            //gridControl3.DataSource = dt1;

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gridView1.ActiveFilter.Clear();
            //gridView1.ActiveFilterString = "[account_type]='" + cmb_types.Text + "'";

        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "[account_name] like'%" + searchControl1.Text + "%'";
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            gridControl1.ShowPrintPreview();

        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.RightMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.Landscape = true;

        }
    }
}