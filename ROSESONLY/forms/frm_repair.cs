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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;

namespace ROSESONLY.forms
{
    public partial class frm_repair : DevExpress.XtraEditors.XtraForm
    {
        //Server myserver = new Server(".");
        public frm_repair()
        {
            InitializeComponent();
        }

        private void frm_repair_Load(object sender, EventArgs e)
        {
            txt_contype.Text = Properties.Settings.Default.connection_type;
            txt_servername.Text = Properties.Settings.Default.server_name;
            txt_database.Text = Properties.Settings.Default.database;
            txt_user.Text = Properties.Settings.Default.user_id;
            txt_password.Text = Properties.Settings.Default.password;
            //try
            //{
            //    DatabaseCollection db = myserver.Databases;
            //    for (int i = 0; i < db.Count; i++)
            //    {
            //        comboBoxEdit1.Properties.Items.Add(db[i].Name);
            //    }
            //    textEdit2.Text = myserver.Name;
            //}
            //catch (Exception)
            //{
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //myserver.Databases[comboBoxEdit1.Text].Drop();
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //myserver.DetachDatabase(comboBoxEdit1.Text,true);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.connection_type = txt_contype.Text;
            Properties.Settings.Default.server_name = txt_servername.Text;
            Properties.Settings.Default.database = txt_database.Text;
            Properties.Settings.Default.user_id = txt_user.Text;
            Properties.Settings.Default.password = txt_password.Text;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void txt_contype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txt_contype.SelectedIndex==0)
            {
                panelControl1.Enabled = true;
            }
            else
            {
                panelControl1.Enabled = false;

            }
        }
    }
}