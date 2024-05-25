namespace PhamaceySystem.Forms.Report_Forms
{
    partial class F_damege_rep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_damege_rep));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_refresh = new DevExpress.XtraEditors.SimpleButton();
            this.in_op_SearchlookupEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Med_idSearchlookupEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView51 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_view_serch = new DevExpress.XtraEditors.SimpleButton();
            this.emp_SearchlookupEdit21 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView521 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.in_op_dateDateEdit = new System.Windows.Forms.DateTimePicker();
            this.chb_from_to = new System.Windows.Forms.CheckBox();
            this.from_dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.to_dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.in_op_SearchlookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Med_idSearchlookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emp_SearchlookupEdit21.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView521)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Size = new System.Drawing.Size(800, 50);
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gc);
            this.dataLayoutControl1.Controls.Add(this.btn_refresh);
            this.dataLayoutControl1.Controls.Add(this.in_op_SearchlookupEdit);
            this.dataLayoutControl1.Controls.Add(this.Med_idSearchlookupEdit1);
            this.dataLayoutControl1.Controls.Add(this.btn_view_serch);
            this.dataLayoutControl1.Controls.Add(this.emp_SearchlookupEdit21);
            this.dataLayoutControl1.Controls.Add(this.in_op_dateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.chb_from_to);
            this.dataLayoutControl1.Controls.Add(this.from_dateTimePicker1);
            this.dataLayoutControl1.Controls.Add(this.to_dateTimePicker2);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 50);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(800, 291);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gc
            // 
            this.gc.Location = new System.Drawing.Point(12, -10);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(639, 289);
            this.gc.TabIndex = 105;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gv.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.Appearance.Row.Options.UseTextOptions = true;
            this.gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsFind.AlwaysVisible = true;
            this.gv.OptionsMenu.ShowFooterItem = true;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.ImageOptions.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(658, 14);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(110, 36);
            this.btn_refresh.StyleController = this.dataLayoutControl1;
            this.btn_refresh.TabIndex = 111;
            this.btn_refresh.Text = "تحديث ";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // in_op_SearchlookupEdit
            // 
            this.in_op_SearchlookupEdit.Location = new System.Drawing.Point(658, 54);
            this.in_op_SearchlookupEdit.Margin = new System.Windows.Forms.Padding(2);
            this.in_op_SearchlookupEdit.Name = "in_op_SearchlookupEdit";
            this.in_op_SearchlookupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.in_op_SearchlookupEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_op_SearchlookupEdit.Properties.Appearance.Options.UseFont = true;
            this.in_op_SearchlookupEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.in_op_SearchlookupEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.in_op_SearchlookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.in_op_SearchlookupEdit.Properties.NullText = "";
            this.in_op_SearchlookupEdit.Properties.PopupView = this.gridView5;
            this.in_op_SearchlookupEdit.Size = new System.Drawing.Size(50, 26);
            this.in_op_SearchlookupEdit.StyleController = this.dataLayoutControl1;
            this.in_op_SearchlookupEdit.TabIndex = 104;
            this.in_op_SearchlookupEdit.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.in_op_SearchlookupEdit_CustomDisplayText);
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // Med_idSearchlookupEdit1
            // 
            this.Med_idSearchlookupEdit1.Location = new System.Drawing.Point(658, 84);
            this.Med_idSearchlookupEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.Med_idSearchlookupEdit1.Name = "Med_idSearchlookupEdit1";
            this.Med_idSearchlookupEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Med_idSearchlookupEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Med_idSearchlookupEdit1.Properties.Appearance.Options.UseFont = true;
            this.Med_idSearchlookupEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.Med_idSearchlookupEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Med_idSearchlookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Med_idSearchlookupEdit1.Properties.NullText = "";
            this.Med_idSearchlookupEdit1.Properties.PopupView = this.gridView51;
            this.Med_idSearchlookupEdit1.Size = new System.Drawing.Size(50, 26);
            this.Med_idSearchlookupEdit1.StyleController = this.dataLayoutControl1;
            this.Med_idSearchlookupEdit1.TabIndex = 104;
            this.Med_idSearchlookupEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.Med_idSearchlookupEdit1_CustomDisplayText);
            // 
            // gridView51
            // 
            this.gridView51.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView51.Name = "gridView51";
            this.gridView51.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView51.OptionsView.ShowGroupPanel = false;
            // 
            // btn_view_serch
            // 
            this.btn_view_serch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_view_serch.ImageOptions.Image")));
            this.btn_view_serch.Location = new System.Drawing.Point(658, 240);
            this.btn_view_serch.Name = "btn_view_serch";
            this.btn_view_serch.Size = new System.Drawing.Size(110, 36);
            this.btn_view_serch.StyleController = this.dataLayoutControl1;
            this.btn_view_serch.TabIndex = 112;
            this.btn_view_serch.Text = "عرض";
            this.btn_view_serch.Click += new System.EventHandler(this.btn_view_serch_Click);
            // 
            // emp_SearchlookupEdit21
            // 
            this.emp_SearchlookupEdit21.Location = new System.Drawing.Point(658, 114);
            this.emp_SearchlookupEdit21.Margin = new System.Windows.Forms.Padding(2);
            this.emp_SearchlookupEdit21.Name = "emp_SearchlookupEdit21";
            this.emp_SearchlookupEdit21.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.emp_SearchlookupEdit21.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_SearchlookupEdit21.Properties.Appearance.Options.UseFont = true;
            this.emp_SearchlookupEdit21.Properties.Appearance.Options.UseTextOptions = true;
            this.emp_SearchlookupEdit21.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.emp_SearchlookupEdit21.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.emp_SearchlookupEdit21.Properties.NullText = "";
            this.emp_SearchlookupEdit21.Properties.PopupView = this.gridView521;
            this.emp_SearchlookupEdit21.Size = new System.Drawing.Size(50, 26);
            this.emp_SearchlookupEdit21.StyleController = this.dataLayoutControl1;
            this.emp_SearchlookupEdit21.TabIndex = 104;
            this.emp_SearchlookupEdit21.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.emp_SearchlookupEdit21_CustomDisplayText);
            // 
            // gridView521
            // 
            this.gridView521.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView521.Name = "gridView521";
            this.gridView521.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView521.OptionsView.ShowGroupPanel = false;
            // 
            // in_op_dateDateEdit
            // 
            this.in_op_dateDateEdit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.in_op_dateDateEdit.Location = new System.Drawing.Point(658, 144);
            this.in_op_dateDateEdit.Name = "in_op_dateDateEdit";
            this.in_op_dateDateEdit.Size = new System.Drawing.Size(50, 20);
            this.in_op_dateDateEdit.TabIndex = 106;
            // 
            // chb_from_to
            // 
            this.chb_from_to.Location = new System.Drawing.Point(658, 168);
            this.chb_from_to.Name = "chb_from_to";
            this.chb_from_to.Size = new System.Drawing.Size(110, 20);
            this.chb_from_to.TabIndex = 113;
            this.chb_from_to.Text = "عن فترة";
            this.chb_from_to.UseVisualStyleBackColor = true;
            this.chb_from_to.CheckedChanged += new System.EventHandler(this.chb_from_to_CheckedChanged);
            // 
            // from_dateTimePicker1
            // 
            this.from_dateTimePicker1.Enabled = false;
            this.from_dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from_dateTimePicker1.Location = new System.Drawing.Point(658, 192);
            this.from_dateTimePicker1.Name = "from_dateTimePicker1";
            this.from_dateTimePicker1.Size = new System.Drawing.Size(50, 20);
            this.from_dateTimePicker1.TabIndex = 105;
            // 
            // to_dateTimePicker2
            // 
            this.to_dateTimePicker2.Enabled = false;
            this.to_dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_dateTimePicker2.Location = new System.Drawing.Point(658, 216);
            this.to_dateTimePicker2.Name = "to_dateTimePicker2";
            this.to_dateTimePicker2.Size = new System.Drawing.Size(50, 20);
            this.to_dateTimePicker2.TabIndex = 106;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(783, 313);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(643, 293);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "خيارات البحث";
            this.layoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem10,
            this.layoutControlItem14,
            this.layoutControlItem7,
            this.layoutControlItem11,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(643, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(120, 293);
            this.layoutControlGroup2.Text = "خيارات البحث";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btn_refresh;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(114, 40);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.in_op_SearchlookupEdit;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem2.CustomizationFormText = "فواتير";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(114, 30);
            this.layoutControlItem2.Text = "فواتير";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Med_idSearchlookupEdit1;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 70);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(114, 30);
            this.layoutControlItem5.Text = "دواء";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btn_view_serch;
            this.layoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 226);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(114, 40);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.emp_SearchlookupEdit21;
            this.layoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(114, 30);
            this.layoutControlItem14.Text = "الموظف";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.in_op_dateDateEdit;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem7.CustomizationFormText = "إلى";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(114, 24);
            this.layoutControlItem7.Text = "تاريخ العملية";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.chb_from_to;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 154);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(114, 24);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.from_dateTimePicker1;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem3.CustomizationFormText = "من";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 178);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(114, 24);
            this.layoutControlItem3.Text = "من";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.to_dateTimePicker2;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem4.CustomizationFormText = "إلى";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 202);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(114, 24);
            this.layoutControlItem4.Text = "إلى";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 13);
            // 
            // F_damege_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataLayoutControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "F_damege_rep";
            this.Text = "F_damege_rep";
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.in_op_SearchlookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Med_idSearchlookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emp_SearchlookupEdit21.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView521)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_refresh;
        private DevExpress.XtraEditors.SearchLookUpEdit in_op_SearchlookupEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.SearchLookUpEdit Med_idSearchlookupEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView51;
        private DevExpress.XtraEditors.SimpleButton btn_view_serch;
        private DevExpress.XtraEditors.SearchLookUpEdit emp_SearchlookupEdit21;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView521;
        private System.Windows.Forms.DateTimePicker in_op_dateDateEdit;
        private System.Windows.Forms.CheckBox chb_from_to;
        private System.Windows.Forms.DateTimePicker from_dateTimePicker1;
        private System.Windows.Forms.DateTimePicker to_dateTimePicker2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}