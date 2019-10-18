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
using ROSESONLY.reports;
using DevExpress.XtraReports.UI;

namespace ROSESONLY.forms
{
    public partial class frm_salesreturn : DevExpress.XtraEditors.XtraForm
    {
        int timer_intrvale = 0;
        connectiondata cd = new connectiondata();
        bool addnew = true;
        private static frm_salesreturn frm;
        public  DataTable dt_products = new DataTable();
        DataTable dt_navigations = new DataTable();
        int code;
       public  decimal discount_value;
       public decimal discount_persent;
        decimal buy_price;
        bool validating = true;
        public int m_value = 0;
        static void form_closed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_salesreturn get_main
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_salesreturn();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                } return frm;
            }
        }
        public frm_salesreturn()
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
            dt_products.Columns.Add("discount_value",typeof(decimal));
            dt_products.Columns.Add("total", typeof(decimal), "(qty*price)-discount_value");
            dt_products.Columns.Add("buy_price",typeof(decimal));
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
            dt = cd.getdata("sp_salesBindingProducts", p);
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
        void bindingcashier()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@user_id", connectiondata.user_id);

            dt = cd.getdata("sp_bindingcashier", p);
            cmb_cashier.Properties.DataSource = dt;
            cmb_cashier.Properties.DisplayMember = "cashier_name";
            cmb_cashier.Properties.ValueMember = "cashier_id";
            txt_discount.Text = "0";
            dt_products.Clear();
            bindinginvoiceNO();
        }
        void cleardata()
        {
            cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());
            txt_purchaseno.Text = string.Empty;
            txt_lastbalance.Text = "0";
            dt_products.Clear();
            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            txt_discount.Text = "0";
            bindinginvoiceNO();
            txt_total.Text = "0";
            gridControl2.Visible = false;
        }
        void bindingsearch()
        {
            txt_serach.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_serach.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_code", connectiondata.user_id);
            p[1] = new SqlParameter("@move_type", "مرتجع بيع");

            dt = cd.getdata("sp_MoviesNavigation", p);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt_serach.MaskBox.AutoCompleteCustomSource.Add(dt.Rows[i][1].ToString());
            }
        }
        void loading_data()
        {
            bindingaccounts();
            bindingstores();
            bindingcashier();
            bindinginvoiceNO();
            txt_date.Text = DateTime.Today.ToShortDateString();
            binding_navigations();
            //custmize form  whith main setting
            cmb_stores.EditValue = Properties.Settings.Default.main_store;
            cmb_cashier.EditValue = Properties.Settings.Default.main_cashier;
            cmb_vendors.EditValue = Properties.Settings.Default.mainaccount;
            auto_insert.EditValue = Properties.Settings.Default.auto_add;
            auto_changeprice.EditValue = Properties.Settings.Default.change_price;
            ck_productRepet.EditValue = Properties.Settings.Default.repeate;
            use_parcode.EditValue = Properties.Settings.Default.use_barcode;
            if (m_value != 0)
            {
                getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
            }

        }
        private void frm_purchase_Load(object sender, EventArgs e)
        {
            timer2.Start();
            progressPanel1.Visible = true;
        }
        public void bindingaccounts()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingaccounts", null);
            cmb_vendors.Properties.DataSource = dt;
            cmb_vendors.Properties.DisplayMember = "account_name";
            cmb_vendors.Properties.ValueMember = "account_code";
        }
        void bindinginvoiceNO()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_type", "مرتجع بيع");
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
                   txt_code.Properties.Items.Clear();
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
                        txt_qty.Text = txt_defaultqty.Text;
                        txt_qty.Focus();
                        bindingunits(int.Parse(dt.Rows[0]["product_code"].ToString()));
                        code=int.Parse(dt.Rows[0]["product_code"].ToString());
                        if (Convert.ToBoolean(larg_price.EditValue) == true)
                        {
                            discount_value = 0;
                            txt_price.Text = dt.Rows[0]["larg_price"].ToString();
                        }
                        else
                        {
                            txt_price.Text = dt.Rows[0]["sell_price"].ToString();
                            discount_value = Convert.ToDecimal(dt.Rows[0]["discount_value"].ToString())/100*Convert.ToDecimal(txt_price.Text);
                            discount_persent=Convert.ToDecimal(dt.Rows[0]["discount_value"].ToString())/100;
                        }
                        buy_price = Convert.ToDecimal(dt.Rows[0]["average_price"].ToString());
                        errorProvider1.Dispose();
                        if (Convert.ToBoolean(auto_insert.EditValue) == true)
                        {
                            addnewproduct();
                        }
                    }
                    else
                    {
                    getselected_product();
                }
            }

            //gridControl2.Visible = false;
        }
        private void searchControl1_Leave(object sender, EventArgs e)
        {
        }
        private void txt_code_EditValueChanged(object sender, EventArgs e)
        {
          //  bindingproducts();
            if (string.IsNullOrEmpty(txt_code.Text)) { clearproduct_data(); }
            gridView2.ActiveFilter.Clear();
            gridView2.ActiveFilterString = "[product_name]+[product_code] like '%" + txt_code.Text + "%'";
            if (Convert.ToBoolean(use_parcode.EditValue) == true) { return; }
            if (gridView2.RowCount==0)
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
            txt_price.Text = dt.Rows[0][1].ToString();
            discount_value = discount_persent * Convert.ToDecimal(txt_price.Text);
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
            if(string.IsNullOrEmpty(txt_code.Text))
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
            SqlParameter[] ps = new SqlParameter[2];
            ps[0] = new SqlParameter("@unit_name", txt_unit.Text);
            ps[1] = new SqlParameter("@product_code", code);
            DataTable dt_unit = new DataTable();
            dt_unit = cd.getdata("sp_bindingprice", ps);

            //get the quantity of product adding befor in the datatable
            decimal q = 0;
            foreach (DataRow item in dt_products.Rows)
            {
                if(int.Parse(item["product_code"].ToString())==code)
                {
                    q += Convert.ToDecimal(item["qty"].ToString()) * Convert.ToDecimal(dt_unit.Rows[0][2].ToString());
                }
            }
           
            //check product price is less then limite price................
            #region checkprice
            DataTable dt_price = new DataTable();
            SqlParameter[] p_price = new SqlParameter[1];
            p_price[0] = new SqlParameter("@product_code", code);
            dt_price = cd.getdata("sp_getlimiteprice", p_price);
            if(dt_price.Rows.Count!=0)
            {
                    if(Convert.ToDecimal(dt_price.Rows[0]["limit_sellprice"].ToString())>Convert.ToDecimal(txt_price.Text))
                    {
                        MSg.showmsg("سعر البيع أقل من  السعر المسموح به ", MSg.msgbutton.ok, MSg.msgicon.information);
                    }
            }
            #endregion
            // check if product was added befor in the invoice
            DataRow[] findrow;
            findrow = dt_products.Select("product_code=" +code + "");
          
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
                    newproduct["discount_value"] = discount_value*Convert.ToDecimal(txt_qty.Text);
                    newproduct["buy_price"] = buy_price;
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
                    findrow[0]["discount_value"] = (decimal.Parse(findrow[0]["qty"].ToString()) + decimal.Parse(txt_qty.Text)) * discount_value;
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
                newproduct["discount_value"] = discount_value * Convert.ToDecimal(txt_qty.Text);
                newproduct["buy_price"] = buy_price;
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
            code = 0;
            discount_persent = 0;
            discount_value = 0;
            buy_price = 0;
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
            if (string.IsNullOrEmpty(txt_discount.Text)) { return; }
            decimal total = string.IsNullOrEmpty(txt_total.Text)?Convert.ToDecimal("0"): Convert.ToDecimal(txt_total.Text);
            decimal discount = string.IsNullOrEmpty(txt_discount.Text) ? Convert.ToDecimal("0") : Convert.ToDecimal(txt_discount.Text);
            txt_net.Text = (total - discount).ToString();
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
            txt_discount2.Text = txt_discount.Text;
            calculating_value();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
            frm_purchasepay frm = new frm_purchasepay();
            frm.txt_remain.Text = (Convert.ToDecimal(txt_total.Text) - Convert.ToDecimal(txt_discount.Text)).ToString();
            frm.total = (Convert.ToDecimal(txt_total.Text) - Convert.ToDecimal(txt_discount.Text));
           // frm.txt_paid.Text = Convert.ToDecimal(txt_paidvalue.Text).ToString();
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
               if(gridControl2.Visible==false)
               {
               gridControl2.Visible = true;
               }
               else
               {
               gridControl2.Visible = false;
               }
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
                int code_product = int.Parse(gridView1.GetRowCellValue(selectrow, "product_code").ToString());
               decimal dis=Convert.ToDecimal(gridView1.GetRowCellValue(selectrow,"discount_value").ToString());
               discount_value = dis / (price * qty);
                
                frm.cmb_unit.Text = gridView1.GetRowCellValue(selectrow, "unit_name").ToString();
                frm.id = int.Parse(gridView1.GetRowCellValue(selectrow, "id").ToString());
                frm.txt_qty.Text = qty.ToString();
                frm.txt_productname.Text = product_name.ToString();
                frm.txt_price.Text = price.ToString();
                frm.product_code = code_product;
                frm.bindingunits(code_product);
                frm.form_name = "sales_return";
                frm.qty = qty;
                frm.available_qty = decimal.Parse(gridView1.GetRowCellValue(selectrow, "available_qty").ToString());
                if(addnew==true)
                {
                frm.addnew = true ;
                }else{
                frm.addnew = false;
                }
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
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "add_new", 1) == false)
            {
                return;
            }

            gridView1.ActiveFilter.Clear();
            if (radioGroup1.EditValue.ToString() == "اجل")
          {
                if (string.IsNullOrEmpty(cmb_vendors.Text))
                {
                    errorProvider1.SetError(cmb_vendors, "يرجى أدخال أسم الحساب فى حاله ان الفاتورة اجلة");
                    return;
                }
                if (cmb_vendors.EditValue.ToString() == XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString())
                {
                    errorProvider1.SetError(cmb_vendors, "يرجى أختيار عميل أخر غير العميل المباشر");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
            }
            if (gridView1.RowCount==0)
            {
                MSg.showmsg("لا يمكن حفظ فاتورة  خالية من الأصناف", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            #region addnew invoice.....
            if(addnew==true)
            {
            bindinginvoiceNO();
            SqlParameter[] param = new SqlParameter[12];
            param[0]=new SqlParameter("@move_type","مرتجع بيع");
            param[1]=new SqlParameter("@move_date",Convert.ToDateTime(txt_date.Text));
            param[2]=new SqlParameter("@invoice_no",txt_invice_no.Text);
            param[3]=new SqlParameter("@store_code",cmb_stores.EditValue);
            param[4]=new SqlParameter("@account_code",string .IsNullOrEmpty(cmb_vendors.Text)?int.Parse("0"):cmb_vendors.EditValue);
            param[5]=new SqlParameter("@purchase_no",string.IsNullOrEmpty(txt_purchaseno.Text)?0: int.Parse(txt_purchaseno.Text));
            param[6]=new SqlParameter("@pay_type",radioGroup1.EditValue);
            param[7]=new SqlParameter("@discount",decimal.Parse(txt_discount.Text));
            param[8]=new SqlParameter("@total_value",decimal.Parse(txt_total.Text));
            param[9]=new SqlParameter("@cashier_code",cmb_cashier.EditValue);
            param[10]=new SqlParameter("@user_id", connectiondata.user_id);
            param[11]=new SqlParameter("@purchasetable",dt_products);
            cd.runproc("sp_salesinsert", param);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            binding_navigations();
            bindingsearch();
                if(radioGroup1.EditValue.ToString()=="نقدى")
                {
                    SqlParameter[] p = new SqlParameter[7];
                    p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[2] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_cashermoveInser", p);
                }
                cleardata();
                gridControl2.Visible = false;
            return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[13];
            param1[0] = new SqlParameter("@move_type", "مرتجع بيع");
            param1[1] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
            param1[2] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            param1[3] = new SqlParameter("@store_code", cmb_stores.EditValue);
            param1[4] = new SqlParameter("@account_code", cmb_vendors.EditValue);
            param1[5] = new SqlParameter("@purchase_no", string.IsNullOrEmpty(txt_purchaseno.Text) ? 0 : int.Parse(txt_purchaseno.Text));
            param1[6] = new SqlParameter("@pay_type", radioGroup1.EditValue);
            param1[7] = new SqlParameter("@discount", decimal.Parse(txt_discount.Text));
            param1[8] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            param1[9] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
            param1[10] = new SqlParameter("@user_id", connectiondata.user_id);
            param1[11] = new SqlParameter("@purchasetable", dt_products);
           int rowno=navigations_view.FocusedRowHandle;
           param1[12] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
           cd.runproc("sp_salesUpdate", param1);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
          //update esal data
            #region CashierData
            if (radioGroup1.EditValue.ToString() == "نقدى")
            {
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@invoice_no", int.Parse(txt_invice_no.Text));
                pa[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_searchINCashier", pa);
                if (dt.Rows.Count == 0)
                {
                    SqlParameter[] p = new SqlParameter[7];
                    p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[2] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_cashermoveInser", p);
                }
                else
                {
                    SqlParameter[] p = new SqlParameter[6];
                    p[0] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[1] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[2] = new SqlParameter("@creadit_value", Convert.ToDecimal(txt_net.Text));
                    p[3] = new SqlParameter("@debit_value",Convert.ToDecimal("0"));
                    p[4] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[5] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_casiermoviesupdate", p);
                }
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                cd.runproc("sp_deletecashier", p);
                if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                {
                    frm_payesal frm = new frm_payesal();
                    frm.lb_total.Text = txt_net.Text;
                    frm.form_name = "sales_return";
                    frm.ShowDialog();
                }

            }

            #endregion

            cleardata();
            addnew = true;
            cmb_stores.Enabled = true;
            gridControl2.Visible = false;
            #endregion

        }


        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//when user press enter .........
            {

                getselected_product();
            }
            if (e.KeyCode == Keys.Up)//when user click up..........
            {
                if (gridView2.FocusedRowHandle == 1)
                {
                    txt_code.Focus();
                }
            }

        }
         void getselected_product()
        {
            int product_code = int.Parse(gridView2.GetFocusedRowCellValue("product_code").ToString());
            string product_name = gridView2.GetFocusedRowCellValue("product_name").ToString();
            string unit_name = gridView2.GetFocusedRowCellValue("unit_name").ToString();
            string def_price = gridView2.GetFocusedRowCellValue("sell_price").ToString();
            txt_code.Text = product_name.ToString();
            bindingunits(product_code);
            code = product_code;
            txt_unit.Text = unit_name;
            txt_price.Text = def_price;
            txt_qty.Text = txt_defaultqty.Text;
            txt_qty.Focus();
            buy_price = Convert.ToDecimal(gridView2.GetFocusedRowCellValue("average_price").ToString());

            //add new item to dt_products automaticly.....................
            if (Convert.ToBoolean(auto_insert.EditValue) == true)
            {
                addnewproduct();
            }

        }
        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            getselected_product();
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

        void binding_navigations()
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_code", connectiondata.user_id);
            p[1] = new SqlParameter("@move_type", "مرتجع بيع");

            dt_navigations = cd.getdata("sp_MoviesNavigation", p);
            grid_navigtions.DataSource = dt_navigations;

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "nav_", 1) == false)
            {
                return;
            }

            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MoveFirst();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
        }
        void getserachdata(int move_no)
        {
            if (navigations_view.RowCount == 0) { return; }

            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_no", move_no);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_returnpurchasemain", p);
            txt_invice_no.Text = dt.Rows[0]["invoice_no"].ToString();
            txt_purchaseno.Text = dt.Rows[0]["purchase_no"].ToString();
            cmb_vendors.EditValue = dt.Rows[0]["account_code"];
            cmb_stores.EditValue = dt.Rows[0]["store_code"];
            cmb_cashier.EditValue = dt.Rows[0]["cashier_code"];
            txt_discount.Text = dt.Rows[0]["discount"].ToString();
            radioGroup1.EditValue = dt.Rows[0]["pay_type"].ToString(); 

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
                newrows["discount_value"] = item["discount_value"];
                newrows["buy_price"] = item["buy_price"];
                dt_products.Rows.Add(newrows);
            }
            updatetotal();
            calculating_value();
            addnew = false;
            cmb_stores.Enabled = false;

        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "nav_", 1) == false)
            {
                return;
            }
            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MoveLast();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "nav_", 1) == false)
            {
                return;
            }
            if (navigations_view.RowCount == 0) { return; }

            if (navigations_view.RowCount == 0) { return; }

            navigations_view.MoveNext();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));


        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "nav_", 1) == false)
            {
                return;
            }
            if (navigations_view.RowCount == 0) { return; }

            if (navigations_view.RowCount == 0) { return; }

            navigations_view.MovePrev();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void txt_serach_KeyDown(object sender, KeyEventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "nav_", 1) == false)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                int invoice_no = int.Parse(txt_serach.Text);
                DataRow[] _row;
                _row = dt_navigations.Select("invoice_no=" + invoice_no + "");
                if (_row.Length != 0)
                {
                    getserachdata(int.Parse(_row[0]["move_no"].ToString()));
                    int focusedrow = int.Parse(navigations_view.LocateByValue("invoice_no", invoice_no, null).ToString());
                    navigations_view.FocusedRowHandle = focusedrow;

                }
            }

            //if (e.KeyCode==Keys.Enter)
            //{
            //    DataRow[] searchrow;
            //    searchrow = dt_navigations.Select("invoice_no='" + txt_serach.Text + "'");
            //    if (searchrow.Length > 0)
            //    {
            //        dt_products.Columns.Remove("id");
            //        dt_products.Columns.Add("id", typeof(int));
            //        dt_products.Columns["id"].AutoIncrement = true;
            //        dt_products.Columns["id"].AutoIncrementSeed = 1;
            //        dt_products.Columns["id"].AutoIncrementStep = 1;

            //        string move_no = searchrow[0]["move_no"].ToString();
            //        SqlParameter[] p = new SqlParameter[1];
            //        p[0] = new SqlParameter("@move_no", move_no);
            //        DataTable dt = new DataTable();
            //        dt = cd.getdata("sp_returnpurchasemain", p);
            //        txt_invice_no.Text = dt.Rows[0]["invoice_no"].ToString();
            //        txt_purchaseno.Text = dt.Rows[0]["purchase_no"].ToString();
            //        cmb_vendors.EditValue = dt.Rows[0]["account_code"];
            //        cmb_stores.EditValue = dt.Rows[0]["store_code"];
            //        cmb_cashier.EditValue = dt.Rows[0]["cashier_code"];
            //        txt_discount.Text = dt.Rows[0]["discount"].ToString();

            //        SqlParameter[] p1 = new SqlParameter[1];
            //        p1[0] = new SqlParameter("@move_no", move_no);
            //        DataTable dt2 = new DataTable();
            //        dt2 = cd.getdata("sp_returnpurchasedetails", p1);
            //        dt_products.Clear();
            //        foreach (DataRow item in dt2.Rows)
            //        {
            //            DataRow newrows;
            //            newrows = dt_products.NewRow();
            //            newrows["product_code"] = item["product_code"].ToString();

            //            SqlParameter[] pa = new SqlParameter[2];
            //            pa[0] = new SqlParameter("@product_code", int.Parse(item["product_code"].ToString()));
            //            pa[1] = new SqlParameter("@store_id", cmb_stores.EditValue);
            //            DataTable dt_qty = new DataTable();
            //            dt_qty = cd.getdata("sp_prodcust_balance", pa);

            //            newrows["product_name"] = item["product_name"].ToString();
            //            newrows["available_qty"] = Convert.ToDecimal(dt_qty.Rows[0][0].ToString());
            //            newrows["unit_name"] = item["unit_name"].ToString();
            //            newrows["qty"] = item["qty"];
            //            newrows["price"] = item["price"];
            //            dt_products.Rows.Add(newrows);
            //        }
            //        updatetotal();
            //        calculating_value();
            //        addnew = false;

            //    }
            //}
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "delete_", 1) == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(txt_invice_no.Text)) { return; }
            if(MSg.showmsg("هل تريد حذف بيانات الفاتورة",MSg.msgbutton.okcancel,MSg.msgicon.delete)==MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@move_no", int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
                p[1] = new SqlParameter("@invoice_no", int.Parse(navigations_view.GetFocusedRowCellValue("invoice_no").ToString()));
                p[2] = new SqlParameter("@invoice_type", "مرتجع بيع");
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
            p[0] = new SqlParameter("@account_code", cmb_vendors.EditValue.ToString());
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_vendorbalance", p);
            if (dt.Rows.Count == 0) { return; }
            txt_lastbalance.Text = dt.Rows[0][0].ToString();
        }

        private void simpleButton12_Click_1(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "مرتجع البيع", "add_new", 1) == false)
            {
                return;
            }

            gridView1.ActiveFilter.Clear();

            if (radioGroup1.EditValue.ToString() == "اجل")
            {
                if (string.IsNullOrEmpty(cmb_vendors.Text))
                {
                    errorProvider1.SetError(cmb_vendors, "يرجى أدخال أسم الحساب فى حاله ان الفاتورة اجلة");
                    return;
                }
                if (cmb_vendors.EditValue.ToString() == XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString())
                {
                    errorProvider1.SetError(cmb_vendors, "يرجى أختيار عميل أخر غير العميل المباشر");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
            }
            if (gridView1.RowCount == 0)
            {
                MSg.showmsg("لا يمكن حفظ فاتورة شراء خالية من الأصناف", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            #region addnew invoice.....
            if (addnew == true)
            {
                bindinginvoiceNO();

                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@move_type", "مرتجع بيع");
                param[1] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                param[2] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                param[3] = new SqlParameter("@store_code", cmb_stores.EditValue);
                param[4] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                param[5] = new SqlParameter("@purchase_no", string.IsNullOrEmpty(txt_purchaseno.Text) ? 0 : int.Parse(txt_purchaseno.Text));
                param[6] = new SqlParameter("@pay_type", radioGroup1.EditValue);
                param[7] = new SqlParameter("@discount", decimal.Parse(txt_discount.Text));
                param[8] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
                param[9] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                param[10] = new SqlParameter("@user_id", connectiondata.user_id);
                param[11] = new SqlParameter("@purchasetable", dt_products);
                cd.runproc("sp_salesinsert", param);
                MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
                binding_navigations();
                bindingsearch();
            #region CashierData
            if (radioGroup1.EditValue.ToString() == "نقدى")
            {
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@invoice_no", int.Parse(txt_invice_no.Text));
                pa[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_searchINCashier", pa);
                if (dt.Rows.Count == 0)
                {
                    SqlParameter[] p = new SqlParameter[7];
                    p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[2] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_cashermoveInser", p);
                }
                else
                {
                    SqlParameter[] p = new SqlParameter[6];
                    p[0] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[1] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[2] = new SqlParameter("@creadit_value", Convert.ToDecimal("0"));
                    p[3] = new SqlParameter("@debit_value", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[5] = new SqlParameter("@invoice_type", "مرتجع بيع");
                    cd.runproc("sp_casiermoviesupdate", p);
                }
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                cd.runproc("sp_deletecashier", p);
                if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                {
                    frm_payesal frm = new frm_payesal();
                    frm.lb_total.Text = txt_net.Text;
                    frm.form_name = "sales_return";
                    frm.ShowDialog();
                }
            }
            #endregion
                //print invoicedata
                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                para[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                DataTable dt_r = new DataTable();
                dt_r = cd.getdata("rpt_purchaseInvoicePrint", para);
                XtraReport rpt;
                rpt = new rpt_purchaseInvoice();
                switch (XtraForm1.getmain.dt_setting.Rows[0]["sales_type"].ToString())
                {
                    case "1":
                        rpt = new rpt_purchaseInvoice();
                        break;
                    case "2":
                        rpt = new rpt_invoicerecipit();
                        break;
                    case "3":
                        rpt = new rpt_invoicerecipt2();
                        break;
                }
                rpt.DataSource = dt_r;
                rpt.PrinterName = XtraForm1.getmain.dt_setting.Rows[0]["sales_Rprinter"].ToString();
                rpt.Print();
                cleardata();
                return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[13];
            param1[0] = new SqlParameter("@move_type", "مرتجع بيع");
            param1[1] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
            param1[2] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            param1[3] = new SqlParameter("@store_code", cmb_stores.EditValue);
            param1[4] = new SqlParameter("@account_code", cmb_vendors.EditValue);
            param1[5] = new SqlParameter("@purchase_no", string.IsNullOrEmpty(txt_purchaseno.Text) ? 0 : int.Parse(txt_purchaseno.Text));
            param1[6] = new SqlParameter("@pay_type", radioGroup1.EditValue.ToString());
            param1[7] = new SqlParameter("@discount", decimal.Parse(txt_discount.Text));
            param1[8] = new SqlParameter("@total_value", decimal.Parse(txt_total.Text));
            param1[9] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
            param1[10] = new SqlParameter("@user_id", connectiondata.user_id);
            param1[11] = new SqlParameter("@purchasetable", dt_products);
            int rowno = navigations_view.FocusedRowHandle;
            param1[12] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
            cd.runproc("sp_salesUpdate", param1);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            //print invoicedata
            SqlParameter[] pam = new SqlParameter[2];
            pam[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            pam[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
            DataTable dt_r1 = new DataTable();
            dt_r1 = cd.getdata("rpt_purchaseInvoicePrint", pam);
            XtraReport rpt1;
            rpt1 = new rpt_invoicerecipit();
            switch (XtraForm1.getmain.dt_setting.Rows[0]["sales_type"].ToString())
            {
                case "1":
                    rpt1 = new rpt_purchaseInvoice();
                    break;
                case "2":
                    rpt1 = new rpt_invoicerecipit();
                    break;
                case "3":
                    rpt1 = new rpt_invoicerecipt2();
                    break;
            }
            rpt1.DataSource = dt_r1;
            rpt1.PrinterName = XtraForm1.getmain.dt_setting.Rows[0]["sales_Rprinter"].ToString();
            rpt1.Print();

            //update esal data
            if (radioGroup1.EditValue.ToString() == "نقدى")
            {
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                p[1] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                p[2] = new SqlParameter("@creadit_value", Convert.ToDecimal("0"));
                p[3] = new SqlParameter("@debit_value", Convert.ToDecimal(txt_net.Text));
                p[4] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[5] = new SqlParameter("@invoice_type", "مرتجع بيع");
                cd.runproc("sp_casiermoviesupdate", p);
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[1] = new SqlParameter("@invoice_type", "مرتجع بيع");
                cd.runproc("sp_deletecashier", p);
            }

            cleardata();
            addnew = true;
            cmb_stores.Enabled = true;
            #endregion
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void txt_code_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void txt_purchaseno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_purchaseno.Text)) { return; }
                SqlParameter[] pam = new SqlParameter[2];
                pam[0] = new SqlParameter("@invoice_no", int.Parse(txt_purchaseno.Text));
                pam[1] = new SqlParameter("@user_id", connectiondata.user_id);
                DataTable dt1 = new DataTable();
                dt1 = cd.getdata("sp_getsalesdata", pam);
                if(dt1.Rows.Count==0)
                {
                    errorProvider1.SetError(txt_purchaseno, "يرجى أدخال رقم فاتورة بيع صحيحه");
                }
                else
                {
                    dt_products.Columns.Remove("id");
                    dt_products.Columns.Add("id", typeof(int));
                    dt_products.Columns["id"].AutoIncrement = true;
                    dt_products.Columns["id"].AutoIncrementSeed = 1;
                    dt_products.Columns["id"].AutoIncrementStep = 1;

                    int move_no = int.Parse(dt1.Rows[0][0].ToString());
                    SqlParameter[] p = new SqlParameter[1];
                    p[0] = new SqlParameter("@move_no", move_no);
                    DataTable dt = new DataTable();
                    dt = cd.getdata("sp_returnpurchasemain", p);
                   // txt_invice_no.Text = dt.Rows[0]["invoice_no"].ToString();
                    txt_purchaseno.Text = dt.Rows[0]["purchase_no"].ToString();
                    cmb_vendors.EditValue = dt.Rows[0]["account_code"];
                    cmb_stores.EditValue = dt.Rows[0]["store_code"];
                    cmb_cashier.EditValue = dt.Rows[0]["cashier_code"];
                    txt_discount.Text = dt.Rows[0]["discount"].ToString();
                    radioGroup1.EditValue = dt.Rows[0]["pay_type"].ToString();

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
                        newrows["discount_value"] = item["discount_value"];
                        newrows["buy_price"] = item["buy_price"];
                        dt_products.Rows.Add(newrows);
                    }
                    updatetotal();
                    calculating_value();
                    cmb_stores.Enabled = false;

                }
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            int[] selectedrows = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedrows.Length; i++)
            {
                gridView1.DeleteRow(i);
                dt_products.AcceptChanges();
                updatetotal();
            }
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            bool isfound = false;
            int[] selectedrows = gridView1.GetSelectedRows();
            for (int i = 0; i < gridView1.RowCount-1; i++)
            {
                for (int f = 0; f < selectedrows.Length; f++)
                {
                    if(selectedrows[f]==i)
                    {
                        isfound = true;
                        break;
                    }
                    else
                    {
                        isfound = false;
                    }
                }
                if(isfound==false)
                {
                gridView1.DeleteRow(i);
                dt_products.AcceptChanges();
                updatetotal();
                }
            }

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_invice_no_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_purchaseno_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_date_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer_intrvale += timer2.Interval;
            if(timer_intrvale==100)
            {
                loading_data();
                txt_code.Focus();
                timer2.Stop();
                progressPanel1.Visible = false;
            }
        }

        private void frm_salesreturn_Activated(object sender, EventArgs e)
        {
            binding_navigations();
        }
        //******************************   


    }
}