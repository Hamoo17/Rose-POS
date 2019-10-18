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
using System.Threading;
using ROSESONLY.reports;
using DevExpress.XtraReports.UI;

namespace ROSESONLY.forms
{
    public partial class frm_SalesInvoice : DevExpress.XtraEditors.XtraForm
    {
        int timer_interval = 0;
        int invoice_no = 0;
        connectiondata cd = new connectiondata();
        bool addnew = true;
        private static frm_SalesInvoice frm;
        public DataTable dt_products = new DataTable();
        DataTable dt_navigations = new DataTable();
        int code;
        public decimal discount_value;
        public decimal discount_persent;
        decimal buy_price;
        bool validating = true;
        public int m_value = 0;
        static void form_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_SalesInvoice get_main
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_SalesInvoice();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                }
                return frm;
            }
        }
        public frm_SalesInvoice()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
        }
        void generatdatatable()
        {
            dt_products.Columns.Add("product_code", typeof(int));
            dt_products.Columns.Add("product_name", typeof(string));
            dt_products.Columns.Add("available_qty", typeof(int));
            dt_products.Columns.Add("unit_name", typeof(string));
            dt_products.Columns.Add("qty", typeof(decimal));
            dt_products.Columns.Add("price", typeof(decimal));
            dt_products.Columns.Add("discount_value", typeof(decimal));
            dt_products.Columns.Add("total", typeof(decimal), "(qty*price)-discount_value");
            dt_products.Columns.Add("buy_price", typeof(decimal));
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
            //DataTable dt = new DataTable();
            //dt = cd.getdata("sp_bindingstores", null);
            //cmb_stores.Properties.DataSource = dt;
            //cmb_stores.Properties.DisplayMember = "store_name";
            //cmb_stores.Properties.ValueMember = "store_id";
        }
        void bindingcashier()
        {
            //DataTable dt = new DataTable();
            //dt = cd.getdata("sp_bindingcashier", null);
            //cmb_cashier.Properties.DataSource = dt;
            //cmb_cashier.Properties.DisplayMember = "cashier_name";
            //cmb_cashier.Properties.ValueMember = "cashier_id";
            //txt_discount.Text = "0";
            //dt_products.Clear();
            //bindinginvoiceNO();
        }
        void cleardata()
        {
            cmb_vendors.EditValue = 0;
            //txt_purchaseno.Text = string.Empty;
            txt_lastbalance.Text = "0";
            txt_date.Text = Convert.ToDateTime(DateTime.Today).ToShortDateString();
            dt_products.Clear();
            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            txt_discount.Text = "0";
            bindinginvoiceNO();
            txt_total.Text = "0";
            txt_net.Text = "0";
            lb_countity.Text = string.Empty;
            lb_productscount.Text = string.Empty;
            lb_total.Text = string.Empty;
            gridControl2.Visible = false;
            txt_code.Focus();
        }
        void bindingsearch()
        {
            //txt_serach.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txt_serach.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            //DataTable dt = new DataTable();
            //SqlParameter[] p = new SqlParameter[2];
            //p[0] = new SqlParameter("@user_code", connectiondata.user_id);
            //p[1] = new SqlParameter("@move_type", "بيع");

            //dt = cd.getdata("sp_MoviesNavigation", p);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    txt_serach.MaskBox.AutoCompleteCustomSource.Add(dt.Rows[i][1].ToString());
            //}
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
            p[0] = new SqlParameter("@move_type", "بيع");

            DataTable dt = new DataTable();
            dt = cd.getdata("sp_BindingMoviesNO", p);
            txt_invice_no.Text = dt.Rows[0][0].ToString();
            invoice_no=int.Parse(dt.Rows[0][0].ToString());
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
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@code", code);
            p[1] = new SqlParameter("@store_id", cmb_stores.EditValue);
            p[2] = new SqlParameter("@unit", txt_unit.Text);
            DataSet dts = new DataSet();
            dts = cd.get_dataset("sp_getproductsdata", p);
            //get the quantity of product adding befor in the datatable
            decimal q = 0;
            foreach (DataRow item in dt_products.Rows)
            {
                if (int.Parse(item["product_code"].ToString()) == code)
                {
                    q += Convert.ToDecimal(item["qty"].ToString()) * Convert.ToDecimal(dts.Tables[1].Rows[0][2].ToString());
                }
            }

            if (Convert.ToDecimal(dts.Tables[0].Rows[0][0].ToString()) < (Convert.ToDecimal(txt_qty.Text) * decimal.Parse(dts.Tables[1].Rows[0][2].ToString())) + q)
            {
                MSg.showmsg("عفوا الكمية المتاحة أقل من الكمية المطلوبة  متاح " + Math.Round((decimal.Parse(dts.Tables[0].Rows[0][0].ToString()) / decimal.Parse(dts.Tables[1].Rows[0][2].ToString())), 2), MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            //check product price is less then limite price................
            #region checkprice
            if (dts.Tables[2].Rows.Count != 0)
            {
                if (Convert.ToDecimal(dts.Tables[2].Rows[0]["limit_sellprice"].ToString()) > Convert.ToDecimal(txt_price.Text))
                {
                    MSg.showmsg("سعر البيع أقل من  السعر المسموح به ", MSg.msgbutton.ok, MSg.msgicon.information);
                }
            }
            #endregion
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
                    newproduct["available_qty"] = Convert.ToDecimal(dts.Tables[0].Rows[0][0].ToString());
                    newproduct["discount_value"] = Math.Round(discount_value * Convert.ToDecimal(txt_qty.Text), 2);
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
                newproduct["available_qty"] = Convert.ToDecimal(dts.Tables[0].Rows[0][0].ToString());
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
            txt_unit.Properties.Items.Clear();
        }
        void calculating_value()
        {
            if (string.IsNullOrEmpty(txt_discount.Text)) { return; }
            decimal total = string.IsNullOrEmpty(txt_total.Text) ? Convert.ToDecimal("0") : Convert.ToDecimal(txt_total.Text);
            decimal discount = string.IsNullOrEmpty(txt_discount.Text) ? Convert.ToDecimal("0") : Convert.ToDecimal(txt_discount.Text);
            txt_net.Text = (total - discount).ToString();
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
        void binding_navigations()
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_code", connectiondata.user_id);
            p[1] = new SqlParameter("@move_type", "بيع");
            dt_navigations = cd.getdata("sp_MoviesNavigation", p);
            grid_navigtions.DataSource = dt_navigations;
        }
        void getserachdata(int move_no)
        {
            frm_mainpage frm = new frm_mainpage();
            if (frm.checkpermissions(connectiondata.user_id, "فواتير البيع", "nav_", 1) == false)
            {
                return;
            }
            if (navigations_view.RowCount == 0) { return; }
            dt_products.Columns.Remove("id");
            dt_products.Columns.Add("id", typeof(int));
            dt_products.Columns["id"].AutoIncrement = true;
            dt_products.Columns["id"].AutoIncrementSeed = 1;
            dt_products.Columns["id"].AutoIncrementStep = 1;
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_no", move_no);
            DataSet dts = new DataSet();
            dts = cd.get_dataset("sp_getinvoicedata", p);
            txt_invice_no.Text = dts.Tables[0].Rows[0]["invoice_no"].ToString();
            invoice_no = int.Parse(dts.Tables[0].Rows[0]["invoice_no"].ToString());
            txt_purchaseno.Text = dts.Tables[0].Rows[0]["purchase_no"].ToString();
            cmb_vendors.EditValue = dts.Tables[0].Rows[0]["account_code"];
            cmb_stores.EditValue = dts.Tables[0].Rows[0]["store_code"];
            cmb_cashier.EditValue = dts.Tables[0].Rows[0]["cashier_code"];
            txt_discount.Text = dts.Tables[0].Rows[0]["discount"].ToString();
            radioGroup1.EditValue = dts.Tables[0].Rows[0]["pay_type"].ToString();
            txt_date.Text = Convert.ToDateTime(dts.Tables[0].Rows[0]["move_date"]).ToString("d");
            dt_products.Clear();
            foreach (DataRow item in dts.Tables[1].Rows)
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
            addnew = false;
            cmb_stores.Enabled = false;

        }
        void changeprice()
        {
            if (Convert.ToBoolean(auto_changeprice.EditValue) == true)
            {
                foreach (DataRow item in dt_products.Rows)
                {
                    SqlParameter[] p25 = new SqlParameter[3];
                    p25[0] = new SqlParameter("@product_code", int.Parse(item["product_code"].ToString()));
                    p25[1] = new SqlParameter("@price", Convert.ToDecimal(item["price"]).ToString());
                    p25[2] = new SqlParameter("@unit_name", item["unit_name"].ToString());
                    cd.runproc("sp_changsellprice", p25);
                }
            }

        }
        public void updatetotal()
        {
            txt_total.Text = Math.Round(Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue), 2).ToString();
            calculating_value();
            lb_productscount.Text = gridView1.Columns["product_code"].SummaryItem.SummaryValue.ToString();
            lb_total.Text = Math.Round(Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue), 2).ToString();
            lb_countity.Text = Convert.ToDecimal(gridView1.Columns["qty"].SummaryItem.SummaryValue).ToString();

        }
        string looading_data()
        {
                generatdatatable();
                //det data from database in to dataset>>>>
                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@move_type", "بيع");
                p[1] = new SqlParameter("@user_id", connectiondata.user_id);
                ds = cd.get_dataset("sp_loading_data", p);
                //binding accounts data........
                cmb_vendors.Properties.DataSource = ds.Tables[0];
                cmb_vendors.Properties.DisplayMember = "account_name";
                cmb_vendors.Properties.ValueMember = "account_code";
                //binding cashier data................
                cmb_cashier.Properties.DataSource = ds.Tables[2];
                cmb_cashier.Properties.DisplayMember = "cashier_name";
                cmb_cashier.Properties.ValueMember = "cashier_id";
                //binding stores .......................
                cmb_stores.Properties.DataSource = ds.Tables[1];
                cmb_stores.Properties.DisplayMember = "store_name";
                cmb_stores.Properties.ValueMember = "store_id";
                //get invoice no............
                txt_invice_no.Text = ds.Tables[3].Rows[0][0].ToString();
                //binding navigations..............
                dt_navigations = ds.Tables[4];
                grid_navigtions.DataSource = dt_navigations;

                txt_date.Text = DateTime.Today.ToShortDateString();
                txt_discount.Text = "0";
            //custmize form  whith main setting
            cmb_stores.EditValue = Properties.Settings.Default.main_store; 
            cmb_cashier.EditValue = Properties.Settings.Default.main_cashier;
            cmb_vendors.EditValue = Properties.Settings.Default.mainaccount;
            auto_insert.EditValue = Properties.Settings.Default.auto_add;
            auto_changeprice.EditValue = Properties.Settings.Default.change_price;
            ck_productRepet.EditValue = Properties.Settings.Default.repeate;
            use_parcode.EditValue = Properties.Settings.Default.use_barcode;
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "فواتير البيع", "change_date", 2) == true)
                {
                    txt_date.ReadOnly = false;
                }
                if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "فواتير البيع", "pr_changeprice", 2) == true)
                {
                    txt_price.ReadOnly = false;
                }

                if (m_value != 0)
                {
                    getserachdata(m_value);
                    m_value = 0;
                }
            string x = "";
            return x;
        }
        private void frm_SalesInvoice_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressPanel1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            });
        }

        private void frm_SalesInvoice_Activated(object sender, EventArgs e)
        {
            binding_navigations();
            //bindingsearch();
        }

        private void frm_SalesInvoice_MouseEnter(object sender, EventArgs e)
        {

        }

        private void use_parcode_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(use_parcode.EditValue) == true)
            {
                gridControl2.Visible = false;
            }

        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MoveFirst();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MovePrev();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void txt_serach_KeyDown(object sender, KeyEventArgs e)
        {
            frm_mainpage frm = new frm_mainpage();
            if (frm.checkpermissions(connectiondata.user_id, "فواتير البيع", "nav_", 1) == false)
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

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MoveNext();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));

        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            if (navigations_view.RowCount == 0) { return; }
            navigations_view.MoveLast();
            getserachdata(int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));


        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "فواتير البيع", "add_new", 1) == false)
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
                if(int.Parse(cmb_vendors.EditValue.ToString()) ==Properties.Settings.Default.mainaccount)
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
                param[0] = new SqlParameter("@move_type", "بيع");
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
                changeprice();
                if (radioGroup1.EditValue.ToString() == "نقدى")
                {
                    SqlParameter[] p = new SqlParameter[7];
                    p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[2] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_salesmoveInser", p);
                }
                else
                {
                    if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                    {
                        frm_payesal frm_ = new frm_payesal();
                        frm_.lb_total.Text = txt_net.Text;
                        frm_.form_name = "sales";
                        frm_.ShowDialog();
                    }
                }
                cleardata();
                gridControl2.Visible = false;
                cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());
                return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[13];
            param1[0] = new SqlParameter("@move_type", "بيع");
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
            int rowno = navigations_view.FocusedRowHandle;
            param1[12] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
            cd.runproc("sp_salesUpdate", param1);
            MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            changeprice();
            //update esal data
            #region CashierData
            if (radioGroup1.EditValue.ToString() == "نقدى")
            {
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@invoice_no", int.Parse(txt_invice_no.Text));
                pa[1] = new SqlParameter("@invoice_type", "بيع");
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
                    p[6] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_salesmoveInser", p);
                }
                else
                {
                    SqlParameter[] p = new SqlParameter[6];
                    p[0] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[1] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[2] = new SqlParameter("@creadit_value", Convert.ToDecimal("0"));
                    p[3] = new SqlParameter("@debit_value", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[5] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_casiermoviesupdate", p);
                }
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[1] = new SqlParameter("@invoice_type", "بيع");
                cd.runproc("sp_deletecashier", p);
                if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                {
                    frm_payesal frm_ = new frm_payesal();
                    frm_.lb_total.Text = txt_net.Text;
                    frm_.form_name = "sales";
                    frm_.ShowDialog();
                }

            }

            #endregion
            cleardata();
            addnew = true;
            cmb_stores.Enabled = true;
            gridControl2.Visible = false;
            #endregion
            cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            frm_mainpage frm = new frm_mainpage();
            if (frm.checkpermissions(connectiondata.user_id, "فواتير البيع", "add_new", 1) == false)
            {
                return;
            }
            gridView1.ActiveFilter.Clear();

            if (radioGroup1.EditValue.ToString() == "اجل")
            {
                if (string.IsNullOrEmpty(cmb_vendors.Text))
                {
                    errorProvider1.SetError(cmb_vendors, "يرجى أدخال أسم العميل فى حالة الفواتير الأجلة");
                        return;
                }
                if (int.Parse(cmb_vendors.EditValue.ToString()) == Properties.Settings.Default.mainaccount)
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
                param[0] = new SqlParameter("@move_type", "بيع");
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
                //MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
                binding_navigations();
                bindingsearch();
                changeprice();
                if (radioGroup1.EditValue.ToString() == "نقدى")
                {
                    SqlParameter[] p = new SqlParameter[7];
                    p[0] = new SqlParameter("@move_date", Convert.ToDateTime(txt_date.Text));
                    p[1] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[2] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[3] = new SqlParameter("@value_", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@user_id", connectiondata.user_id);
                    p[5] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[6] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_salesmoveInser", p);
                }
                else
                {
                    if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                    {
                        frm_payesal frm_ = new frm_payesal();
                        frm_.lb_total.Text = txt_net.Text;
                        frm_.form_name = "sales";
                        frm_.ShowDialog();
                    }
                }
                //print invoicedata
                printing_invoice();
                cleardata();
                cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());
                return;
            }
            #endregion
            #region update invoice.....
            SqlParameter[] param1 = new SqlParameter[13];
            param1[0] = new SqlParameter("@move_type", "بيع");
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
            int rowno = navigations_view.FocusedRowHandle;
            param1[12] = new SqlParameter("@move_no", navigations_view.GetRowCellValue(rowno, "move_no").ToString());
            cd.runproc("sp_salesUpdate", param1);
            //MSg.showmsg("تم حفظ بيانات الفاتورة", MSg.msgbutton.ok, MSg.msgicon.saved);
            changeprice();
            //update esal data
            #region CashierData
            if (radioGroup1.EditValue.ToString() == "نقدى")
            {
                SqlParameter[] pa = new SqlParameter[2];
                pa[0] = new SqlParameter("@invoice_no", int.Parse(txt_invice_no.Text));
                pa[1] = new SqlParameter("@invoice_type", "بيع");
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
                    p[6] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_salesmoveInser", p);
                }
                else
                {
                    SqlParameter[] p = new SqlParameter[6];
                    p[0] = new SqlParameter("@account_code", string.IsNullOrEmpty(cmb_vendors.Text) ? int.Parse("0") : cmb_vendors.EditValue);
                    p[1] = new SqlParameter("@cashier_code", cmb_cashier.EditValue);
                    p[2] = new SqlParameter("@creadit_value", Convert.ToDecimal("0"));
                    p[3] = new SqlParameter("@debit_value", Convert.ToDecimal(txt_net.Text));
                    p[4] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                    p[5] = new SqlParameter("@invoice_type", "بيع");
                    cd.runproc("sp_casiermoviesupdate", p);
                }
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
                p[1] = new SqlParameter("@invoice_type", "بيع");
                cd.runproc("sp_deletecashier", p);
                if (MSg.showmsg("هل تم سداد جزاء من قيمة الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.OK)
                {
                    frm_payesal frm_ = new frm_payesal();
                    frm_.lb_total.Text = txt_net.Text;
                    frm_.form_name = "sales";
                    frm_.ShowDialog();
                }

            }
            #endregion
            //print invoicedata
            printing_invoice();
            cleardata();
            addnew = true;
            cmb_stores.Enabled = true;
            #endregion
            cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());
        }

        private void bt_Click(object sender, EventArgs e)
        {
            frm_mainpage frm = new frm_mainpage();
            if (frm.checkpermissions(connectiondata.user_id, "فواتير البيع", "delete_", 1) == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(txt_invice_no.Text)) { return; }
            if (MSg.showmsg("هل تريد حذف بيانات الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@move_no", int.Parse(navigations_view.GetFocusedRowCellValue("move_no").ToString()));
                p[1] = new SqlParameter("@invoice_no", int.Parse(navigations_view.GetFocusedRowCellValue("invoice_no").ToString()));
                p[2] = new SqlParameter("@invoice_type", "بيع");
                cd.runproc("sp_movesdelete", p);
                cleardata();
                binding_navigations();
                bindingproducts();
                addnew = true;
                cmb_vendors.EditValue = int.Parse(XtraForm1.getmain.dt_setting.Rows[0]["main_account"].ToString());

            }


        }

        private void txt_code_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void txt_code_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(use_parcode.EditValue) != true)
            {
                if (gridControl2.Visible == false)
                {
                    gridControl2.Visible = true;
                }
                else
                {
                    gridControl2.Visible = false;
                }
            }

        }

        private void txt_code_EditValueChanged(object sender, EventArgs e)
        {
            //  bindingproducts();
            if (string.IsNullOrEmpty(txt_code.Text)) { clearproduct_data(); }
            gridView2.ActiveFilter.Clear();
            gridView2.ActiveFilterString = "[product_name]+[product_code] like '%" + txt_code.Text + "%'";
            if (Convert.ToBoolean(use_parcode.EditValue) == true) { return; }
            if (gridView2.RowCount == 0)
            {
                //  lb_noitems.Visible = true;
                validating = false;
            }
            else
            {
                //  lb_noitems.Visible = false;
                validating = true;
            }

        }
        //get data form gridview after select
        void fill_data()
        {
            if (validating == false) { return; }
            int product_code = int.Parse(gridView2.GetFocusedRowCellValue("product_code").ToString());
            string product_name = gridView2.GetFocusedRowCellValue("product_name").ToString();
            string unit_name = gridView2.GetFocusedRowCellValue("unit_name").ToString();
            if (Convert.ToBoolean(larg_price.EditValue) == true)
            {
                discount_value = 0;
                txt_price.Text = gridView2.GetFocusedRowCellValue("larg_price").ToString();
            }
            else
            {
                txt_price.Text = gridView2.GetFocusedRowCellValue("sell_price").ToString();
                discount_value = (Convert.ToDecimal(gridView2.GetFocusedRowCellValue("discount_percent").ToString()) / 100) * Convert.ToDecimal(txt_price.Text);
                discount_persent = Convert.ToDecimal(gridView2.GetFocusedRowCellValue("discount_percent").ToString()) / 100;
            }
            buy_price = Convert.ToDecimal(gridView2.GetFocusedRowCellValue("average_price").ToString());
            txt_code.Text = product_name.ToString();
            if(Convert.ToBoolean(auto_insert.EditValue)==false)
            {
                bindingunits(product_code);
            }
            txt_unit.Text = unit_name.ToString();
            txt_qty.Text = txt_defaultqty.Text;
            txt_qty.Focus();
            code = product_code;
            if (Convert.ToBoolean(auto_insert.EditValue) == true)
            {
                addnewproduct();
            }
            gridControl2.Visible = false;
        }
        private void txt_code_KeyDown(object sender, KeyEventArgs e)
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
                if (gridView2.RowCount == 0)
                {
                    return;
                }
                else
                {
                    txt_code.Properties.Items.Clear();
                    gridControl2.Focus();
                    gridView2.FocusedRowHandle = 0;
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
                    // bindingunits(int.Parse(dt.Rows[0]["product_code"].ToString()));
                    code = int.Parse(dt.Rows[0]["product_code"].ToString());
                    if (Convert.ToBoolean(larg_price.EditValue) == true)
                    {
                        discount_value = 0;
                        txt_price.Text = dt.Rows[0]["larg_price"].ToString();
                    }
                    else
                    {
                        txt_price.Text = dt.Rows[0]["sell_price"].ToString();
                        discount_value = (Convert.ToDecimal(dt.Rows[0]["discount_value"].ToString()) / 100) * Convert.ToDecimal(txt_price.Text);
                        discount_persent = Convert.ToDecimal(dt.Rows[0]["discount_value"].ToString()) / 100;
                    }
                    buy_price = Convert.ToDecimal(dt.Rows[0]["average_price"].ToString());
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
                    fill_data();
                }
            }

        }
        void printing_invoice()
        {
            //SqlParameter[] para = new SqlParameter[2];
            //para[0] = new SqlParameter("@invoice_no", txt_invice_no.Text);
            //para[1] = new SqlParameter("@invoice_type", "بيع");
            //DataTable dt_r = new DataTable();
            //dt_r = cd.getdata("rpt_purchaseInvoicePrint", para);
            frm_othermain.getmain.dt_invoicedata.Rows.Clear();
            DataRow new_row;
            new_row = frm_othermain.getmain.dt_invoicedata.NewRow();
            new_row["invoice_no"] =invoice_no;
            new_row["invoice_date"] =txt_date.Text;
            new_row["accounts_name"] =cmb_vendors.Text;
            new_row["store_name"] =cmb_stores.Text;
            new_row["discount"] =txt_discount.Text;
            new_row["net_value"] =txt_net.Text;
            new_row["user_name"] = frm_othermain.getmain.lb_user_name.Text; ;
            frm_othermain.getmain.dt_invoicedata.Rows.Add(new_row);
            DevExpress.XtraReports.UI.XtraReport rpt1;
            rpt1 = new rpt_purchaseInvoice();
            switch (Properties.Settings.Default.sales_paper)
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
            rpt1.DataSource = dt_products;
            rpt1.PrinterName = Properties.Settings.Default.sales_printer;
            rpt1.Print();
        }//طباعة فاتورة البيع
        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToBoolean(use_parcode.EditValue) != true && Convert.ToInt32(e.KeyChar) != 13)
            {
                gridControl2.Visible = true;
            }
            txt_code.Properties.Items.Clear();
        }

        private void txt_unit_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void txt_qty_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addnewproduct();
            }

        }

        private void txt_price_Enter(object sender, EventArgs e)
        {
            gridControl2.Visible = false;

        }

        private void txt_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addnewproduct();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            addnewproduct();
        }

        private void cmb_vendors_EditValueChanged(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@account_code", cmb_vendors.EditValue.ToString());
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_vendorbalance", p);
            if (dt.Rows.Count == 0) { return; }
            if (int.Parse(cmb_vendors.EditValue.ToString()) != 0)
            {
                txt_lastbalance.Text = dt.Rows[0][0].ToString();
            }
        }

        private void cmb_vendors_Enter(object sender, EventArgs e)
        {
            bindingaccounts();
        }

        private void cmb_stores_EditValueChanged(object sender, EventArgs e)
        {
            bindingproducts();
        }

        private void txt_discount_EditValueChanged(object sender, EventArgs e)
        {
            txt_discount2.Text = txt_discount.Text;
            calculating_value();

        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            fill_data();
        }

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//when user press enter .........
            {
                fill_data();
            }
            if (e.KeyCode == Keys.Up)//when user click up..........
            {
                if (gridView2.FocusedRowHandle == 0)
                {
                    txt_code.Focus();
                }
            }


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void panelControl2_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary)
            {
                decimal _total = Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue);
                e.TotalValue = _total;
                e.TotalValueReady = true;
                txt_total.Text = e.TotalValue.ToString();
                calculating_value();
            }

        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            gridControl2.Visible = false;
        }

        private void panelControl2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.RowCount != 0)
            {
                frm_changeqty frm = new frm_changeqty();
                int selectrow = gridView1.FocusedRowHandle;
                decimal qty = decimal.Parse(gridView1.GetRowCellValue(selectrow, "qty").ToString());
                decimal price = decimal.Parse(gridView1.GetRowCellValue(selectrow, "price").ToString());
                string product_name = gridView1.GetRowCellValue(selectrow, "product_name").ToString();
                int code_product = int.Parse(gridView1.GetRowCellValue(selectrow, "product_code").ToString());
                decimal dis = Convert.ToDecimal(gridView1.GetRowCellValue(selectrow, "discount_value").ToString());
                discount_value = dis / (price * qty);

                frm.cmb_unit.Text = gridView1.GetRowCellValue(selectrow, "unit_name").ToString();
                frm.id = int.Parse(gridView1.GetRowCellValue(selectrow, "id").ToString());
                frm.txt_qty.Text = qty.ToString();
                frm.txt_productname.Text = product_name.ToString();
                frm.txt_price.Text = price.ToString();
                frm.product_code = code_product;
                frm.bindingunits(code_product);
                frm.form_name = "sales";
                frm.qty = qty;
                frm.available_qty = decimal.Parse(gridView1.GetRowCellValue(selectrow, "available_qty").ToString());
                if (addnew == true)
                {
                    frm.addnew = true;
                }
                else
                {
                    frm.addnew = false;
                }
                frm.ShowDialog();
            }

        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }
            //if(addnew==false)
            //{
            //    SqlParameter[] p = new SqlParameter[3];
            //    int x = int.Parse(gridView1.GetFocusedRowCellValue("product_code").ToString());
            //    p[0] = new SqlParameter("@product_code",x );
            //    p[1] = new SqlParameter("@store_code", cmb_stores.EditValue);
            //    p[2] = new SqlParameter("@stor_to", int.Parse("0"));
            //    cd.runproc("sp_UpdateavialbeQtyAfterDelete", p);
            //}
            if (MSg.showmsg("حذف بيانات الصنف من الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
                gridView1.DeleteSelectedRows();
                dt_products.AcceptChanges();
                updatetotal();
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
            if (Convert.ToBoolean(larg_price.EditValue) == true)
            {
                txt_price.Text = Math.Round((Convert.ToDecimal(dt.Rows[0]["unit_count"].ToString()) * Convert.ToDecimal(dt.Rows[0]["larg_price"].ToString())), 2).ToString();
                discount_value = 0;
            }
            else
            {
                txt_price.Text = dt.Rows[0][1].ToString();
                //decimal unit_count = decimal.Parse(dt.Rows[0]["unit_count"].ToString());
                discount_value = (discount_persent * Convert.ToDecimal(txt_price.Text));
            }
            txt_qty.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_code.Focus();
            txt_code.Text = string.Empty;
            timer1.Enabled = false;

        }

        private void frm_SalesInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    btn_save_Click(null, null);
                    break;

                case Keys.F11:
                    btn_print_Click(null, null);
                    break;
                case Keys.F12:
                    btn_delete_ButtonClick(null, null);
                    break;
            }
        }

        private void gridControl2_VisibleChanged(object sender, EventArgs e)
        {
            if(gridControl2.Visible==true)
            {
                bindingproducts();
            }
        }

        private void txt_serach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_stores_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (addnew == true && gridView1.RowCount != 0)
            {
                e.Cancel = true;
            }

        }

        private void cmb_vendors_DoubleClick(object sender, EventArgs e)
        {
            frm_addacounts frm = new frm_addacounts();
            frm_othermain.getmain.openform(frm);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer_interval+=timer2.Interval;
            if (timer_interval == 300)
            {
                {
                    looading_data();
                    txt_code.Focus();
                    timer2.Stop();
                    progressPanel1.Visible = false;
                }
            }
        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "product_name like '%" + searchControl1.Text + "%'";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                e.Result = looading_data();
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressPanel1.Visible = false;
        }
    }
}