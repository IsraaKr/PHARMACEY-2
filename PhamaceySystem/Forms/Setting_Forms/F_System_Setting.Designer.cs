namespace PhamaceySystem.Forms.Setting_Forms
{
    partial class F_System_Setting
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
            this.ch_show_exp_date_form = new DevExpress.XtraEditors.CheckEdit();
            this.ch_show_exp_date_not = new DevExpress.XtraEditors.CheckEdit();
            this.ch_show_med_min_form = new DevExpress.XtraEditors.CheckEdit();
            this.ch_show_med_min_not = new DevExpress.XtraEditors.CheckEdit();
            this.colorPickEdit_master = new DevExpress.XtraEditors.ColorPickEdit();
            this.col = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_exp_date_form.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_exp_date_not.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_med_min_form.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_med_min_not.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_master.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiltle.Size = new System.Drawing.Size(800, 49);
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ch_show_exp_date_form);
            this.dataLayoutControl1.Controls.Add(this.ch_show_exp_date_not);
            this.dataLayoutControl1.Controls.Add(this.ch_show_med_min_form);
            this.dataLayoutControl1.Controls.Add(this.ch_show_med_min_not);
            this.dataLayoutControl1.Controls.Add(this.colorPickEdit_master);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 49);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.col;
            this.dataLayoutControl1.Size = new System.Drawing.Size(800, 292);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ch_show_exp_date_form
            // 
            this.ch_show_exp_date_form.Location = new System.Drawing.Point(272, 152);
            this.ch_show_exp_date_form.MenuManager = this.barMang;
            this.ch_show_exp_date_form.Name = "ch_show_exp_date_form";
            this.ch_show_exp_date_form.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_show_exp_date_form.Properties.Appearance.Options.UseFont = true;
            this.ch_show_exp_date_form.Properties.Caption = "عرض نافذة المواد المنتهية الصلاحية";
            this.ch_show_exp_date_form.Size = new System.Drawing.Size(312, 23);
            this.ch_show_exp_date_form.StyleController = this.dataLayoutControl1;
            this.ch_show_exp_date_form.TabIndex = 13;
            // 
            // ch_show_exp_date_not
            // 
            this.ch_show_exp_date_not.Location = new System.Drawing.Point(272, 125);
            this.ch_show_exp_date_not.MenuManager = this.barMang;
            this.ch_show_exp_date_not.Name = "ch_show_exp_date_not";
            this.ch_show_exp_date_not.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_show_exp_date_not.Properties.Appearance.Options.UseFont = true;
            this.ch_show_exp_date_not.Properties.Caption = "عرض تنبيه المواد المنتهية الصلاحية";
            this.ch_show_exp_date_not.Size = new System.Drawing.Size(312, 23);
            this.ch_show_exp_date_not.StyleController = this.dataLayoutControl1;
            this.ch_show_exp_date_not.TabIndex = 12;
            // 
            // ch_show_med_min_form
            // 
            this.ch_show_med_min_form.Location = new System.Drawing.Point(272, 98);
            this.ch_show_med_min_form.MenuManager = this.barMang;
            this.ch_show_med_min_form.Name = "ch_show_med_min_form";
            this.ch_show_med_min_form.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_show_med_min_form.Properties.Appearance.Options.UseFont = true;
            this.ch_show_med_min_form.Properties.Caption = "عرض نافذة المواد التي شارفت على الانتهاء";
            this.ch_show_med_min_form.Size = new System.Drawing.Size(312, 23);
            this.ch_show_med_min_form.StyleController = this.dataLayoutControl1;
            this.ch_show_med_min_form.TabIndex = 11;
            // 
            // ch_show_med_min_not
            // 
            this.ch_show_med_min_not.Location = new System.Drawing.Point(272, 68);
            this.ch_show_med_min_not.MenuManager = this.barMang;
            this.ch_show_med_min_not.Name = "ch_show_med_min_not";
            this.ch_show_med_min_not.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_show_med_min_not.Properties.Appearance.Options.UseFont = true;
            this.ch_show_med_min_not.Properties.Caption = "عرض تنبه المواد التي شارفت على الانتهاء";
            this.ch_show_med_min_not.Size = new System.Drawing.Size(312, 23);
            this.ch_show_med_min_not.StyleController = this.dataLayoutControl1;
            this.ch_show_med_min_not.TabIndex = 10;
            // 
            // colorPickEdit_master
            // 
            this.colorPickEdit_master.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit_master.Location = new System.Drawing.Point(274, 36);
            this.colorPickEdit_master.Margin = new System.Windows.Forms.Padding(2);
            this.colorPickEdit_master.MenuManager = this.barMang;
            this.colorPickEdit_master.Name = "colorPickEdit_master";
            this.colorPickEdit_master.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickEdit_master.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit_master.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEdit_master.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit_master.Size = new System.Drawing.Size(308, 26);
            this.colorPickEdit_master.StyleController = this.dataLayoutControl1;
            this.colorPickEdit_master.TabIndex = 6;
            // 
            // col
            // 
            this.col.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.col.GroupBordersVisible = false;
            this.col.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.col.Name = "Root";
            this.col.Size = new System.Drawing.Size(800, 292);
            this.col.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(260, 164);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(316, 108);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.colorPickEdit_master;
            this.layoutControlItem3.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Size = new System.Drawing.Size(316, 56);
            this.layoutControlItem3.Text = "لون العناوين";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(260, 272);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(576, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(204, 272);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ch_show_med_min_not;
            this.layoutControlItem2.Location = new System.Drawing.Point(260, 56);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(316, 30);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ch_show_med_min_form;
            this.layoutControlItem1.Location = new System.Drawing.Point(260, 86);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(316, 27);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ch_show_exp_date_not;
            this.layoutControlItem4.Location = new System.Drawing.Point(260, 113);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(316, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ch_show_exp_date_form;
            this.layoutControlItem5.Location = new System.Drawing.Point(260, 140);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // F_System_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataLayoutControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_System_Setting";
            this.Text = "F_System_Setting";
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_exp_date_form.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_exp_date_not.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_med_min_form.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ch_show_med_min_not.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_master.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup col;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit_master;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.CheckEdit ch_show_med_min_not;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit ch_show_med_min_form;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit ch_show_exp_date_form;
        private DevExpress.XtraEditors.CheckEdit ch_show_exp_date_not;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}