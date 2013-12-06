namespace Snakee
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tbMain = new Snakee.TriangleBox();
            this.plbSidebar = new Snakee.PictureListBox();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Length = 10;
            this.tbMain.Location = new System.Drawing.Point(169, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Offset = 0;
            this.tbMain.Size = new System.Drawing.Size(393, 436);
            this.tbMain.TabIndex = 1;
            // 
            // plbSidebar
            // 
            this.plbSidebar.BackColor = System.Drawing.SystemColors.Window;
            this.plbSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.plbSidebar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.plbSidebar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plbSidebar.FormattingEnabled = true;
            this.plbSidebar.HorizontalExtent = 45;
            this.plbSidebar.HorizontalScrollbar = true;
            this.plbSidebar.Images = ((System.Collections.Generic.List<object>)(resources.GetObject("plbSidebar.Images")));
            this.plbSidebar.ItemHeight = 15;
            this.plbSidebar.Items.AddRange(new object[] {
            "Main"});
            this.plbSidebar.Location = new System.Drawing.Point(0, 0);
            this.plbSidebar.Name = "plbSidebar";
            this.plbSidebar.Size = new System.Drawing.Size(163, 448);
            this.plbSidebar.TabIndex = 2;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 448);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.plbSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TriangleBox tbMain;
        private PictureListBox plbSidebar;
    }
}