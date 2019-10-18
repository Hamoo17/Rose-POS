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
    public partial class frm_productChangePrice : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        DataTable dt_prodcuts = new DataTable();

        public frm_productChangePrice()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch (comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    decimal percent = Convert.ToDecimal((Convert.ToDecimal(spinEdit1.Text) / 100) + 1);
                    foreach (DataRow item in dt_prodcuts.Rows)
                    {
                        if (Convert.ToBoolean(item["select_"].ToString()) == true)
                        {
                            item.BeginEdit();
                            item["sell_price"] = (Convert.ToDecimal(item["sell_price"].ToString()) * percent);
                            item.EndEdit();
                        }
                    }
                    break;
                case 1:
                    foreach (DataRow item in dt_prodcuts.Rows)
                    {
                        if (Convert.ToBoolean(item["select_"].ToString()) == true)
                        {
                            item.BeginEdit();
                            item["sell_price"] = Convert.ToDecimal(item["sell_price"].ToString()) + Convert.ToDecimal(spinEdit1.Text);
                            item.EndEdit();
                        }
                    }
                    break;

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MSg.showmsg("هل تريد حفظ تعديلات على اسعار البيع", MSg.msgbutton.okcancel, MSg.msgicon.information) == MSg.result.CANCEL) { return; }
            foreach (DataRow item in dt_prodcuts.Rows)
            {
                if (Convert.ToBoolean(item["select_"].ToString()) == true)
                {
                    SqlParameter[] p = new SqlParameter[2];
                    p[0] = new SqlParameter("@product_code", int.Parse(item["product_code"].ToString()));
                    p[1] = new SqlParameter("@price", decimal.Parse(item["sell_price"].ToString()));
                    cd.runproc("sp_changeprice", p);
                }
            }
        }

        private void frm_productChangePrice_Load(object sender, EventArgs e)
        {
            dt_prodcuts = cd.getdata("sp_Barcoddata", null);
            gridControl1.DataSource = dt_prodcuts;

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void separatorControl1_Click(object sender, EventArgs e)
        {

        }
    }
}