namespace MyDropBox
{
    partial class DropBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropBox));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoAboutMyBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem,
            this.createFolderToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 92);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.createFolderToolStripMenuItem.Text = "Create folder";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.createFolderToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.removeToolStripMenuItem.Text = "Delete";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloginToolStripMenuItem,
            this.deleteAccountToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // reloginToolStripMenuItem
            // 
            this.reloginToolStripMenuItem.Name = "reloginToolStripMenuItem";
            this.reloginToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.reloginToolStripMenuItem.Text = "Relogin";
            this.reloginToolStripMenuItem.Click += new System.EventHandler(this.reloginToolStripMenuItem_Click);
            // 
            // deleteAccountToolStripMenuItem
            // 
            this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            this.deleteAccountToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteAccountToolStripMenuItem.Text = "Delete Account";
            this.deleteAccountToolStripMenuItem.Click += new System.EventHandler(this.deleteAccountToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoAboutMyBoxToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // infoAboutMyBoxToolStripMenuItem
            // 
            this.infoAboutMyBoxToolStripMenuItem.Name = "infoAboutMyBoxToolStripMenuItem";
            this.infoAboutMyBoxToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.infoAboutMyBoxToolStripMenuItem.Text = "Info about my box";
            this.infoAboutMyBoxToolStripMenuItem.Click += new System.EventHandler(this.infoAboutMyBoxToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 278);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.png");
            this.imageList1.Images.SetKeyName(1, "1.png");
            this.imageList1.Images.SetKeyName(2, "2.png");
            this.imageList1.Images.SetKeyName(3, "3.png");
            this.imageList1.Images.SetKeyName(4, "4.png");
            this.imageList1.Images.SetKeyName(5, "5.png");
            this.imageList1.Images.SetKeyName(6, "6.png");
            this.imageList1.Images.SetKeyName(7, "7.png");
            this.imageList1.Images.SetKeyName(8, "8.png");
            this.imageList1.Images.SetKeyName(9, "9.png");
            this.imageList1.Images.SetKeyName(10, "10.png");
            this.imageList1.Images.SetKeyName(11, "11.png");
            this.imageList1.Images.SetKeyName(12, "12.png");
            this.imageList1.Images.SetKeyName(13, "13.png");
            this.imageList1.Images.SetKeyName(14, "14.png");
            this.imageList1.Images.SetKeyName(15, "15.png");
            this.imageList1.Images.SetKeyName(16, "16.png");
            this.imageList1.Images.SetKeyName(17, "17.png");
            this.imageList1.Images.SetKeyName(18, "18.png");
            this.imageList1.Images.SetKeyName(19, "19.png");
            this.imageList1.Images.SetKeyName(20, "20.png");
            this.imageList1.Images.SetKeyName(21, "21.png");
            this.imageList1.Images.SetKeyName(22, "22.png");
            this.imageList1.Images.SetKeyName(23, "23.png");
            this.imageList1.Images.SetKeyName(24, "24.png");
            this.imageList1.Images.SetKeyName(25, "25.png");
            this.imageList1.Images.SetKeyName(26, "26.png");
            this.imageList1.Images.SetKeyName(27, "27.png");
            this.imageList1.Images.SetKeyName(28, "28.png");
            this.imageList1.Images.SetKeyName(29, "29.png");
            this.imageList1.Images.SetKeyName(30, "30.png");
            this.imageList1.Images.SetKeyName(31, "31.png");
            this.imageList1.Images.SetKeyName(32, "32.png");
            this.imageList1.Images.SetKeyName(33, "33.png");
            this.imageList1.Images.SetKeyName(34, "34.png");
            this.imageList1.Images.SetKeyName(35, "35.png");
            this.imageList1.Images.SetKeyName(36, "36.png");
            this.imageList1.Images.SetKeyName(37, "37.png");
            this.imageList1.Images.SetKeyName(38, "38.png");
            this.imageList1.Images.SetKeyName(39, "39.png");
            this.imageList1.Images.SetKeyName(40, "40.png");
            this.imageList1.Images.SetKeyName(41, "41.png");
            this.imageList1.Images.SetKeyName(42, "42.png");
            this.imageList1.Images.SetKeyName(43, "43.png");
            this.imageList1.Images.SetKeyName(44, "44.png");
            this.imageList1.Images.SetKeyName(45, "45.png");
            this.imageList1.Images.SetKeyName(46, "46.png");
            this.imageList1.Images.SetKeyName(47, "47.png");
            this.imageList1.Images.SetKeyName(48, "48.png");
            this.imageList1.Images.SetKeyName(49, "49.png");
            this.imageList1.Images.SetKeyName(50, "50.png");
            this.imageList1.Images.SetKeyName(51, "51.png");
            // 
            // DropBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 302);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DropBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DropBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DropBox_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoAboutMyBoxToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}