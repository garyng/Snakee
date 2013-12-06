namespace Snakee
{
    partial class frmMapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapEditor));
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnNewMap = new System.Windows.Forms.Button();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.epnlThemeInfo = new Snakee.ExpandablePanel();
            this.btnThemeFore = new System.Windows.Forms.Button();
            this.btnThemeBack = new System.Windows.Forms.Button();
            this.picThemePreBox = new System.Windows.Forms.PictureBox();
            this.epnlMapInfo = new Snakee.ExpandablePanel();
            this.ctbMapInterval = new CustomTextBox.CustomTxtBox();
            this.ctbMapSnakeLength = new CustomTextBox.CustomTxtBox();
            this.ctbMapBlockSize = new CustomTextBox.CustomTxtBox();
            this.ctbMapHeight = new CustomTextBox.CustomTxtBox();
            this.ctbMapWidth = new CustomTextBox.CustomTxtBox();
            this.ctbMapName = new CustomTextBox.CustomTxtBox();
            this.pnlSkinCon = new System.Windows.Forms.Panel();
            this.epSkinPreview = new Snakee.ExpandablePanel();
            this.epSkinPreviewWall = new Snakee.ExpandablePanel();
            this.epSkinPreviewFood = new Snakee.ExpandablePanel();
            this.epSkinPreviewTurnFat = new Snakee.ExpandablePanel();
            this.epSkinPreviewTurn = new Snakee.ExpandablePanel();
            this.epSkinPreviewTail = new Snakee.ExpandablePanel();
            this.epSkinPreviewEatHead = new Snakee.ExpandablePanel();
            this.epSkinPreviewHead = new Snakee.ExpandablePanel();
            this.epSkinPreviewFatBody = new Snakee.ExpandablePanel();
            this.epSkinPreviewBody = new Snakee.ExpandablePanel();
            this.epnlSkinInfo = new Snakee.ExpandablePanel();
            this.lblSkinHelp = new System.Windows.Forms.Label();
            this.plbSkinPath = new Snakee.PictureListBox();
            this.btnImportSkin = new System.Windows.Forms.Button();
            this.tsBarSkin = new System.Windows.Forms.ToolStrip();
            this.tsbtnBackToHome = new System.Windows.Forms.ToolStripButton();
            this.tssBack = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDefault = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGenMap = new System.Windows.Forms.ToolStripButton();
            this.pnlSkinEditorCon = new System.Windows.Forms.Panel();
            this.plbErrorWarningSkin = new Snakee.PictureListBox();
            this.tsBarMap = new System.Windows.Forms.ToolStrip();
            this.tsbtnBackToSkin = new System.Windows.Forms.ToolStripButton();
            this.tssBackSkin = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMapSave = new System.Windows.Forms.ToolStripButton();
            this.tssPaintAction = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnBlock = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectFill = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectDraw = new System.Windows.Forms.ToolStripButton();
            this.tssUndo = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRedo = new System.Windows.Forms.ToolStripButton();
            this.pnlMapEditorCon = new System.Windows.Forms.Panel();
            this.pnlMapBoxCon = new System.Windows.Forms.Panel();
            this.pnlHome.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            this.epnlThemeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThemePreBox)).BeginInit();
            this.epnlMapInfo.SuspendLayout();
            this.pnlSkinCon.SuspendLayout();
            this.epSkinPreview.SuspendLayout();
            this.epnlSkinInfo.SuspendLayout();
            this.tsBarSkin.SuspendLayout();
            this.pnlSkinEditorCon.SuspendLayout();
            this.tsBarMap.SuspendLayout();
            this.pnlMapEditorCon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.lblCaption);
            this.pnlHome.Controls.Add(this.btnLoadMap);
            this.pnlHome.Controls.Add(this.btnNewMap);
            this.pnlHome.Location = new System.Drawing.Point(604, 6);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(295, 131);
            this.pnlHome.TabIndex = 0;
            this.pnlHome.Visible = false;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(295, 84);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Snakee - Map And Skin Editor";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLoadMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnLoadMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btnLoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMap.Location = new System.Drawing.Point(144, 34);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(120, 70);
            this.btnLoadMap.TabIndex = 1;
            this.btnLoadMap.Text = "Load Map...";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // btnNewMap
            // 
            this.btnNewMap.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnNewMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btnNewMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewMap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMap.Location = new System.Drawing.Point(18, 38);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(120, 70);
            this.btnNewMap.TabIndex = 0;
            this.btnNewMap.Text = "New Map";
            this.btnNewMap.UseVisualStyleBackColor = true;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.AutoScroll = true;
            this.pnlSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSideBar.Controls.Add(this.epnlThemeInfo);
            this.pnlSideBar.Controls.Add(this.epnlMapInfo);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(181, 614);
            this.pnlSideBar.TabIndex = 1;
            // 
            // epnlThemeInfo
            // 
            this.epnlThemeInfo.AutoScroll = true;
            this.epnlThemeInfo.Caption = "Theme Info";
            this.epnlThemeInfo.Controls.Add(this.btnThemeFore);
            this.epnlThemeInfo.Controls.Add(this.btnThemeBack);
            this.epnlThemeInfo.Controls.Add(this.picThemePreBox);
            this.epnlThemeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.epnlThemeInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epnlThemeInfo.IsExpand = true;
            this.epnlThemeInfo.Location = new System.Drawing.Point(0, 212);
            this.epnlThemeInfo.Name = "epnlThemeInfo";
            this.epnlThemeInfo.Size = new System.Drawing.Size(179, 127);
            this.epnlThemeInfo.TabIndex = 1;
            // 
            // btnThemeFore
            // 
            this.btnThemeFore.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThemeFore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnThemeFore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btnThemeFore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeFore.Location = new System.Drawing.Point(11, 92);
            this.btnThemeFore.Name = "btnThemeFore";
            this.btnThemeFore.Size = new System.Drawing.Size(155, 23);
            this.btnThemeFore.TabIndex = 2;
            this.btnThemeFore.Text = "Foreground Color";
            this.btnThemeFore.UseVisualStyleBackColor = true;
            this.btnThemeFore.Click += new System.EventHandler(this.btnThemeFore_Click);
            // 
            // btnThemeBack
            // 
            this.btnThemeBack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThemeBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnThemeBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.btnThemeBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeBack.Location = new System.Drawing.Point(11, 63);
            this.btnThemeBack.Name = "btnThemeBack";
            this.btnThemeBack.Size = new System.Drawing.Size(155, 23);
            this.btnThemeBack.TabIndex = 1;
            this.btnThemeBack.Text = "Background Color";
            this.btnThemeBack.UseVisualStyleBackColor = true;
            this.btnThemeBack.Click += new System.EventHandler(this.btnThemeBack_Click);
            // 
            // picThemePreBox
            // 
            this.picThemePreBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThemePreBox.Location = new System.Drawing.Point(11, 22);
            this.picThemePreBox.Name = "picThemePreBox";
            this.picThemePreBox.Size = new System.Drawing.Size(155, 35);
            this.picThemePreBox.TabIndex = 0;
            this.picThemePreBox.TabStop = false;
            // 
            // epnlMapInfo
            // 
            this.epnlMapInfo.AutoScroll = true;
            this.epnlMapInfo.Caption = "Map Info";
            this.epnlMapInfo.Controls.Add(this.ctbMapInterval);
            this.epnlMapInfo.Controls.Add(this.ctbMapSnakeLength);
            this.epnlMapInfo.Controls.Add(this.ctbMapBlockSize);
            this.epnlMapInfo.Controls.Add(this.ctbMapHeight);
            this.epnlMapInfo.Controls.Add(this.ctbMapWidth);
            this.epnlMapInfo.Controls.Add(this.ctbMapName);
            this.epnlMapInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.epnlMapInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epnlMapInfo.IsExpand = true;
            this.epnlMapInfo.Location = new System.Drawing.Point(0, 0);
            this.epnlMapInfo.Name = "epnlMapInfo";
            this.epnlMapInfo.Size = new System.Drawing.Size(179, 212);
            this.epnlMapInfo.TabIndex = 0;
            // 
            // ctbMapInterval
            // 
            this.ctbMapInterval.Caption = "Interval";
            this.ctbMapInterval.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapInterval.Location = new System.Drawing.Point(11, 169);
            this.ctbMapInterval.Name = "ctbMapInterval";
            this.ctbMapInterval.ReadOnly = false;
            this.ctbMapInterval.Size = new System.Drawing.Size(155, 23);
            this.ctbMapInterval.TabIndex = 5;
            this.ctbMapInterval.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapInterval_TextBoxKeyDown);
            // 
            // ctbMapSnakeLength
            // 
            this.ctbMapSnakeLength.Caption = "Snake Initial Length";
            this.ctbMapSnakeLength.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapSnakeLength.Location = new System.Drawing.Point(11, 140);
            this.ctbMapSnakeLength.Name = "ctbMapSnakeLength";
            this.ctbMapSnakeLength.ReadOnly = false;
            this.ctbMapSnakeLength.Size = new System.Drawing.Size(155, 23);
            this.ctbMapSnakeLength.TabIndex = 4;
            this.ctbMapSnakeLength.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapSnakeLength_TextBoxKeyDown);
            // 
            // ctbMapBlockSize
            // 
            this.ctbMapBlockSize.Caption = "Block Size";
            this.ctbMapBlockSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapBlockSize.Location = new System.Drawing.Point(11, 111);
            this.ctbMapBlockSize.Name = "ctbMapBlockSize";
            this.ctbMapBlockSize.ReadOnly = false;
            this.ctbMapBlockSize.Size = new System.Drawing.Size(155, 23);
            this.ctbMapBlockSize.TabIndex = 3;
            this.ctbMapBlockSize.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapBlockSize_TextBoxKeyDown);
            // 
            // ctbMapHeight
            // 
            this.ctbMapHeight.Caption = "Height";
            this.ctbMapHeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapHeight.Location = new System.Drawing.Point(11, 82);
            this.ctbMapHeight.Name = "ctbMapHeight";
            this.ctbMapHeight.ReadOnly = false;
            this.ctbMapHeight.Size = new System.Drawing.Size(155, 23);
            this.ctbMapHeight.TabIndex = 2;
            this.ctbMapHeight.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapHeight_TextBoxKeyDown);
            // 
            // ctbMapWidth
            // 
            this.ctbMapWidth.Caption = "Width";
            this.ctbMapWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapWidth.Location = new System.Drawing.Point(11, 53);
            this.ctbMapWidth.Name = "ctbMapWidth";
            this.ctbMapWidth.ReadOnly = false;
            this.ctbMapWidth.Size = new System.Drawing.Size(155, 23);
            this.ctbMapWidth.TabIndex = 1;
            this.ctbMapWidth.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctbMapWidth_TextBoxKeyDown);
            // 
            // ctbMapName
            // 
            this.ctbMapName.Caption = "Name";
            this.ctbMapName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbMapName.Location = new System.Drawing.Point(11, 24);
            this.ctbMapName.Name = "ctbMapName";
            this.ctbMapName.ReadOnly = false;
            this.ctbMapName.Size = new System.Drawing.Size(155, 23);
            this.ctbMapName.TabIndex = 0;
            // 
            // pnlSkinCon
            // 
            this.pnlSkinCon.Controls.Add(this.epSkinPreview);
            this.pnlSkinCon.Controls.Add(this.epnlSkinInfo);
            this.pnlSkinCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSkinCon.Location = new System.Drawing.Point(181, 25);
            this.pnlSkinCon.Name = "pnlSkinCon";
            this.pnlSkinCon.Size = new System.Drawing.Size(395, 589);
            this.pnlSkinCon.TabIndex = 3;
            // 
            // epSkinPreview
            // 
            this.epSkinPreview.AutoScroll = true;
            this.epSkinPreview.Caption = "Skin Preview";
            this.epSkinPreview.Controls.Add(this.epSkinPreviewWall);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewFood);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewTurnFat);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewTurn);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewTail);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewEatHead);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewHead);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewFatBody);
            this.epSkinPreview.Controls.Add(this.epSkinPreviewBody);
            this.epSkinPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.epSkinPreview.IsExpand = true;
            this.epSkinPreview.Location = new System.Drawing.Point(0, 277);
            this.epSkinPreview.Name = "epSkinPreview";
            this.epSkinPreview.Size = new System.Drawing.Size(395, 312);
            this.epSkinPreview.TabIndex = 3;
            // 
            // epSkinPreviewWall
            // 
            this.epSkinPreviewWall.AutoScroll = true;
            this.epSkinPreviewWall.Caption = "Skin Preview - Wall";
            this.epSkinPreviewWall.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewWall.IsExpand = true;
            this.epSkinPreviewWall.Location = new System.Drawing.Point(0, 720);
            this.epSkinPreviewWall.Name = "epSkinPreviewWall";
            this.epSkinPreviewWall.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewWall.TabIndex = 7;
            // 
            // epSkinPreviewFood
            // 
            this.epSkinPreviewFood.AutoScroll = true;
            this.epSkinPreviewFood.Caption = "Skin Preview - Food";
            this.epSkinPreviewFood.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewFood.IsExpand = true;
            this.epSkinPreviewFood.Location = new System.Drawing.Point(0, 630);
            this.epSkinPreviewFood.Name = "epSkinPreviewFood";
            this.epSkinPreviewFood.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewFood.TabIndex = 6;
            // 
            // epSkinPreviewTurnFat
            // 
            this.epSkinPreviewTurnFat.AutoScroll = true;
            this.epSkinPreviewTurnFat.Caption = "Skin Preview - Fat Turning Body";
            this.epSkinPreviewTurnFat.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewTurnFat.IsExpand = true;
            this.epSkinPreviewTurnFat.Location = new System.Drawing.Point(0, 540);
            this.epSkinPreviewTurnFat.Name = "epSkinPreviewTurnFat";
            this.epSkinPreviewTurnFat.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewTurnFat.TabIndex = 2;
            // 
            // epSkinPreviewTurn
            // 
            this.epSkinPreviewTurn.AutoScroll = true;
            this.epSkinPreviewTurn.Caption = "Skin Preview - Turning Body";
            this.epSkinPreviewTurn.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewTurn.IsExpand = true;
            this.epSkinPreviewTurn.Location = new System.Drawing.Point(0, 450);
            this.epSkinPreviewTurn.Name = "epSkinPreviewTurn";
            this.epSkinPreviewTurn.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewTurn.TabIndex = 3;
            // 
            // epSkinPreviewTail
            // 
            this.epSkinPreviewTail.AutoScroll = true;
            this.epSkinPreviewTail.Caption = "Skin Preview - Tail";
            this.epSkinPreviewTail.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewTail.IsExpand = true;
            this.epSkinPreviewTail.Location = new System.Drawing.Point(0, 360);
            this.epSkinPreviewTail.Name = "epSkinPreviewTail";
            this.epSkinPreviewTail.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewTail.TabIndex = 5;
            // 
            // epSkinPreviewEatHead
            // 
            this.epSkinPreviewEatHead.AutoScroll = true;
            this.epSkinPreviewEatHead.Caption = "Skin Preview - Eating Head";
            this.epSkinPreviewEatHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewEatHead.IsExpand = true;
            this.epSkinPreviewEatHead.Location = new System.Drawing.Point(0, 270);
            this.epSkinPreviewEatHead.Name = "epSkinPreviewEatHead";
            this.epSkinPreviewEatHead.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewEatHead.TabIndex = 1;
            // 
            // epSkinPreviewHead
            // 
            this.epSkinPreviewHead.AutoScroll = true;
            this.epSkinPreviewHead.Caption = "Skin Preview - Head";
            this.epSkinPreviewHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewHead.IsExpand = true;
            this.epSkinPreviewHead.Location = new System.Drawing.Point(0, 180);
            this.epSkinPreviewHead.Name = "epSkinPreviewHead";
            this.epSkinPreviewHead.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewHead.TabIndex = 4;
            // 
            // epSkinPreviewFatBody
            // 
            this.epSkinPreviewFatBody.AutoScroll = true;
            this.epSkinPreviewFatBody.Caption = "Skin Preview - Fat Body";
            this.epSkinPreviewFatBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewFatBody.IsExpand = true;
            this.epSkinPreviewFatBody.Location = new System.Drawing.Point(0, 90);
            this.epSkinPreviewFatBody.Name = "epSkinPreviewFatBody";
            this.epSkinPreviewFatBody.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewFatBody.TabIndex = 1;
            // 
            // epSkinPreviewBody
            // 
            this.epSkinPreviewBody.AutoScroll = true;
            this.epSkinPreviewBody.Caption = "Skin Preview - Body";
            this.epSkinPreviewBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.epSkinPreviewBody.IsExpand = true;
            this.epSkinPreviewBody.Location = new System.Drawing.Point(0, 0);
            this.epSkinPreviewBody.Name = "epSkinPreviewBody";
            this.epSkinPreviewBody.Size = new System.Drawing.Size(378, 90);
            this.epSkinPreviewBody.TabIndex = 0;
            // 
            // epnlSkinInfo
            // 
            this.epnlSkinInfo.AutoScroll = true;
            this.epnlSkinInfo.Caption = "Skin Info";
            this.epnlSkinInfo.Controls.Add(this.lblSkinHelp);
            this.epnlSkinInfo.Controls.Add(this.plbSkinPath);
            this.epnlSkinInfo.Controls.Add(this.btnImportSkin);
            this.epnlSkinInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.epnlSkinInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epnlSkinInfo.IsExpand = true;
            this.epnlSkinInfo.Location = new System.Drawing.Point(0, 0);
            this.epnlSkinInfo.Name = "epnlSkinInfo";
            this.epnlSkinInfo.Size = new System.Drawing.Size(395, 277);
            this.epnlSkinInfo.TabIndex = 2;
            // 
            // lblSkinHelp
            // 
            this.lblSkinHelp.AutoSize = true;
            this.lblSkinHelp.Location = new System.Drawing.Point(6, 17);
            this.lblSkinHelp.Name = "lblSkinHelp";
            this.lblSkinHelp.Size = new System.Drawing.Size(345, 45);
            this.lblSkinHelp.TabIndex = 0;
            this.lblSkinHelp.Text = "Left double click to select the path of the specific skin.\r\n*The skin image file " +
                "must be in PNG format.\r\n*The skin size must match the BlockSize in the Map Info " +
                "section.";
            // 
            // plbSkinPath
            // 
            this.plbSkinPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plbSkinPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.plbSkinPath.FormattingEnabled = true;
            this.plbSkinPath.HorizontalExtent = 166;
            this.plbSkinPath.HorizontalScrollbar = true;
            this.plbSkinPath.Images = ((System.Collections.Generic.List<object>)(resources.GetObject("plbSkinPath.Images")));
            this.plbSkinPath.ItemHeight = 20;
            this.plbSkinPath.Items.AddRange(new object[] {
            "Body (Down Right)",
            "Fat Body (Down Right)",
            "Head (Right)",
            "Eating Head (Right)",
            "Tail (Right)",
            "Turning Body (Up Right)",
            "Fat Turning Body (Up Right)",
            "Food",
            "Wall"});
            this.plbSkinPath.Location = new System.Drawing.Point(3, 65);
            this.plbSkinPath.Name = "plbSkinPath";
            this.plbSkinPath.Size = new System.Drawing.Size(195, 191);
            this.plbSkinPath.TabIndex = 1;
            this.plbSkinPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.plbSkinPath_MouseDoubleClick);
            // 
            // btnImportSkin
            // 
            this.btnImportSkin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSkin.Location = new System.Drawing.Point(203, 65);
            this.btnImportSkin.Name = "btnImportSkin";
            this.btnImportSkin.Size = new System.Drawing.Size(214, 191);
            this.btnImportSkin.TabIndex = 2;
            this.btnImportSkin.Text = resources.GetString("btnImportSkin.Text");
            this.btnImportSkin.UseVisualStyleBackColor = true;
            this.btnImportSkin.Click += new System.EventHandler(this.btnImportSkin_Click);
            // 
            // tsBarSkin
            // 
            this.tsBarSkin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnBackToHome,
            this.tssBack,
            this.tsbtnDefault,
            this.tsbtnGenMap});
            this.tsBarSkin.Location = new System.Drawing.Point(181, 0);
            this.tsBarSkin.Name = "tsBarSkin";
            this.tsBarSkin.Size = new System.Drawing.Size(395, 25);
            this.tsBarSkin.TabIndex = 2;
            // 
            // tsbtnBackToHome
            // 
            this.tsbtnBackToHome.Image = global::Snakee.Properties.Resources.button_back;
            this.tsbtnBackToHome.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnBackToHome.Name = "tsbtnBackToHome";
            this.tsbtnBackToHome.Size = new System.Drawing.Size(105, 22);
            this.tsbtnBackToHome.Text = "Back To Home";
            this.tsbtnBackToHome.Click += new System.EventHandler(this.tsbtnBack_Click);
            // 
            // tssBack
            // 
            this.tssBack.Name = "tssBack";
            this.tssBack.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDefault
            // 
            this.tsbtnDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnDefault.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDefault.Image")));
            this.tsbtnDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDefault.Name = "tsbtnDefault";
            this.tsbtnDefault.Size = new System.Drawing.Size(120, 22);
            this.tsbtnDefault.Text = "Reload Default Value";
            this.tsbtnDefault.Click += new System.EventHandler(this.tsbtnDefault_Click);
            // 
            // tsbtnGenMap
            // 
            this.tsbtnGenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnGenMap.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGenMap.Image")));
            this.tsbtnGenMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGenMap.Name = "tsbtnGenMap";
            this.tsbtnGenMap.Size = new System.Drawing.Size(112, 22);
            this.tsbtnGenMap.Text = "Generate New Map";
            this.tsbtnGenMap.Click += new System.EventHandler(this.tsbtnGenMap_Click);
            // 
            // pnlSkinEditorCon
            // 
            this.pnlSkinEditorCon.Controls.Add(this.pnlSkinCon);
            this.pnlSkinEditorCon.Controls.Add(this.tsBarSkin);
            this.pnlSkinEditorCon.Controls.Add(this.pnlSideBar);
            this.pnlSkinEditorCon.Controls.Add(this.plbErrorWarningSkin);
            this.pnlSkinEditorCon.Location = new System.Drawing.Point(0, 2);
            this.pnlSkinEditorCon.Name = "pnlSkinEditorCon";
            this.pnlSkinEditorCon.Size = new System.Drawing.Size(576, 697);
            this.pnlSkinEditorCon.TabIndex = 4;
            this.pnlSkinEditorCon.Visible = false;
            // 
            // plbErrorWarningSkin
            // 
            this.plbErrorWarningSkin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plbErrorWarningSkin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.plbErrorWarningSkin.FormattingEnabled = true;
            this.plbErrorWarningSkin.HorizontalScrollbar = true;
            this.plbErrorWarningSkin.Images = ((System.Collections.Generic.List<object>)(resources.GetObject("plbErrorWarningSkin.Images")));
            this.plbErrorWarningSkin.ItemHeight = 20;
            this.plbErrorWarningSkin.Location = new System.Drawing.Point(0, 614);
            this.plbErrorWarningSkin.Name = "plbErrorWarningSkin";
            this.plbErrorWarningSkin.Size = new System.Drawing.Size(576, 83);
            this.plbErrorWarningSkin.TabIndex = 5;
            // 
            // tsBarMap
            // 
            this.tsBarMap.BackColor = System.Drawing.SystemColors.Control;
            this.tsBarMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnBackToSkin,
            this.tssBackSkin,
            this.tsbtnMapSave,
            this.tssPaintAction,
            this.tsbtnBlock,
            this.tsbtnLine,
            this.tsbtnRectFill,
            this.tsbtnRectDraw,
            this.tssUndo,
            this.tsbtnUndo,
            this.tsbtnRedo});
            this.tsBarMap.Location = new System.Drawing.Point(0, 0);
            this.tsBarMap.Name = "tsBarMap";
            this.tsBarMap.Size = new System.Drawing.Size(430, 25);
            this.tsBarMap.TabIndex = 5;
            this.tsBarMap.MouseEnter += new System.EventHandler(this.tsBarMap_MouseEnter);
            // 
            // tsbtnBackToSkin
            // 
            this.tsbtnBackToSkin.Image = global::Snakee.Properties.Resources.button_back;
            this.tsbtnBackToSkin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBackToSkin.Name = "tsbtnBackToSkin";
            this.tsbtnBackToSkin.Size = new System.Drawing.Size(128, 22);
            this.tsbtnBackToSkin.Text = "Back To Skin Editor";
            this.tsbtnBackToSkin.Click += new System.EventHandler(this.tsbtnBackToSkin_Click);
            // 
            // tssBackSkin
            // 
            this.tssBackSkin.Name = "tssBackSkin";
            this.tssBackSkin.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnMapSave
            // 
            this.tsbtnMapSave.Image = global::Snakee.Properties.Resources.button_save;
            this.tsbtnMapSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMapSave.Name = "tsbtnMapSave";
            this.tsbtnMapSave.Size = new System.Drawing.Size(87, 22);
            this.tsbtnMapSave.Text = "Save Map...";
            this.tsbtnMapSave.Click += new System.EventHandler(this.tsbtnMapSave_Click);
            // 
            // tssPaintAction
            // 
            this.tssPaintAction.Name = "tssPaintAction";
            this.tssPaintAction.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnBlock
            // 
            this.tsbtnBlock.Checked = true;
            this.tsbtnBlock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnBlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnBlock.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBlock.Image")));
            this.tsbtnBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBlock.Name = "tsbtnBlock";
            this.tsbtnBlock.Size = new System.Drawing.Size(23, 22);
            this.tsbtnBlock.Text = "Draw Block";
            this.tsbtnBlock.Click += new System.EventHandler(this.tsbtnBlock_Click);
            // 
            // tsbtnLine
            // 
            this.tsbtnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLine.Image = global::Snakee.Properties.Resources.button_line;
            this.tsbtnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLine.Name = "tsbtnLine";
            this.tsbtnLine.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLine.Text = "Draw Line";
            this.tsbtnLine.Click += new System.EventHandler(this.tsbtnLine_Click);
            // 
            // tsbtnRectFill
            // 
            this.tsbtnRectFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectFill.Image = global::Snakee.Properties.Resources.button_rectanglefill;
            this.tsbtnRectFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectFill.Name = "tsbtnRectFill";
            this.tsbtnRectFill.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRectFill.Text = "Fill Rectangle";
            this.tsbtnRectFill.Click += new System.EventHandler(this.tsbtnRectFill_Click);
            // 
            // tsbtnRectDraw
            // 
            this.tsbtnRectDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectDraw.Image = global::Snakee.Properties.Resources.button_rectangle;
            this.tsbtnRectDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectDraw.Name = "tsbtnRectDraw";
            this.tsbtnRectDraw.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRectDraw.Text = "Draw Rectangle";
            this.tsbtnRectDraw.Click += new System.EventHandler(this.tsbtnRectDraw_Click);
            // 
            // tssUndo
            // 
            this.tssUndo.Name = "tssUndo";
            this.tssUndo.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnUndo
            // 
            this.tsbtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUndo.Enabled = false;
            this.tsbtnUndo.Image = global::Snakee.Properties.Resources.button_undo;
            this.tsbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUndo.Name = "tsbtnUndo";
            this.tsbtnUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnUndo.Text = "Undo";
            this.tsbtnUndo.Click += new System.EventHandler(this.tsbtnUndo_Click);
            // 
            // tsbtnRedo
            // 
            this.tsbtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRedo.Enabled = false;
            this.tsbtnRedo.Image = global::Snakee.Properties.Resources.button_redo;
            this.tsbtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRedo.Name = "tsbtnRedo";
            this.tsbtnRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRedo.Text = "Redo";
            this.tsbtnRedo.Click += new System.EventHandler(this.tsbtnRedo_Click);
            // 
            // pnlMapEditorCon
            // 
            this.pnlMapEditorCon.Controls.Add(this.pnlMapBoxCon);
            this.pnlMapEditorCon.Controls.Add(this.tsBarMap);
            this.pnlMapEditorCon.Location = new System.Drawing.Point(604, 143);
            this.pnlMapEditorCon.Name = "pnlMapEditorCon";
            this.pnlMapEditorCon.Size = new System.Drawing.Size(430, 418);
            this.pnlMapEditorCon.TabIndex = 5;
            this.pnlMapEditorCon.Visible = false;
            // 
            // pnlMapBoxCon
            // 
            this.pnlMapBoxCon.AutoScroll = true;
            this.pnlMapBoxCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapBoxCon.Location = new System.Drawing.Point(0, 25);
            this.pnlMapBoxCon.Name = "pnlMapBoxCon";
            this.pnlMapBoxCon.Size = new System.Drawing.Size(430, 393);
            this.pnlMapBoxCon.TabIndex = 6;
            this.pnlMapBoxCon.MouseLeave += new System.EventHandler(this.pnlMapBoxCon_MouseLeave);
            this.pnlMapBoxCon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMapBoxCon_MouseUp);
            // 
            // frmMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 735);
            this.Controls.Add(this.pnlMapEditorCon);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlSkinEditorCon);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakee - Map And Skin Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMapEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmMapEditor_Load);
            this.pnlHome.ResumeLayout(false);
            this.pnlSideBar.ResumeLayout(false);
            this.epnlThemeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picThemePreBox)).EndInit();
            this.epnlMapInfo.ResumeLayout(false);
            this.pnlSkinCon.ResumeLayout(false);
            this.epSkinPreview.ResumeLayout(false);
            this.epnlSkinInfo.ResumeLayout(false);
            this.epnlSkinInfo.PerformLayout();
            this.tsBarSkin.ResumeLayout(false);
            this.tsBarSkin.PerformLayout();
            this.pnlSkinEditorCon.ResumeLayout(false);
            this.pnlSkinEditorCon.PerformLayout();
            this.tsBarMap.ResumeLayout(false);
            this.tsBarMap.PerformLayout();
            this.pnlMapEditorCon.ResumeLayout(false);
            this.pnlMapEditorCon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlSkinCon;
        private System.Windows.Forms.ToolStripButton tsbtnGenMap;
        private System.Windows.Forms.ToolStrip tsBarSkin;
        private System.Windows.Forms.Panel pnlSkinEditorCon;
        private ExpandablePanel epnlMapInfo;
        private ExpandablePanel epnlSkinInfo;
        private ExpandablePanel epnlThemeInfo;
        private CustomTextBox.CustomTxtBox ctbMapName;
        private CustomTextBox.CustomTxtBox ctbMapWidth;
        private CustomTextBox.CustomTxtBox ctbMapBlockSize;
        private CustomTextBox.CustomTxtBox ctbMapHeight;
        private CustomTextBox.CustomTxtBox ctbMapSnakeLength;
        private System.Windows.Forms.Button btnThemeFore;
        private System.Windows.Forms.Button btnThemeBack;
        private System.Windows.Forms.PictureBox picThemePreBox;
        private System.Windows.Forms.ToolStripButton tsbtnBackToHome;
        private System.Windows.Forms.ToolStripButton tsbtnDefault;
        private System.Windows.Forms.Label lblSkinHelp;
        private System.Windows.Forms.Button btnImportSkin;
        private ExpandablePanel epSkinPreview;
        private ExpandablePanel epSkinPreviewWall;
        private ExpandablePanel epSkinPreviewFood;
        private ExpandablePanel epSkinPreviewTurnFat;
        private ExpandablePanel epSkinPreviewTurn;
        private ExpandablePanel epSkinPreviewTail;
        private ExpandablePanel epSkinPreviewEatHead;
        private ExpandablePanel epSkinPreviewHead;
        private ExpandablePanel epSkinPreviewFatBody;
        private ExpandablePanel epSkinPreviewBody;
        private CustomTextBox.CustomTxtBox ctbMapInterval;
        private System.Windows.Forms.ToolStrip tsBarMap;
        private System.Windows.Forms.ToolStripButton tsbtnMapSave;
        private System.Windows.Forms.ToolStripSeparator tssBack;
        private System.Windows.Forms.ToolStripButton tsbtnBackToSkin;
        private System.Windows.Forms.ToolStripSeparator tssBackSkin;
        private System.Windows.Forms.ToolStripButton tsbtnUndo;
        private System.Windows.Forms.ToolStripSeparator tssUndo;
        private System.Windows.Forms.ToolStripButton tsbtnRedo;
        private System.Windows.Forms.Panel pnlMapEditorCon;
        private PictureListBox plbErrorWarningSkin;
        private PictureListBox plbSkinPath;
        private System.Windows.Forms.Panel pnlMapBoxCon;
        private System.Windows.Forms.ToolStripSeparator tssPaintAction;
        private System.Windows.Forms.ToolStripButton tsbtnRectDraw;
        private System.Windows.Forms.ToolStripButton tsbtnRectFill;
        private System.Windows.Forms.ToolStripButton tsbtnBlock;
        private System.Windows.Forms.ToolStripButton tsbtnLine;
    }
}