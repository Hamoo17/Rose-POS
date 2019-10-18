namespace ROSESONLY.reports
{
    partial class rpt_barcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lb_caption = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_price = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_name = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(ROSESONLY.reports.DataSet1.parcode_printDataTable);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 18F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 3.208461F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_caption,
            this.lb_price,
            this.lb_name,
            this.xrBarCode1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 222.2082F;
            this.Detail.Name = "Detail";
            // 
            // lb_caption
            // 
            this.lb_caption.BackColor = System.Drawing.Color.Transparent;
            this.lb_caption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_caption.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_caption.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.lb_caption.BorderWidth = 1F;
            this.lb_caption.Dpi = 254F;
            this.lb_caption.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lb_caption.ForeColor = System.Drawing.Color.Black;
            this.lb_caption.LocationFloat = new DevExpress.Utils.PointFloat(254.3734F, 165.1082F);
            this.lb_caption.Name = "lb_caption";
            this.lb_caption.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_caption.SizeF = new System.Drawing.SizeF(108.6266F, 43.10001F);
            this.lb_caption.StyleName = "DetailData1";
            this.lb_caption.StylePriority.UseBackColor = false;
            this.lb_caption.StylePriority.UseBorderColor = false;
            this.lb_caption.StylePriority.UseBorderDashStyle = false;
            this.lb_caption.StylePriority.UseBorders = false;
            this.lb_caption.StylePriority.UseBorderWidth = false;
            this.lb_caption.StylePriority.UseFont = false;
            this.lb_caption.StylePriority.UseForeColor = false;
            this.lb_caption.StylePriority.UsePadding = false;
            this.lb_caption.StylePriority.UseTextAlignment = false;
            this.lb_caption.Text = "L.E";
            this.lb_caption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lb_price
            // 
            this.lb_price.BackColor = System.Drawing.Color.Transparent;
            this.lb_price.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_price.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_price.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.lb_price.BorderWidth = 1F;
            this.lb_price.Dpi = 254F;
            this.lb_price.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sell_price]")});
            this.lb_price.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.lb_price.ForeColor = System.Drawing.Color.Black;
            this.lb_price.LocationFloat = new DevExpress.Utils.PointFloat(21.00001F, 165.1082F);
            this.lb_price.Name = "lb_price";
            this.lb_price.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_price.SizeF = new System.Drawing.SizeF(233.3734F, 43.10001F);
            this.lb_price.StyleName = "DetailData1";
            this.lb_price.StylePriority.UseBackColor = false;
            this.lb_price.StylePriority.UseBorderColor = false;
            this.lb_price.StylePriority.UseBorderDashStyle = false;
            this.lb_price.StylePriority.UseBorders = false;
            this.lb_price.StylePriority.UseBorderWidth = false;
            this.lb_price.StylePriority.UseFont = false;
            this.lb_price.StylePriority.UseForeColor = false;
            this.lb_price.StylePriority.UsePadding = false;
            this.lb_price.StylePriority.UseTextAlignment = false;
            this.lb_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lb_name
            // 
            this.lb_name.BackColor = System.Drawing.Color.Transparent;
            this.lb_name.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_name.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_name.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.lb_name.BorderWidth = 1F;
            this.lb_name.Dpi = 254F;
            this.lb_name.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[product_name]")});
            this.lb_name.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.lb_name.ForeColor = System.Drawing.Color.Black;
            this.lb_name.LocationFloat = new DevExpress.Utils.PointFloat(21F, 18.54152F);
            this.lb_name.Name = "lb_name";
            this.lb_name.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_name.SizeF = new System.Drawing.SizeF(342F, 48.1F);
            this.lb_name.StyleName = "DetailData1";
            this.lb_name.StylePriority.UseBackColor = false;
            this.lb_name.StylePriority.UseBorderColor = false;
            this.lb_name.StylePriority.UseBorderDashStyle = false;
            this.lb_name.StylePriority.UseBorders = false;
            this.lb_name.StylePriority.UseBorderWidth = false;
            this.lb_name.StylePriority.UseFont = false;
            this.lb_name.StylePriority.UseForeColor = false;
            this.lb_name.StylePriority.UsePadding = false;
            this.lb_name.StylePriority.UseTextAlignment = false;
            this.lb_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[parcode]")});
            this.xrBarCode1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrBarCode1.KeepTogether = false;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(21F, 66.64152F);
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 254F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(342F, 98.4667F);
            this.xrBarCode1.StylePriority.UseBorders = false;
            this.xrBarCode1.StylePriority.UseFont = false;
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.Symbology = code128Generator1;
            this.xrBarCode1.Text = "2154536587542";
            this.xrBarCode1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrBarCode1_BeforePrint);
            // 
            // rpt_barcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 18, 3);
            this.PageHeight = 250;
            this.PageWidth = 380;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "18.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.rpt_barcode_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3_Odd;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lb_price;
        private DevExpress.XtraReports.UI.XRLabel lb_name;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel lb_caption;
    }
}
