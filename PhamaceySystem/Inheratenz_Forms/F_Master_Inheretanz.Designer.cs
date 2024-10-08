﻿namespace PhamaceySystem
{
    partial class F_Master_Inheretanz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Master_Inheretanz));
            this.timer_states_bar = new System.Windows.Forms.Timer(this.components);
            this.lbl_tiltle = new System.Windows.Forms.Label();
            this.timer_date = new System.Windows.Forms.Timer(this.components);
            this.barMang = new DevExpress.XtraBars.BarManager(this.components);
            this.menu_bar = new DevExpress.XtraBars.Bar();
            this.bar_neew = new DevExpress.XtraBars.BarButtonItem();
            this.sp_new = new DevExpress.XtraBars.BarButtonItem();
            this.bar_add = new DevExpress.XtraBars.BarButtonItem();
            this.sp_add = new DevExpress.XtraBars.BarButtonItem();
            this.bar_add_save = new DevExpress.XtraBars.BarButtonItem();
            this.sp_add_save = new DevExpress.XtraBars.BarButtonItem();
            this.bar_edit = new DevExpress.XtraBars.BarButtonItem();
            this.sp_edite = new DevExpress.XtraBars.BarButtonItem();
            this.bar_close = new DevExpress.XtraBars.BarButtonItem();
            this.bar_delete = new DevExpress.XtraBars.BarButtonItem();
            this.sp_delete = new DevExpress.XtraBars.BarButtonItem();
            this.bar_print = new DevExpress.XtraBars.BarButtonItem();
            this.sp_print = new DevExpress.XtraBars.BarButtonItem();
            this.bar_refresh = new DevExpress.XtraBars.BarButtonItem();
            this.sp_refresh = new DevExpress.XtraBars.BarButtonItem();
            this.status_bar = new DevExpress.XtraBars.Bar();
            this.bar_states = new DevExpress.XtraBars.BarStaticItem();
            this.bar_User = new DevExpress.XtraBars.BarStaticItem();
            this.bar_date = new DevExpress.XtraBars.BarStaticItem();
            this.bar_time = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barMang)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_states_bar
            // 
            this.timer_states_bar.Interval = 5000;
            this.timer_states_bar.Tick += new System.EventHandler(this.timer_states_bar_Tick);
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.BackColor = System.Drawing.Color.Maroon;
            this.lbl_tiltle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_tiltle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tiltle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_tiltle.Location = new System.Drawing.Point(0, 0);
            this.lbl_tiltle.MaximumSize = new System.Drawing.Size(3000, 40);
            this.lbl_tiltle.MinimumSize = new System.Drawing.Size(0, 40);
            this.lbl_tiltle.Name = "lbl_tiltle";
            this.lbl_tiltle.Size = new System.Drawing.Size(1040, 40);
            this.lbl_tiltle.TabIndex = 5;
            this.lbl_tiltle.Text = "....";
            this.lbl_tiltle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_date
            // 
            this.timer_date.Interval = 1000;
            this.timer_date.Tick += new System.EventHandler(this.timer_date_Tick);
            // 
            // barMang
            // 
            this.barMang.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.menu_bar,
            this.status_bar});
            this.barMang.DockControls.Add(this.barDockControlTop);
            this.barMang.DockControls.Add(this.barDockControlBottom);
            this.barMang.DockControls.Add(this.barDockControlLeft);
            this.barMang.DockControls.Add(this.barDockControlRight);
            this.barMang.Form = this;
            this.barMang.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_add,
            this.bar_delete,
            this.bar_states,
            this.bar_close,
            this.sp_edite,
            this.sp_add,
            this.sp_delete,
            this.bar_edit,
            this.bar_print,
            this.bar_time,
            this.bar_date,
            this.bar_User,
            this.bar_neew,
            this.sp_new,
            this.sp_print,
            this.bar_add_save,
            this.sp_add_save,
            this.bar_refresh,
            this.sp_refresh});
            this.barMang.MainMenu = this.menu_bar;
            this.barMang.MaxItemId = 30;
            this.barMang.OptionsStubGlyphs.Padding = new System.Windows.Forms.Padding(0);
            this.barMang.StatusBar = this.status_bar;
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
            this.menu_bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_neew),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_new),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_add),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_add),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_add_save),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_add_save),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_edit),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_edite),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_close),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_delete),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_delete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_print),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_print),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_refresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.sp_refresh)});
            this.menu_bar.OptionsBar.MultiLine = true;
            this.menu_bar.OptionsBar.UseWholeRow = true;
            this.menu_bar.Text = "Main menu";
            // 
            // bar_neew
            // 
            this.bar_neew.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_neew.Caption = "جديد";
            this.bar_neew.Id = 23;
            this.bar_neew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bar_neew.ImageOptions.SvgImage")));
            this.bar_neew.Name = "bar_neew";
            this.bar_neew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_neew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_neew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_neew_ItemClick);
            // 
            // sp_new
            // 
            this.sp_new.Id = 24;
            this.sp_new.Name = "sp_new";
            this.sp_new.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_add
            // 
            this.bar_add.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_add.Caption = "حفظ";
            this.bar_add.Id = 0;
            this.bar_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_add.ImageOptions.Image")));
            this.bar_add.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_add.ImageOptions.LargeImage")));
            this.bar_add.Name = "bar_add";
            this.bar_add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_add_ItemClick);
            // 
            // sp_add
            // 
            this.sp_add.Id = 14;
            this.sp_add.Name = "sp_add";
            this.sp_add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_add_save
            // 
            this.bar_add_save.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_add_save.Caption = "حفظ و إدخال";
            this.bar_add_save.Id = 26;
            this.bar_add_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_add_save.ImageOptions.Image")));
            this.bar_add_save.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_add_save.ImageOptions.LargeImage")));
            this.bar_add_save.Name = "bar_add_save";
            this.bar_add_save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_add_save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_add_save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_add_save_ItemClick);
            // 
            // sp_add_save
            // 
            this.sp_add_save.Id = 27;
            this.sp_add_save.Name = "sp_add_save";
            this.sp_add_save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_edit
            // 
            this.bar_edit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_edit.Caption = "تعديل";
            this.bar_edit.Id = 17;
            this.bar_edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_edit.ImageOptions.Image")));
            this.bar_edit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_edit.ImageOptions.LargeImage")));
            this.bar_edit.Name = "bar_edit";
            this.bar_edit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_edit_ItemClick);
            // 
            // sp_edite
            // 
            this.sp_edite.Id = 13;
            this.sp_edite.Name = "sp_edite";
            this.sp_edite.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_close
            // 
            this.bar_close.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bar_close.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_close.Caption = "خروج";
            this.bar_close.Id = 11;
            this.bar_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_close.ImageOptions.Image")));
            this.bar_close.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_close.ImageOptions.LargeImage")));
            this.bar_close.Name = "bar_close";
            this.bar_close.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_close_ItemClick);
            // 
            // bar_delete
            // 
            this.bar_delete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_delete.Caption = "حذف";
            this.bar_delete.Id = 3;
            this.bar_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_delete.ImageOptions.Image")));
            this.bar_delete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_delete.ImageOptions.LargeImage")));
            this.bar_delete.Name = "bar_delete";
            this.bar_delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_delete_ItemClick);
            // 
            // sp_delete
            // 
            this.sp_delete.Id = 16;
            this.sp_delete.Name = "sp_delete";
            this.sp_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.bar_print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_print_ItemClick);
            // 
            // sp_print
            // 
            this.sp_print.Id = 25;
            this.sp_print.Name = "sp_print";
            this.sp_print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_refresh
            // 
            this.bar_refresh.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.bar_refresh.Caption = "تحديث";
            this.bar_refresh.Id = 28;
            this.bar_refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_refresh.ImageOptions.Image")));
            this.bar_refresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_refresh.ImageOptions.LargeImage")));
            this.bar_refresh.Name = "bar_refresh";
            this.bar_refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bar_refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_refresh_ItemClick);
            // 
            // sp_refresh
            // 
            this.sp_refresh.Id = 29;
            this.sp_refresh.Name = "sp_refresh";
            this.sp_refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // status_bar
            // 
            this.status_bar.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_bar.BarAppearance.Disabled.Options.UseFont = true;
            this.status_bar.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12F);
            this.status_bar.BarAppearance.Hovered.Options.UseFont = true;
            this.status_bar.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_bar.BarAppearance.Normal.Options.UseFont = true;
            this.status_bar.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 12F);
            this.status_bar.BarAppearance.Pressed.Options.UseFont = true;
            this.status_bar.BarName = "Status bar";
            this.status_bar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.status_bar.DockCol = 0;
            this.status_bar.DockRow = 0;
            this.status_bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.status_bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_states),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_User),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_date),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_time)});
            this.status_bar.OptionsBar.AllowQuickCustomization = false;
            this.status_bar.OptionsBar.DrawDragBorder = false;
            this.status_bar.OptionsBar.UseWholeRow = true;
            this.status_bar.Text = "Status bar";
            // 
            // bar_states
            // 
            this.bar_states.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.bar_states.Caption = "...";
            this.bar_states.Id = 0;
            this.bar_states.Name = "bar_states";
            this.bar_states.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // bar_User
            // 
            this.bar_User.Caption = "..";
            this.bar_User.Id = 21;
            this.bar_User.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_User.ImageOptions.Image")));
            this.bar_User.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_User.ImageOptions.LargeImage")));
            this.bar_User.Name = "bar_User";
            this.bar_User.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // bar_time
            // 
            this.bar_time.Caption = "..";
            this.bar_time.Id = 19;
            this.bar_time.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_time.ImageOptions.Image")));
            this.bar_time.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_time.ImageOptions.LargeImage")));
            this.bar_time.Name = "bar_time";
            this.bar_time.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMang;
            this.barDockControlTop.Size = new System.Drawing.Size(1040, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 675);
            this.barDockControlBottom.Manager = this.barMang;
            this.barDockControlBottom.Size = new System.Drawing.Size(1040, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barMang;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 675);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1040, 0);
            this.barDockControlRight.Manager = this.barMang;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 675);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barButtonItem6.Caption = "إضافة";
            this.barButtonItem6.Id = 0;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barButtonItem1.Caption = "جديد";
            this.barButtonItem1.Id = 23;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barButtonItem2.Caption = "جديد";
            this.barButtonItem2.Id = 23;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barButtonItem3.Caption = "جديد";
            this.barButtonItem3.Id = 23;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // F_Master_Inheretanz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 675);
            this.Controls.Add(this.lbl_tiltle);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_Master_Inheretanz";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Master_Inheretanz";
            this.Load += new System.EventHandler(this.F_Master_Inheretanz_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.F_Master_Inheretanz_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barMang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraBars.Bar menu_bar;
        public DevExpress.XtraBars.BarButtonItem bar_add;
        public DevExpress.XtraBars.BarButtonItem bar_delete;
        private DevExpress.XtraBars.Bar status_bar;
        public DevExpress.XtraBars.BarStaticItem bar_states;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem bar_neew;
        public DevExpress.XtraBars.BarButtonItem barButtonItem6;
        public DevExpress.XtraBars.BarButtonItem sp_add;
        public DevExpress.XtraBars.BarButtonItem sp_new;
        public DevExpress.XtraBars.BarButtonItem bar_edit;
        public DevExpress.XtraBars.BarButtonItem sp_edite;
        public DevExpress.XtraBars.BarButtonItem sp_delete;
        public DevExpress.XtraBars.BarButtonItem bar_close;
        public DevExpress.XtraBars.BarButtonItem bar_print;
        public DevExpress.XtraBars.BarButtonItem sp_print;
        public System.Windows.Forms.Label lbl_tiltle;
        public DevExpress.XtraBars.BarManager barMang;
        public System.Windows.Forms.Timer timer_states_bar;
        public System.Windows.Forms.Timer timer_date;
        public DevExpress.XtraBars.BarStaticItem bar_User;
        public DevExpress.XtraBars.BarStaticItem bar_date;
        public DevExpress.XtraBars.BarStaticItem bar_time;
        public DevExpress.XtraBars.BarButtonItem bar_add_save;
        public DevExpress.XtraBars.BarButtonItem sp_add_save;
        public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        public DevExpress.XtraBars.BarButtonItem bar_refresh;
        public DevExpress.XtraBars.BarButtonItem sp_refresh;
    }
}