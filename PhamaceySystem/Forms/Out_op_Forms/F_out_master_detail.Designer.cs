namespace PhamaceySystem.Forms.Out_op_Forms
{
    partial class F_out_master_detail
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv_2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.Size = new System.Drawing.Size(800, 60);
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gv_2;
            gridLevelNode1.RelationName = "gv_item";
            this.gc.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gc.Location = new System.Drawing.Point(0, 60);
            this.gc.MainView = this.gv;
            this.gc.MenuManager = this.barMang;
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(800, 281);
            this.gc.TabIndex = 13;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_2,
            this.gv});
            // 
            // gv_2
            // 
            this.gv_2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv_2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gv_2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv_2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gv_2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv_2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv_2.Appearance.Row.Options.UseFont = true;
            this.gv_2.Appearance.Row.Options.UseTextOptions = true;
            this.gv_2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_2.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_2.GridControl = this.gc;
            this.gv_2.Name = "gv_2";
            this.gv_2.OptionsPrint.AllowMultilineHeaders = true;
            this.gv_2.OptionsPrint.ExpandAllDetails = true;
            this.gv_2.OptionsPrint.PrintDetails = true;
            this.gv_2.OptionsPrint.PrintFilterInfo = true;
            this.gv_2.OptionsView.ShowAutoFilterRow = true;
            this.gv_2.OptionsView.ShowFooter = true;
            // 
            // gv
            // 
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.Row.Options.UseFont = true;
            this.gv.Appearance.Row.Options.UseTextOptions = true;
            this.gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsMenu.EnableFooterMenu = false;
            this.gv.OptionsPrint.AllowMultilineHeaders = true;
            this.gv.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gv.OptionsPrint.ExpandAllDetails = true;
            this.gv.OptionsPrint.PrintDetails = true;
            this.gv.OptionsPrint.PrintFilterInfo = true;
            this.gv.OptionsPrint.PrintFooter = false;
            this.gv.OptionsPrint.PrintGroupFooter = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            // 
            // F_out_master_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gc);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "F_out_master_detail";
            this.Text = "F_out_master_detail";
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            this.Controls.SetChildIndex(this.gc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
    }
}