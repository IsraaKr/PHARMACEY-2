namespace PhamaceySystem.Forms.Report_Forms
{
    partial class XtraReport4
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport4));
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings3 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.vendorTable = new DevExpress.XtraReports.UI.XRTable();
            this.vendorNameRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorName = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorAddressRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorCityRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorCity = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorCountryRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorCountry = new DevExpress.XtraReports.UI.XRTableCell();
            this.invoiceDate = new DevExpress.XtraReports.UI.XRLabel();
            this.invoiceLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.invoiceNumberTable = new DevExpress.XtraReports.UI.XRTable();
            this.invoiceNumberCaptionRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.invoiceNumberCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalTable = new DevExpress.XtraReports.UI.XRTable();
            this.totalRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.totalCaption = new DevExpress.XtraReports.UI.XRTableCell();
            this.total = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.op_id = new DevExpress.XtraReports.Parameters.Parameter();
            this.date = new DevExpress.XtraReports.Parameters.Parameter();
            this.med = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceNumberTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 21F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 28F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 40.87496F;
            this.Detail.Name = "Detail";
            // 
            // xrTable1
            // 
            this.xrTable1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable1.BorderWidth = 3F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(643.75F, 25F);
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseBorderWidth = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_name]")});
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 0.24124756596366392D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[in_item_expDate]")});
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.TextFormatString = "{0:d}";
            this.xrTableCell5.Weight = 0.24124756596366392D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[in_item_quntity]")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell7.Weight = 0.24124756596366392D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[is_out]")});
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "xrTableCell11";
            this.xrTableCell11.Weight = 0.24124756596366392D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_cat_name]")});
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 0.24124756596366392D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_count]")});
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Text = "xrTableCell13";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell13.Weight = 0.24124756596366392D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_minimum]")});
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell14.Weight = 0.24124756596366392D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_name]")});
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "xrTableCell15";
            this.xrTableCell15.Weight = 0.24124756596366392D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[med_shape_name]")});
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "xrTableCell16";
            this.xrTableCell16.Weight = 0.24124756596366392D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[name]")});
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "xrTableCell17";
            this.xrTableCell17.Weight = 0.24124756596366392D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[out_item_quntitey]")});
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell18.Weight = 0.24124756596366392D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[T_Store_Placees_name]")});
            this.xrTableCell19.Multiline = true;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.Weight = 0.24124756596366392D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel1,
            this.vendorTable,
            this.invoiceDate,
            this.invoiceLabel,
            this.invoiceNumberTable});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("in_op_id", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 220.25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.xrTable2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.xrTable2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable2.BorderWidth = 3F;
            this.xrTable2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(77.11855F, 185.25F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(566.6315F, 35.00002F);
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UsePadding = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 11.5D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Multiline = true;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseTextAlignment = false;
            this.xrTableCell22.Text = "xrTableCell3";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell22.Weight = 0.40990579427752155D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "xrTableCell2";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell23.Weight = 0.40990579427752155D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "xrTableCell1";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell24.Weight = 0.40990579427752155D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "Qty";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell25.Weight = 0.40990579427752155D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 0, 5, 0, 100F);
            this.xrTableCell26.StylePriority.UsePadding = false;
            this.xrTableCell26.Text = "Description";
            this.xrTableCell26.Weight = 0.40990579427752155D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "Price";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell27.Weight = 0.40990579427752155D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "LineTotal ";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell28.Weight = 0.40990579427752155D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[in_op_id]")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(29.31134F, 75F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(188.5834F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vendorTable
            // 
            this.vendorTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.vendorTable.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.vendorTable.LocationFloat = new DevExpress.Utils.PointFloat(375.5209F, 40.20834F);
            this.vendorTable.Name = "vendorTable";
            this.vendorTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.vendorNameRow,
            this.vendorAddressRow,
            this.vendorCityRow,
            this.vendorCountryRow});
            this.vendorTable.SizeF = new System.Drawing.SizeF(250F, 80F);
            this.vendorTable.StylePriority.UseFont = false;
            this.vendorTable.StylePriority.UseTextAlignment = false;
            this.vendorTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // vendorNameRow
            // 
            this.vendorNameRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorName});
            this.vendorNameRow.Name = "vendorNameRow";
            this.vendorNameRow.Weight = 0.8D;
            // 
            // vendorName
            // 
            this.vendorName.CanShrink = true;
            this.vendorName.Name = "vendorName";
            this.vendorName.StylePriority.UseFont = false;
            this.vendorName.StylePriority.UsePadding = false;
            this.vendorName.Text = "VendorName";
            this.vendorName.Weight = 1D;
            // 
            // vendorAddressRow
            // 
            this.vendorAddressRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorAddress});
            this.vendorAddressRow.Name = "vendorAddressRow";
            this.vendorAddressRow.Weight = 0.8D;
            // 
            // vendorAddress
            // 
            this.vendorAddress.CanShrink = true;
            this.vendorAddress.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Donar_name]")});
            this.vendorAddress.Name = "vendorAddress";
            this.vendorAddress.StylePriority.UseFont = false;
            this.vendorAddress.Text = "VendorAddress";
            this.vendorAddress.Weight = 1D;
            // 
            // vendorCityRow
            // 
            this.vendorCityRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorCity});
            this.vendorCityRow.Name = "vendorCityRow";
            this.vendorCityRow.Weight = 0.8D;
            // 
            // vendorCity
            // 
            this.vendorCity.CanShrink = true;
            this.vendorCity.Name = "vendorCity";
            this.vendorCity.StylePriority.UseFont = false;
            this.vendorCity.Text = "VendorCity";
            this.vendorCity.Weight = 1D;
            // 
            // vendorCountryRow
            // 
            this.vendorCountryRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorCountry});
            this.vendorCountryRow.Name = "vendorCountryRow";
            this.vendorCountryRow.Weight = 0.8D;
            // 
            // vendorCountry
            // 
            this.vendorCountry.CanShrink = true;
            this.vendorCountry.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Emp_name]")});
            this.vendorCountry.Name = "vendorCountry";
            this.vendorCountry.StylePriority.UseFont = false;
            this.vendorCountry.Text = "VendorCountry";
            this.vendorCountry.Weight = 1D;
            // 
            // invoiceDate
            // 
            this.invoiceDate.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.invoiceDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[in_op_date]")});
            this.invoiceDate.LocationFloat = new DevExpress.Utils.PointFloat(28.53546F, 107.2917F);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.invoiceDate.SizeF = new System.Drawing.SizeF(189.3593F, 22.99996F);
            this.invoiceDate.StylePriority.UseTextAlignment = false;
            this.invoiceDate.Text = "InvoiceDate";
            this.invoiceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.invoiceDate.TextFormatString = "{0:d MMMM yyyy}";
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.invoiceLabel.LocationFloat = new DevExpress.Utils.PointFloat(29.31134F, 0F);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.SizeF = new System.Drawing.SizeF(157.29F, 45F);
            this.invoiceLabel.StylePriority.UseFont = false;
            this.invoiceLabel.StylePriority.UsePadding = false;
            this.invoiceLabel.StylePriority.UseTextAlignment = false;
            this.invoiceLabel.Text = "Invoice";
            this.invoiceLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // invoiceNumberTable
            // 
            this.invoiceNumberTable.LocationFloat = new DevExpress.Utils.PointFloat(29.31134F, 54.99999F);
            this.invoiceNumberTable.Name = "invoiceNumberTable";
            this.invoiceNumberTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.invoiceNumberCaptionRow});
            this.invoiceNumberTable.SizeF = new System.Drawing.SizeF(188.5834F, 20F);
            this.invoiceNumberTable.StylePriority.UseTextAlignment = false;
            this.invoiceNumberTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // invoiceNumberCaptionRow
            // 
            this.invoiceNumberCaptionRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.invoiceNumberCaption});
            this.invoiceNumberCaptionRow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.invoiceNumberCaptionRow.Name = "invoiceNumberCaptionRow";
            this.invoiceNumberCaptionRow.StylePriority.UseFont = false;
            this.invoiceNumberCaptionRow.Weight = 0.26666666666666672D;
            // 
            // invoiceNumberCaption
            // 
            this.invoiceNumberCaption.CanShrink = true;
            this.invoiceNumberCaption.Name = "invoiceNumberCaption";
            this.invoiceNumberCaption.StylePriority.UseTextAlignment = false;
            this.invoiceNumberCaption.Text = "Invoice No.";
            this.invoiceNumberCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.invoiceNumberCaption.Weight = 1.0235326443596697D;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalTable});
            this.GroupFooter1.HeightF = 55.62496F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // totalTable
            // 
            this.totalTable.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.totalTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            this.totalTable.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.totalTable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.totalTable.ForeColor = System.Drawing.Color.Black;
            this.totalTable.LocationFloat = new DevExpress.Utils.PointFloat(313.5417F, 0F);
            this.totalTable.Name = "totalTable";
            this.totalTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 5, 0, 100F);
            this.totalTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.totalRow});
            this.totalTable.SizeF = new System.Drawing.SizeF(336.4583F, 35F);
            this.totalTable.StylePriority.UseBorderColor = false;
            this.totalTable.StylePriority.UseBorders = false;
            this.totalTable.StylePriority.UseFont = false;
            this.totalTable.StylePriority.UseForeColor = false;
            this.totalTable.StylePriority.UsePadding = false;
            // 
            // totalRow
            // 
            this.totalRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.totalRow.BorderWidth = 3F;
            this.totalRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.totalCaption,
            this.total});
            this.totalRow.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalRow.Name = "totalRow";
            this.totalRow.StylePriority.UseBorderColor = false;
            this.totalRow.StylePriority.UseBorderWidth = false;
            this.totalRow.StylePriority.UseFont = false;
            this.totalRow.Weight = 1.5217391304347823D;
            // 
            // totalCaption
            // 
            this.totalCaption.Name = "totalCaption";
            this.totalCaption.StylePriority.UseFont = false;
            this.totalCaption.StylePriority.UseTextAlignment = false;
            this.totalCaption.Text = "Total";
            this.totalCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            this.totalCaption.Weight = 2.8346436193713713D;
            // 
            // total
            // 
            this.total.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[T_OPeration_IN_1].[in_item_id].Count()")});
            this.total.Name = "total";
            this.total.StylePriority.UseFont = false;
            this.total.StylePriority.UseTextAlignment = false;
            this.total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            this.total.TextFormatString = "{0}";
            this.total.Weight = 3.7904626522673168D;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.PageFooter.HeightF = 76.04166F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 12F);
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(386.2499F, 27.41667F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(253.7501F, 23.00001F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo2.TextFormatString = "{0:dddd, dd MMMM, yyyy hh:mm tt}";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(307.8947F, 10.00001F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(40.625F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // op_id
            // 
            this.op_id.Description = "op_id";
            this.op_id.MultiValue = true;
            this.op_id.Name = "op_id";
            this.op_id.Type = typeof(int);
            dynamicListLookUpSettings1.DataMember = "Query";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "in_op_id";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.SortMember = null;
            dynamicListLookUpSettings1.ValueMember = "in_op_id";
            this.op_id.ValueSourceSettings = dynamicListLookUpSettings1;
            // 
            // date
            // 
            this.date.Description = "date";
            this.date.MultiValue = true;
            this.date.Name = "date";
            this.date.Type = typeof(int);
            dynamicListLookUpSettings2.DataMember = "Query";
            dynamicListLookUpSettings2.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings2.DisplayMember = "in_op_date";
            dynamicListLookUpSettings2.FilterString = null;
            dynamicListLookUpSettings2.SortMember = null;
            dynamicListLookUpSettings2.ValueMember = "in_op_id";
            this.date.ValueSourceSettings = dynamicListLookUpSettings2;
            // 
            // med
            // 
            this.med.Description = "med";
            this.med.MultiValue = true;
            this.med.Name = "med";
            dynamicListLookUpSettings3.DataMember = "Query";
            dynamicListLookUpSettings3.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings3.DisplayMember = "med_name";
            dynamicListLookUpSettings3.FilterString = null;
            dynamicListLookUpSettings3.SortMember = null;
            dynamicListLookUpSettings3.ValueMember = "med_name";
            this.med.ValueSourceSettings = dynamicListLookUpSettings3;
            // 
            // XtraReport4
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 21, 28);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.op_id,
            this.date,
            this.med});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceNumberTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTable vendorTable;
        private DevExpress.XtraReports.UI.XRTableRow vendorNameRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorName;
        private DevExpress.XtraReports.UI.XRTableRow vendorAddressRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorAddress;
        private DevExpress.XtraReports.UI.XRTableRow vendorCityRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorCity;
        private DevExpress.XtraReports.UI.XRTableRow vendorCountryRow;
        private DevExpress.XtraReports.UI.XRTableCell vendorCountry;
        private DevExpress.XtraReports.UI.XRLabel invoiceDate;
        private DevExpress.XtraReports.UI.XRLabel invoiceLabel;
        private DevExpress.XtraReports.UI.XRTable invoiceNumberTable;
        private DevExpress.XtraReports.UI.XRTableRow invoiceNumberCaptionRow;
        private DevExpress.XtraReports.UI.XRTableCell invoiceNumberCaption;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRTable totalTable;
        private DevExpress.XtraReports.UI.XRTableRow totalRow;
        private DevExpress.XtraReports.UI.XRTableCell totalCaption;
        private DevExpress.XtraReports.UI.XRTableCell total;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.Parameters.Parameter op_id;
        private DevExpress.XtraReports.Parameters.Parameter date;
        private DevExpress.XtraReports.Parameters.Parameter med;
    }
}
