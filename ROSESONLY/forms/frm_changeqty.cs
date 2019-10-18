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
    public partial class frm_changeqty : DevExpress.XtraEditors.XtraForm
    {
        public bool addnew;
        public int id;
        public string form_name;
        connectiondata cd = new connectiondata();
        public int product_code;
        public decimal available_qty;
        public int unit_count = 0;
        public decimal qty;
        public frm_changeqty()
        {
            InitializeComponent();
            bindingunits(product_code);
        }
        public void bindingunits(int product_code)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@product_code", product_code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingunits", p);
            cmb_unit.Properties.Items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                cmb_unit.Properties.Items.Add(item[0].ToString());
            }
        }

        private void frm_changeqty_Load(object sender, EventArgs e)
        {
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (form_name != "purchase" && form_name != "sales_return" && form_name!="adjust")
           {
               //get unit count
               SqlParameter[] ps = new SqlParameter[2];
               ps[0] = new SqlParameter("@unit_name", cmb_unit.Text);
               ps[1] = new SqlParameter("@product_code", product_code);
               DataTable dt_unit = new DataTable();
               dt_unit = cd.getdata("sp_bindingprice", ps);
               decimal x = available_qty + (qty * Convert.ToDecimal(dt_unit.Rows[0][2].ToString()));

                if(addnew==false)
               {
                   if (Convert.ToDecimal(txt_qty.Text) * Convert.ToDecimal(dt_unit.Rows[0][2].ToString()) > x)
                   {
                       MSg.showmsg("عفوا الكمية المتاحة أقل من الكمية المطلوبة  متاح " + (Math.Round(available_qty / Convert.ToDecimal(dt_unit.Rows[0][2].ToString()), 2) + (qty)).ToString(), MSg.msgbutton.ok, MSg.msgicon.information);
                       return;
                   }
               }
               else
               {
                   if (Convert.ToDecimal(txt_qty.Text) * Convert.ToDecimal(dt_unit.Rows[0][2].ToString()) > available_qty)
                   {
                       MSg.showmsg("عفوا الكمية المتاحة أقل من الكمية المطلوبة  متاح " + (Math.Round(available_qty / Convert.ToDecimal(dt_unit.Rows[0][2].ToString()), 2)).ToString(), MSg.msgbutton.ok, MSg.msgicon.information);
                       return;
                   }

               }

           }
            DataRow[] findrow;
            switch (form_name)
            {
                case "purchase":
                findrow = frm_purchase.get_main.dt_products.Select("id=" + id + "");
                if(findrow.Length!=0)
                {
                    findrow[0].BeginEdit();
                    findrow[0]["qty"] =decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }
                frm_purchase.get_main.updatetotal();
                break;
                case "purchase_return":
                findrow = frm_purchaseReturn.get_main.dt_products.Select("id=" + id + "");
                if(findrow.Length!=0)
                {
                    findrow[0].BeginEdit();
                    findrow[0]["qty"] =decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }
                frm_purchaseReturn.get_main.updatetotal();
                break;
                case "sales":
                findrow = frm_SalesInvoice.get_main.dt_products.Select("id=" + id + "");
                if (findrow.Length != 0)
                {
                    //check product price is less then limite price................
                    #region checkprice
                    DataTable dt_price = new DataTable();
                    SqlParameter[] p_price = new SqlParameter[1];
                    p_price[0] = new SqlParameter("@product_code", int.Parse(findrow[0]["product_code"].ToString()));
                    dt_price = cd.getdata("sp_getlimiteprice", p_price);
                    if (dt_price.Rows.Count != 0)
                    {
                        if (Convert.ToDecimal(dt_price.Rows[0]["limit_sellprice"].ToString()) > Convert.ToDecimal(txt_price.Text))
                        {
                            MSg.showmsg("سعر البيع أقل من  السعر المسموح به ", MSg.msgbutton.ok, MSg.msgicon.information);
                        }
                    }
                    #endregion

                    findrow[0].BeginEdit();
                    findrow[0]["discount_value"] =  Convert.ToDecimal(txt_qty.Text) * frm_SalesInvoice.get_main.discount_value*Convert.ToDecimal(txt_price.Text);
                    findrow[0]["qty"] = decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }
                frm_SalesInvoice.get_main.updatetotal();
                break;

                case "sales_return":
                findrow = frm_salesreturn.get_main.dt_products.Select("id=" + id + "");
                if (findrow.Length != 0)
                {
                    findrow[0].BeginEdit();
                    findrow[0]["discount_value"] = Convert.ToDecimal(txt_qty.Text) * frm_salesreturn.get_main.discount_value * Convert.ToDecimal(txt_price.Text);
                    findrow[0]["qty"] = decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }

                frm_salesreturn.get_main.updatetotal();
                break;
                case "transfer":
                findrow = frm_storeTransfer.get_main.dt_products.Select("id=" + id + "");
                if (findrow.Length != 0)
                {
                    findrow[0].BeginEdit();
                    findrow[0]["qty"] = decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }

                frm_storeTransfer.get_main.updatetotal();
                break;
                case "adjust":
                findrow = frm_adjustment.get_main.dt_products.Select("id=" + id + "");
                if (findrow.Length != 0)
                {
                    findrow[0].BeginEdit();
                    findrow[0]["qty"] = decimal.Parse(txt_qty.Text);
                    findrow[0]["price"] = decimal.Parse(txt_price.Text);
                    findrow[0]["unit_name"] = cmb_unit.Text;
                    findrow[0].EndEdit();
                }

                frm_adjustment.get_main.updatetotal();
                break;

            }
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@unit_name", cmb_unit.Text);
            p[1] = new SqlParameter("@product_code", product_code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingprice", p);
            if (dt.Rows.Count == 0) { return; }
            txt_price.Text = dt.Rows[0][0].ToString();

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_qty_Enter(object sender, EventArgs e)
        {
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btn_change_Click(null, null);
            }
        }

        private void txt_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_change_Click(null, null);
            }

        }
    }
}