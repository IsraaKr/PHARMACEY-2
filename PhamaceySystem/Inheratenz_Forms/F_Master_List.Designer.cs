namespace PhamaceySystem
{
    partial class F_Master_List
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt_id = new DevExpress.XtraEditors.TextEdit();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txt = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_add1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_add1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.Size = new System.Drawing.Size(600, 60);
            this.lbl_tiltle.TabIndex = 0;
            this.lbl_tiltle.Text = "...";
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gc);
            this.dataLayoutControl1.Controls.Add(this.txt_id);
            this.dataLayoutControl1.Controls.Add(this.txt_name);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(600, 611);
            this.dataLayoutControl1.TabIndex = 11;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gc
            // 
            this.gc.Location = new System.Drawing.Point(17, 109);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(566, 485);
            this.gc.TabIndex = 12;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gv.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.Appearance.Row.Options.UseTextOptions = true;
            this.gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsFind.AlwaysVisible = true;
            this.gv.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gv.OptionsSelection.MultiSelect = true;
            this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gv_SelectionChanged);
            this.gv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_KeyDown);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(25, 75);
            this.txt_id.Margin = new System.Windows.Forms.Padding(5);
            this.txt_id.Name = "txt_id";
            this.txt_id.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Properties.Appearance.Options.UseFont = true;
            this.txt_id.Properties.Padding = new System.Windows.Forms.Padding(-1);
            this.txt_id.Size = new System.Drawing.Size(224, 22);
            this.txt_id.StyleController = this.dataLayoutControl1;
            this.txt_id.TabIndex = 4;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(310, 75);
            this.txt_name.Margin = new System.Windows.Forms.Padding(5);
            this.txt_name.Name = "txt_name";
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Properties.Padding = new System.Windows.Forms.Padding(-1);
            this.txt_name.Size = new System.Drawing.Size(224, 22);
            this.txt_name.StyleController = this.dataLayoutControl1;
            this.txt_name.TabIndex = 4;
            this.txt_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_name_KeyDown);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.txt,
            this.txt_add1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(15, 15, 15, 15);
            this.Root.Size = new System.Drawing.Size(600, 611);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gc;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(570, 489);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 50);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 50);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(570, 50);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txt
            // 
            this.txt.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.AppearanceItemCaption.Options.UseFont = true;
            this.txt.Control = this.txt_name;
            this.txt.CustomizationFormText = "txt";
            this.txt.Location = new System.Drawing.Point(285, 50);
            this.txt.Name = "txt";
            this.txt.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.txt.Size = new System.Drawing.Size(285, 42);
            this.txt.TextSize = new System.Drawing.Size(38, 18);
            // 
            // txt_add1
            // 
            this.txt_add1.Control = this.txt_id;
            this.txt_add1.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.txt_add1.CustomizationFormText = "txt_add";
            this.txt_add1.Location = new System.Drawing.Point(0, 50);
            this.txt_add1.Name = "txt_add1";
            this.txt_add1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.txt_add1.Size = new System.Drawing.Size(285, 42);
            this.txt_add1.Text = "txt_add";
            this.txt_add1.TextSize = new System.Drawing.Size(38, 15);
            this.txt_add1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // F_Master_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 720);
            this.Controls.Add(this.dataLayoutControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "F_Master_List";
            this.Text = "F_Master_ADD";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_add1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public DevExpress.XtraGrid.GridControl gc;
        public DevExpress.XtraGrid.Views.Grid.GridView gv;
        public DevExpress.XtraLayout.LayoutControlGroup Root;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlItem txt_add1;
        public DevExpress.XtraEditors.TextEdit txt_id;
        public DevExpress.XtraEditors.TextEdit txt_name;
        public DevExpress.XtraLayout.LayoutControlItem txt;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}