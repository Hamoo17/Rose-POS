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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraPrinting;

namespace ROSESONLY.forms
{
    public partial class frm_cashierMovies : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();

        private static frm_cashierMovies frm;
        public bool checkopenedform(Form frm)
        {
            foreach (BaseDocument item in FRM_MAIN.getmain.documentManager1.View.Documents)
            {
                if (item.Caption == frm.Text)
                {
                    FRM_MAIN.getmain.documentManager1.View.ActivateDocument(item.Form);
                    return true;
                }
            }
            return false;
        }//check form open 
        public void openform(Form frm)
        {
            if (checkopenedform(frm) == false)
            {
                frm.MdiParent = FRM_MAIN.getmain;
                frm.Show();
            }
        }

        static  void form_closed(object sender ,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_cashierMovies getmain
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_cashierMovies();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                } return frm;
            }
        }
        public frm_cashierMovies()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
            gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridView1_CustomUnboundColumnData);

        }
        
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_mainpage frm1 = new frm_mainpage();
            if (frm1.checkpermissions(connectiondata.user_id, "الخزينة", "add_new", 1) == true)
            {
                frm_cashieradd frm = new frm_cashieradd();
                frm_othermain.getmain.openform(frm);
            }

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            frm_mainpage frm1 = new frm_mainpage();
            if (frm1.checkpermissions(connectiondata.user_id, "الخزينة", "delete_", 1) == false)
            {
                return;
            }
            if (gridView1.RowCount == 0) { return; }
            if (MSg.showmsg("حذف بيانات الأيصال", MSg.msgbutton.okcancel, MSg.msgicon.warning) == MSg.result.CANCEL) { return; }
           if(gridView1.GetFocusedRowCellValue("invoice_type").ToString()=="تحويلات خزينة")
           {
               SqlParameter[] pa = new SqlParameter[1];
               pa[0] = new SqlParameter("@transfer_code", int.Parse(gridView1.GetFocusedRowCellValue("transfer_code").ToString()));
               cd.runproc("sp_deleteTransfer", pa);
           }
           else
           {
            int rowindex = gridView1.FocusedRowHandle;
            string move_no = gridView1.GetRowCellValue(rowindex, "move_no").ToString();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_no", move_no);
            cd.runproc("sp_cashierremove", p);
           }
            bindingcashierdata();
            bindingbalance();

        }
        public void bindingcashierdata()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
            p[1] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[2] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            dt = cd.getdata("sp_cashierReturnData", p);
            gridControl1.DataSource = dt;
        }
        public void bindingbalance()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
            p[1] = new SqlParameter("@first", Convert.ToDateTime(txt_date1.Text));
            p[2] = new SqlParameter("@last", Convert.ToDateTime(txt_date2.Text));
            dt = cd.getdata("sp_cashierbalance", p);
            txt_net1.Text = dt.Rows[0][0].ToString();
            txt_net2.Text = dt.Rows[0][1].ToString();
        }

        private void frm_prodcuts_Load(object sender, EventArgs e)
        {
            bindingcashier();
            cmb_cashier.ItemIndex = 0;
            txt_date1.Text = DateTime.Today.ToString("d");
            txt_date2.Text = DateTime.Today.ToString("d");
            bindingcashierdata();
            bindingbalance();
            gridView1.IndicatorWidth = 30;
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_mainpage frm1 = new frm_mainpage();
            if (frm1.checkpermissions(connectiondata.user_id, "الخزينة", "add_new", 1) == true)
            {
                frm_cashieradd frm = new frm_cashieradd();
                frm_othermain.getmain.openform(frm);
            }

        }

        private void frm_prodcuts_Deactivate(object sender, EventArgs e)
        {
           
        }

        private void frm_prodcuts_Activated(object sender, EventArgs e)
        {
            bindingcashierdata();
            bindingbalance();
        }

        private void cmb_category_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            bindingcashierdata();
            bindingbalance();
        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void gridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                gridView1.MovePrev();
            }
            else if (e.Delta < 0)
            {
                gridView1.MoveNext();
            }            
        }
        int returnmovenumber(int invoice_no,string invoice_type)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@invoice_no", invoice_no);
            p[1] = new SqlParameter("@invoice_type", invoice_type);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_getmovenumber", p);
            int move_no = int.Parse(dt.Rows[0][0].ToString());
            return move_no;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_mainpage frm_ = new frm_mainpage();
            if (frm_.checkpermissions(connectiondata.user_id, "الخزينة", "edit_", 1) == false)
            {
                return;
            }

            if (gridView1.RowCount == 0) { return; }
            FormCollection fc = Application.OpenForms;
            switch (gridView1.GetFocusedRowCellValue("invoice_type").ToString())
            {
                case "شراء":
                    foreach (Form item in fc)
                    {
                        if(item.Text=="شراء")
                        {
                            frm_purchase.get_main.Close();
                            break;
                        }
                    }
                    frm_purchase.get_main.m_value = returnmovenumber(int.Parse(gridView1.GetFocusedRowCellValue("invoice_no").ToString()), gridView1.GetFocusedRowCellValue("invoice_type").ToString());
                    frm_othermain.getmain.openform(frm_purchase.get_main);
                    break;
                case "بيع":
                    foreach (Form item in fc)
                    {
                        if(item.Text=="فاتورة بيع")
                        {
                            frm_SalesInvoice.get_main.Close();
                            break;
                        }
                    }
                    frm_SalesInvoice.get_main.m_value = returnmovenumber(int.Parse(gridView1.GetFocusedRowCellValue("invoice_no").ToString()), gridView1.GetFocusedRowCellValue("invoice_type").ToString());
                    frm_othermain.getmain.openform(frm_SalesInvoice.get_main);
                    break;
                case "مرتجع شراء":
                    foreach (Form item in fc)
                    {
                        if(item.Text=="مرتجع شراء")
                        {
                            frm_purchaseReturn.get_main.Close();
                            break;
                        }
                    }
                    frm_purchaseReturn.get_main.m_value = returnmovenumber(int.Parse(gridView1.GetFocusedRowCellValue("invoice_no").ToString()), gridView1.GetFocusedRowCellValue("invoice_type").ToString());
                    frm_othermain.getmain.openform(frm_purchaseReturn.get_main);
                    break;
                case "مرتجع بيع":
                    foreach (Form item in fc)
                    {
                        if(item.Text=="مرتجع بيع")
                        {
                            frm_salesreturn.get_main.Close();
                            break;
                        }
                    }
                    frm_salesreturn.get_main.m_value = returnmovenumber(int.Parse(gridView1.GetFocusedRowCellValue("invoice_no").ToString()), gridView1.GetFocusedRowCellValue("invoice_type").ToString());
                    frm_othermain.getmain.openform(frm_salesreturn.get_main);
                    break;
                case "تحويلات خزينة":
                    SqlParameter[] para = new SqlParameter[1];
                    int code=int.Parse(gridView1.GetFocusedRowCellValue("transfer_code").ToString());
                    para[0] = new SqlParameter("@transfer_code", code);
                    DataTable dt1 = new DataTable();
                    dt1 = cd.getdata("sp_returnTransferData", para);
                    frm_cashierconvert frm1 = new frm_cashierconvert();
                    frm1.txt_date.Text =Convert.ToDateTime(dt1.Rows[0]["move_date"]).ToString("d");
                    frm1.txt_value.Text = dt1.Rows[0]["credit_value"].ToString();
                    frm1.cmb_cashier1.EditValue = dt1.Rows[0]["cashier1"].ToString();
                    frm1.cmb_cashier2.EditValue = dt1.Rows[0]["cashier2"].ToString();
                    frm1.transfer_code = code;
                    frm1.btn_saveexit.Tag = 1;
                    frm1.ShowDialog();
                    break;
                default:  
            int rowindex = gridView1.FocusedRowHandle;
            string invoice_no = gridView1.GetRowCellValue(rowindex, "invoice_no").ToString();
            int move_no = int.Parse(gridView1.GetRowCellValue(rowindex, "move_no").ToString());
            string move_type = gridView1.GetRowCellValue(rowindex, "move_type").ToString();

            if(invoice_no!="0")
            {

            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@move_no", move_no);
                p[1] = new SqlParameter("@move_type", move_type);
                DataTable dt_ = new DataTable();
                dt_ = cd.getdata("sp_cashierreturn", p);
                        //frm_cashierupdate frm = new frm_cashierupdate();
                        int accountcode;
                if (move_type=="صادر")
                {
                    frm_cashierout frm = new frm_cashierout();
                    frm.txt_value.Text = gridView1.GetRowCellValue(rowindex, "creadit_value").ToString();
                     accountcode = int.Parse(gridView1.GetRowCellValue(rowindex, "account_code").ToString());
                    frm.txt_date.Text = Convert.ToDateTime(gridView1.GetRowCellValue(rowindex, "move_date").ToString()).ToString("d");
                    frm.cmb_accounts.EditValue = accountcode;
                    frm.cmb_cashier.EditValue = cmb_cashier.EditValue;
                    frm.txt_band.Text = gridView1.GetRowCellValue(rowindex, "band").ToString();
                    frm.txt_notes.Text = gridView1.GetRowCellValue(rowindex, "notes").ToString();
                    frm.cmb_accounts.Focus();
                    frm.btn_ok.Tag = "1";
                    frm.move_no = move_no;
                    frm_othermain.getmain.openform(frm);
                    }
                    else
                    {
                    frm_cashieradd frm = new frm_cashieradd();
                    frm.txt_value.Text = gridView1.GetRowCellValue(rowindex, "debit_value").ToString();
                        accountcode = int.Parse(gridView1.GetRowCellValue(rowindex, "account_code").ToString());
                    frm.txt_date.Text = Convert.ToDateTime(gridView1.GetRowCellValue(rowindex, "move_date").ToString()).ToString("d");
                    frm.cmb_accounts.EditValue = accountcode;
                    frm.cmb_cashier.EditValue = cmb_cashier.EditValue;
                    frm.txt_band.Text = gridView1.GetRowCellValue(rowindex, "band").ToString();
                    frm.txt_notes.Text = gridView1.GetRowCellValue(rowindex, "notes").ToString();
                    frm.move_no = move_no;
                    frm.btn_ok.Tag = "1";
                    frm.cmb_accounts.Focus();
                    frm_othermain.getmain.openform(frm);
                    }
                }
                break;

            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column.FieldName == "balance_" & e.IsGetData)
            {
                decimal total = 0m;
                int rHandle = view.GetRowHandle(e.ListSourceRowIndex);
                for (int i = -1; i <= rHandle - 1; i++)
                {
                    total += Convert.ToDecimal(view.GetRowCellValue(i + 1, "debit_value")) - Convert.ToDecimal(view.GetRowCellValue(i + 1, "creadit_value"));
                }
                e.Value = total;
            }

        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }


        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frm_revenueanaluzing frm = new frm_revenueanaluzing();
            openform(frm);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frm_mainpage frm1 = new frm_mainpage();
            if (frm1.checkpermissions(connectiondata.user_id, "الخزينة", "change_date", 1) == false)
            {
                return;
            }

            frm_cashierconvert frm = new frm_cashierconvert();
            frm.ShowDialog();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                simpleButton8_Click(null, null);
            }

        }

        private void frm_cashierMovies_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frm_expensesAnalyze frm = new frm_expensesAnalyze();
            openform(frm);


        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
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

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }
    }
}