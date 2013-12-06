namespace CustomTextBox
{
    partial class CustomTxtBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtText = new System.Windows.Forms.TextBox();
            this.picCaption = new System.Windows.Forms.PictureBox();
            this.lblForFocus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(3, 62);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(165, 23);
            this.txtText.TabIndex = 1;
            this.txtText.MouseEnter += new System.EventHandler(this.txtText_MouseEnter);
            this.txtText.MouseLeave += new System.EventHandler(this.txtText_MouseLeave);
            // 
            // picCaption
            // 
            this.picCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaption.Location = new System.Drawing.Point(3, 0);
            this.picCaption.Name = "picCaption";
            this.picCaption.Size = new System.Drawing.Size(165, 55);
            this.picCaption.TabIndex = 0;
            this.picCaption.TabStop = false;
            this.picCaption.MouseEnter += new System.EventHandler(this.picCaption_MouseEnter);
            // 
            // lblForFocus
            // 
            this.lblForFocus.AutoSize = true;
            this.lblForFocus.Location = new System.Drawing.Point(0, 0);
            this.lblForFocus.Name = "lblForFocus";
            this.lblForFocus.Size = new System.Drawing.Size(0, 15);
            this.lblForFocus.TabIndex = 2;
            // 
            // CustomTxtBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblForFocus);
            this.Controls.Add(this.picCaption);
            this.Controls.Add(this.txtText);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomTxtBox";
            this.Size = new System.Drawing.Size(173, 100);
            ((System.ComponentModel.ISupportInitialize)(this.picCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.PictureBox picCaption;
        private System.Windows.Forms.Label lblForFocus;
    }
}
