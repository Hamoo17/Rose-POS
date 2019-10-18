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
    public partial class frm_units : DevExpress.XtraEditors.XtraForm
    {
        public bool min_unit;
        int Aselwi;
        public static decimal buyprice;
        public static decimal sellprice;
        DataRow[] selectrow;
        public frm_units()
        {
            InitializeComponent();
            //panelControl1.BackColor = Properties.Settings.Default.item_color;
            //btn_save.Appearance.BackColor = Properties.Settings.Default.item_color;

        }
        public void retrndata(string rownumber)
        {
            
            selectrow = frm_addproducts.getmain.dt_units.Select("min_unit='" + rownumber + "'");
            txt_parcode.Text = selectrow[0]["parcode"].ToString();
            txt_name.Text = selectrow[0]["unit_name"].ToString();
            txt_count.Text = selectrow[0]["unit_count"].ToString();
            txt_buyprice.Text = selectrow[0]["buy_price"].ToString();
            txt_sellprice.Text = selectrow[0]["sell_price"].ToString();
            ck_buy.EditValue = selectrow[0]["buy_default"];
            ck_sell.EditValue = selectrow[0]["sell_default"];
            btn_save.Tag = "1";
        }
        private void frm_units_Load(object sender, EventArgs e)
        {
            Aselwi = int.Parse("1");
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Randomize(double Min, double Max)
        {
            Random rd = new Random();
            int j = 1;
            while (j <= Aselwi)
            {
                double d = rd.NextDouble();
                double f = Min + (Max - Min) * d;
                double dr = Math.Round(f);
                txt_parcode.Text = dr.ToString();
                j++;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            double RangFrom = double.Parse("1000000000000");
            double RangTo = double.Parse("9999999999999");
            Randomize(RangFrom, RangTo);
            Aselwi = int.Parse("1");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           //validating
            if(string.IsNullOrEmpty(txt_name.Text)||string.IsNullOrEmpty(txt_count.Text))
            {
                MSg.showmsg("يرجى إدخال البيانات المطلوبة", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
         
            //check default value 
            if (ck_buy.EditValue.ToString() == "True")
            {
                foreach (DataRow item in frm_addproducts.getmain.dt_units.Rows)
                {
                        item.BeginEdit();
                        item["buy_default"] = "false";
                        item.EndEdit();
                }
            }
            if (ck_sell.EditValue.ToString() == "True")
            {
                foreach (DataRow item in frm_addproducts.getmain.dt_units.Rows)
                {
                        item.BeginEdit();
                        item["sell_default"] = "false";
                        item.EndEdit();
                }
            }
            //check quantity int min unit
            decimal qty;
            DataRow[] _rows;
            _rows = frm_addproducts.getmain.dt_units.Select("min_unit=1");
            qty = Convert.ToDecimal(_rows[0]["unit_count"].ToString());
            if (min_unit == true&& _rows.Length!=1)
            {
                foreach (DataRow item in frm_addproducts.getmain.dt_units.Rows)
                {
                    decimal x = Decimal.Parse(item["unit_count"].ToString());
                    if(decimal.Parse(txt_count.Text)>x)
                    {
                        errorProvider1.SetError(txt_count, "الوحدة الصغرى يجب ان تكون اقل فى العدد من باقى الوحدات");
                        return;
                    }
                }
            }

            if (qty >Convert.ToDecimal(txt_count.Text) &&min_unit==false)
            {
                errorProvider1.SetError(txt_count, "الوحدة الصغرى يجب ان تكون اقل فى العدد من باقى الوحدات");
                return;
            }
            if(btn_save.Tag.ToString()=="0")
          {
              //Random x = new Random();
              DataRow row;
              row = frm_addproducts.getmain.dt_units.NewRow();
              row["parcode"] = txt_parcode.Text;
              row["unit_name"] = txt_name.Text;
              row["unit_count"] = txt_count.Text;
              row["buy_price"] = txt_buyprice.Text;
              row["sell_price"] = txt_sellprice.Text;
              row["buy_default"] = ck_buy.EditValue;
              row["sell_default"] = ck_sell.EditValue.ToString();
              row["min_unit"] = "0";
               frm_addproducts.getmain.dt_units.Rows.Add(row);
              frm_addproducts.getmain.dt_units.AcceptChanges();
          }
            else
            {
                selectrow[0].BeginEdit();
                selectrow[0]["parcode"] = txt_parcode.Text;
                selectrow[0]["unit_name"] = txt_name.Text;
                selectrow[0]["unit_count"] = txt_count.Text;
                selectrow[0]["buy_price"] = txt_buyprice.Text;
                selectrow[0]["sell_price"] = txt_sellprice.Text;
                selectrow[0]["buy_default"] = ck_buy.EditValue;
                selectrow[0]["sell_default"] = ck_sell.EditValue;
                selectrow[0].EndEdit();
            }
            this.Close();
        }
        private void ck_buy_Click(object sender, EventArgs e)
        {
        }

        private void txt_count_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
            txt_buyprice.Text = (Convert.ToDecimal(txt_count.Text) * buyprice).ToString();
            txt_sellprice.Text = (Convert.ToDecimal(txt_count.Text) * sellprice).ToString();
            }
            catch 
            { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ck_buy.EditValue = true;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}