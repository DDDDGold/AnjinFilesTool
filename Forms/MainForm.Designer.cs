namespace AnjinApplication
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusBar = new StatusStrip();
            stateText = new ToolStripStatusLabel();
            processBar = new ToolStripProgressBar();
            fileListBox = new ListBox();
            searchTb = new TextBox();
            searchBtn = new Button();
            replaceTb = new TextBox();
            replaceBtn = new Button();
            srcText = new Label();
            warningText = new Label();
            fileMenu = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            operationMenu = new ToolStripMenuItem();
            noneMenuItem = new ToolStripMenuItem();
            refreshMenuItem = new ToolStripMenuItem();
            filterMenu = new ToolStripMenuItem();
            skipFolderMenuItem = new ToolStripMenuItem();
            menuBar = new MenuStrip();
            rightClickMenu = new ContextMenuStrip(components);
            renameMenuItem = new ToolStripMenuItem();
            openByExplorer = new ToolStripMenuItem();
            statusBar.SuspendLayout();
            menuBar.SuspendLayout();
            rightClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusBar.AutoSize = false;
            statusBar.BackColor = SystemColors.Control;
            statusBar.Dock = DockStyle.None;
            statusBar.ImageScalingSize = new Size(32, 32);
            statusBar.Items.AddRange(new ToolStripItem[] { stateText, processBar });
            statusBar.Location = new Point(0, 967);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(650, 41);
            statusBar.TabIndex = 6;
            statusBar.Text = "statusStrip1";
            // 
            // stateText
            // 
            stateText.ActiveLinkColor = Color.White;
            stateText.Name = "stateText";
            stateText.Size = new Size(331, 31);
            stateText.Spring = true;
            stateText.Text = "状态";
            stateText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // processBar
            // 
            processBar.ForeColor = SystemColors.Control;
            processBar.Name = "processBar";
            processBar.Size = new Size(300, 29);
            // 
            // fileListBox
            // 
            fileListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileListBox.BorderStyle = BorderStyle.FixedSingle;
            fileListBox.FormattingEnabled = true;
            fileListBox.HorizontalScrollbar = true;
            fileListBox.ItemHeight = 31;
            fileListBox.Location = new Point(58, 290);
            fileListBox.Name = "fileListBox";
            fileListBox.SelectionMode = SelectionMode.MultiExtended;
            fileListBox.Size = new Size(532, 653);
            fileListBox.TabIndex = 7;
            fileListBox.MouseDown += fileListBox_MouseDown;
            // 
            // searchTb
            // 
            searchTb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTb.Location = new Point(58, 66);
            searchTb.Name = "searchTb";
            searchTb.PlaceholderText = "关键字";
            searchTb.Size = new Size(344, 38);
            searchTb.TabIndex = 8;
            // 
            // searchBtn
            // 
            searchBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchBtn.Location = new Point(440, 61);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(150, 46);
            searchBtn.TabIndex = 9;
            searchBtn.Text = "查找";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // replaceTb
            // 
            replaceTb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            replaceTb.Location = new Point(58, 137);
            replaceTb.Name = "replaceTb";
            replaceTb.PlaceholderText = "替换为";
            replaceTb.Size = new Size(344, 38);
            replaceTb.TabIndex = 10;
            // 
            // replaceBtn
            // 
            replaceBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            replaceBtn.Location = new Point(440, 132);
            replaceBtn.Name = "replaceBtn";
            replaceBtn.Size = new Size(150, 46);
            replaceBtn.TabIndex = 11;
            replaceBtn.Text = "替换为";
            replaceBtn.UseVisualStyleBackColor = true;
            replaceBtn.Click += replaceBtn_Click;
            // 
            // srcText
            // 
            srcText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            srcText.AutoEllipsis = true;
            srcText.ForeColor = SystemColors.ButtonHighlight;
            srcText.Location = new Point(58, 252);
            srcText.Name = "srcText";
            srcText.Size = new Size(532, 35);
            srcText.TabIndex = 12;
            srcText.Text = "文件路径";
            // 
            // warningText
            // 
            warningText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            warningText.AutoEllipsis = true;
            warningText.BackColor = SystemColors.Control;
            warningText.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            warningText.ForeColor = Color.Red;
            warningText.Location = new Point(58, 181);
            warningText.Name = "warningText";
            warningText.Size = new Size(532, 35);
            warningText.TabIndex = 13;
            warningText.Text = "错误信息";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openMenuItem, saveMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(82, 38);
            fileMenu.Text = "文件";
            // 
            // openMenuItem
            // 
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Size = new Size(287, 44);
            openMenuItem.Text = "打开";
            openMenuItem.Click += openMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(287, 44);
            saveMenuItem.Text = "保存";
            saveMenuItem.Click += saveMenuItem_Click;
            // 
            // operationMenu
            // 
            operationMenu.DropDownItems.AddRange(new ToolStripItem[] { noneMenuItem, refreshMenuItem });
            operationMenu.Name = "operationMenu";
            operationMenu.Size = new Size(82, 38);
            operationMenu.Text = "操作";
            // 
            // noneMenuItem
            // 
            noneMenuItem.Name = "noneMenuItem";
            noneMenuItem.Size = new Size(280, 44);
            noneMenuItem.Text = "无";
            // 
            // refreshMenuItem
            // 
            refreshMenuItem.Name = "refreshMenuItem";
            refreshMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            refreshMenuItem.Size = new Size(280, 44);
            refreshMenuItem.Text = "刷新";
            refreshMenuItem.Click += refreshMenuItem_Click;
            // 
            // filterMenu
            // 
            filterMenu.DropDownItems.AddRange(new ToolStripItem[] { skipFolderMenuItem });
            filterMenu.Name = "filterMenu";
            filterMenu.Size = new Size(106, 38);
            filterMenu.Text = "过滤器";
            // 
            // skipFolderMenuItem
            // 
            skipFolderMenuItem.Name = "skipFolderMenuItem";
            skipFolderMenuItem.Size = new Size(359, 44);
            skipFolderMenuItem.Text = "不显示文件夹";
            skipFolderMenuItem.Click += skipFolderMenuItem_Click;
            // 
            // menuBar
            // 
            menuBar.ImageScalingSize = new Size(32, 32);
            menuBar.Items.AddRange(new ToolStripItem[] { fileMenu, operationMenu, filterMenu });
            menuBar.Location = new Point(0, 0);
            menuBar.Name = "menuBar";
            menuBar.Size = new Size(650, 42);
            menuBar.TabIndex = 2;
            menuBar.Text = "menuStrip1";
            // 
            // rightClickMenu
            // 
            rightClickMenu.ImageScalingSize = new Size(32, 32);
            rightClickMenu.Items.AddRange(new ToolStripItem[] { renameMenuItem, openByExplorer });
            rightClickMenu.Name = "rightClickMenu";
            rightClickMenu.Size = new Size(353, 80);
            // 
            // renameMenuItem
            // 
            renameMenuItem.Name = "renameMenuItem";
            renameMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            renameMenuItem.Size = new Size(352, 38);
            renameMenuItem.Text = "重命名";
            renameMenuItem.Click += renameMenuItem_Click;
            // 
            // openByExplorer
            // 
            openByExplorer.Name = "openByExplorer";
            openByExplorer.Size = new Size(352, 38);
            openByExplorer.Text = "在文件资源管理器中打开";
            openByExplorer.Click += openByExplorer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 1008);
            Controls.Add(warningText);
            Controls.Add(srcText);
            Controls.Add(replaceBtn);
            Controls.Add(replaceTb);
            Controls.Add(searchBtn);
            Controls.Add(searchTb);
            Controls.Add(fileListBox);
            Controls.Add(statusBar);
            Controls.Add(menuBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuBar;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "暗金的文件小工具";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            menuBar.ResumeLayout(false);
            menuBar.PerformLayout();
            rightClickMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusBar;
        private ToolStripStatusLabel stateText;
        private ListBox fileListBox;
        private TextBox searchTb;
        private Button searchBtn;
        private TextBox replaceTb;
        private Button replaceBtn;
        private Label srcText;
        private Label warningText;
        private ToolStripProgressBar processBar;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem operationMenu;
        private ToolStripMenuItem noneMenuItem;
        private ToolStripMenuItem filterMenu;
        private ToolStripMenuItem skipFolderMenuItem;
        private MenuStrip menuBar;
        private ContextMenuStrip rightClickMenu;
        private ToolStripMenuItem renameMenuItem;
        private ToolStripMenuItem openByExplorer;
        private ToolStripMenuItem refreshMenuItem;
    }
}