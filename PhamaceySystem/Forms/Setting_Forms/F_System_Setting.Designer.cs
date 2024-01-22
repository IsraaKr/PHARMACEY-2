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
            this.textEdit_gc_row_count = new DevExpress.XtraEditors.TextEdit();
            this.colorPickEdit_master = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEdit_list = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEdit_graid = new DevExpress.XtraEditors.ColorPickEdit();
            this.col = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_gc_row_count.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_master.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_list.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_graid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tiltle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_tiltle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_tiltle.Size = new System.Drawing.Size(1067, 60);
            // 
            // timer_date
            // 
            this.timer_date.Enabled = true;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.textEdit_gc_row_count);
            this.dataLayoutControl1.Controls.Add(this.colorPickEdit_master);
            this.dataLayoutControl1.Controls.Add(this.colorPickEdit_list);
            this.dataLayoutControl1.Controls.Add(this.colorPickEdit_graid);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 60);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.col;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1067, 360);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEdit_gc_row_count
            // 
            this.textEdit_gc_row_count.Location = new System.Drawing.Point(15, 186);
            this.textEdit_gc_row_count.MenuManager = this.barMang;
            this.textEdit_gc_row_count.Name = "textEdit_gc_row_count";
            this.textEdit_gc_row_count.Properties.Mask.EditMask = "d";
            this.textEdit_gc_row_count.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_gc_row_count.Size = new System.Drawing.Size(816, 26);
            this.textEdit_gc_row_count.StyleController = this.dataLayoutControl1;
            this.textEdit_gc_row_count.TabIndex = 8;
            // 
            // colorPickEdit_master
            // 
            this.colorPickEdit_master.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit_master.Location = new System.Drawing.Point(27, 134);
            this.colorPickEdit_master.MenuManager = this.barMang;
            this.colorPickEdit_master.Name = "colorPickEdit_master";
            this.colorPickEdit_master.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickEdit_master.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit_master.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEdit_master.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit_master.Size = new System.Drawing.Size(792, 30);
            this.colorPickEdit_master.StyleController = this.dataLayoutControl1;
            this.colorPickEdit_master.TabIndex = 6;
            // 
            // colorPickEdit_list
            // 
            this.colorPickEdit_list.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit_list.Location = new System.Drawing.Point(27, 94);
            this.colorPickEdit_list.MenuManager = this.barMang;
            this.colorPickEdit_list.Name = "colorPickEdit_list";
            this.colorPickEdit_list.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickEdit_list.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit_list.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEdit_list.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit_list.Size = new System.Drawing.Size(792, 30);
            this.colorPickEdit_list.StyleController = this.dataLayoutControl1;
            this.colorPickEdit_list.TabIndex = 5;
            // 
            // colorPickEdit_graid
            // 
            this.colorPickEdit_graid.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit_graid.Location = new System.Drawing.Point(27, 54);
            this.colorPickEdit_graid.Margin = new System.Windows.Forms.Padding(4);
            this.colorPickEdit_graid.MenuManager = this.barMang;
            this.colorPickEdit_graid.Name = "colorPickEdit_graid";
            this.colorPickEdit_graid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickEdit_graid.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit_graid.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEdit_graid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit_graid.Size = new System.Drawing.Size(792, 30);
            this.colorPickEdit_graid.StyleController = this.dataLayoutControl1;
            this.colorPickEdit_graid.TabIndex = 4;
            // 
            // col
            // 
            this.col.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.col.GroupBordersVisible = false;
            this.col.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlGroup1,
            this.layoutControlItem5});
            this.col.Name = "col";
            this.col.Size = new System.Drawing.Size(1067, 360);
            this.col.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 209);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1047, 131);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1047, 171);
            this.layoutControlGroup1.Text = "ألوان العناوين";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.colorPickEdit_graid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(1023, 40);
            this.layoutControlItem1.Text = "الجداول";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(218, 24);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.colorPickEdit_list;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(1023, 40);
            this.layoutControlItem2.Text = "القوائم";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(218, 24);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.colorPickEdit_master;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(1023, 40);
            this.layoutControlItem3.Text = "الكلي";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(218, 24);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.textEdit_gc_row_count;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 171);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(1047, 38);
            this.layoutControlItem5.Text = "عدد عناصر الجداول للعرض";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(218, 28);
            // 
            // F_System_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataLayoutControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "F_System_Setting";
            this.Text = "F_System_Setting";
            this.Controls.SetChildIndex(this.lbl_tiltle, 0);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_gc_row_count.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_master.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_list.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit_graid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup col;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit_graid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit textEdit_gc_row_count;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit_master;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit_list;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}