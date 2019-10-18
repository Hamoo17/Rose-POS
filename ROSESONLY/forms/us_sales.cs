using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ROSESONLY.DLL;
using DevExpress.XtraBars.Docking2010.Views;
namespace ROSESONLY.forms
{
    public partial class us_sales : UserControl
    {
        connectiondata cd = new connectiondata();
        DataTable dt_detalis = new DataTable();
        public string type = "sales";
        public us_sales()
        {
            InitializeComponent();
            if(type=="sales")
            {
                gridColumn8.Visible = true;
                gridColumn29.Visible = true;
                gridColumn24.Visible = true;
                gridColumn28.Visible = true;
            }
            else
            {
                gridColumn8.Visible = false;
                gridColumn29.Visible = false;
                gridColumn24.Visible = false;
                gridColumn28.Visible = false;
            }
        }
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
        public void bindingselectedrow( int move_no)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@move_no", move_no);
            dt_detalis = cd.getdata("sp_salesINVOICESDetails", p);
            gridControl2.DataSource = dt_detalis;
        }
        private void btn_select_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int move_no = int.Parse(gridView1.GetFocusedRowCellValue("move_no").ToString());
            bindingselectedrow(move_no );
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                dt_detalis.Clear();
                return; }
            int move_no = int.Parse(gridView1.GetFocusedRowCellValue("move_no").ToString());
            bindingselectedrow(move_no);
        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            switch (gridView1.GetFocusedRowCellValue("move_type").ToString())
           {
               case "بيع":
            foreach (Form item in fc)
            {
                if (item.Text == "فاتورة بيع")
                {
                    frm_SalesInvoice.get_main.Close();
                    break;
                }
            }
            frm_SalesInvoice.get_main.m_value = int.Parse(gridView1.GetFocusedRowCellValue("move_no").ToString());
         //   frm_sales.get_main.Text = "تعديل بيع رقم" + " " + gridView1.GetFocusedRowCellValue("invoice_no").ToString();
            frm_othermain.getmain.openform(frm_SalesInvoice.get_main);
                   break;
               case "مرتجع بيع":
            foreach (Form item in fc)
            {
                if (item.Text == "مرتجع بيع")
                {
                    frm_salesreturn.get_main.Close();
                    break;
                }
            }
            frm_salesreturn.get_main.m_value = int.Parse(gridView1.GetFocusedRowCellValue("move_no").ToString());
            frm_othermain.getmain.openform(frm_salesreturn.get_main);
                   break;
           }
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MSg.showmsg("هل تريد حذف بيانات الفاتورة", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@move_no", int.Parse(gridView1.GetFocusedRowCellValue("move_no").ToString()));
                p[1] = new SqlParameter("@invoice_no", int.Parse(gridView1.GetFocusedRowCellValue("invoice_no").ToString()));
                p[2] = new SqlParameter("@invoice_type",gridView1.GetFocusedRowCellValue("move_type").ToString());
                cd.runproc("sp_movesdelete", p);
                gridView1.DeleteSelectedRows();
                if (gridView1.RowCount == 0)
                {
                    dt_detalis.Clear();
                    gridControl2.DataSource = dt_detalis;
                }
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
} 
