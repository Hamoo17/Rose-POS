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
using DevExpress.Data.Filtering;
using System.IO;
namespace ROSESONLY.forms
{
    public partial class frm_category : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        int category_code;
        bool allowfilter = true;
        bool allowupdate = false;
        string category_name;
        public frm_category()
        {
            InitializeComponent();
            //panelControl1.BackColor = Properties.Settings.Default.item_color;
            //gridView1.Appearance.HideSelectionRow.BackColor =System.Drawing.Color.FromArgb(255, 227 ,255);
            //gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(255, 227, 255);
            //gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(255, 227, 255);

        }

        private void frm_category_Load(object sender, EventArgs e)
        {
            bindingcategory();
            txt_name.Text = string.Empty;

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
        }
        void bindingcategory()
        {
            //binding all catagory
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_categoryselect", null);
            gridControl1.DataSource = dt;
        }
        bool checkname()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@category_name", txt_name.Text);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_categorycheckname", p);
            if(dt.Rows[0][0].ToString()=="0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkbeforupdate()
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@cat_name", txt_name.Text);
            p[1] = new SqlParameter("@cat_code", category_code);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_category", p);
            if (dt.Rows[0][0].ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            //saving image

            if(string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.SetError(txt_name, "يرجى إدخال أسم المجموعه قبل الحفظ");
                return;
            }
            else
            {
               if(btn_save.Tag.ToString()=="0")
               {
                    if (checkname() == false)
                    {
                        errorProvider1.SetError(txt_name, "لا يمكن تكرار أسم المجموعة");
                    }
                    else
                    {
                        errorProvider1.Dispose();
                        gridView1.ClearColumnsFilter();
                        category_name = txt_name.Text;
                        SqlParameter[] p = new SqlParameter[1];
                        p[0] = new SqlParameter("@category_name", txt_name.Text);

                        cd.runproc("sp_categoryInsert", p);
                  
                        bindingcategory();
                      
                        //select in gridview
                        gridView1.TopRowIndex = gridView1.RowCount - 1;
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        txt_name.Text = string.Empty;
                        txt_name.Focus();
                             //check form addproducts is open or no
                        FormCollection fm = Application.OpenForms;
                        foreach (Form item in fm)
                        {
                            if (item.Text == "frm_addproducts")
                            {
                                frm_addproducts.getmain.bindingcatagory();
                                frm_addproducts.getmain.cmb_category.Text = category_name;
                                this.Close();
                                return;
                            }
                        }
                    }

               }
               else
                       {

                         if(checkbeforupdate()==false)
                         {
                             MSg.showmsg("أسم الصنف مسجل مسبقا ولا يمكن تكراره ", MSg.msgbutton.ok, MSg.msgicon.information);
                             return;
                         }
                         else
                         {
                             SqlParameter[] p1 = new SqlParameter[2];
                             p1[0] = new SqlParameter("@category_code", category_code);
                             p1[1] = new SqlParameter("@category_name", txt_name.Text);
                             cd.runproc("sp_categoryupdate", p1);
                             bindingcategory();
                             errorProvider1.Dispose();
                             allowupdate = false;
                             allowfilter = true;
                             int filter = gridView1.LocateByValue("category_code", category_code);
                             gridView1.FocusedRowHandle = filter;
                             txt_name.Text = string.Empty;
                             txt_name.Focus();
                         }

                       }
                
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            int currentrow = gridView1.FocusedRowHandle;
            int cat_code = int.Parse(gridView1.GetRowCellValue(currentrow, "category_code").ToString());

            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("@cat_code", cat_code);
            DataTable dt1 = new DataTable();
            dt1 = cd.getdata("sp_categorybefordelete", pa);
            if(dt1.Rows[0][0].ToString()!="0")
            {
                MSg.showmsg("لا يمكن حذف بيانات المجموعة لوجود أصناف بهذه المجموعة", MSg.msgbutton.okcancel, MSg.msgicon.warning);
                return;
            }
            if(MSg.showmsg("حذف بيانات المجموعة",MSg.msgbutton.okcancel,MSg.msgicon.warning)==MSg.result.OK)
            {
               
                SqlParameter[] p = new SqlParameter[1];
                p[0]=new SqlParameter("@cat_code",cat_code);
                cd.runproc("sp_categorydelete", p);
                gridView1.DeleteSelectedRows();
                txt_name.Text = string.Empty;
            }       
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void txt_name_EditValueChanged(object sender, EventArgs e)
        {
            if (allowfilter == false) { return; }
            gridView1.ActiveFilterCriteria = new BinaryOperator(new OperandProperty("category_name"), new OperandValue("%" + txt_name.Text + "%"), BinaryOperatorType.Like);

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            allowfilter = false;
            int currentrow = gridView1.FocusedRowHandle;
            category_code = int.Parse(gridView1.GetRowCellValue(currentrow, "category_code").ToString());
            txt_name.Text = gridView1.GetRowCellValue(currentrow, "category_name").ToString();
            allowupdate = true;
            btn_save.Tag = "1";
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            frm_addproducts.getmain.bindingcatagory();
            frm_addproducts.getmain.cmb_category.Text = category_name;
            this.Close();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {

        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btn_save_Click(null, null);
                labelControl5_Click(null, null);
            }
        }
    }
}