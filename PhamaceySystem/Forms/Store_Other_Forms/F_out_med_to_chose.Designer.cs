namespace PhamaceySystem.Forms.Store_Other_Forms
{
    partial class F_out_med_to_chose
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
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tiltle.Size = new System.Drawing.Size(720, 49);
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gc.Location = new System.Drawing.Point(0, 49);
            this.gc.MainView = this.gv;
            this.gc.Margin = new System.Windows.Forms.Padding(2);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(720, 562);
            this.gc.TabIndex = 26;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            this.gc.Click += new System.EventHandler(this.gc_Click);
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
            this.gv.DetailHeight = 239;
            this.gv.FixedLineWidth = 1;
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsFind.AlwaysVisible = true;
            this.gv.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gv.OptionsSelection.MultiSelect = true;
            this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gv_InvalidRowException);
            this.gv.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gv_ValidateRow);
            this.gv.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gv_CustomUnboundColumnData);
            // 
            // F_out_med_to_chose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 720);
            this.Controls.Add(this.gc);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F_out_med_to_chose";
            this.Text = "F_out_med_to_chose";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            this.Controls.SetChildIndex(this.gc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gc;
        public DevExpress.XtraGrid.Views.Grid.GridView gv;
    }
}