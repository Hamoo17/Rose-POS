namespace ROSESONLY.reports
{
    partial class rpt_invoicerecipit
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraPrinting.BarCode.EAN8Generator eaN8Generator1 = new DevExpress.XtraPrinting.BarCode.EAN8Generator();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lb_store = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_name = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_usernames = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_accounts = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_date = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_invoiceno = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_discount = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_net = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.lb_notes = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.lb_phone2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_phone = new DevExpress.XtraReports.UI.XRLabel();
            this.lb_adress = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(ROSESONLY.reports.DataSet1.purchase_invoicePrintDataTable);
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
            this.TopMargin.HeightF = 40F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lb_store,
            this.lb_name});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 247.3666F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.StylePriority.UseBackColor = false;
            this.ReportHeader.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportHeader_BeforePrint);
            // 
            // lb_store
            // 
            this.lb_store.BackColor = System.Drawing.Color.Transparent;
            this.lb_store.BorderColor = System.Drawing.Color.White;
            this.lb_store.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_store.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lb_store.BorderWidth = 2F;
            this.lb_store.Dpi = 254F;
            this.lb_store.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.lb_store.ForeColor = System.Drawing.Color.White;
            this.lb_store.LocationFloat = new DevExpress.Utils.PointFloat(162.9379F, 152.2399F);
            this.lb_store.Name = "lb_store";
            this.lb_store.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_store.SizeF = new System.Drawing.SizeF(278.0472F, 50.37667F);
            this.lb_store.StyleName = "DetailCaption1";
            this.lb_store.StylePriority.UseBackColor = false;
            this.lb_store.StylePriority.UseBorderColor = false;
            this.lb_store.StylePriority.UseBorderDashStyle = false;
            this.lb_store.StylePriority.UseBorders = false;
            this.lb_store.StylePriority.UseBorderWidth = false;
            this.lb_store.StylePriority.UseFont = false;
            this.lb_store.StylePriority.UseForeColor = false;
            this.lb_store.StylePriority.UsePadding = false;
            this.lb_store.StylePriority.UseTextAlignment = false;
            this.lb_store.Text = "branch name";
            this.lb_store.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_name
            // 
            this.lb_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_name.BorderColor = System.Drawing.Color.White;
            this.lb_name.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_name.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lb_name.BorderWidth = 2F;
            this.lb_name.Dpi = 254F;
            this.lb_name.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold);
            this.lb_name.ForeColor = System.Drawing.Color.White;
            this.lb_name.LocationFloat = new DevExpress.Utils.PointFloat(0F, 13.22917F);
            this.lb_name.Name = "lb_name";
            this.lb_name.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_name.SizeF = new System.Drawing.SizeF(608.0001F, 209.1374F);
            this.lb_name.StyleName = "DetailCaption1";
            this.lb_name.StylePriority.UseBackColor = false;
            this.lb_name.StylePriority.UseBorderColor = false;
            this.lb_name.StylePriority.UseBorderDashStyle = false;
            this.lb_name.StylePriority.UseBorders = false;
            this.lb_name.StylePriority.UseBorderWidth = false;
            this.lb_name.StylePriority.UseFont = false;
            this.lb_name.StylePriority.UseForeColor = false;
            this.lb_name.StylePriority.UsePadding = false;
            this.lb_name.StylePriority.UseTextAlignment = false;
            this.lb_name.Text = "testing";
            this.lb_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lb_name.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lb_name_BeforePrint);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel11,
            this.lb_usernames,
            this.lb_accounts,
            this.lb_date,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 192.4268F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StylePriority.UseTextAlignment = false;
            this.GroupHeader1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.GroupHeader1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeader1_BeforePrint);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(18.21514F, 17.9985F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(131.1394F, 45.19087F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = ":cashier";
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.White;
            this.xrLabel11.BorderColor = System.Drawing.Color.Black;
            this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel11.BorderWidth = 1F;
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(546.0432F, 133.2185F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(54.07977F, 59.20832F);
            this.xrLabel11.StyleName = "DetailCaption1";
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorderDashStyle = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseBorderWidth = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "#";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_usernames
            // 
            this.lb_usernames.BackColor = System.Drawing.Color.Transparent;
            this.lb_usernames.BorderColor = System.Drawing.Color.Gray;
            this.lb_usernames.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_usernames.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lb_usernames.BorderWidth = 1F;
            this.lb_usernames.Dpi = 254F;
            this.lb_usernames.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_usernames.ForeColor = System.Drawing.Color.Black;
            this.lb_usernames.LocationFloat = new DevExpress.Utils.PointFloat(149.3545F, 16.16029F);
            this.lb_usernames.Name = "lb_usernames";
            this.lb_usernames.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_usernames.SizeF = new System.Drawing.SizeF(205.836F, 47.02908F);
            this.lb_usernames.StyleName = "DetailData1";
            this.lb_usernames.StylePriority.UseBackColor = false;
            this.lb_usernames.StylePriority.UseBorderColor = false;
            this.lb_usernames.StylePriority.UseBorderDashStyle = false;
            this.lb_usernames.StylePriority.UseBorders = false;
            this.lb_usernames.StylePriority.UseBorderWidth = false;
            this.lb_usernames.StylePriority.UseFont = false;
            this.lb_usernames.StylePriority.UseForeColor = false;
            this.lb_usernames.StylePriority.UsePadding = false;
            this.lb_usernames.StylePriority.UseTextAlignment = false;
            this.lb_usernames.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lb_accounts
            // 
            this.lb_accounts.BackColor = System.Drawing.Color.Transparent;
            this.lb_accounts.BorderColor = System.Drawing.Color.Gray;
            this.lb_accounts.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_accounts.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lb_accounts.BorderWidth = 1F;
            this.lb_accounts.Dpi = 254F;
            this.lb_accounts.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_accounts.ForeColor = System.Drawing.Color.Black;
            this.lb_accounts.LocationFloat = new DevExpress.Utils.PointFloat(25.00001F, 63.18937F);
            this.lb_accounts.Name = "lb_accounts";
            this.lb_accounts.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_accounts.SizeF = new System.Drawing.SizeF(566F, 47.0291F);
            this.lb_accounts.StyleName = "DetailData1";
            this.lb_accounts.StylePriority.UseBackColor = false;
            this.lb_accounts.StylePriority.UseBorderColor = false;
            this.lb_accounts.StylePriority.UseBorderDashStyle = false;
            this.lb_accounts.StylePriority.UseBorders = false;
            this.lb_accounts.StylePriority.UseBorderWidth = false;
            this.lb_accounts.StylePriority.UseFont = false;
            this.lb_accounts.StylePriority.UseForeColor = false;
            this.lb_accounts.StylePriority.UsePadding = false;
            this.lb_accounts.StylePriority.UseTextAlignment = false;
            this.lb_accounts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lb_date
            // 
            this.lb_date.BackColor = System.Drawing.Color.Transparent;
            this.lb_date.BorderColor = System.Drawing.Color.Gray;
            this.lb_date.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_date.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lb_date.BorderWidth = 1F;
            this.lb_date.Dpi = 254F;
            this.lb_date.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_date.ForeColor = System.Drawing.Color.Black;
            this.lb_date.LocationFloat = new DevExpress.Utils.PointFloat(364.5562F, 16.16027F);
            this.lb_date.Name = "lb_date";
            this.lb_date.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_date.SizeF = new System.Drawing.SizeF(226.4438F, 47.0291F);
            this.lb_date.StyleName = "DetailData1";
            this.lb_date.StylePriority.UseBackColor = false;
            this.lb_date.StylePriority.UseBorderColor = false;
            this.lb_date.StylePriority.UseBorderDashStyle = false;
            this.lb_date.StylePriority.UseBorders = false;
            this.lb_date.StylePriority.UseBorderWidth = false;
            this.lb_date.StylePriority.UseFont = false;
            this.lb_date.StylePriority.UseForeColor = false;
            this.lb_date.StylePriority.UsePadding = false;
            this.lb_date.StylePriority.UseTextAlignment = false;
            this.lb_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lb_date.TextFormatString = "{0:yyyy-MM-dd}";
            // 
            // xrLabel7
            // 
            this.xrLabel7.BackColor = System.Drawing.Color.White;
            this.xrLabel7.BorderColor = System.Drawing.Color.Black;
            this.xrLabel7.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.BorderWidth = 1F;
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(302.1098F, 133.2185F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(243.8104F, 59.20832F);
            this.xrLabel7.StyleName = "DetailCaption1";
            this.xrLabel7.StylePriority.UseBackColor = false;
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorderDashStyle = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseBorderWidth = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "الصنف";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BackColor = System.Drawing.Color.White;
            this.xrLabel8.BorderColor = System.Drawing.Color.Black;
            this.xrLabel8.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.BorderWidth = 1F;
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(208.6125F, 133.2185F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(93.4973F, 59.20832F);
            this.xrLabel8.StyleName = "DetailCaption1";
            this.xrLabel8.StylePriority.UseBackColor = false;
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorderDashStyle = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "الكمية";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.White;
            this.xrLabel9.BorderColor = System.Drawing.Color.Black;
            this.xrLabel9.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.BorderWidth = 1F;
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(115.8993F, 133.2185F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(92.71326F, 59.20832F);
            this.xrLabel9.StyleName = "DetailCaption1";
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorderDashStyle = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseBorderWidth = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "السعر";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.BackColor = System.Drawing.Color.White;
            this.xrLabel10.BorderColor = System.Drawing.Color.Black;
            this.xrLabel10.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel10.BorderWidth = 1F;
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(14F, 133.2185F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(101.8993F, 59.20832F);
            this.xrLabel10.StyleName = "DetailCaption1";
            this.xrLabel10.StylePriority.UseBackColor = false;
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorderDashStyle = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseBorderWidth = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "القيمة";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel22,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 55.88F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel15.BorderColor = System.Drawing.Color.Black;
            this.xrLabel15.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel15.BorderWidth = 1F;
            this.xrLabel15.CanGrow = false;
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 5F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(545.9202F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(54.20288F, 55.88F);
            this.xrLabel15.StyleName = "DetailData1";
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseBorderColor = false;
            this.xrLabel15.StylePriority.UseBorderDashStyle = false;
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseBorderWidth = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel15.Summary = xrSummary1;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel15.WordWrap = false;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel22.BorderColor = System.Drawing.Color.Black;
            this.xrLabel22.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel22.BorderWidth = 1F;
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[total]")});
            this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(14F, 0F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(101.8993F, 55.88F);
            this.xrLabel22.StyleName = "DetailData1";
            this.xrLabel22.StylePriority.UseBackColor = false;
            this.xrLabel22.StylePriority.UseBorderColor = false;
            this.xrLabel22.StylePriority.UseBorderDashStyle = false;
            this.xrLabel22.StylePriority.UseBorders = false;
            this.xrLabel22.StylePriority.UseBorderWidth = false;
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseForeColor = false;
            this.xrLabel22.StylePriority.UsePadding = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel22.TextFormatString = "{0:#,#}";
            // 
            // xrLabel19
            // 
            this.xrLabel19.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel19.BorderColor = System.Drawing.Color.Black;
            this.xrLabel19.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel19.BorderWidth = 1F;
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[product_name]")});
            this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(302.1098F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(243.8104F, 55.88F);
            this.xrLabel19.StyleName = "DetailData1";
            this.xrLabel19.StylePriority.UseBackColor = false;
            this.xrLabel19.StylePriority.UseBorderColor = false;
            this.xrLabel19.StylePriority.UseBorderDashStyle = false;
            this.xrLabel19.StylePriority.UseBorders = false;
            this.xrLabel19.StylePriority.UseBorderWidth = false;
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseForeColor = false;
            this.xrLabel19.StylePriority.UsePadding = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel20.BorderColor = System.Drawing.Color.Black;
            this.xrLabel20.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.BorderWidth = 1F;
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[qty]")});
            this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(208.6125F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(93.4973F, 55.88F);
            this.xrLabel20.StyleName = "DetailData1";
            this.xrLabel20.StylePriority.UseBackColor = false;
            this.xrLabel20.StylePriority.UseBorderColor = false;
            this.xrLabel20.StylePriority.UseBorderDashStyle = false;
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseBorderWidth = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseForeColor = false;
            this.xrLabel20.StylePriority.UsePadding = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel20.TextFormatString = "{0:#,#}";
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel21.BorderColor = System.Drawing.Color.Black;
            this.xrLabel21.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel21.BorderWidth = 1F;
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[price]")});
            this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(115.8993F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(92.71326F, 55.88F);
            this.xrLabel21.StyleName = "DetailData1";
            this.xrLabel21.StylePriority.UseBackColor = false;
            this.xrLabel21.StylePriority.UseBorderColor = false;
            this.xrLabel21.StylePriority.UseBorderDashStyle = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseBorderWidth = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseForeColor = false;
            this.xrLabel21.StylePriority.UsePadding = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel21.TextFormatString = "{0:#,#}";
            // 
            // pageInfo1
            // 
            this.pageInfo1.Dpi = 254F;
            this.pageInfo1.Font = new System.Drawing.Font("Arial", 7F);
            this.pageInfo1.ForeColor = System.Drawing.Color.Gray;
            this.pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(117.8993F, 488.0829F);
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo1.SizeF = new System.Drawing.SizeF(372.9622F, 30.47998F);
            this.pageInfo1.StyleName = "PageInfo";
            this.pageInfo1.StylePriority.UseFont = false;
            this.pageInfo1.StylePriority.UseForeColor = false;
            this.pageInfo1.StylePriority.UseTextAlignment = false;
            this.pageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.pageInfo1.TextFormatString = "{0:dddd, dd MMMM, yyyy hh:mm tt}";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.White;
            this.xrLabel4.BorderColor = System.Drawing.Color.Black;
            this.xrLabel4.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.BorderWidth = 1F;
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(204.6978F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(97.412F, 52.59918F);
            this.xrLabel4.StyleName = "DetailCaption1";
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorderColor = false;
            this.xrLabel4.StylePriority.UseBorderDashStyle = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseBorderWidth = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "الخصم";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.White;
            this.xrLabel5.BorderColor = System.Drawing.Color.Black;
            this.xrLabel5.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.BorderWidth = 1F;
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(204.6978F, 52.59918F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(97.41202F, 52.59917F);
            this.xrLabel5.StyleName = "DetailCaption1";
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorderColor = false;
            this.xrLabel5.StylePriority.UseBorderDashStyle = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseBorderWidth = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "الأجمالى";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lb_invoiceno
            // 
            this.lb_invoiceno.BackColor = System.Drawing.Color.Transparent;
            this.lb_invoiceno.BorderColor = System.Drawing.Color.Transparent;
            this.lb_invoiceno.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_invoiceno.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lb_invoiceno.BorderWidth = 2F;
            this.lb_invoiceno.Dpi = 254F;
            this.lb_invoiceno.Font = new System.Drawing.Font("Arial", 7F);
            this.lb_invoiceno.ForeColor = System.Drawing.Color.Black;
            this.lb_invoiceno.LocationFloat = new DevExpress.Utils.PointFloat(180.899F, 439.8229F);
            this.lb_invoiceno.Name = "lb_invoiceno";
            this.lb_invoiceno.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_invoiceno.SizeF = new System.Drawing.SizeF(187.206F, 48.26001F);
            this.lb_invoiceno.StyleName = "DetailData1";
            this.lb_invoiceno.StylePriority.UseBackColor = false;
            this.lb_invoiceno.StylePriority.UseBorderColor = false;
            this.lb_invoiceno.StylePriority.UseBorderDashStyle = false;
            this.lb_invoiceno.StylePriority.UseBorders = false;
            this.lb_invoiceno.StylePriority.UseBorderWidth = false;
            this.lb_invoiceno.StylePriority.UseFont = false;
            this.lb_invoiceno.StylePriority.UseForeColor = false;
            this.lb_invoiceno.StylePriority.UsePadding = false;
            this.lb_invoiceno.StylePriority.UseTextAlignment = false;
            this.lb_invoiceno.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_discount
            // 
            this.lb_discount.BackColor = System.Drawing.Color.Transparent;
            this.lb_discount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_discount.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_discount.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_discount.BorderWidth = 1F;
            this.lb_discount.Dpi = 254F;
            this.lb_discount.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_discount.ForeColor = System.Drawing.Color.Black;
            this.lb_discount.LocationFloat = new DevExpress.Utils.PointFloat(13.99999F, 0F);
            this.lb_discount.Name = "lb_discount";
            this.lb_discount.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_discount.SizeF = new System.Drawing.SizeF(194.6125F, 52.59918F);
            this.lb_discount.StyleName = "DetailData1";
            this.lb_discount.StylePriority.UseBackColor = false;
            this.lb_discount.StylePriority.UseBorderColor = false;
            this.lb_discount.StylePriority.UseBorderDashStyle = false;
            this.lb_discount.StylePriority.UseBorders = false;
            this.lb_discount.StylePriority.UseBorderWidth = false;
            this.lb_discount.StylePriority.UseFont = false;
            this.lb_discount.StylePriority.UseForeColor = false;
            this.lb_discount.StylePriority.UsePadding = false;
            this.lb_discount.StylePriority.UseTextAlignment = false;
            this.lb_discount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lb_net
            // 
            this.lb_net.BackColor = System.Drawing.Color.Transparent;
            this.lb_net.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_net.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_net.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lb_net.BorderWidth = 1F;
            this.lb_net.Dpi = 254F;
            this.lb_net.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_net.ForeColor = System.Drawing.Color.Black;
            this.lb_net.LocationFloat = new DevExpress.Utils.PointFloat(13.99999F, 52.59918F);
            this.lb_net.Name = "lb_net";
            this.lb_net.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_net.SizeF = new System.Drawing.SizeF(194.6125F, 52.59917F);
            this.lb_net.StyleName = "DetailData1";
            this.lb_net.StylePriority.UseBackColor = false;
            this.lb_net.StylePriority.UseBorderColor = false;
            this.lb_net.StylePriority.UseBorderDashStyle = false;
            this.lb_net.StylePriority.UseBorders = false;
            this.lb_net.StylePriority.UseBorderWidth = false;
            this.lb_net.StylePriority.UseFont = false;
            this.lb_net.StylePriority.UseForeColor = false;
            this.lb_net.StylePriority.UsePadding = false;
            this.lb_net.StylePriority.UseTextAlignment = false;
            this.lb_net.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.lb_notes,
            this.xrLine1,
            this.lb_phone2,
            this.lb_phone,
            this.lb_adress,
            this.xrBarCode1,
            this.pageInfo1,
            this.lb_invoiceno,
            this.xrLabel5,
            this.lb_net,
            this.lb_discount,
            this.xrLabel4});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 530.5629F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportFooter_BeforePrint);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(14.00003F, 269.2884F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(586.9998F, 5.291664F);
            // 
            // lb_notes
            // 
            this.lb_notes.BackColor = System.Drawing.Color.Transparent;
            this.lb_notes.BorderColor = System.Drawing.Color.White;
            this.lb_notes.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_notes.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lb_notes.BorderWidth = 2F;
            this.lb_notes.Dpi = 254F;
            this.lb_notes.Font = new System.Drawing.Font("VIP Rawy Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lb_notes.ForeColor = System.Drawing.Color.Black;
            this.lb_notes.LocationFloat = new DevExpress.Utils.PointFloat(18.21514F, 154.4843F);
            this.lb_notes.Name = "lb_notes";
            this.lb_notes.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_notes.SizeF = new System.Drawing.SizeF(563.9202F, 95.15076F);
            this.lb_notes.StyleName = "DetailCaption1";
            this.lb_notes.StylePriority.UseBackColor = false;
            this.lb_notes.StylePriority.UseBorderColor = false;
            this.lb_notes.StylePriority.UseBorderDashStyle = false;
            this.lb_notes.StylePriority.UseBorders = false;
            this.lb_notes.StylePriority.UseBorderWidth = false;
            this.lb_notes.StylePriority.UseFont = false;
            this.lb_notes.StylePriority.UseForeColor = false;
            this.lb_notes.StylePriority.UsePadding = false;
            this.lb_notes.StylePriority.UseTextAlignment = false;
            this.lb_notes.Text = " ";
            this.lb_notes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(14.00003F, 127.1926F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(586.9998F, 5.291664F);
            // 
            // lb_phone2
            // 
            this.lb_phone2.BackColor = System.Drawing.Color.Transparent;
            this.lb_phone2.BorderColor = System.Drawing.Color.White;
            this.lb_phone2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_phone2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lb_phone2.BorderWidth = 2F;
            this.lb_phone2.Dpi = 254F;
            this.lb_phone2.Font = new System.Drawing.Font("Times New Roman", 7F);
            this.lb_phone2.ForeColor = System.Drawing.Color.Black;
            this.lb_phone2.LocationFloat = new DevExpress.Utils.PointFloat(57.09742F, 335.9314F);
            this.lb_phone2.Name = "lb_phone2";
            this.lb_phone2.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_phone2.SizeF = new System.Drawing.SizeF(238.9082F, 39.87997F);
            this.lb_phone2.StyleName = "DetailCaption1";
            this.lb_phone2.StylePriority.UseBackColor = false;
            this.lb_phone2.StylePriority.UseBorderColor = false;
            this.lb_phone2.StylePriority.UseBorderDashStyle = false;
            this.lb_phone2.StylePriority.UseBorders = false;
            this.lb_phone2.StylePriority.UseBorderWidth = false;
            this.lb_phone2.StylePriority.UseFont = false;
            this.lb_phone2.StylePriority.UseForeColor = false;
            this.lb_phone2.StylePriority.UsePadding = false;
            this.lb_phone2.StylePriority.UseTextAlignment = false;
            this.lb_phone2.Text = " ";
            this.lb_phone2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lb_phone
            // 
            this.lb_phone.BackColor = System.Drawing.Color.Transparent;
            this.lb_phone.BorderColor = System.Drawing.Color.White;
            this.lb_phone.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_phone.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lb_phone.BorderWidth = 2F;
            this.lb_phone.Dpi = 254F;
            this.lb_phone.Font = new System.Drawing.Font("Times New Roman", 7F);
            this.lb_phone.ForeColor = System.Drawing.Color.Black;
            this.lb_phone.LocationFloat = new DevExpress.Utils.PointFloat(296.0056F, 335.9313F);
            this.lb_phone.Name = "lb_phone";
            this.lb_phone.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_phone.SizeF = new System.Drawing.SizeF(262.9404F, 39.87997F);
            this.lb_phone.StyleName = "DetailCaption1";
            this.lb_phone.StylePriority.UseBackColor = false;
            this.lb_phone.StylePriority.UseBorderColor = false;
            this.lb_phone.StylePriority.UseBorderDashStyle = false;
            this.lb_phone.StylePriority.UseBorders = false;
            this.lb_phone.StylePriority.UseBorderWidth = false;
            this.lb_phone.StylePriority.UseFont = false;
            this.lb_phone.StylePriority.UseForeColor = false;
            this.lb_phone.StylePriority.UsePadding = false;
            this.lb_phone.StylePriority.UseTextAlignment = false;
            this.lb_phone.Text = " ";
            this.lb_phone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lb_adress
            // 
            this.lb_adress.BackColor = System.Drawing.Color.Transparent;
            this.lb_adress.BorderColor = System.Drawing.Color.White;
            this.lb_adress.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.lb_adress.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lb_adress.BorderWidth = 2F;
            this.lb_adress.Dpi = 254F;
            this.lb_adress.Font = new System.Drawing.Font("Times New Roman", 7F);
            this.lb_adress.ForeColor = System.Drawing.Color.Black;
            this.lb_adress.LocationFloat = new DevExpress.Utils.PointFloat(15F, 288.0515F);
            this.lb_adress.Name = "lb_adress";
            this.lb_adress.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.lb_adress.SizeF = new System.Drawing.SizeF(561.9202F, 39.87994F);
            this.lb_adress.StyleName = "DetailCaption1";
            this.lb_adress.StylePriority.UseBackColor = false;
            this.lb_adress.StylePriority.UseBorderColor = false;
            this.lb_adress.StylePriority.UseBorderDashStyle = false;
            this.lb_adress.StylePriority.UseBorders = false;
            this.lb_adress.StylePriority.UseBorderWidth = false;
            this.lb_adress.StylePriority.UseFont = false;
            this.lb_adress.StylePriority.UseForeColor = false;
            this.lb_adress.StylePriority.UsePadding = false;
            this.lb_adress.StylePriority.UseTextAlignment = false;
            this.lb_adress.Text = " ";
            this.lb_adress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[invoice_no]")});
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(152.3545F, 388.8113F);
            this.xrBarCode1.Module = 2.54F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(269.4258F, 51.0116F);
            this.xrBarCode1.Symbology = eaN8Generator1;
            // 
            // calculatedField1
            // 
            this.calculatedField1.Expression = "[total_value]-[discount]";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // rpt_invoicerecipit
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.Detail,
            this.ReportFooter});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calculatedField1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(33, 10, 40, 25);
            this.PageHeight = 2794;
            this.PageWidth = 651;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RollPaper = true;
            this.ShowPreviewMarginLines = false;
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "18.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.rpt_invoicerecipit_BeforePrint);
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
        private DevExpress.XtraReports.UI.XRLabel lb_invoiceno;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lb_store;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel lb_usernames;
        private DevExpress.XtraReports.UI.XRLabel lb_accounts;
        private DevExpress.XtraReports.UI.XRLabel lb_date;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lb_discount;
        private DevExpress.XtraReports.UI.XRLabel lb_net;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel lb_name;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel lb_phone;
        private DevExpress.XtraReports.UI.XRLabel lb_adress;
        private DevExpress.XtraReports.UI.XRLabel lb_phone2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel lb_notes;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.CalculatedField calculatedField1;
    }
}
