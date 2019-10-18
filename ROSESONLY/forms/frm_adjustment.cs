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
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;

namespace ROSESONLY.forms
{
    public partial class frm_adjustment : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int m_value = 0;
        bool addnew = true;
        private static frm_adjustment frm;
        public  DataTable dt_products = new DataTable();
        DataTable dt_navigations = new DataTable();
        int code;
        bool validating = true;
        static void form_closed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_adjustment get_main
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_adjustment();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                } return frm;
            }
        }
        public frm_adjustment()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
            generatdatatable();
        }
        void generatdatatable()
        {
            dt_products.Columns.Add("product_code", typeof(int));
            dt_products.Columns.Add("product_name", typeof(string));
            dt_products.Columns.Add("available_qty", typeof(int));
            dt_products.Columns.Add("unit_name", typeof(string));
            dt_products.Columns.Add("qty", typeof(decimal));
            dt_products.Columns.Add("price", typeof(decimal));
            dt_products.Columns.Add("total", typeof(decimal), "qty*price");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            gridControl1.DataSource = dt_products;

        }
        void bindingproducts()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@store_id", cmb_stores.EditValue);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_purchaseBindingProducts", p);
            gridControl2.DataSource = dt;
        }

        void bindingstores()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@user_id", connectiondata.user_id);

            dt = cd.getdata("sp_bindingstores", p);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";


        }
        void cleardata()
        {
            dt_products.Clear();
            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            bindinginvoiceNO();
            txt_total.Text = "0";
        }
        void bindingsearch()
        {
            txt_serach.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_serach.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DataTable dt = new DataTable();
            SqlParameter[]p=new SqlParameter[2];
            p[0]=new SqlParameter("@user_code",connectiondata.user_id);
            p[1]=new SqlParameter("@move_type","تسوية");

            dt = cd.getdata("sp_MoviesNavigation", p);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt_serach.MaskBox.AutoCompleteCustomSource.Add(dt.Rows[i][1].ToString());
            }
        }
        void loading_data()
        {
            bindingstores();
            bindinginvoiceNO();
            cmb_stores.ItemIndex = 0;
            bindingproducts();
            txt_date.Text = DateTime.Today.ToShortDateString();
            gridView1.IndicatorWidth = 30;
            binding_navigations();
            bindingsearch();

        }
        private void frm_purchase_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                auto_insert.EditValue = Convert.ToBoolean(XtraForm1.getmain.dt_setting.Rows[0]["auto_add"].ToString());
                ck_productRepet.EditValue = Convert.ToBoolean(XtraForm1.getmain.dt_setting.Rows[0]["product_repeat"].ToString());
                use_parcode.EditValue = Convert.ToBoolean(XtraForm1.getmain.dt_setting.Rows[0]["use_barcode"].ToString());

                loading_data();
            });
        }

        void bindinginvoiceNO()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_type", "تسوية");

            DataTable dt = new DataTable();
            dt = cd.getdata("sp_BindingMoviesNO", p);
            txt_invice_no.Text = dt.Rows[0][0].ToString();
        }

        void bindingunits(int product_code)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@product_code", product_code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingunits", p);
            txt_unit.Properties.Items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                txt_unit.Properties.Items.Add(item[0].ToString());
            }
        }


        private void searchControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                txt_defaultqty.Focus();
                BeginInvoke(new Action(() => txt_defaultqty.SelectAll()));
                timer1.Enabled = true;
                return;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
               if(gridView2.RowCount==0)
               {
                   return;
               }
               else
               {
                   gridControl2.Focus();
                   gridView2.FocusedRowHandle = 1;
               }
            }
            if (string.IsNullOrEmpty(txt_code.Text)) { return; }

            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToBoolean(use_parcode.EditValue) == true)
                    {
                        DataTable dt = new DataTable();
                        SqlParameter[] p = new SqlParameter[1];
                        p[0] = new SqlParameter("@parcode", txt_code.Text);
                        dt = cd.getdata("sp_useparcode", p);
                        if (dt.Rows.Count == 0)
                        {
                            errorProvider1.SetError(txt_code, "لا يوجد صنف مسجل بهذا الباركود");
                            return;
                        }
                        txt_code.Text = dt.Rows[0]["product_name"].ToString();
                        txt_unit.Text = dt.Rows[0]["unit_name"].ToString();
                        txt_price.Text = dt.Rows[0]["buy_price"].ToString();
                        txt_qty.Text = txt_defaultqty.Text;
                        txt_qty.Focus();
                        bindingunits(int.Parse(dt.Rows[0]["product_code"].ToString()));
                        code=int.Parse(dt.Rows[0]["product_code"].ToString());
                        errorProvider1.Dispose();
                        if (Convert.ToBoolean(auto_insert.EditValue) == true)
                        {
                            addnewproduct();
                    }
                    else
                    {
                        bindingunits(code);
                    }
                }
                    else
                    {
                        if (validating == false) { return; }
                        int rowindex = gridView2.FocusedRowHandle;
                        int product_code = int.Parse(gridView2.GetRowCellValue(rowindex, "product_code").ToString());
                        string product_name = gridView2.GetRowCellValue(rowindex, "product_name").ToString();
                        string unit_name = gridView2.GetRowCellValue(rowindex, "def_unit").ToString();
                        string price = gridView2.GetRowCellValue(rowindex, "def_price").ToString();
                        txt_code.Text = product_name.ToString();
                        txt_unit.Text = unit_name.ToString();
                        txt_qty.Text = txt_defaultqty.Text;
                        txt_price.Text = price.ToString();
                        txt_qty.Focus();
                        code = product_code;
                    bindingunits(product_code);

                    if (Convert.ToBoolean(auto_insert.EditValue) == true)
                        {
                            addnewproduct();
                        }
                    }
            }

            //gridControl2.Visible = false;
        }

        private void searchControl1_Leave(object sender, EventArgs e)
        {
        }


        private void txt_code_EditValueChanged(object sender, EventArgs e)
        {
            gridView2.ActiveFilter.Clear();
            gridView2.ActiveFilterString = "[product_code]+[product_name] like '%" + txt_code.Text + "%'";

            if (Convert.ToBoolean(use_parcode.EditValue) == true) { return; }
            if (gridView2.RowCount == 0)
            {
                validating = false;
            }
            else
            {
                validating = true;
            }

        }

        private void txt_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@unit_name", txt_unit.Text);
            p[1] = new SqlParameter("@product_code", code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingprice", p);
            if (dt.Rows.Count == 0) { return; }
            txt_price.Text = dt.Rows[0][0].ToString();
        }
        public void updatetotal()
        {
            txt_total.Text = Math.Round(Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue), 2).ToString();
            lb_productscount.Text = gridView1.Columns["product_code"].SummaryItem.SummaryValue.ToString();
            lb_total.Text = Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue).ToString();
            lb_countity.Text = Convert.ToDecimal(gridView1.Columns["qty"].SummaryItem.SummaryValue).ToString();

        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            addnewproduct();
        }
        void addnewproduct()
        {
            #region validating
            if (validating == false) { return; }
            if (string.IsNullOrEmpty(txt_code.Text))
            {
                errorProvider1.SetError(txt_code, "يرجى أختيار الصنف");
                return;
            }
            if (string.IsNullOrEmpty(txt_unit.Text))
            {
                errorProvider1.SetError(txt_unit, "يرجى أختيار الوحده");
                return;
            }
            errorProvider1.Dispose();
            gridControl2.Visible = false;
            #endregion
            //cheack if available qty was larg than required qty
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@product_code", code);
            p[1] = new SqlParameter("@store_id", cmb_stores.EditValue);

            DataTable dt_qty = new DataTable();
            dt_qty = cd.getdata("sp_prodcust_balance", p);

            // check if product was added befor in the invoice
            DataRow[] findrow;
            findrow = dt_products.Select("product_code=" + code + "");
            if (findrow.Length > 0 && Convert.ToDecimal(findrow[0]["price"].ToString()) == Convert.ToDecimal(txt_price.Text))
            {
                if (Convert.ToBoolean(ck_productRepet.EditValue) == true)
                {
                    #region NewProduct
                    DataRow newproduct;
                    newproduct = dt_products.NewRow();
                    newproduct["product_code"] = code;
                    newproduct["product_name"] = txt_code.Text;
                    newproduct["unit_name"] = txt_unit.Text;
                    newproduct["qty"] = Convert.ToDecimal(txt_qty.Text);
                    newproduct["price"] = Convert.ToDecimal(txt_price.Text);
                    newproduct["available_qty"] = Convert.ToDecimal(dt_qty.Rows[0][0].ToString());
                    dt_products.Rows.Add(newproduct);
                    int focus_id = gridView1.LocateByValue("id", newproduct["id"], null);
                    gridView1.FocusedRowHandle = focus_id;
                    clearproduct_data();
                    updatetotal();
                    #endregion
                }
                else
                {
                    #region UpdatCurrentProduct
                    findrow[0].BeginEdit();
                    findrow[0]["qty"] = decimal.Parse(findrow[0]["qty"].ToString()) + decimal.Parse(txt_qty.Text);
                    findrow[0].EndEdit();
                    clearproduct_data();
                    updatetotal();
                    int focusid = gridView1.LocateByValue("id", findrow[0]["id"], null);
                    gridView1.FocusedRowHandle = focusid;
                    #endregion
                }
            }
            else
            {
                #region NewProduct
                DataRow newproduct;
                newproduct = dt_products.NewRow();
                newproduct["product_code"] = code;
                newproduct["product_name"] = txt_code.Text;
                newproduct["unit_name"] = txt_unit.Text;
                newproduct["qty"] = Convert.ToDecimal(txt_qty.Text);
                newproduct["price"] = Convert.ToDecimal(txt_price.Text);
                newproduct["available_qty"] = Convert.ToDecimal(dt_qty.Rows[0][0].ToString());
                dt_products.Rows.Add(newproduct);
                int focus_id = gridView1.LocateByValue("id", newproduct["id"], null);
                gridView1.FocusedRowHandle = focus_id;
                clearproduct_data();
                updatetotal();
                #endregion

            }
        }

        void clearproduct_data()
        {
            txt_code.Text = string.Empty;
            txt_unit.Text = string.Empty;
            txt_price.Text = "0";
            txt_qty.Text = "0";
            txt_code.Focus();
        }
        private void txt_unit_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void txt_qty_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;

        }

        private void txt_price_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;

        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_code.Focus();
            txt_code.Text = string.Empty;
            timer1.Enabled = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if(e.RowHandle >=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
            }
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if(e.IsTotalSummary)
           {
                decimal _total = Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue);
               e.TotalValue = _total;
               e.TotalValueReady = true;
               txt_total.Text = e.TotalValue.ToString();
               calculating_value();
            }
        }
        void calculating_value()
        {
            decimal total = string.IsNullOrEmpty(txt_total.Text)?Convert.ToDecimal("0"): Convert.ToDecimal(txt_total.Text);
        }
        private void frm_purchase_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl20_Click(object sender, EventArgs e)
        {
            txt_code.Focus();
        }


        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_discount_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
            frm_purchasepay frm = new frm_purchasepay();
            frm.ShowDialog();
        }

        private void cmb_stores_EditValueChanged(object sender, EventArgs e)
        {
            bindingproducts();
        }

        private void txt_paidvalue_EditValueChanged(object sender, EventArgs e)
        {
            calculating_value();
        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToBoolean(use_parcode.EditValue) != true)
            {
                gridControl2.Visible = true;
            }
            txt_code.Properties.Items.Clear();
        }


        private void txt_code_Click(object sender, EventArgs e)
        {
           if(Convert.ToBoolean(use_parcode.EditValue)!=true)
           {
               gridControl2.Visible = true;
           }

        }

        private void txt_total_EditValueChanged_1(object sender, EventArgs e)
        {
            calculating_value();
        }
        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                addnewproduct();
            }
        }

        private void txt_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addnewproduct();
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }
            if (MSg.showmsg("حذف بيانات الصنف من الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
                gridView1.DeleteSelectedRows();
                dt_products.AcceptChanges();
                updatetotal();
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
        }

        private void gridView1_MouseEnter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;

        }
        void validatingproducts()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@parcode", txt_code.Text);
            dt = cd.getdata("sp_useparcode", p);
            if (dt.Rows.Count == 0)
            {
                errorProvider1.SetError(txt_code, "لا يوجد صنف مسجل بهذا الباركود");
                return;
            }

        }
        private void txt_code_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount != 0)
            {
                frm_changeqty frm = new frm_changeqty();
                int selectrow = gridView1.FocusedRowHandle;
                decimal qty = decimal.Parse(gridView1.GetRowCellValue(selectrow, "qty").ToString());
                decimal price = decimal.Parse(gridView1.GetRowCellValue(selectrow, "price").ToString());
                string product_name = gridView1.GetRowCellValue(selectrow, "product_name").ToString();
                int code = int.Parse(gridView1.GetRowCellValue(selectrow, "product_code").ToString());
                frm.cmb_unit.Text = gridView1.GetRowCellValue(selectrow, "unit_name").ToString();
                frm.id = int.Parse(gridView1.GetRowCellValue(selectrow, "id").ToString());
                frm.txt_qty.Text = qty.ToString();
                frm.txt_productname.Text = product_name.ToString();
                frm.txt_price.Text = price.ToString();
                frm.product_code = code;
                frm.bindingunits(code);
                frm.form_name = "adjust";
                frm.ShowDialog();
            }

        }

        private void use_parcode_CheckedChanged(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(use_parcode.EditValue)==true)
            {
                gridControl2.Visible = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "add_new", 1) == false)
            {
                return;
            }

            gridView1.ActiveFilter.Clear();
            if(gridView1.RowCount==0)
            {
                MSg.showmsg("لا يمكن حفظ فاتورة شراء خالية من الأصناف", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            #region addnew invoice.....
            if(addnew==true)
            {
            SqlParameter[] param = new SqlParameter[7];
            param[0]=new SqlParameter("@move_type","تسوية");
            param[1]=new SqlParameter("@move_date",Convert.ToDateTime(txt_date.Text));
            param[2]=new SqlParameter("@invoice_no",txt_invice_no.Text);
            param[3]=new SqlParameter("@store_code",cmb_stores.EditValue);
            param[4]=new SqlParameter("@user_id", connectiondata.user_id);
            param[5]=new SqlParameter("@purchasetable",dt_products);
            param[6] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            cd.runproc("sp_Adjustinsert", param);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            binding_navigations();
            bindingsearch();
                cleardata();
                gridControl2.Visible = false;
            return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[7];
            param1[0] = new SqlParameter("@move_type", "تسوية");
            param1[1] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
            param1[2] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            param1[3] = new SqlParameter("@store_code", cmb_stores.EditValue);
            param1[4] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            param1[5] = new SqlParameter("@purchasetable", dt_products);
           int rowno=navigations_view.FocusedRowHandle;
           param1[6] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
           cd.runproc("sp_AdjustUpdate", param1);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            cleardata();
            addnew = true;
            cmb_stores.Enabled = true;
            gridControl2.Visible = false;
            #endregion
        }


        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int rowindex = gridView2.FocusedRowHandle;
                int product_code = int.Parse(gridView2.GetRowCellValue(rowindex, "product_code").ToString());
                string product_name = gridView2.GetRowCellValue(rowindex, "product_name").ToString();
                string unit_name = gridView2.GetRowCellValue(rowindex, "unit_name").ToString();
                string price = gridView2.GetRowCellValue(rowindex, "buy_price").ToString();
                txt_code.Text = product_name.ToString();
                txt_unit.Text = unit_name.ToString();
                txt_qty.Text = txt_defaultqty.Text;
                txt_price.Text = price.ToString();
                bindingunits(product_code);
                code = product_code;
                txt_qty.Focus();
                if (Convert.ToBoolean(auto_insert.EditValue) == true)
                {
                    addnewproduct();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gridView2.FocusedRowHandle == 1)
                {
                    txt_code.Focus();
                }
            }

        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int rowindex = gridView2.FocusedRowHandle;
            int product_code = int.Parse(gridView2.GetRowCellValue(rowindex, "product_code").ToString());
            string product_name = gridView2.GetRowCellValue(rowindex, "product_name").ToString();
            string unit_name = gridView2.GetRowCellValue(rowindex, "def_unit").ToString();
            string price = gridView2.GetRowCellValue(rowindex, "def_price").ToString();
            txt_code.Text = product_name.ToString();
            txt_unit.Text = unit_name.ToString();
            txt_qty.Text = txt_defaultqty.Text;
            txt_price.Text = price.ToString();
            code = product_code;
            bindingunits(product_code);
            txt_qty.Focus();
            if (Convert.ToBoolean(auto_insert.EditValue) == true)
            {
                addnewproduct();
            }

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            frm_addproducts.getmain.ShowDialog();
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            frm_addacounts frm = new frm_addacounts();
            frm.ShowDialog();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {

        }

        void binding_navigations()
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_code", connectiondata.user_id);
            p[1] = new SqlParameter("@move_type", "تسوية");

            dt_navigations = cd.getdata("sp_MoviesNavigation", p);
            grid_navigtions.DataSource = dt_navigations;

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "nav_", 1) == false)
            {
                return;
            }

            navigations_view.MoveFirst();
            getserachdata();
        }
        void getserachdata()
        {
            if (navigations_view.RowCount == 0) { return; }

            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;

            int x = navigations_view.FocusedRowHandle;
            string move_no = navigations_view.GetRowCellValue(x, "move_no").ToString();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_no", move_no);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_returnpurchasemain", p);
            txt_invice_no.Text = dt.Rows[0]["invoice_no"].ToString();
            cmb_stores.EditValue = dt.Rows[0]["store_code"];

            SqlParameter[] p1 = new SqlParameter[1];
            p1[0] = new SqlParameter("@move_no", move_no);
            DataTable dt2 = new DataTable();
            dt2 = cd.getdata("sp_returnpurchasedetails", p1);
            dt_products.Clear();
            foreach (DataRow item in dt2.Rows)
            {
                DataRow newrows;
                newrows = dt_products.NewRow();
                newrows["product_code"] = item["product_code"].ToString();
              
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@product_code", int.Parse(item["product_code"].ToString()));
                pa[1] = new SqlParameter("@store_id", cmb_stores.EditValue);
                DataTable dt_qty = new DataTable();
                dt_qty = cd.getdata("sp_prodcust_balance", pa);

                newrows["product_name"] = item["product_name"].ToString();
                newrows["available_qty"] = Convert.ToDecimal(dt_qty.Rows[0][0].ToString());
                newrows["unit_name"] = item["unit_name"].ToString();
                newrows["qty"] =item["qty"];
                newrows["price"] =item["price"];
                dt_products.Rows.Add(newrows);
            }
            updatetotal();
            calculating_value();
            addnew = false;
            cmb_stores.Enabled = false;

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "nav_", 1) == false)
            {
                return;
            }

            navigations_view.MoveLast();
            getserachdata();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "nav_", 1) == false)
            {
                return;
            }

            navigations_view.MoveNext();
            getserachdata();

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "nav_", 1) == false)
            {
                return;
            }

            navigations_view.MovePrev();
            getserachdata();
        }

        private void txt_serach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow[] searchrow;
                searchrow = dt_navigations.Select("invoice_no='" + txt_serach.Text + "'");
                if (searchrow.Length > 0)
                {
                    dt_products.Columns.Remove("id");
                    dt_products.Columns.Add("id", typeof(int));
                    dt_products.Columns["id"].AutoIncrement = true;
                    dt_products.Columns["id"].AutoIncrementSeed = 1;
                    dt_products.Columns["id"].AutoIncrementStep = 1;

                    string move_no = searchrow[0][0].ToString();
                    SqlParameter[] p = new SqlParameter[1];
                    p[0] = new SqlParameter("@move_no", move_no);
                    DataTable dt = new DataTable();
                    dt = cd.getdata("sp_returnpurchasemain", p);
                    txt_invice_no.Text = dt.Rows[0]["invoice_no"].ToString();
                    cmb_stores.EditValue = dt.Rows[0]["store_code"];

                    SqlParameter[] p1 = new SqlParameter[1];
                    p1[0] = new SqlParameter("@move_no", move_no);
                    DataTable dt2 = new DataTable();
                    dt2 = cd.getdata("sp_returnpurchasedetails", p1);
                    dt_products.Clear();
                    foreach (DataRow item in dt2.Rows)
                    {
                        DataRow newrows;
                        newrows = dt_products.NewRow();
                        newrows["product_code"] = item["product_code"].ToString();

                        SqlParameter[] pa = new SqlParameter[2];
                        pa[0] = new SqlParameter("@product_code", int.Parse(item["product_code"].ToString()));
                        pa[1] = new SqlParameter("@store_id", cmb_stores.EditValue);
                        DataTable dt_qty = new DataTable();
                        dt_qty = cd.getdata("sp_prodcust_balance", pa);

                        newrows["product_name"] = item["product_name"].ToString();
                        newrows["available_qty"] = Convert.ToDecimal(dt_qty.Rows[0][0].ToString());
                        newrows["unit_name"] = item["unit_name"].ToString();
                        newrows["qty"] = item["qty"];
                        newrows["price"] = item["price"];
                        dt_products.Rows.Add(newrows);
                    }
                    updatetotal();
                    calculating_value();
                    addnew = false;

                }
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "delete_", 1) == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(txt_invice_no.Text)) { return; }
            if(MSg.showmsg("هل تريد حذف بيانات الفاتورة",MSg.msgbutton.okcancel,MSg.msgicon.delete)==MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@move_no", int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
                p[1] = new SqlParameter("@invoice_no", int.Parse(navigations_view.GetFocusedRowCellValue("invoice_no").ToString()));
                p[2] = new SqlParameter("@invoice_type", "بيع");
                cd.runproc("sp_movesdelete", p);
                cleardata();
                binding_navigations();
                addnew = true;
            }

        }

        private void txt_serach_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void searchControl1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "[product_name] like '%" + searchControl1.Text + "%'" ;
            updatetotal();
        }

        private void gridControl2_VisibleChanged(object sender, EventArgs e)
        {
            if(gridControl2.Visible==false)
            {
            }
            else
            {
                bindingproducts();
            }
        }

        private void cmb_vendors_EditValueChanged(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[1];
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_vendorbalance", p);
            if (dt.Rows.Count == 0) { return; }
        }

        private void simpleButton12_Click_1(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "تسوية مخزن", "add_new", 1) == false)
            {
                return;
            }

            gridView1.ActiveFilter.Clear();

            if (gridView1.RowCount == 0)
            {
                MSg.showmsg("لا يمكن حفظ فاتورة شراء خالية من الأصناف", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            #region addnew invoice.....
            if (addnew == true)
            {
            SqlParameter[] param = new SqlParameter[7];
            param[0]=new SqlParameter("@move_type","تسوية");
            param[1]=new SqlParameter("@move_date",Convert.ToDateTime(txt_date.Text));
            param[2]=new SqlParameter("@invoice_no",txt_invice_no.Text);
            param[3]=new SqlParameter("@store_code",cmb_stores.EditValue);
            param[4]=new SqlParameter("@user_id", connectiondata.user_id);
            param[5]=new SqlParameter("@purchasetable",dt_products);
            param[6] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            cd.runproc("sp_Adjustinsert", param);
                MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
                binding_navigations();
                bindingsearch();
                //print invoicedata
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                para[1] = new SqlParameter("@invoice_type", "تسوية");
                DataTable dt_r = new DataTable();
                dt_r = cd.getdata("rpt_purchaseInvoicePrint", para);
                ROSESONLY.reports.rpt_purchaseInvoice rpt = new reports.rpt_purchaseInvoice();
                rpt.DataSource = dt_r;
                frm_showreports frm1 = new frm_showreports();
                frm1.documentViewer1.DocumentSource = rpt;
                frm1.ShowDialog();
                cleardata();
                gridControl2.Visible = false;

                return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[7];
            param1[0] = new SqlParameter("@move_type", "تسوية");
            param1[1] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
            param1[2] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            param1[3] = new SqlParameter("@store_code", cmb_stores.EditValue);
            param1[4] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            param1[5] = new SqlParameter("@purchasetable", dt_products);
            int rowno = navigations_view.FocusedRowHandle;
            param1[6] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
            cd.runproc("sp_AdjustUpdate", param1);

            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            //print invoicedata
            SqlParameter[] pam = new SqlParameter[2];
            pam[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            pam[1] = new SqlParameter("@invoice_type", "تسوية");
            DataTable dt_r1 = new DataTable();
            dt_r1 = cd.getdata("rpt_purchaseInvoicePrint", pam);
            ROSESONLY.reports.rpt_purchaseInvoice rpt1 = new reports.rpt_purchaseInvoice();
            rpt1.DataSource = dt_r1;
            frm_showreports frm2 = new frm_showreports();
            frm2.documentViewer1.DocumentSource = rpt1;
            frm2.ShowDialog();

            cleardata();
            addnew = true;
            gridControl2.Visible = false;
            cmb_stores.Enabled = true;

            #endregion

        }

        private void lb_noitems_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void ck_productRepet_CheckedChanged(object sender, EventArgs e)
        {

        }
        //******************************   


    }
}