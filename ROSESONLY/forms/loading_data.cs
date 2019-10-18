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
using ROSESONLY.DLL;
namespace ROSESONLY.forms
{
    public partial class loading_data : DevExpress.XtraEditors.XtraForm
    {
        connectiondata cd = new connectiondata();
        public loading_data()
        {
            InitializeComponent();
        }

        private void loading_data_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds= cd.get_dataset("sp_loading_data", null);
            gridControl1.DataSource = ds.Tables[0];
            gridControl2.DataSource = ds.Tables[1];
            gridControl3.DataSource = ds.Tables[2];

        }
    }
}