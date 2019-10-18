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
    public partial class frm_pointfosales : DevExpress.XtraEditors.XtraForm
    {
        public frm_pointfosales()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs r)
        {

            for (int i = 0; i < 50; i++)
            {
                SimpleButton sb = new SimpleButton();
                flowLayoutPanel1.Controls.Add(sb);
                sb.Text = "Product_name" + i;
                sb.Image = Properties.Resources.if_print_16_22615;
                sb.ImageLocation = ImageLocation.TopCenter;
                sb.Width = 100;
                sb.Click += (s, e) => { MessageBox.Show(sb.Text.ToString()); };
                sb.ToolTip = sb.Text;
                sb.Height = 100;
            }
        }

        private void frm_pointfosales_Click(object sender, EventArgs e)
        {
            
        }
    }
}