namespace TotalCommander
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.colNameL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSizeL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttrL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Right2 = new System.Windows.Forms.ToolStrip();
            this.TextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.Right1 = new System.Windows.Forms.ToolStrip();
            this.ComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.Label2 = new System.Windows.Forms.ToolStripLabel();
            this.listViewRight = new System.Windows.Forms.ListView();
            this.colNameR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSizeR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttrR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Left1 = new System.Windows.Forms.ToolStrip();
            this.ComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.Label1 = new System.Windows.Forms.ToolStripLabel();
            this.Left2 = new System.Windows.Forms.ToolStrip();
            this.TextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.folderButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.largeIcon = new System.Windows.Forms.ImageList(this.components);
            this.smallIcon = new System.Windows.Forms.ImageList(this.components);
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Right2.SuspendLayout();
            this.Right1.SuspendLayout();
            this.Left1.SuspendLayout();
            this.Left2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menu.Size = new System.Drawing.Size(817, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listViewLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Right2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Right1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewRight, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Left1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Left2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.733333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 401);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listViewLeft
            // 
            this.listViewLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNameL,
            this.colExtL,
            this.colSizeL,
            this.colDateL,
            this.colAttrL});
            this.listViewLeft.HideSelection = false;
            this.listViewLeft.Location = new System.Drawing.Point(3, 61);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(394, 315);
            this.listViewLeft.TabIndex = 8;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.Details;
            this.listViewLeft.ItemActivate += new System.EventHandler(this.ListViewLeft_ItemActivate);
            // 
            // colNameL
            // 
            this.colNameL.Text = "Name";
            this.colNameL.Width = 128;
            // 
            // colExtL
            // 
            this.colExtL.Text = "Ext";
            // 
            // colSizeL
            // 
            this.colSizeL.Text = "Size";
            // 
            // colDateL
            // 
            this.colDateL.Text = "Date";
            // 
            // colAttrL
            // 
            this.colAttrL.Text = "Attr";
            // 
            // Right2
            // 
            this.Right2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Right2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextBox2});
            this.Right2.Location = new System.Drawing.Point(408, 30);
            this.Right2.Name = "Right2";
            this.Right2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Right2.Size = new System.Drawing.Size(409, 25);
            this.Right2.TabIndex = 7;
            this.Right2.Text = "toolStrip5";
            // 
            // TextBox2
            // 
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(300, 25);
            // 
            // Right1
            // 
            this.Right1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Right1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboBox2,
            this.Label2});
            this.Right1.Location = new System.Drawing.Point(408, 0);
            this.Right1.Name = "Right1";
            this.Right1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Right1.Size = new System.Drawing.Size(409, 25);
            this.Right1.TabIndex = 5;
            this.Right1.Text = "toolStripRight";
            // 
            // ComboBox2
            // 
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(121, 25);
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 22);
            this.Label2.Text = "toolStripLabel2";
            // 
            // listViewRight
            // 
            this.listViewRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNameR,
            this.colExtR,
            this.colSizeR,
            this.colDateR,
            this.colAttrR});
            this.listViewRight.HideSelection = false;
            this.listViewRight.Location = new System.Drawing.Point(411, 61);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(394, 315);
            this.listViewRight.TabIndex = 2;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            this.listViewRight.View = System.Windows.Forms.View.Details;
            this.listViewRight.ItemActivate += new System.EventHandler(this.ListViewRight_ItemActivate);
            // 
            // colNameR
            // 
            this.colNameR.Text = "Name";
            this.colNameR.Width = 128;
            // 
            // colExtR
            // 
            this.colExtR.Text = "Ext";
            // 
            // colSizeR
            // 
            this.colSizeR.Text = "Size";
            // 
            // colDateR
            // 
            this.colDateR.Text = "Date";
            // 
            // colAttrR
            // 
            this.colAttrR.Text = "Attr";
            // 
            // Left1
            // 
            this.Left1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Left1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboBox1,
            this.Label1});
            this.Left1.Location = new System.Drawing.Point(0, 0);
            this.Left1.Name = "Left1";
            this.Left1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Left1.Size = new System.Drawing.Size(408, 25);
            this.Left1.TabIndex = 4;
            this.Left1.Text = "toolStripLeft";
            // 
            // ComboBox1
            // 
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(121, 25);
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 22);
            this.Label1.Text = "toolStripLabel1";
            // 
            // Left2
            // 
            this.Left2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Left2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextBox1});
            this.Left2.Location = new System.Drawing.Point(0, 30);
            this.Left2.Name = "Left2";
            this.Left2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Left2.Size = new System.Drawing.Size(408, 25);
            this.Left2.TabIndex = 6;
            this.Left2.Text = "toolStrip4";
            // 
            // TextBox1
            // 
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(300, 25);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.deleteButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.folderButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.moveButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.editButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.viewButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 433);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(797, 40);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(639, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(153, 34);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete (F8)";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(480, 3);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(153, 34);
            this.folderButton.TabIndex = 3;
            this.folderButton.Text = "Folder (F7)";
            this.folderButton.UseVisualStyleBackColor = true;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(321, 3);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(153, 34);
            this.moveButton.TabIndex = 2;
            this.moveButton.Text = "Move (F6)";
            this.moveButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(162, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(153, 34);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit (F4)";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(3, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(153, 34);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "View (F3)";
            this.viewButton.UseVisualStyleBackColor = true;
            // 
            // largeIcon
            // 
            this.largeIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeIcon.ImageStream")));
            this.largeIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.largeIcon.Images.SetKeyName(0, "folder.png");
            // 
            // smallIcon
            // 
            this.smallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallIcon.ImageStream")));
            this.smallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.smallIcon.Images.SetKeyName(0, "folder.png");
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(817, 25);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 484);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "TotalCommander";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Right2.ResumeLayout(false);
            this.Right2.PerformLayout();
            this.Right1.ResumeLayout(false);
            this.Right1.PerformLayout();
            this.Left1.ResumeLayout(false);
            this.Left1.PerformLayout();
            this.Left2.ResumeLayout(false);
            this.Left2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewRight;
        private System.Windows.Forms.ToolStrip Left1;
        private System.Windows.Forms.ToolStrip Right2;
        private System.Windows.Forms.ToolStripTextBox TextBox2;
        private System.Windows.Forms.ToolStrip Right1;
        private System.Windows.Forms.ToolStripComboBox ComboBox2;
        private System.Windows.Forms.ToolStripLabel Label2;
        private System.Windows.Forms.ToolStripComboBox ComboBox1;
        private System.Windows.Forms.ToolStripLabel Label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.ToolStrip Left2;
        private System.Windows.Forms.ToolStripTextBox TextBox1;
        private System.Windows.Forms.ImageList largeIcon;
        private System.Windows.Forms.ColumnHeader colNameR;
        private System.Windows.Forms.ColumnHeader colExtR;
        private System.Windows.Forms.ColumnHeader colSizeR;
        private System.Windows.Forms.ColumnHeader colDateR;
        private System.Windows.Forms.ColumnHeader colAttrR;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.ColumnHeader colNameL;
        private System.Windows.Forms.ColumnHeader colExtL;
        private System.Windows.Forms.ColumnHeader colSizeL;
        private System.Windows.Forms.ColumnHeader colDateL;
        private System.Windows.Forms.ColumnHeader colAttrL;
        private System.Windows.Forms.ImageList smallIcon;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

