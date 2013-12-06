namespace Snakee
{
    partial class frmMain
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
            this.picSnakeCon = new System.Windows.Forms.PictureBox();
            this.txtKeyInput = new System.Windows.Forms.TextBox();
            this.picInfoCon = new System.Windows.Forms.PictureBox();
            this.picStartCountDown = new System.Windows.Forms.PictureBox();
            this.picShowTips = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSnakeCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStartCountDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowTips)).BeginInit();
            this.SuspendLayout();
            // 
            // picSnakeCon
            // 
            this.picSnakeCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSnakeCon.Location = new System.Drawing.Point(12, 68);
            this.picSnakeCon.Name = "picSnakeCon";
            this.picSnakeCon.Size = new System.Drawing.Size(327, 344);
            this.picSnakeCon.TabIndex = 0;
            this.picSnakeCon.TabStop = false;
            // 
            // txtKeyInput
            // 
            this.txtKeyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyInput.Location = new System.Drawing.Point(345, 12);
            this.txtKeyInput.Name = "txtKeyInput";
            this.txtKeyInput.ReadOnly = true;
            this.txtKeyInput.Size = new System.Drawing.Size(10, 22);
            this.txtKeyInput.TabIndex = 1;
            this.txtKeyInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtKeyInput_PreviewKeyDown);
            // 
            // picInfoCon
            // 
            this.picInfoCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picInfoCon.Location = new System.Drawing.Point(12, 12);
            this.picInfoCon.Name = "picInfoCon";
            this.picInfoCon.Size = new System.Drawing.Size(327, 50);
            this.picInfoCon.TabIndex = 2;
            this.picInfoCon.TabStop = false;
            // 
            // picStartCountDown
            // 
            this.picStartCountDown.BackColor = System.Drawing.Color.Transparent;
            this.picStartCountDown.Location = new System.Drawing.Point(345, 40);
            this.picStartCountDown.Name = "picStartCountDown";
            this.picStartCountDown.Size = new System.Drawing.Size(10, 33);
            this.picStartCountDown.TabIndex = 3;
            this.picStartCountDown.TabStop = false;
            this.picStartCountDown.Visible = false;
            // 
            // picShowTips
            // 
            this.picShowTips.Location = new System.Drawing.Point(345, 79);
            this.picShowTips.Name = "picShowTips";
            this.picShowTips.Size = new System.Drawing.Size(10, 33);
            this.picShowTips.TabIndex = 4;
            this.picShowTips.TabStop = false;
            this.picShowTips.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 438);
            this.Controls.Add(this.picShowTips);
            this.Controls.Add(this.picStartCountDown);
            this.Controls.Add(this.picInfoCon);
            this.Controls.Add(this.txtKeyInput);
            this.Controls.Add(this.picSnakeCon);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakee!";
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picSnakeCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfoCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStartCountDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowTips)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSnakeCon;
        private System.Windows.Forms.TextBox txtKeyInput;
        private System.Windows.Forms.PictureBox picInfoCon;
        private System.Windows.Forms.PictureBox picStartCountDown;
        private System.Windows.Forms.PictureBox picShowTips;
    }
}

