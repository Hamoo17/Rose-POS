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
    public partial class frm_changeprice : DevExpress.XtraEditors.XtraForm
    {
        public int id;
        public frm_changeprice()
        {
            InitializeComponent();
        }

        private void frm_changeqty_Load(object sender, EventArgs e)
        {
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}