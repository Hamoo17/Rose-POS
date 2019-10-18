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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
using System.Collections.Specialized;
using System.Security.AccessControl;
using Microsoft.Win32;
using MicroVisionTrailMaker;


namespace ROSESONLY.forms
{
    public partial class frm_login : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        MicroVisionTrailMaker.TrailRegister trial = new TrailRegister();
        string str = "";
        public frm_login()
        {
            InitializeComponent();
            lb_number.Text = Properties.Settings.Default.open_number.ToString();
            Properties.Settings.Default.open_number += 1;
            Properties.Settings.Default.Save();
        }
        string getkey()
        {
            try
            {
                RegistryKey reg;
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Rose_reg", true);
                string x;
                x = reg.GetValue("prog_key").ToString();
                return x;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            //check programe regestrations************
            if (getkey() == string.Empty)
            {
                trayagain:
                str = trial.TrialPeriod(7, "SOFTWARE", "windowslog");
                if (string.IsNullOrEmpty(str))
                {
                    goto trayagain;
                }
                else
                {
                    if (str.StartsWith("XXX") == true)
                    {
                        if(Properties.Settings.Default.open_number>100)
                        {
                            frm_activations frm2 = new frm_activations();
                            frm2.ShowDialog();
                        }
                    }
                    else
                    {
                        frm_activations frm2 = new frm_activations();
                        frm2.ShowDialog();
                    }
                }
            }
            else
            {
                if (MicroVisionSerial.Encryption.Activation.CheckActivationKey(Security.FingerPrint.Value(), getkey()) == false)
                {
                    MessageBox.Show("error in activations code");
                    frm_activations frm = new frm_activations();
                    frm.ShowDialog();
                    Application.Exit();
                }
            }
            //attaching database to server...................
            //if(Properties.Settings.Default.connection_type== "Local Server")
            //{
            //    Server myserver = new Server(".");
            //    Database my_database = myserver.Databases["DB_ROSES"];
            //    DatabaseCollection db = myserver.Databases;
            //    for (int i = 0; i < db.Count; i++)
            //    {
            //        if (db[i].Name == "DB_ROSES")
            //        {
            //            return;
            //        }
            //    }
            //    StringCollection databasepath = new StringCollection();
            //    databasepath.Add(Application.StartupPath + @"\DB_ROSES.mdf");
            //    databasepath.Add(Application.StartupPath + @"\DB_ROSES_log.ldf");
            //    myserver.AttachDatabase("DB_ROSES", databasepath);
            //}
        }
        bool checklogin()
        {
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_name", txt_username.Text);
            p[1] = new SqlParameter("@password", txt_password.Text);
            dt = cd.getdata("sp_userlogin", p);
            if(dt.Rows.Count==0)
            {
                return false;
            }
            else
            {
                connectiondata.user_id=int.Parse(dt.Rows[0][0].ToString());
                connectiondata._username = dt.Rows[0][1].ToString();
                return true;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_password.Text) || string.IsNullOrEmpty(txt_username.Text))
            {
                MSg.showmsg("يرجى أدخال أسم المستخدم وكلمة المرور", MSg.msgbutton.ok, MSg.msgicon.information);
                return;
            }
            if (checklogin() == true)
            {
                this.Hide();
                frm_othermain.getmain.lb_user_name.Text = connectiondata._username;
                frm_othermain.getmain.ShowDialog();
                this.Close();
            }
            else
            {
                MSg.showmsg("خطأ فى أسم المستخدم أو كلمة المرور", MSg.msgbutton.ok, MSg.msgicon.information);
            }

        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_username.Text))
                {
                    errorProvider1.SetError(txt_username, "أدخل أسم المستخدم");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (string.IsNullOrEmpty(txt_password.Text))
                {
                    errorProvider1.SetError(txt_password, "أدخل كلمة المرور");
                    return;
                }
                else
                {
                    errorProvider1.Dispose();
                }
                if (checklogin() == true)
                {
                    this.Hide();
                    FRM_MAIN.getmain.lb_user_name.Text = txt_username.Text;
                    connectiondata._username = txt_username.Text;
                    FRM_MAIN.getmain.ShowDialog();
                    this.Close();
                }
                else
                {
                    txt_username.Text = string.Empty;
                    txt_password.Text = string.Empty;
                    txt_username.Focus();
                    errorProvider1.Dispose();
                }

            }
        }

        private void txt_password_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMetroTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text))
            {
                lb_username.Visible = true;
            }
            else
            {
                lb_username.Visible = false;
            }

        }

        private void bunifuMetroTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_password.Text))
            {
                lb_password.Visible = true;
            }
            else
            {
                lb_password.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_password.Text) || string.IsNullOrEmpty(txt_username.Text))
                {
                    MSg.showmsg("يرجى أدخال أسم المستخدم وكلمة المرور", MSg.msgbutton.ok, MSg.msgicon.information);
                    return;
                }
                if (checklogin() == true)
                {
                    this.Hide();
                    frm_othermain.getmain.lb_user_name.Text = connectiondata._username;
                    frm_othermain.getmain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MSg.showmsg("خطأ فى أسم المستخدم أو كلمة المرور", MSg.msgbutton.ok, MSg.msgicon.information);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_repair frm = new frm_repair();
            frm.ShowDialog();
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}