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
    public partial class frm_storeproducts : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int store_id;
        public frm_storeproducts()
        {
            InitializeComponent();
            //panelControl1.BackColor = Properties.Settings.Default.item_color;
            //btn_save.Appearance.BackColor=Properties.Settings.Default.item_color;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_storeproducts_Load(object sender, EventArgs e)
        {
            bindingstores();
        }
        void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_storesSelect", null);
            cmb_stores.Properties.DataSource = dt;
            cmb_stores.Properties.DisplayMember = "store_name";
            cmb_stores.Properties.ValueMember = "store_id";
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cmb_stores.Text))
            {
                errorProvider1.SetError(cmb_stores, "يرجى أختيار المخزن");
                return;
            }
            if (string.IsNullOrEmpty(txt_quantity.Text))
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(txt_quantity, "يرجى أدخال رصيد الصنف");
                return;
            }
            if(btn_save.Tag.ToString()=="0")
            {
                DataRow[] checkrow;
                checkrow = frm_addproducts.getmain.dt_stores.Select("store_id=" + cmb_stores.EditValue + "");
                if(checkrow.Length!=0)
                {
                    checkrow[0].BeginEdit();
                    checkrow[0]["first_balance"]=decimal.Parse( checkrow[0]["first_balance"].ToString())+ decimal.Parse(txt_quantity.Text);
                    checkrow[0].EndEdit();
                    this.Close();
                }else{
            DataRow row;
            row = frm_addproducts.getmain.dt_stores.NewRow();
            row["store_id"] = cmb_stores.EditValue;
            row["store_name"] = cmb_stores.Text;
            row["first_balance"] =Convert.ToDecimal(txt_quantity.Text);
            frm_addproducts.getmain.dt_stores.Rows.Add(row);
            this.Close();

                }
            }
            else
            {
               if(store_id!=int.Parse(cmb_stores.EditValue.ToString()))
               {
                   DataRow[] checkrow;
                   checkrow = frm_addproducts.getmain.dt_stores.Select("store_id=" + cmb_stores.EditValue + "");
                   if (checkrow.Length != 0)
                   {
                       checkrow[0].BeginEdit();
                       checkrow[0]["first_balance"] = decimal.Parse(checkrow[0]["first_balance"].ToString()) + decimal.Parse(txt_quantity.Text);
                       checkrow[0].EndEdit();
                       frm_addproducts.getmain.gridView1.DeleteSelectedRows();
                       frm_addproducts.getmain.dt_stores.AcceptChanges();
                       this.Close();
                       return;
                   }
               }
                    DataRow[] selectrow;
                    selectrow = frm_addproducts.getmain.dt_stores.Select("store_id=" + store_id + "");
                    selectrow[0].BeginEdit();
                    selectrow[0]["store_id"] = cmb_stores.EditValue;
                    selectrow[0]["store_name"] = cmb_stores.Text;
                    selectrow[0]["first_balance"] = txt_quantity.Text;
                    selectrow[0].EndEdit();
                    this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show((this.Location.X + "/" + this.Location.Y).ToString());

        }
    }
}