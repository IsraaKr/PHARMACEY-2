namespace PhamaceySystem.Forms.Store_Other_Forms
{
    partial class F_Store_Med_ExpDate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Store_Med_ExpDate));
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbl_tiltle = new System.Windows.Forms.Label();
            this.menu_bar = new DevExpress.XtraBars.Bar();
            this.barMang = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar_close = new DevExpress.XtraBars.BarButtonItem();
            this.bar_print = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar_time = new DevExpress.XtraBars.BarStaticItem();
            this.bar_date = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMang)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 60);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(800, 350);
            this.gc.TabIndex = 7;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsPrint.AllowMultilineHeaders = true;
            this.gv.OptionsPrint.ExpandAllDetails = true;
            this.gv.OptionsPrint.PrintDetails = true;
            this.gv.OptionsPrint.PrintFilterInfo = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_RowStyle);
            this.gv.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gv_SelectionChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_tiltle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_tiltle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tiltle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_tiltle.Location = new System.Drawing.Point(0, 0);
            this.lbl_tiltle.Name = "lbl_tiltle";
            this.lbl_tiltle.Size = new System.Drawing.Size(800, 60);
            this.lbl_tiltle.TabIndex = 8;
            this.lbl_tiltle.Text = "....";
            this.lbl_tiltle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu_bar
            // 
            this.menu_bar.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 18F);
            this.menu_bar.BarAppearance.Disabled.Options.UseFont = true;
            this.menu_bar.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 18F);
            this.menu_bar.BarAppearance.Hovered.Options.UseFont = true;
            this.menu_bar.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_bar.BarAppearance.Normal.Options.UseFont = true;
            this.menu_bar.BarAppearance.Pressed.BackColor = System.Drawing.Color.Orange;
            this.menu_bar.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 18F);
            this.menu_bar.BarAppearance.Pressed.ForeColor = System.Drawing.Color.White;
            this.menu_bar.BarAppearance.Pressed.Options.UseBackColor = true;
            this.menu_bar.BarAppearance.Pressed.Options.UseFont = true;
            this.menu_bar.BarAppearance.Pressed.Options.UseForeColor = true;
            this.menu_bar.BarName = "Main menu";
            this.menu_bar.DockCol = 0;
            this.menu_bar.DockRow = 1;
            this.menu_bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.menu_bar.FloatLocation = new System.Drawing.Point(242, 365);
            this.menu_bar.OptionsBar.MultiLine = true;
            this.menu_bar.OptionsBar.UseWholeRow = true;
            this.menu_bar.Text = "Main menu";
            // 
            // barMang
            // 
            this.barMang.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barMang.DockControls.Add(this.barDockControlTop);
            this.barMang.DockControls.Add(this.barDockControlBottom);
            this.barMang.DockControls.Add(this.barDockControlLeft);
            this.barMang.DockControls.Add(this.barDockControlRight);
            this.barMang.Form = this;
            this.barMang.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_close,
            this.bar_print,
            this.bar_time,
            this.bar_date,
            this.barStaticItem3});
            this.barMang.MainMenu = this.bar1;
            this.barMang.MaxItemId = 28;
            this.barMang.OptionsStubGlyphs.Padding = new System.Windows.Forms.Padding(0);
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 18F);
            this.bar1.BarAppearance.Disabled.Options.UseFont = true;
            this.bar1.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 18F);
            this.bar1.BarAppearance.Hovered.Options.UseFont = true;
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarAppearance.Pressed.BackColor = System.Drawing.Color.Orange;
            this.bar1.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 18F);
            this.bar1.BarAppearance.Pressed.ForeColor = System.Drawing.Color.White;
            this.bar1.BarAppearance.Pressed.Options.UseBackColor = true;
            this.bar1.BarAppearance.Pressed.Options.UseFont = true;
            this.bar1.BarAppearance.Pressed.Options.UseForeColor = true;
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.FloatLocation = new System.Drawing.Point(242, 365);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_close),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_print)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // bar_close
            // 
            this.bar_close.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bar_close.Caption = "خروج";
            this.bar_close.Id = 11;
            this.bar_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_close.ImageOptions.Image")));
            this.bar_close.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_close.ImageOptions.LargeImage")));
            this.bar_close.Name = "bar_close";
            this.bar_close.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar_print
            // 
            this.bar_print.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_print.Caption = "طباعة و تصدير ";
            this.bar_print.Id = 18;
            this.bar_print.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_print.ImageOptions.Image")));
            this.bar_print.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_print.ImageOptions.LargeImage")));
            this.bar_print.Name = "bar_print";
            this.bar_print.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMang;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 410);
            this.barDockControlBottom.Manager = this.barMang;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 40);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barMang;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 410);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 0);
            this.barDockControlRight.Manager = this.barMang;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 410);
            // 
            // bar_time
            // 
            this.bar_time.Caption = "..";
            this.bar_time.Id = 19;
            this.bar_time.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_time.ImageOptions.Image")));
            this.bar_time.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_time.ImageOptions.LargeImage")));
            this.bar_time.Name = "bar_time";
            this.bar_time.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar_date
            // 
            this.bar_date.Caption = "..";
            this.bar_date.Id = 20;
            this.bar_date.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_date.ImageOptions.Image")));
            this.bar_date.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_date.ImageOptions.LargeImage")));
            this.bar_date.Name = "bar_date";
            this.bar_date.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "..";
            this.barStaticItem3.Id = 21;
            this.barStaticItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem3.ImageOptions.Image")));
            this.barStaticItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem3.ImageOptions.LargeImage")));
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // F_Store_Med_ExpDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.lbl_tiltle);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_Store_Med_ExpDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "F_Store_Med_ExpDate";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        public System.Windows.Forms.Label lbl_tiltle;
        public DevExpress.XtraBars.Bar menu_bar;
        public DevExpress.XtraBars.BarManager barMang;
        public DevExpress.XtraBars.Bar bar1;
        public DevExpress.XtraBars.BarButtonItem bar_close;
        public DevExpress.XtraBars.BarButtonItem bar_print;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarStaticItem bar_time;
        public DevExpress.XtraBars.BarStaticItem bar_date;
        public DevExpress.XtraBars.BarStaticItem barStaticItem3;
    }
}