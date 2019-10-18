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
    public partial class frm_stores : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public int store_id;
        public frm_stores()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_stores_Load(object sender, EventArgs e)
        {
            //panelControl1.BackColor = Properties.Settings.Default.item_color;
            //btn_save.Appearance.BackColor = Properties.Settings.Default.item_color;
        }
        bool checkname()
        {
           
            SqlParameter[]p=new SqlParameter[1];
            p[0]=new SqlParameter("@store_name",txt_name.Text);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_storebeforinsert", p);
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
            p[0] = new SqlParameter("@store_name", txt_name.Text);
            p[1] = new SqlParameter("@store_id", store_id);
            DataTable dt = new DataTable();
            dt = cd.getdata("sp_storecheck", p);
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
            if(string.IsNullOrEmpty(txt_name.Text))
            {
                errorProvider1.SetError(txt_name, "أدخل أسم المخزن او الفرع");
                return;
            }
            if(btn_save.Tag.ToString()=="0")
            {
                     if(checkname()==false)
                     {
                         errorProvider1.SetError(txt_name, "لا يمكن تكرار أسم المخزن");
                         return;
                     }
                     else
                     {
                         errorProvider1.Dispose();
                         SqlParameter[] p = new SqlParameter[1];
                         p[0] = new SqlParameter("@store_name", txt_name.Text);
                         cd.runproc("sp_storesinsert", p);
                         frm_settings.get_main.bindingstores();
                         this.Close();
                     }
            }
            else
            {
                if(checkbeforupdate()==false)
                {
                    MSg.showmsg("أسم المخزن مسجل مسبقا ولا يمكن تكراره", MSg.msgbutton.ok, MSg.msgicon.information);
                    return;
                }
                else
                {
                errorProvider1.Dispose();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@store_name", txt_name.Text);
                p[1] = new SqlParameter("@store_id", store_id);
                cd.runproc("sp_storesupdate", p);
                frm_settings.get_main.bindingstores();
                this.Close();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}