using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.BarCode;

namespace ROSESONLY.reports
{
    public partial class rpt_barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_barcode()
        {
            //this.Margins.Top = Properties.Settings.Default.top_margins;
            //this.PageWidth = Properties.Settings.Default.b_width;
            //this.PageHeight = Properties.Settings.Default.b_high;
            //this.Margins.Left = Properties.Settings.Default.left_margins;
            InitializeComponent();
            if (Properties.Settings.Default.show_barcode == true)
            {
                xrBarCode1.ShowText = true;
            }
            else
            {
                xrBarCode1.ShowText = false;
            }

            if (Properties.Settings.Default.show_name == true)
            {
                lb_name.Visible = true;
            }
            else
            {
                lb_name.Visible = false;
            }
            if (Properties.Settings.Default.show_price == true)
            {
                lb_price.Visible = true;
                lb_caption.Visible = true;

            }
            else
            {
                lb_price.Visible = false;
                lb_caption.Visible = false; ;

            }


        }

        private void rpt_barcode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            float page_height = this.PageHeight;
            float page_width = this.PageWidth;
            float[] old_height = new float[4];
            old_height[0] = xrBarCode1.HeightF/page_height;
            old_height[1] = lb_name.HeightF/page_height;
            old_height[2] = lb_price.HeightF / page_height;
            old_height[3] = lb_caption.HeightF / page_height;

            float[] old_width = new float[4];
            old_width[0] = xrBarCode1.WidthF/page_width;
            old_width[1] = lb_name.WidthF / page_width;
            old_width[2] = lb_price.WidthF / page_width;
            old_width[3] = lb_caption.WidthF / page_width;

            float[] old_top = new float[4];
            old_top[0] = xrBarCode1.TopF / page_height;
            old_top[1] = lb_name.TopF / page_height;
            old_top[2] = lb_price.TopF / page_height;
            old_top[3] = lb_caption.TopF / page_height;

            float[] old_left = new float[4];
            old_left[0] = xrBarCode1.LeftF / page_width;
            old_left[1] = lb_name.LeftF / page_width;
            old_left[2] = lb_price.LeftF / page_width;
            old_left[3] = lb_caption.LeftF / page_width;


            //..........................
            this.PageSize = new Size(Properties.Settings.Default.b_width, Properties.Settings.Default.b_high);
            float new_height = this.PageHeight;
            float new_width = this.PageWidth;

            xrBarCode1.SizeF = new SizeF(old_width[0]*new_width,old_height[0]*new_height);
            lb_name.SizeF = new SizeF(old_width[1] * new_width,old_height[1] * new_height);
            lb_price.SizeF = new SizeF(old_width[2] * new_width,old_height[2] * new_height);
            lb_caption.SizeF = new SizeF( old_width[3] * new_width,old_height[3] * new_height);

            xrBarCode1.LocationF = new PointF(old_left[0] * new_width, old_top[0] * new_height);
            lb_name.LocationF = new PointF(old_left[1] * new_width, old_top[1] * new_height);
            lb_price.LocationF = new PointF(old_left[2] * new_width, old_top[2] * new_height);
            lb_caption.LocationF = new PointF(old_left[3] * new_width, old_top[3] * new_height);

            this.Margins = new System.Drawing.Printing.Margins(Properties.Settings.Default.left_margins, 0, Properties.Settings.Default.top_margins, 0);
            xrBarCode1.Font = new Font(Properties.Settings.Default.font_name, Properties.Settings.Default.barcode_size);
            lb_name.Font = new Font(Properties.Settings.Default.font_name, Properties.Settings.Default.name_size);
            lb_price.Font = new Font(Properties.Settings.Default.font_name, Properties.Settings.Default.price_size);
            lb_caption.Font = new Font(Properties.Settings.Default.font_name, Properties.Settings.Default.price_size);
            
            //xrBarCode1.Symbology = GetBarCodeSymbology((Symbology)searchLookUpEditBarCodeSymbology.EditValue);
            //propertyGridControlBarCode.SelectedObject = null;
            //propertyGridControlBarCode.SelectedObject = barCodeControl1.Symbology;
        }
            private void xrBarCode1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
