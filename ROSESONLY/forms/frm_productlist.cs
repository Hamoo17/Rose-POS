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
using DevExpress.XtraPrinting;

namespace ROSESONLY.forms
{
    public partial class frm_productlist : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();

        //public DataTable dt_parcod = new DataTable();
        private static frm_productlist frm;
        static void form_closed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_productlist getmain
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_productlist();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                }
                return frm;
            }
        }

        public frm_productlist()
        {
            if (frm == null)
                frm = this;
            InitializeComponent();
        }
        public void bindingproducts()
        {
            DataTable dt_pro = new DataTable();
            dt_pro = cd.getdata("sp_productdatareturn", null);
            gridControl1.DataSource = dt_pro;
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "الأصناف", "add_new", 1) == true)
            {
                frm_othermain.getmain.openform(frm_addproducts.getmain);
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "الأصناف", "edit_", 1) == true)
            {
                int rowindex = gridView1.FocusedRowHandle;
                int product_code = int.Parse(gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                frm_addproducts.getmain.addnew = false;
                frm_addproducts.getmain.old_code = product_code;
                frm_addproducts.getmain.returndata(product_code);
                frm_othermain.getmain.openform(frm_addproducts.getmain);
            }
        }
            private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "الأصناف", "delete_", 1) == false)
            {
                return;
            }

            try
            {
                if (MSg.showmsg("حذف بيانات الاصناف المحدده", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if(Convert.ToBoolean(gridView1.GetRowCellValue(i,"select_").ToString())==true)
                        {
                            int product_code = int.Parse(gridView1.GetRowCellValue(i, "product_code").ToString());
                            SqlParameter[] p = new SqlParameter[1];
                            p[0] = new SqlParameter("@product_code", product_code);
                            DataTable dt = new DataTable();
                            dt = cd.getdata("sp_checkproductbefordelete", p);
                            if (dt.Rows.Count != 0)
                            {
                                continue;
                            }
                            else
                            {
                                SqlParameter[] pa = new SqlParameter[1];
                                pa[0] = new SqlParameter("@product_code", product_code);
                                cd.runproc("sp_products_remove", pa);
                            }
                        }
                    }
                    bindingproducts();
                }

            }
            catch
            { }

        }

        private void frm_productlist_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                bindingproducts();
                //dt_parcod.Columns.Add("product_name");
                //dt_parcod.Columns.Add("product_code");
                //dt_parcod.Columns.Add("parcode");
                //dt_parcod.Columns.Add("sell_price");
                //dt_parcod.Columns.Add("avialble_qty", typeof(int));
                //dt_parcod.Columns.Add("category_name");

            });

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string FileName = Application.StartupPath + @"products.Xlsx";
            gridControl1.ExportToXlsx(FileName);
            System.Diagnostics.Process.Start(FileName);

        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void btn_productmoves_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) { return; }

            string product_name = gridView1.GetFocusedRowCellValue("product_name").ToString();
            int product_code_ = int.Parse(gridView1.GetFocusedRowCellValue("product_code").ToString());
            frm_productsMovies frm = new frm_productsMovies();
            frm.product_name.Text = product_name;
            frm.Text += " " + product_name;
            frm.txt_products.EditValue = product_code_;
            frm_othermain.getmain.openform(frm);
            frm.btn_show_Click(null, null);

        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.RightMargin = 5;
            pb.PageSettings.TopMargin = 5;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.BottomMargin = 5;
            pb.PageSettings.Landscape = true;

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int rowindex = gridView1.FocusedRowHandle;
            int product_code = int.Parse(gridView1.GetRowCellValue(rowindex, "product_code").ToString());
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@product_code", product_code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_productPurchasePrice", p);
            gridControl2.DataSource = dt;

            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("@product_code", product_code);
            DataTable dt1 = new DataTable();
            dt1 = cd.getdata("sp_productQTYinStore", pa);
            gridControl3.DataSource = dt1;

        }

        private void searchControl1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilter.Clear();
            gridView1.ActiveFilterString = "[product_name] +[product_code]+[parcode] like '%" + searchControl1.Text + "%'";
            //lb_count.Text = gridView1.RowCount.ToString();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int rowindex = gridView1.FocusedRowHandle;
                int product_code = int.Parse(gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@product_code", product_code);
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_productPurchasePrice", p);
                gridControl2.DataSource = dt;

                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@product_code", product_code);
                DataTable dt1 = new DataTable();
                dt1 = cd.getdata("sp_productQTYinStore", pa);
                gridControl3.DataSource = dt1;
            }
            catch
            { }

        }

        private void frm_productlist_Activated(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                bindingproducts();
            });
        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (frm_othermain.getmain.checkpermissions(connectiondata.user_id, "الأصناف", "edit_", 1) == true)
            {
                int rowindex = gridView1.FocusedRowHandle;
                int product_code = int.Parse(gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                frm_addproducts.getmain.addnew = false;
                frm_addproducts.getmain.old_code = product_code;
                frm_addproducts.getmain.returndata(product_code);
                frm_othermain.getmain.openform(frm_addproducts.getmain);
            }

        }

        private void btn_delete__ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MSg.showmsg("حذف بيانات  الصنف", MSg.msgbutton.okcancel, MSg.msgicon.delete) == MSg.result.OK)
            {
                        int product_code = int.Parse(gridView1.GetFocusedRowCellValue("product_code").ToString());
                        SqlParameter[] p = new SqlParameter[1];
                        p[0] = new SqlParameter("@product_code", product_code);
                        DataTable dt = new DataTable();
                        dt = cd.getdata("sp_checkproductbefordelete", p);
                        if (dt.Rows.Count != 0)
                        {
                      MSg.showmsg("لا يمكن حذف الصنف لوجود حركات  علية", MSg.msgbutton.ok, MSg.msgicon.delete);
                        }
                        else
                        {
                            SqlParameter[] pa = new SqlParameter[1];
                            pa[0] = new SqlParameter("@product_code", product_code);
                            cd.runproc("sp_products_remove", pa);
                        }
                    }
                bindingproducts();
            }

        private void btn_movies_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string product_name = gridView1.GetFocusedRowCellValue("product_name").ToString();
            int product_code_ = int.Parse(gridView1.GetFocusedRowCellValue("product_code").ToString());
            frm_productsMovies frm = new frm_productsMovies();
            frm.product_name.Text = product_name;
            frm.Text += " " + product_name;
            frm.txt_products.EditValue = product_code_;
            frm_othermain.getmain.openform(frm);
            frm.btn_show_Click(null, null);

        }
    
    }
}