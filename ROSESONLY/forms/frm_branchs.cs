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

namespace ROSESONLY.forms
{
    public partial class frm_branchs : DevExpress.XtraEditors.XtraForm
    {
        public frm_branchs()
        {
            InitializeComponent();
            //panelControl1.BackColor = Properties.Settings.Default.item_color;
            //simpleButton1.Appearance.BackColor = Properties.Settings.Default.item_color;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_branchs_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }
    }
}