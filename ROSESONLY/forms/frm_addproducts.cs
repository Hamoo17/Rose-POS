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
    public partial class frm_addproducts : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public  DataTable dt_stores=new DataTable();
        public  DataTable dt_units=new DataTable();
        private static frm_addproducts frm;
        bool validatingcode;
        bool validatingname;
        public  bool addnew = true;
        public int old_code;
        static void form_closed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_addproducts getmain
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_addproducts();
                    frm.FormClosed += new FormClosedEventHandler(form_closed);
                } return frm;
            }
        }
        public frm_addproducts()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            dt_stores.Columns.Add("store_id", typeof(int));
            dt_stores.Columns.Add("store_name", typeof(string));
            dt_stores.Columns.Add("first_balance", typeof(decimal));
            dt_stores.Columns.Add("balance_price", typeof(decimal));
            grd_stores.DataSource = dt_stores;
            //*************************
            dt_units.Columns.Add("parcode",typeof(string));
            dt_units.Columns.Add("unit_name",typeof(string));
            dt_units.Columns.Add("unit_count", typeof(decimal));
            dt_units.Columns.Add("buy_price", typeof(decimal));
            dt_units.Columns.Add("sell_price", typeof(decimal));
            dt_units.Columns.Add("min_unit", typeof(string));
            dt_units.Columns.Add("buy_default", typeof(Boolean));
            dt_units.Columns.Add("sell_default", typeof(Boolean));
            addfirstunit();
            _addstoredata();
            grd_units.DataSource = dt_units;
        }
        void addfirstunit()
        {
            //add first unit
            DataRow row;
            row = dt_units.NewRow();
            row["unit_name"] = "قطعه";
            row["unit_count"] = Convert.ToDecimal("1");
            row["buy_price"] = Convert.ToDecimal("0");
            row["sell_price"] = Convert.ToDecimal("0");
            row["sell_default"] = true;
            row["buy_default"] = true;
            row["min_unit"] = "1";
            dt_units.Rows.Add(row);

        }
        void _addstoredata()
        {
           DataTable dt=new DataTable();
            dt=cd.getdata("sp_selectstores", null);
            for (int i = 0; i < dt.Rows.Count; i++)
			{
			DataRow newrow;
            newrow = dt_stores.NewRow();
            newrow["store_id"] = dt.Rows[i]["store_id"].ToString();
            newrow["store_name"] = dt.Rows[i]["store_name"].ToString();
            newrow["first_balance"] = "0";
            newrow["balance_price"] = "0";
            dt_stores.Rows.Add(newrow);
			}
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       public  void bindingcatagory()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_bindingcategory", null);
            cmb_category.Properties.DataSource = dt;
            cmb_category.Properties.DisplayMember = "category_name";
            cmb_category.Properties.ValueMember = "category_code";
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frm_storeproducts frm = new frm_storeproducts();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(653, 556);
            frm.ShowDialog();
        }
        
        private void frm_addproducts_Load(object sender, EventArgs e)
        {
         bindingcatagory();
         if(addnew==true){txt_code.Text=bindingproduct_code().ToString();}
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
        }

        private void btn_saveandnew_Click(object sender, EventArgs e)
        {
          if(addnew==true)
          {
              //add new product
              #region validatingdata
              if (string.IsNullOrEmpty(txt_code.Text))
              {
                  errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                  return;
              }
              if (string.IsNullOrEmpty(txt_name.Text))
              {
                  errorProvider1.Dispose();
                  errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                  return;
              }
              if (string.IsNullOrEmpty(cmb_category.Text))
              {
                  errorProvider1.Dispose();
                  errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                  return;
              }
              productcode_validating();
              validatingproductName();
              if (validatingcode == false || validatingname == false)
              {
                  MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                  return;
              }
              #endregion
              //saving image
              if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
              MemoryStream ms = new MemoryStream();
              product_image.Image.Save(ms, product_image.Image.RawFormat);
              byte[] imagebyte = ms.ToArray();
              #region savingdata
              errorProvider1.Dispose();
              SqlParameter[] p = new SqlParameter[12];
              p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
              p[1] = new SqlParameter("@product_name", txt_name.Text);
              p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
              p[3] = new SqlParameter("@isactive", isactive.EditValue);
              p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
              p[5] = new SqlParameter("@product_image", imagebyte);
              p[6] = new SqlParameter("@product_units", dt_units);
              p[7] = new SqlParameter("@store", dt_stores);
              p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
              p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
              p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
              p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));
              cd.runproc("sp_productsInsert", p);
              frm_productlist.getmain.bindingproducts();
              int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
              this.Close();
              #endregion
          }
          else
          {
              //update current product
              #region update productdata
                      #region validatingdata
                      if (string.IsNullOrEmpty(txt_code.Text))
                      {
                          errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                          return;
                      }
                      if (string.IsNullOrEmpty(txt_name.Text))
                      {
                          errorProvider1.Dispose();
                          errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                          return;
                      }
                      if (string.IsNullOrEmpty(cmb_category.Text))
                      {
                          errorProvider1.Dispose();
                          errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                          return;
                      }
                      productcode_validating();
                      validatingproductName();
                      if (validatingcode == false || validatingname == false)
                      {
                          MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                          return;
                      }
                      #endregion
                      //saving image
                      if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
                      MemoryStream ms = new MemoryStream();
                      product_image.Image.Save(ms, product_image.Image.RawFormat);
                      byte[] imagebyte = ms.ToArray();
                      #region savingdata
                      errorProvider1.Dispose();
                      SqlParameter[] p = new SqlParameter[12];
                      p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
                      p[1] = new SqlParameter("@product_name", txt_name.Text);
                      p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
                      p[3] = new SqlParameter("@isactive", isactive.EditValue);
                      p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
                      p[5] = new SqlParameter("@product_image", imagebyte);
                      p[6] = new SqlParameter("@product_units", dt_units);
                      p[7] = new SqlParameter("@store", dt_stores);
                      p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
                      p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
                      p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
                      p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));

                      cd.runproc("sp_productsupdate", p);
                frm_productlist.getmain.bindingproducts();
                      int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
                      this.Close();
                      #endregion

              #endregion
          }
        }

        private void product_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==DialogResult.OK)
            {
                product_image.Image = Image.FromFile(op.FileName);
            }
        }

        private void txt_code_EditValueChanged(object sender, EventArgs e)
        {

        }
        int bindingproduct_code()
        {
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_productcode", null);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        void productcode_validating()
        {
           if(addnew==true)
           {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_checkproduct_code", p);
            if (dt.Rows[0][0].ToString() != "0")
            {
                errorProvider1.SetError(txt_code, "يرجى أدخال كود اخر للصنف");
                validatingcode = false;
            }
            else
            {
                errorProvider1.Dispose();
                validatingcode = true;
            }
           }
           else
           {
               SqlParameter[] p = new SqlParameter[2];
               p[0] = new SqlParameter("@old_code", old_code);
               p[1] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
               DataTable dt = new DataTable();
               dt = cd.getdata("sp_productcode_validating", p);
               if (dt.Rows[0][0].ToString() != "0")
               {
                   errorProvider1.SetError(txt_code, "يرجى أدخال كود اخر للصنف");
                   validatingcode = false;
               }
               else
               {
                   errorProvider1.Dispose();
                   validatingcode = true;
               }

           }

        }
        private void txt_code_Validating(object sender, CancelEventArgs e)
        {
            productcode_validating();
        }
        void validatingproductName()
        {
            #region validatin product name
            if (addnew == true)
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@product_name", txt_name.Text);
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_productname_validating", p);
                if (dt.Rows[0][0].ToString() != "0")
                {
                    errorProvider1.SetError(txt_name, "أسم الصنف مسجل مسبقا ");
                    validatingname = false;
                }
                else
                {
                    validatingname = true;
                    errorProvider1.Dispose();
                }
            }
            else
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@product_name", txt_name.Text);
                p[1] = new SqlParameter("@old_code", old_code);
                DataTable dt = new DataTable();
                dt = cd.getdata("sp_productname_validating2", p);
                if (dt.Rows[0][0].ToString() != "0")
                {
                    errorProvider1.SetError(txt_name, "أسم الصنف مسجل مسبقا ");
                    validatingname = false;
                }
                else
                {
                    validatingname = true;
                    errorProvider1.Dispose();
                }
            }

            #endregion

        }
        private void txt_name_Validating(object sender, CancelEventArgs e)
        {
            validatingproductName();
        }
        void cleardata()
        {
            txt_largeprice.Text= "0";
            txt_discount.Text = "0";
            txt_limitprice.Text = "0";
            txt_less.Text = "0";
        txt_code.Text= bindingproduct_code().ToString();
        txt_name.Text = string.Empty;
        cmb_category.EditValue = -1;
        txt_less.Text = "0";
        dt_stores.Clear();
        dt_units.Clear();
        addfirstunit();
        _addstoredata();
        product_image.Image = ROSESONLY.Properties.Resources.product_image;
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if(addnew==true)
            {
            #region validatingdata
            if (string.IsNullOrEmpty(txt_code.Text))
            {
                errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                return;
            }
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                return;
            }
            if (string.IsNullOrEmpty(cmb_category.Text))
            {
                errorProvider1.Dispose();
                errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                return;
            }
            productcode_validating();
            validatingproductName();
            if (validatingcode == false||validatingname==false)
            {
                MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            errorProvider1.Dispose();
            #endregion
            #region savingdata
            //saving image
            if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
            MemoryStream ms = new MemoryStream();
            product_image.Image.Save(ms, product_image.Image.RawFormat);
            byte[] imagebyte = ms.ToArray();
            bindingproduct_code();
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
            p[1] = new SqlParameter("@product_name", txt_name.Text);
            p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
            p[3] = new SqlParameter("@isactive", isactive.EditValue);
            p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
            p[5] = new SqlParameter("@product_image", imagebyte);
            p[6] = new SqlParameter("@product_units", dt_units);
            p[7] = new SqlParameter("@store", dt_stores);
            p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
            p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
            p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
            p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));

            cd.runproc("sp_productsInsert", p);
                MSg.showmsg("تم حفظ بيانت الصنف بنجاح", MSg.msgbutton.ok, MSg.msgicon.information);
                frm_productlist.getmain.bindingproducts();
            int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
            cleardata();
            txt_name.Focus();
            #endregion
            }
            else
            {
                #region update productdata
                #region validatingdata
                if (string.IsNullOrEmpty(txt_code.Text))
                {
                    errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                    return;
                }
                if (string.IsNullOrEmpty(txt_name.Text))
                {
                    errorProvider1.Dispose();
                    errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                    return;
                }
                if (string.IsNullOrEmpty(cmb_category.Text))
                {
                    errorProvider1.Dispose();
                    errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                    return;
                }
                productcode_validating();
                validatingproductName();
                if (validatingcode == false || validatingname == false)
                {
                    MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                    return;
                }
                #endregion
                //saving image
                if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
                MemoryStream ms = new MemoryStream();
                product_image.Image.Save(ms, product_image.Image.RawFormat);
                byte[] imagebyte = ms.ToArray();
                #region savingdata
                errorProvider1.Dispose();
                SqlParameter[] p = new SqlParameter[12];
                p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
                p[1] = new SqlParameter("@product_name", txt_name.Text);
                p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
                p[3] = new SqlParameter("@isactive", isactive.EditValue);
                p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
                p[5] = new SqlParameter("@product_image", imagebyte);
                p[6] = new SqlParameter("@product_units", dt_units);
                p[7] = new SqlParameter("@store", dt_stores);
                p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
                p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
                p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
                p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));

                cd.runproc("sp_productsupdate", p);
                MSg.showmsg("تم حفظ بيانت الصنف بنجاح", MSg.msgbutton.ok, MSg.msgicon.information);
                frm_productlist.getmain.bindingproducts();
                int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
                cleardata();
                txt_name.Focus();
                addnew = true;
                #endregion
                #endregion

            }

        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
        }
