namespace PhamaceySystem.Forms.Store_Other_Forms
{
    partial class F_Store_Graid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Store_Graid));
            this.barBut_in = new DevExpress.XtraBars.BarButtonItem();
            this.barBut_out = new DevExpress.XtraBars.BarButtonItem();
            this.barBut_dam = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.SuspendLayout();
            // 
            // barBut_in
            // 
            this.barBut_in.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barBut_in.Caption = "ادخال";
            this.barBut_in.Id = 28;
            this.barBut_in.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBut_in.ImageOptions.Image")));
            this.barBut_in.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBut_in.ImageOptions.LargeImage")));
            this.barBut_in.Name = "barBut_in";
            this.barBut_in.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBut_in.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBut_in_ItemClick);
            // 
            // barBut_out
            // 
            this.barBut_out.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barBut_out.Caption = "اخراج";
            this.barBut_out.Id = 29;
            this.barBut_out.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBut_out.ImageOptions.Image")));
            this.barBut_out.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBut_out.ImageOptions.LargeImage")));
            this.barBut_out.Name = "barBut_out";
            this.barBut_out.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBut_out.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBut_out_ItemClick);
            // 
            // barBut_dam
            // 
            this.barBut_dam.Border = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.barBut_dam.Caption = "اتلاف";
            this.barBut_dam.Id = 30;
            this.barBut_dam.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBut_dam.ImageOptions.Image")));
            this.barBut_dam.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBut_dam.ImageOptions.LargeImage")));
            this.barBut_dam.Name = "barBut_dam";
            this.barBut_dam.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBut_dam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBut_dam_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Id = 31;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Id = 32;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // F_Store_Graid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 675);
            this.Name = "F_Store_Graid";
            this.Text = "F_Store_Graid";
            this.Load += new System.EventHandler(this.F_Store_Graid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barBut_in;
        private DevExpress.XtraBars.BarButtonItem barBut_out;
        private DevExpress.XtraBars.BarButtonItem barBut_dam;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    }
}