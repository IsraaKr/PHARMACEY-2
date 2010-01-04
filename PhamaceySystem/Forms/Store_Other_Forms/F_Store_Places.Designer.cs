namespace PhamaceySystem.Forms.Store_Forms
{
    partial class F_Store_Places
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
            this.txt_group = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_shuffel = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_shuffel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 19, 19);
            this.Root.Size = new System.Drawing.Size(600, 611);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txt_shuffel);
            this.dataLayoutControl1.Controls.Add(this.txt_group);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(690, 368, 1230, 500);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Size = new System.Drawing.Size(600, 611);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txt_name, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txt_id, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txt_group, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this.txt_shuffel, 0);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(30, 560);
            this.txt_id.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Properties.Appearance.Options.UseFont = true;
            this.txt_id.Size = new System.Drawing.Size(487, 22);
            this.txt_id.TabIndex = 5;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(33, 173);
            this.txt_name.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Properties.Appearance.Options.UseFont = true;
            this.txt_name.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_name.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_name.Size = new System.Drawing.Size(481, 22);
            this.txt_name.TabIndex = 3;
            // 
            // txt
            // 
            this.txt.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.AppearanceItemCaption.Options.UseFont = true;
            this.txt.Location = new System.Drawing.Point(0, 142);
            this.txt.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 13, 12, 12);
            this.txt.Size = new System.Drawing.Size(560, 46);
            this.txt.TextSize = new System.Drawing.Size(41, 18);
            // 
            // lbl_tiltle
            // 
            this.lbl_tiltle.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            // 
            // txt_group
            // 
            this.txt_group.Location = new System.Drawing.Point(33, 81);
            this.txt_group.Name = "txt_group";
            this.txt_group.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_group.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_group.Size = new System.Drawing.Size(481, 22);
            this.txt_group.StyleController = this.dataLayoutControl1;
            this.txt_group.TabIndex = 0;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_group;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 13, 12, 12);
            this.layoutControlItem1.Size = new System.Drawing.Size(560, 46);
            this.layoutControlItem1.Text = "المجموعة";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(41, 15);
            // 
            // txt_shuffel
            // 
            this.txt_shuffel.Location = new System.Drawing.Point(33, 127);
            this.txt_shuffel.Name = "txt_shuffel";
            this.txt_shuffel.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_shuffel.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txt_shuffel.Size = new System.Drawing.Size(481, 22);
            this.txt_shuffel.StyleController = this.dataLayoutControl1;
            this.txt_shuffel.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_shuffel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.Name = "item0";
            this.layoutControlItem2.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem2.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 13, 12, 12);
            this.layoutControlItem2.Size = new System.Drawing.Size(560, 46);
            this.layoutControlItem2.Text = "الرف";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(41, 15);
            // 
            // F_Store_Places
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 720);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "F_Store_Places";
            this.Text = "F_Store_Places";
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_shuffel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txt_group;
        private DevExpress.XtraEditors.TextEdit txt_shuffel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}