//return productsdata
        public void returndata(int product_code)
        {
            DataTable dt1 = new DataTable();
            SqlParameter[] p1 = new SqlParameter[1];
            p1[0] = new SqlParameter("@product_code", product_code);
            dt1 = cd.getdata("sp_returnproductsdata", p1);
            txt_code.Text = dt1.Rows[0]["product_code"].ToString();
            txt_name.Text = dt1.Rows[0]["product_name"].ToString();
            txt_less.Text = dt1.Rows[0]["min_count"].ToString();
            cmb_category.EditValue = dt1.Rows[0]["category_code"];
            isactive.EditValue = dt1.Rows[0]["isactive"];
            isexpire.EditValue = dt1.Rows[0]["isexpiredate"];
            txt_discount.Text = dt1.Rows[0]["discount_percent"].ToString();
            txt_largeprice.Text = dt1.Rows[0]["larg_price"].ToString();
            txt_limitprice.Text = dt1.Rows[0]["limit_sellprice"].ToString();

            //استرجاع بيانات الصوره
            try
            {
                if (dt1.Rows[0]["product_image"] == null)
                {
                    product_image.Image = Properties.Resources.product_image;
                }
                else
                {
                    byte[] imagebyt = (byte[])dt1.Rows[0]["product_image"];
                    MemoryStream ms = new MemoryStream(imagebyt);
                    product_image.Image = Image.FromStream(ms);
                }
            }
            catch (Exception)
            {

                product_image.Image = Properties.Resources.product_image;
            }
            //return productunit data
            SqlParameter[] p2 = new SqlParameter[1];
            p2[0] = new SqlParameter("@product_code", product_code);
            dt_units = cd.getdata("sp_productunitdata", p2);
            grd_units.DataSource = dt_units;
            
            //return store data
            DataTable dt3 = new DataTable();
            SqlParameter[] p3 = new SqlParameter[1];
            p3[0] = new SqlParameter("@product_code", product_code);
            dt_stores = cd.getdata("sp_returnstoredata", p3);
            grd_stores.DataSource = dt_stores;



        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) { return; }
            gridView1.DeleteSelectedRows();
            dt_stores.AcceptChanges();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0) { return; }
            frm_storeproducts frm = new frm_storeproducts();
            frm.cmb_stores.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "store_id");
            frm.txt_quantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "first_balance").ToString();
            frm.btn_save.Tag = "1";
            frm.store_id = int.Parse( frm.cmb_stores.EditValue.ToString());
            frm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (addnew == false)
                {
                    #region update productdata
                    #region validatingdata
                    if (string.IsNullOrEmpty(txt_code.Text))
                    {
                        errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_name.Text))
                    {
                        errorProvider1.Dispose();
                        errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                        return;
                    }
                    if (string.IsNullOrEmpty(cmb_category.Text))
                    {
                        errorProvider1.Dispose();
                        errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                        return;
                    }
                    productcode_validating();
                    validatingproductName();
                    if (validatingcode == false || validatingname == false)
                    {
                        MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                        return;
                    }
                    #endregion
                    //saving image
                    if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
                    MemoryStream ms = new MemoryStream();
                    product_image.Image.Save(ms, product_image.Image.RawFormat);
                    byte[] imagebyte = ms.ToArray();
                    #region savingdata
                    errorProvider1.Dispose();
                    SqlParameter[] p = new SqlParameter[12];
                    p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
                    p[1] = new SqlParameter("@product_name", txt_name.Text);
                    p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
                    p[3] = new SqlParameter("@isactive", isactive.EditValue);
                    p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
                    p[5] = new SqlParameter("@product_image", imagebyte);
                    p[6] = new SqlParameter("@product_units", dt_units);
                    p[7] = new SqlParameter("@store", dt_stores);
                    p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
                    p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
                    p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
                    p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));

                    cd.runproc("sp_productsupdate", p);
                    frm_productlist.getmain.bindingproducts();
                    int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                    frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
                    #endregion

                    #endregion
                    frm_productlist.getmain.gridView1.MoveNext();
                    int rowindex = frm_productlist.getmain.gridView1.FocusedRowHandle;
                    int product_code = int.Parse(frm_productlist.getmain.gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                    returndata(product_code);
                    old_code = product_code;
                }
                else
                {
                    frm_productlist.getmain.gridView1.MoveNext();
                    int rowindex = frm_productlist.getmain.gridView1.FocusedRowHandle;
                    int product_code = int.Parse(frm_productlist.getmain.gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                    returndata(product_code);
                    old_code = product_code;
                    addnew = false;
                }

            }
            catch (Exception)
            {}
                
             
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
            if (addnew == false)
            {
                #region update productdata
                #region validatingdata
                if (string.IsNullOrEmpty(txt_code.Text))
                {
                    errorProvider1.SetError(txt_code, "يرجى أدخال كود الصنف");
                    return;
                }
                if (string.IsNullOrEmpty(txt_name.Text))
                {
                    errorProvider1.Dispose();
                    errorProvider1.SetError(txt_name, "يرجى أدخال أسم الصنف");
                    return;
                }
                if (string.IsNullOrEmpty(cmb_category.Text))
                {
                    errorProvider1.Dispose();
                    errorProvider1.SetError(cmb_category, "يرجى أختيار التصنيف");
                    return;
                }
                productcode_validating();
                validatingproductName();
                if (validatingcode == false || validatingname == false)
                {
                    MSg.showmsg("يرجى التاكد  من البيانات", MSg.msgbutton.ok, MSg.msgicon.information);
                    return;
                }
                #endregion
                //saving image
                if (product_image.Image == null) { product_image.Image = ROSESONLY.Properties.Resources.product_image; }
                MemoryStream ms = new MemoryStream();
                product_image.Image.Save(ms, product_image.Image.RawFormat);
                byte[] imagebyte = ms.ToArray();
                #region savingdata
                errorProvider1.Dispose();
                SqlParameter[] p = new SqlParameter[12];
                p[0] = new SqlParameter("@product_code", int.Parse(txt_code.Text));
                p[1] = new SqlParameter("@product_name", txt_name.Text);
                p[2] = new SqlParameter("@category_code", cmb_category.EditValue);
                p[3] = new SqlParameter("@isactive", isactive.EditValue);
                p[4] = new SqlParameter("@isexpiredate", isexpire.EditValue);
                p[5] = new SqlParameter("@product_image", imagebyte);
                p[6] = new SqlParameter("@product_units", dt_units);
                p[7] = new SqlParameter("@store", dt_stores);
                p[8] = new SqlParameter("@min_count", decimal.Parse(txt_less.Text));
                p[9] = new SqlParameter("@larg_price", Convert.ToDecimal(txt_largeprice.Text));
                p[10] = new SqlParameter("@limit_sellprice", Convert.ToDecimal(txt_limitprice.Text));
                p[11] = new SqlParameter("@discount_present", Convert.ToInt16(txt_discount.Text));

                cd.runproc("sp_productsupdate", p);
                    frm_productlist.getmain.bindingproducts();
                int selectedrow = frm_productlist.getmain.gridView1.LocateByValue("product_code", int.Parse(txt_code.Text), null);
                    frm_productlist.getmain.gridView1.FocusedRowHandle = selectedrow;
                    #endregion

                    #endregion
                    frm_productlist.getmain.gridView1.MovePrev();
                int rowindex = frm_productlist.getmain.gridView1.FocusedRowHandle;
                int product_code = int.Parse(frm_productlist.getmain.gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                returndata(product_code);
                old_code = product_code;
            }
            else
            {
                    frm_productlist.getmain.gridView1.MovePrev();
                int rowindex = frm_productlist.getmain.gridView1.FocusedRowHandle;
                int product_code = int.Parse(frm_productlist.getmain.gridView1.GetRowCellValue(rowindex, "product_code").ToString());
                returndata(product_code);
                old_code = product_code;
                addnew = false;
            }

            }
            catch (Exception)
            {  }
                
        
            

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grd_units_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            frm_category frm = new frm_category();
            frm.ShowDialog();

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.SelectedRowsCount == 0) { return; }
            int row = gridView2.FocusedRowHandle;
            string currentrow = gridView2.GetRowCellValue(row, "min_unit").ToString();
            frm_units frm = new frm_units();
            frm.retrndata(currentrow);
            frm.ShowDialog();

        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void repositoryItemCalcEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
        }

        private void frm_addproducts_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F1)
            {
                simpleButton3_Click_1(null, null);
            }
        }

        private void btn_add_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frm_units frm = new frm_units();
            DataRow[] row;
            row = dt_units.Select("min_unit='1'");
            frm_units.buyprice = Convert.ToDecimal(row[0]["buy_price"].ToString());
            frm_units.sellprice = Convert.ToDecimal(row[0]["sell_price"].ToString());
            frm.ShowDialog();

        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.SelectedRowsCount == 0) { return; }

            int min_unit = int.Parse(gridView2.GetFocusedRowCellValue("min_unit").ToString());
            int row = gridView2.FocusedRowHandle;
            string currentrow = gridView2.GetRowCellValue(row, "min_unit").ToString();
            frm_units frm = new frm_units();
            frm.retrndata(currentrow);
            if (min_unit == 1)
            {
                frm.min_unit = true;
            }
            else
            {
                frm.min_unit = false;
            }

            frm.ShowDialog();

        }

        private void btn_delet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView2.SelectedRowsCount == 0) { return; }
            if (int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "min_unit").ToString()) == 1)
            {
                errorProvider1.SetError(grd_units, "لا يمكن حذف بيانات الوحده الصغرى يمكن التعديل عليها فقط");
                return;
            }
            errorProvider1.Dispose();
            gridView2.DeleteSelectedRows();
            dt_units.AcceptChanges();


        }

        private void btn_add_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {

        }
    }
}