namespace Snakee
{
    partial class frmMapEditor_Bak
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
            this.gbMapPaint = new System.Windows.Forms.GroupBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.rbPaintWall = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbGenerate = new System.Windows.Forms.GroupBox();
            this.gbTheme = new System.Windows.Forms.GroupBox();
            this.gbDefaultTheme = new System.Windows.Forms.GroupBox();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbBlack = new System.Windows.Forms.RadioButton();
            this.picBackFore = new System.Windows.Forms.PictureBox();
            this.btnFore = new System.Windows.Forms.Button();
            this.btnBackground = new System.Windows.Forms.Button();
            this.gbSnakeeSkin = new System.Windows.Forms.GroupBox();
            this.btnSkinDefault = new System.Windows.Forms.Button();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblSkinNote = new System.Windows.Forms.Label();
            this.gbSave = new System.Windows.Forms.GroupBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctbWallPath = new Snakee.CustomTxtButton();
            this.ctbTurnFatUR = new Snakee.CustomTxtButton();
            this.ctbTurnURPath = new Snakee.CustomTxtButton();
            this.ctbTailRPath = new Snakee.CustomTxtButton();
            this.ctbHeadRPath = new Snakee.CustomTxtButton();
            this.ctbHeadEatRPath = new Snakee.CustomTxtButton();
            this.ctbBodyFatDRPath = new Snakee.CustomTxtButton();
            this.ctbBodyDRPath = new Snakee.CustomTxtButton();
            this.ctbFoodPath = new Snakee.CustomTxtButton();
            this.ctbSnakeLength = new CustomTextBox.CustomTxtBox();
            this.ctbSnakeInterval = new CustomTextBox.CustomTxtBox();
            this.ctbMapName = new CustomTextBox.CustomTxtBox();
            this.ctbMapPixelSize = new CustomTextBox.CustomTxtBox();
            this.ctbMapHeight = new CustomTextBox.CustomTxtBox();
            this.ctbMapWidth = new CustomTextBox.CustomTxtBox();
            this.gbMapPaint.SuspendLayout();
            this.gbGenerate.SuspendLayout();
            this.gbTheme.SuspendLayout();
            this.gbDefaultTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackFore)).BeginInit();
            this.gbSnakeeSkin.SuspendLayout();
            this.gbSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMapPaint
            // 
            this.gbMapPaint.Controls.Add(this.lblHelp);
            this.gbMapPaint.Controls.Add(this.rbPaintWall);
            this.gbMapPaint.Location = new System.Drawing.Point(66, 361);
            this.gbMapPaint.Name = "gbMapPaint";
            this.gbMapPaint.Size = new System.Drawing.Size(369, 84);
            this.gbMapPaint.TabIndex = 8;
            this.gbMapPaint.TabStop = false;
            this.gbMapPaint.Text = "Map\'s Painting Tools";
            this.gbMapPaint.Visible = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(62, 22);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(302, 45);
            this.lblHelp.TabIndex = 11;
            this.lblHelp.Text = "How to use:\r\nHold down left mouse button and move = Draw a wall\r\nHold down right " +
                "mouse button and move = Erase a wall";
            // 
            // rbPaintWall
            // 
            this.rbPaintWall.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPaintWall.AutoSize = true;
            this.rbPaintWall.Checked = true;
            this.rbPaintWall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPaintWall.Location = new System.Drawing.Point(14, 22);
            this.rbPaintWall.Name = "rbPaintWall";
            this.rbPaintWall.Size = new System.Drawing.Size(42, 27);
            this.rbPaintWall.TabIndex = 10;
            this.rbPaintWall.TabStop = true;
            this.rbPaintWall.Text = "Wall";
            this.rbPaintWall.UseVisualStyleBackColor = true;
            this.rbPaintWall.CheckedChanged += new System.EventHandler(this.rbPaintWall_CheckedChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Location = new System.Drawing.Point(12, 361);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(338, 79);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate New Map";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gbGenerate
            // 
            this.gbGenerate.Controls.Add(this.ctbSnakeLength);
            this.gbGenerate.Controls.Add(this.ctbSnakeInterval);
            this.gbGenerate.Controls.Add(this.ctbMapName);
            this.gbGenerate.Controls.Add(this.ctbMapPixelSize);
            this.gbGenerate.Controls.Add(this.ctbMapHeight);
            this.gbGenerate.Controls.Add(this.ctbMapWidth);
            this.gbGenerate.Location = new System.Drawing.Point(12, 12);
            this.gbGenerate.Name = "gbGenerate";
            this.gbGenerate.Size = new System.Drawing.Size(266, 142);
            this.gbGenerate.TabIndex = 5;
            this.gbGenerate.TabStop = false;
            this.gbGenerate.Text = "Map\'s Info";
            // 
            // gbTheme
            // 
            this.gbTheme.Controls.Add(this.gbDefaultTheme);
            this.gbTheme.Controls.Add(this.picBackFore);
            this.gbTheme.Controls.Add(this.btnFore);
            this.gbTheme.Controls.Add(this.btnBackground);
            this.gbTheme.Location = new System.Drawing.Point(12, 160);
            this.gbTheme.Name = "gbTheme";
            this.gbTheme.Size = new System.Drawing.Size(266, 194);
            this.gbTheme.TabIndex = 15;
            this.gbTheme.TabStop = false;
            this.gbTheme.Text = "Theme\'s Info";
            // 
            // gbDefaultTheme
            // 
            this.gbDefaultTheme.Controls.Add(this.rbNormal);
            this.gbDefaultTheme.Controls.Add(this.rbBlack);
            this.gbDefaultTheme.Location = new System.Drawing.Point(122, 13);
            this.gbDefaultTheme.Name = "gbDefaultTheme";
            this.gbDefaultTheme.Size = new System.Drawing.Size(138, 61);
            this.gbDefaultTheme.TabIndex = 16;
            this.gbDefaultTheme.TabStop = false;
            this.gbDefaultTheme.Text = "Built-In Theme";
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNormal.Location = new System.Drawing.Point(13, 17);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(104, 19);
            this.rbNormal.TabIndex = 13;
            this.rbNormal.Text = "Normal Theme";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbBlack
            // 
            this.rbBlack.AutoSize = true;
            this.rbBlack.Checked = true;
            this.rbBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbBlack.Location = new System.Drawing.Point(13, 36);
            this.rbBlack.Name = "rbBlack";
            this.rbBlack.Size = new System.Drawing.Size(92, 19);
            this.rbBlack.TabIndex = 14;
            this.rbBlack.TabStop = true;
            this.rbBlack.Text = "Black Theme";
            this.rbBlack.UseVisualStyleBackColor = true;
            this.rbBlack.CheckedChanged += new System.EventHandler(this.rbBlack_CheckedChanged);
            // 
            // picBackFore
            // 
            this.picBackFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackFore.Location = new System.Drawing.Point(6, 22);
            this.picBackFore.Name = "picBackFore";
            this.picBackFore.Size = new System.Drawing.Size(110, 155);
            this.picBackFore.TabIndex = 10;
            this.picBackFore.TabStop = false;
            // 
            // btnFore
            // 
            this.btnFore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFore.Location = new System.Drawing.Point(122, 80);
            this.btnFore.Name = "btnFore";
            this.btnFore.Size = new System.Drawing.Size(117, 46);
            this.btnFore.TabIndex = 11;
            this.btnFore.Text = "Foreground Color...";
            this.btnFore.UseVisualStyleBackColor = true;
            this.btnFore.Click += new System.EventHandler(this.btnFore_Click);
            // 
            // btnBackground
            // 
            this.btnBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackground.Location = new System.Drawing.Point(122, 132);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(117, 45);
            this.btnBackground.TabIndex = 12;
            this.btnBackground.Text = "Background Color...";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // gbSnakeeSkin
            // 
            this.gbSnakeeSkin.Controls.Add(this.btnSkinDefault);
            this.gbSnakeeSkin.Controls.Add(this.pnlPreview);
            this.gbSnakeeSkin.Controls.Add(this.lblSkinNote);
            this.gbSnakeeSkin.Controls.Add(this.ctbWallPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbTurnFatUR);
            this.gbSnakeeSkin.Controls.Add(this.ctbTurnURPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbTailRPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbHeadRPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbHeadEatRPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbBodyFatDRPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbBodyDRPath);
            this.gbSnakeeSkin.Controls.Add(this.ctbFoodPath);
            this.gbSnakeeSkin.Location = new System.Drawing.Point(284, 12);
            this.gbSnakeeSkin.Name = "gbSnakeeSkin";
            this.gbSnakeeSkin.Size = new System.Drawing.Size(341, 342);
            this.gbSnakeeSkin.TabIndex = 9;
            this.gbSnakeeSkin.TabStop = false;
            this.gbSnakeeSkin.Text = "Snakee\'s Skin";
            // 
            // btnSkinDefault
            // 
            this.btnSkinDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkinDefault.Location = new System.Drawing.Point(174, 280);
            this.btnSkinDefault.Name = "btnSkinDefault";
            this.btnSkinDefault.Size = new System.Drawing.Size(161, 56);
            this.btnSkinDefault.TabIndex = 0;
            this.btnSkinDefault.Text = "Me Lazy\r\n< Load Default Skin Please >";
            this.btnSkinDefault.UseVisualStyleBackColor = true;
            this.btnSkinDefault.Click += new System.EventHandler(this.btnSkinDefault_Click);
            // 
            // pnlPreview
            // 
            this.pnlPreview.AutoScroll = true;
            this.pnlPreview.Location = new System.Drawing.Point(174, 22);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(161, 253);
            this.pnlPreview.TabIndex = 20;
            // 
            // lblSkinNote
            // 
            this.lblSkinNote.AutoSize = true;
            this.lblSkinNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkinNote.Location = new System.Drawing.Point(6, 275);
            this.lblSkinNote.Name = "lblSkinNote";
            this.lblSkinNote.Size = new System.Drawing.Size(170, 65);
            this.lblSkinNote.TabIndex = 19;
            this.lblSkinNote.Text = "Snakee\'s Skin: PNG File \r\nSkin Size: Must equal to\r\n     Map\'s Info \"Size Per Uni" +
                "t\"\r\nYou can click on the picturebox \r\n     to hava a larger view";
            // 
            // gbSave
            // 
            this.gbSave.Controls.Add(this.btnSaveAs);
            this.gbSave.Controls.Add(this.btnSave);
            this.gbSave.Location = new System.Drawing.Point(435, 391);
            this.gbSave.Name = "gbSave";
            this.gbSave.Size = new System.Drawing.Size(188, 81);
            this.gbSave.TabIndex = 16;
            this.gbSave.TabStop = false;
            this.gbSave.Text = "Save";
            this.gbSave.Visible = false;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Location = new System.Drawing.Point(6, 46);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(175, 23);
            this.btnSaveAs.TabIndex = 1;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(6, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctbWallPath
            // 
            this.ctbWallPath.Caption = "Wall";
            this.ctbWallPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbWallPath.Location = new System.Drawing.Point(6, 252);
            this.ctbWallPath.Name = "ctbWallPath";
            this.ctbWallPath.Size = new System.Drawing.Size(161, 23);
            this.ctbWallPath.TabIndex = 18;
            this.ctbWallPath.TxtBoxReadOnly = true;
            this.ctbWallPath.ButtonClicked += new System.EventHandler(this.ctbWallPath_ButtonClicked);
            // 
            // ctbTurnFatUR
            // 
            this.ctbTurnFatUR.Caption = "Turning Fat (Up Right)";
            this.ctbTurnFatUR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbTurnFatUR.Location = new System.Drawing.Point(6, 196);
            this.ctbTurnFatUR.Name = "ctbTurnFatUR";
            this.ctbTurnFatUR.Size = new System.Drawing.Size(161, 23);
            this.ctbTurnFatUR.TabIndex = 17;
            this.ctbTurnFatUR.TxtBoxReadOnly = true;
            this.ctbTurnFatUR.ButtonClicked += new System.EventHandler(this.ctbTurnFatUR_ButtonClicked);
            // 
            // ctbTurnURPath
            // 
            this.ctbTurnURPath.Caption = "Turning (Up Right)";
            this.ctbTurnURPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbTurnURPath.Location = new System.Drawing.Point(6, 167);
            this.ctbTurnURPath.Name = "ctbTurnURPath";
            this.ctbTurnURPath.Size = new System.Drawing.Size(161, 23);
            this.ctbTurnURPath.TabIndex = 16;
            this.ctbTurnURPath.TxtBoxReadOnly = true;
            this.ctbTurnURPath.ButtonClicked += new System.EventHandler(this.ctbTurnURPath_ButtonClicked);
            // 
            // ctbTailRPath
            // 
            this.ctbTailRPath.Caption = "Tail (Right)";
            this.ctbTailRPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbTailRPath.Location = new System.Drawing.Point(6, 138);
            this.ctbTailRPath.Name = "ctbTailRPath";
            this.ctbTailRPath.Size = new System.Drawing.Size(161, 23);
            this.ctbTailRPath.TabIndex = 15;
            this.ctbTailRPath.TxtBoxReadOnly = true;
            this.ctbTailRPath.ButtonClicked += new System.EventHandler(this.ctbTailRPath_ButtonClicked);
            // 
            // ctbHeadRPath
            // 
            this.ctbHeadRPath.Caption = "Head (Right)";
            this.ctbHeadRPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbHeadRPath.Location = new System.Drawing.Point(6, 80);
            this.ctbHeadRPath.Name = "ctbHeadRPath";
            this.ctbHeadRPath.Size = new System.Drawing.Size(161, 23);
            this.ctbHeadRPath.TabIndex = 14;
            this.ctbHeadRPath.TxtBoxReadOnly = true;
            this.ctbHeadRPath.ButtonClicked += new System.EventHandler(this.ctbHeadRPath_ButtonClicked);
            // 
            // ctbHeadEatRPath
            // 
            this.ctbHeadEatRPath.Caption = "Head Eat (Right)";
            this.ctbHeadEatRPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbHeadEatRPath.Location = new System.Drawing.Point(6, 109);
            this.ctbHeadEatRPath.Name = "ctbHeadEatRPath";
            this.ctbHeadEatRPath.Size = new System.Drawing.Size(161, 23);
            this.ctbHeadEatRPath.TabIndex = 13;
            this.ctbHeadEatRPath.TxtBoxReadOnly = true;
            this.ctbHeadEatRPath.ButtonClicked += new System.EventHandler(this.ctbHeadEatRPath_ButtonClicked);
            // 
            // ctbBodyFatDRPath
            // 
            this.ctbBodyFatDRPath.Caption = "Body Fat (Down Right)";
            this.ctbBodyFatDRPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbBodyFatDRPath.Location = new System.Drawing.Point(6, 51);
            this.ctbBodyFatDRPath.Name = "ctbBodyFatDRPath";
            this.ctbBodyFatDRPath.Size = new System.Drawing.Size(161, 23);
            this.ctbBodyFatDRPath.TabIndex = 12;
            this.ctbBodyFatDRPath.TxtBoxReadOnly = true;
            this.ctbBodyFatDRPath.ButtonClicked += new System.EventHandler(this.ctbBodyFatDRPath_ButtonClicked);
            // 
            // ctbBodyDRPath
            // 
            this.ctbBodyDRPath.Caption = "Body (Down Right)";
            this.ctbBodyDRPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbBodyDRPath.Location = new System.Drawing.Point(6, 22);
            this.ctbBodyDRPath.Name = "ctbBodyDRPath";
            this.ctbBodyDRPath.Size = new System.Drawing.Size(161, 23);
            this.ctbBodyDRPath.TabIndex = 11;
            this.ctbBodyDRPath.TxtBoxReadOnly = true;
            this.ctbBodyDRPath.ButtonClicked += new System.EventHandler(this.ctbBodyDRPath_ButtonClicked);
            // 
            // ctbFoodPath
            // 
            this.ctbFoodPath.Caption = "Food";
            this.ctbFoodPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbFoodPath.Location = new System.Drawing.Point(6, 223);
            this.ctbFoodPath.Name = "ctbFoodPath";
            this.ctbFoodPath.Size = new System.Drawing.Size(161, 23);
            this.ctbFoodPath.TabIndex = 10;
            this.ctbFoodPath.TxtBoxReadOnly = true;
            this.ctbFoodPath.ButtonClicked += new System.EventHandler(this.ctbFoodPath_ButtonClicked);
            // 
            // ctbSnakeLength
            // 
            this.ctbSnakeLength.Caption = "Snake Length (>3)";
            this.ctbSnakeLength.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbSnakeLength.Location = new System.Drawing.Point(6, 109);
            this.ctbSnakeLength.Name = "ctbSnakeLength";
            this.ctbSnakeLength.ReadOnly = false;
            this.ctbSnakeLength.Size = new System.Drawing.Size(256, 23);
            this.ctbSnakeLength.TabIndex = 18;
            // 
            // ctbSnakeInterval
            // 
            this.ctbSnakeInterval.Caption = "Snakee Speed (MS between 2 moves)";
            this.ctbSnakeInterval.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbSnakeInterval.Location = new System.Drawing.Point(6, 51);
            this.ctbSnakeInterval.Name = "ctbSnakeInterval";
            this.ctbSnakeInterval.ReadOnly = false;
            this.ctbSnakeInterval.Size = new System.Drawing.Size(256, 23);
            this.ctbSnakeInterval.TabIndex = 0;
            this.ctbSnakeInterval.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbSnakeInterval_TextBoxKeyDown);
            // 
            // ctbMapName
            // 
            this.ctbMapName.Caption = "Map Name";
            this.ctbMapName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapName.Location = new System.Drawing.Point(6, 22);
            this.ctbMapName.Name = "ctbMapName";
            this.ctbMapName.ReadOnly = false;
            this.ctbMapName.Size = new System.Drawing.Size(256, 23);
            this.ctbMapName.TabIndex = 17;
            // 
            // ctbMapPixelSize
            // 
            this.ctbMapPixelSize.Caption = "Size Per Unit";
            this.ctbMapPixelSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapPixelSize.Location = new System.Drawing.Point(179, 80);
            this.ctbMapPixelSize.Name = "ctbMapPixelSize";
            this.ctbMapPixelSize.ReadOnly = false;
            this.ctbMapPixelSize.Size = new System.Drawing.Size(83, 23);
            this.ctbMapPixelSize.TabIndex = 16;
            this.ctbMapPixelSize.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapPixelSize_TextBoxKeyDown);
            // 
            // ctbMapHeight
            // 
            this.ctbMapHeight.Caption = "Map Height";
            this.ctbMapHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapHeight.Location = new System.Drawing.Point(87, 80);
            this.ctbMapHeight.Name = "ctbMapHeight";
            this.ctbMapHeight.ReadOnly = false;
            this.ctbMapHeight.Size = new System.Drawing.Size(86, 23);
            this.ctbMapHeight.TabIndex = 9;
            this.ctbMapHeight.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapHeight_TextBoxKeyDown);
            // 
            // ctbMapWidth
            // 
            this.ctbMapWidth.Caption = "Map Width";
            this.ctbMapWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapWidth.Location = new System.Drawing.Point(6, 80);
            this.ctbMapWidth.Name = "ctbMapWidth";
            this.ctbMapWidth.ReadOnly = false;
            this.ctbMapWidth.Size = new System.Drawing.Size(75, 23);
            this.ctbMapWidth.TabIndex = 8;
            this.ctbMapWidth.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapWidth_TextBoxKeyDown);
            // 
            // frmMapEditor_Bak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 465);
            this.Controls.Add(this.gbSave);
            this.Controls.Add(this.gbMapPaint);
            this.Controls.Add(this.gbSnakeeSkin);
            this.Controls.Add(this.gbTheme);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.gbGenerate);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMapEditor_Bak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakee - Map Editor";
            this.Load += new System.EventHandler(this.frmMapEditor_Load);
            this.gbMapPaint.ResumeLayout(false);
            this.gbMapPaint.PerformLayout();
            this.gbGenerate.ResumeLayout(false);
            this.gbTheme.ResumeLayout(false);
            this.gbDefaultTheme.ResumeLayout(false);
            this.gbDefaultTheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackFore)).EndInit();
            this.gbSnakeeSkin.ResumeLayout(false);
            this.gbSnakeeSkin.PerformLayout();
            this.gbSave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbGenerate;
        private CustomTextBox.CustomTxtBox ctbMapWidth;
        private CustomTextBox.CustomTxtBox ctbMapHeight;
        private System.Windows.Forms.Button btnBackground;
        private System.Windows.Forms.Button btnFore;
        private System.Windows.Forms.PictureBox picBackFore;
        private System.Windows.Forms.GroupBox gbTheme;
        private System.Windows.Forms.GroupBox gbDefaultTheme;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbBlack;
        private CustomTextBox.CustomTxtBox ctbMapPixelSize;
        private System.Windows.Forms.GroupBox gbMapPaint;
        private System.Windows.Forms.GroupBox gbSnakeeSkin;
        private CustomTxtButton ctbFoodPath;
        private System.Windows.Forms.RadioButton rbPaintWall;
        private CustomTxtButton ctbHeadEatRPath;
        private CustomTxtButton ctbBodyFatDRPath;
        private CustomTxtButton ctbBodyDRPath;
        private System.Windows.Forms.Label lblSkinNote;
        private CustomTxtButton ctbWallPath;
        private CustomTxtButton ctbTurnFatUR;
        private CustomTxtButton ctbTurnURPath;
        private CustomTxtButton ctbTailRPath;
        private CustomTxtButton ctbHeadRPath;
        private CustomTextBox.CustomTxtBox ctbSnakeInterval;
        private CustomTextBox.CustomTxtBox ctbMapName;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Button btnSkinDefault;
        private System.Windows.Forms.GroupBox gbSave;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSave;
        private CustomTextBox.CustomTxtBox ctbSnakeLength;
        private System.Windows.Forms.Label lblHelp;

    }
}