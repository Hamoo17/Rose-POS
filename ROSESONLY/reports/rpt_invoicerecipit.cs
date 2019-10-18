using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ROSESONLY.forms;
namespace ROSESONLY.reports
{
    public partial class rpt_invoicerecipit : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_invoicerecipit()
        {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lb_accounts.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["accounts_name"].ToString();
            lb_date.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["invoice_date"].ToString();
            lb_usernames.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["user_name"].ToString();
            lb_adress.Text = Properties.Settings.Default.adress;
            lb_phone.Text = Properties.Settings.Default.phone1;
            lb_phone2.Text = Properties.Settings.Default.phone2;
            lb_notes.Text = XtraForm1.getmain.dt_setting.Rows[0]["recipet_notes"].ToString();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lb_name.Text = Properties.Settings.Default.company_name;

        }

        private void rpt_invoicerecipit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lb_discount.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["discount"].ToString();
            lb_net.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["net_value"].ToString();
            lb_invoiceno.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["invoice_no"].ToString();
        }

        private void lb_name_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lb_store.Text = frm_othermain.getmain.dt_invoicedata.Rows[0]["store_name"].ToString();

        }
    }
}
