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
using System.Management;
using DevExpress.XtraPrinting.BarCode.Native;
using DevExpress.Charts.Native;

namespace ROSESONLY.forms
{
    public partial class frm_parcodprint : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        DataTable dt_prodcuts = new DataTable();
        public frm_parcodprint()
        {
            InitializeComponent();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("product_code");
            dt.Columns.Add("product_name");
            dt.Columns.Add("parcode");
            dt.Columns.Add("sell_price");

            foreach (DataRow item in dt_prodcuts.Rows)
            {
                if (Convert.ToBoolean(item["select_"].ToString()) != true) { continue; }
                decimal number = decimal.Parse(item["avialble_qty"].ToString());
                DataRow addrow;
                for (int i = 0; i < number; i++)
                {
                    addrow = dt.NewRow();
                    addrow["product_code"] = item["product_code"].ToString();
                    addrow["product_name"] = item["product_name"].ToString();
                    addrow["parcode"] = item["parcode"].ToString();
                    addrow["sell_price"] = item["sell_price"].ToString();
                    dt.Rows.Add(addrow);
                }
            }
            switch (comboBoxEdit1.Text)
          {
              case "style one":
            ROSESONLY.reports.rpt_parcodeprint rpt = new reports.rpt_parcodeprint();
            rpt.DataSource = dt;
            frm_showreports frm = new frm_showreports();
            frm.documentViewer1.DocumentSource = rpt;
            frm.ShowDialog();
                  break;
              case"style two":
                  ROSESONLY.reports.rpt_prarcodstyle2 rpt1 = new reports.rpt_prarcodstyle2();
            rpt1.DataSource = dt;
            frm_showreports frm1 = new frm_showreports();
            frm1.documentViewer1.DocumentSource = rpt1;
            frm1.ShowDialog();
                  break;
            case "style three":
                  ROSESONLY.reports.rpt_style3 rpt3 = new reports.rpt_style3();
                rpt3.DataSource = dt;
                frm_showreports frm3 = new frm_showreports();
                frm3.documentViewer1.DocumentSource = rpt3;
                frm3.ShowDialog();
                break;
                case "one barcode":
                    ROSESONLY.reports.rpt_barcode rpt4 = new reports.rpt_barcode();
                    rpt4.DataSource = dt;
                    frm_showreports frm4 = new frm_showreports();
                    frm4.documentViewer1.DocumentSource = rpt4;
                    frm4.ShowDialog();
                    break;


            }

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            foreach (DataRow item in dt_prodcuts.Rows)
            {
                item.BeginEdit();
                item["avialble_qty"] = int.Parse(spinEdit1.Text);
                item.EndEdit();
            }
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
                printr_name.Properties.Items.Add(mo["Name"].ToString());
            }

        }
        void binding_products()
        {
            dt_prodcuts = cd.getdata("sp_Barcoddata", null);
            gridControl1.DataSource = dt_prodcuts;
        }
        private void frm_parcodprint_Load(object sender, EventArgs e)
        {
            binding_products();
            left_margian.Text = Properties.Settings.Default.left_margins.ToString();
            top_mirgain.Text = Properties.Settings.Default.top_margins.ToString();
            b_width.Text = Properties.Settings.Default.b_width.ToString();
            b_height.Text = Properties.Settings.Default.b_high.ToString();
            show_name.EditValue = Convert.ToBoolean(Properties.Settings.Default.show_name.ToString());
            show_barcode.EditValue = Convert.ToBoolean(Properties.Settings.Default.show_barcode.ToString());
            show_price.EditValue = Convert.ToBoolean(Properties.Settings.Default.show_price.ToString());
            font_name.Text = Properties.Settings.Default.font_name;
            printr_name.Text = Properties.Settings.Default.printer_name;
            name_size.Text = Properties.Settings.Default.name_size.ToString();
            barode_size.Text = Properties.Settings.Default.barcode_size.ToString();
            price_size.Text = Properties.Settings.Default.price_size.ToString();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {    
            for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (select_all.Checked == true)
                    {
                    gridView1.SetRowCellValue(i, "select_", true);
                }
                else
                {
                    gridView1.SetRowCellValue(i, "select_", false);

                }
            }
        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "[product_name]+[product_code] like '%" + searchControl1.Text + "%'";
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.left_margins = Convert.ToInt16(left_margian.Text);
            Properties.Settings.Default.top_margins = Convert.ToInt16(top_mirgain.Text);
            Properties.Settings.Default.b_width = Convert.ToInt16(b_width.Text);
            Properties.Settings.Default.b_high = Convert.ToInt16(b_height.Text);
            Properties.Settings.Default.show_barcode =Convert.ToBoolean(show_barcode.EditValue);
            Properties.Settings.Default.show_name = Convert.ToBoolean(show_name.EditValue);
            Properties.Settings.Default.show_price = Convert.ToBoolean(show_price.EditValue);
            Properties.Settings.Default.name_size = int.Parse(name_size.Text);
            Properties.Settings.Default.barcode_size = int.Parse(barode_size.Text);
            Properties.Settings.Default.price_size = int.Parse(price_size.Text);
            Properties.Settings.Default.font_name = font_name.Text;
            Properties.Settings.Default.printer_name = printr_name.Text;

            Properties.Settings.Default.Save();
            MSg.showmsg("تم حفظ التصميم", MSg.msgbutton.ok, MSg.msgicon.saved);
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
        }

        private void printr_name_Enter(object sender, EventArgs e)
        {
            binding_printer();
        }

        private void frm_parcodprint_Activated(object sender, EventArgs e)
        {
            dt_prodcuts = cd.getdata("sp_Barcoddata", null);
            gridControl1.DataSource = dt_prodcuts;
        }
    }
}