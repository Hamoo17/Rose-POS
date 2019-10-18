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
using System.IO;

namespace ROSESONLY.forms
{
    public partial class frm_settings : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        private static frm_settings frm;
         static void from_closed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_settings get_main
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_settings();
                    frm.FormClosed += new FormClosedEventHandler(from_closed);
                }
                return frm;
            }
        }
        public frm_settings()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            bindingstores();
            bindinguser();
        }
    public void bindingstores()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_storesSelect", null);
            gridControl1.DataSource = dt;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_branchs frm = new frm_branchs();
            frm.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frm_casher frm = new frm_casher();
            frm.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frm_uswers frm = new frm_uswers();
            frm_othermain.getmain.openform(frm);
        }




        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frm_stores frm = new frm_stores();
            frm.ShowDialog();
        }
        public void bindingcashier()
        {
            //binding cashier data...........
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_cashierselect", null);
            gridControl2.DataSource = dt;

        }
        private void frm_settings_Load(object sender, EventArgs e)
        {
            bindingcashier();
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_returncopmanydata", null);
            if (dt.Rows.Count != 0)
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["logo"].ToString()))
                {
                    logo.Image = Properties.Resources.product_image;
                }
                else
                {
                    byte[] imagebyt = (byte[])dt.Rows[0]["logo"];
                    MemoryStream ms = new MemoryStream(imagebyt);
                    logo.Image = Image.FromStream(ms);
                }
            }

            txt_adress.Text = Properties.Settings.Default.adress;
            txt_email.Text = Properties.Settings.Default.email;
            txt_name.Text = Properties.Settings.Default.company_name;
            txt_phone1.Text = Properties.Settings.Default.phone1;
            txt_phone2.Text = Properties.Settings.Default.phone2;
        }
        public void bindinguser()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_userdata", null);
            gridControl3.DataSource = dt;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }
            int currentrow = gridView1.FocusedRowHandle;
            int store_id = int.Parse(gridView1.GetRowCellValue(currentrow, "store_id").ToString());

            frm_stores frm = new frm_stores();
            frm.txt_name.Text = gridView1.GetRowCellValue(currentrow, "store_name").ToString();
            frm.store_id = store_id;
            frm.btn_save.Tag = "1";
            frm.ShowDialog();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if(MSg.showmsg("حذف بيانات الفرع && المخزن",MSg.msgbutton.okcancel,MSg.msgicon.delete)==MSg.result.OK)
            {
                int currentrow = gridView1.FocusedRowHandle;
                int store_id = int.Parse(gridView1.GetRowCellValue(currentrow, "store_id").ToString());
               //check befor delete......
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@store_id", store_id);
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_checkstorebefordelete", pa);
                if(dt.Rows[0][0].ToString()!="0")
                {
                    MSg.showmsg("لايمكن حذف بيانات المخزن لوجود عمليات تمت عليه", MSg.msgbutton.ok, MSg.msgicon.warning);
                    return;
                }
                else
                {
                    SqlParameter[] p = new SqlParameter[1];
                    p[0] = new SqlParameter("@store_id", store_id);
                    cd.runproc("sp_storedelete", p);
                    bindingstores();
                }


            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0) { return; }
            frm_casher frm = new frm_casher();
            frm.cashier_id=int.Parse(gridView2.GetFocusedRowCellValue("cashier_id").ToString());
            frm.txt_name.Text = gridView2.GetFocusedRowCellValue("cashier_name").ToString();
            frm.btn_save.Tag = 1;
            frm.ShowDialog();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
           int user_code=int.Parse(gridView3.GetFocusedRowCellValue("user_id").ToString());
            frm_uswers frm = new frm_uswers();
            frm.user_id = user_code;
            frm_othermain.getmain.openform(frm);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
        if(MSg.showmsg("حذف بيانات الخزينة",MSg.msgbutton.okcancel,MSg.msgicon.delete)==MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@cashier_code", int.Parse(gridView2.GetFocusedRowCellValue("cashier_id").ToString()));
                try
                {
            cd.runproc("sp_cashierdelete", p);   
                }
                catch (Exception)
                {
                    MSg.showmsg("غير قادر على حذف بيانات الخزينة", MSg.msgbutton.ok, MSg.msgicon.delete);  
                }
                bindingcashier();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
        if(MSg.showmsg("حذف بيانات المستخدم",MSg.msgbutton.okcancel,MSg.msgicon.delete)==MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@user_id", int.Parse(gridView3.GetFocusedRowCellValue("user_id").ToString()));
                    cd.runproc("sp_userdelete", p);   
                   bindinguser();
            }

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            //saving image
            //if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
            MemoryStream ms = new MemoryStream();
            logo.Image.Save(ms, logo.Image.RawFormat);
            byte[] imagebyte = ms.ToArray();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@logo", imagebyte);
            cd.runproc("sp_InsertCompanyData", p);
            Properties.Settings.Default.company_name = txt_name.Text;
            Properties.Settings.Default.adress = txt_adress.Text;
            Properties.Settings.Default.phone2 = txt_phone1.Text;
            Properties.Settings.Default.phone1 = txt_phone1.Text;
            Properties.Settings.Default.email = txt_email.Text;
            Properties.Settings.Default.Save();
            MSg.showmsg("تم حفظ بيانات شركتك", MSg.msgbutton.ok, MSg.msgicon.delete);
        }

        private void logo_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                logo.Image = Image.FromFile(op.FileName);
            }

        }
    }
}