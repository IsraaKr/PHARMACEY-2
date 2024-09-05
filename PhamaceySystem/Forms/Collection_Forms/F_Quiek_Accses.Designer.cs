namespace PhamaceySystem.Forms
{
    partial class F_Quiek_Accses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Quiek_Accses));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_med = new DevExpress.XtraEditors.SimpleButton();
            this.btn_in_op = new DevExpress.XtraEditors.SimpleButton();
            this.btn_out_op = new DevExpress.XtraEditors.SimpleButton();
            this.btn_dam_op = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الوصول السريع";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_add_med);
            this.flowLayoutPanel1.Controls.Add(this.btn_in_op);
            this.flowLayoutPanel1.Controls.Add(this.btn_out_op);
            this.flowLayoutPanel1.Controls.Add(this.btn_dam_op);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(928, 174);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_add_med
            // 
            this.btn_add_med.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_add_med.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_med.Appearance.Options.UseBackColor = true;
            this.btn_add_med.Appearance.Options.UseFont = true;
            this.btn_add_med.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_add_med.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton5.ImageOptions.SvgImage")));
            this.btn_add_med.Location = new System.Drawing.Point(693, 30);
            this.btn_add_med.Margin = new System.Windows.Forms.Padding(10);
            this.btn_add_med.Name = "btn_add_med";
            this.btn_add_med.Size = new System.Drawing.Size(185, 139);
            this.btn_add_med.TabIndex = 4;
            this.btn_add_med.Text = "ادخال بطاقة مادة";
            this.btn_add_med.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // btn_in_op
            // 
            this.btn_in_op.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_in_op.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_in_op.Appearance.Options.UseBackColor = true;
            this.btn_in_op.Appearance.Options.UseFont = true;
            this.btn_in_op.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_in_op.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.btn_in_op.Location = new System.Drawing.Point(488, 30);
            this.btn_in_op.Margin = new System.Windows.Forms.Padding(10);
            this.btn_in_op.Name = "btn_in_op";
            this.btn_in_op.Size = new System.Drawing.Size(185, 139);
            this.btn_in_op.TabIndex = 1;
            this.btn_in_op.Text = "ادخال مواد";
            this.btn_in_op.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btn_out_op
            // 
            this.btn_out_op.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_out_op.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_out_op.Appearance.Options.UseBackColor = true;
            this.btn_out_op.Appearance.Options.UseFont = true;
            this.btn_out_op.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_out_op.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.btn_out_op.Location = new System.Drawing.Point(288, 30);
            this.btn_out_op.Margin = new System.Windows.Forms.Padding(10);
            this.btn_out_op.Name = "btn_out_op";
            this.btn_out_op.Size = new System.Drawing.Size(180, 139);
            this.btn_out_op.TabIndex = 2;
            this.btn_out_op.Text = "اخراج مواد";
            this.btn_out_op.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btn_dam_op
            // 
            this.btn_dam_op.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_dam_op.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dam_op.Appearance.Options.UseBackColor = true;
            this.btn_dam_op.Appearance.Options.UseFont = true;
            this.btn_dam_op.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btn_dam_op.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.btn_dam_op.Location = new System.Drawing.Point(88, 30);
            this.btn_dam_op.Margin = new System.Windows.Forms.Padding(10);
            this.btn_dam_op.Name = "btn_dam_op";
            this.btn_dam_op.Size = new System.Drawing.Size(180, 139);
            this.btn_dam_op.TabIndex = 3;
            this.btn_dam_op.Text = "اتلاف مواد";
            this.btn_dam_op.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(910, 157);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 2;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(934, 181);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(934, 181);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(914, 161);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // F_Quiek_Accses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 394);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_Quiek_Accses";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Quiek_Accses";
            this.Load += new System.EventHandler(this.F_Quiek_Accses_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_in_op;
        private DevExpress.XtraEditors.SimpleButton btn_out_op;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_dam_op;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btn_add_med;
    }
}