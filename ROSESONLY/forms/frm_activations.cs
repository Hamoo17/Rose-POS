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
using Microsoft.Win32;
using System.Security.AccessControl;

namespace ROSESONLY.forms
{
    public partial class frm_activations : DevExpress.XtraEditors.XtraForm
    {
        public frm_activations()
        {
            InitializeComponent();
        }
        bool regisactvations()
        {
            RegistryKey reg;
            try
            {
                //reg = Registry.LocalMachine.OpenSubKey("HARDWARE", true);
                //reg=Registry.LocalMachine.OpenSubKey(@"HARDWARE\cargallary",true);
                //if(reg ==null)
                //{
                reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                reg.CreateSubKey("Rose_reg");
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Rose_reg", true);
                reg.SetValue("prog_key", txt_activations.Text);
                reg.Close();
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_activations.Text))
            {
                MessageBox.Show("Please Enter Activations Keys...", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MicroVisionSerial.Encryption.Activation.CheckActivationKey(txt_serial.Text, txt_activations.Text) == true)
            {
                //Regrist activations value in system regestry.......
                if (regisactvations() == true)
                {
                    MessageBox.Show("Activations Complete", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frm_login frm = new frm_login();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error in activations please contact programmer", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invaild Keys", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frm_activations_Load(object sender, EventArgs e)
        {
            txt_serial.Text = Security.FingerPrint.Value();

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_activations_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}