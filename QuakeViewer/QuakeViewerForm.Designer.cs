namespace QuakeViewer {
  partial class QuakeViewerForm {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuakeViewerForm));
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.pakEntryIcons = new System.Windows.Forms.ImageList(this.components);
      this.viewtabControl = new System.Windows.Forms.TabControl();
      this.binViewTabPage = new System.Windows.Forms.TabPage();
      this.previewTabPage = new System.Windows.Forms.TabPage();
      this.previewPictureBox = new System.Windows.Forms.PictureBox();
      this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
      this.propertyPakEntryOffsetLabel = new System.Windows.Forms.Label();
      this.propertyPakEntryOffsetCaptionLabel = new System.Windows.Forms.Label();
      this.propertyFileInformationLabel = new System.Windows.Forms.Label();
      this.propertyFileInformationCaptionLabel = new System.Windows.Forms.Label();
      this.propertyPakEntryIndexLabel = new System.Windows.Forms.Label();
      this.propertyPakEntryIndexCaptionLabel = new System.Windows.Forms.Label();
      this.propertyFileSizeLabel = new System.Windows.Forms.Label();
      this.propertyFileSizeCaptionLabel = new System.Windows.Forms.Label();
      this.propertyFileNameCaptionLabel = new System.Windows.Forms.Label();
      this.propertyFileNameTextBox = new System.Windows.Forms.TextBox();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStripSeparatorFile = new System.Windows.Forms.ToolStripSeparator();
      this.menuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolBarButtonFileOpen = new System.Windows.Forms.ToolStripButton();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.pakFileTreeView = new QuakeViewer.PakFileTreeView();
      this.binViewTextBox = new QuakeViewer.BinViewTextBox();
      this.toolStripContainer.ContentPanel.SuspendLayout();
      this.toolStripContainer.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer.SuspendLayout();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.viewtabControl.SuspendLayout();
      this.binViewTabPage.SuspendLayout();
      this.previewTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
      this.propertiesGroupBox.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.Location = new System.Drawing.Point(0, 500);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(889, 22);
      this.statusStrip.TabIndex = 0;
      this.statusStrip.Text = "statusStrip1";
      // 
      // toolStripContainer
      // 
      // 
      // toolStripContainer.ContentPanel
      // 
      this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
      this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(889, 451);
      this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
      this.toolStripContainer.Name = "toolStripContainer";
      this.toolStripContainer.Size = new System.Drawing.Size(889, 500);
      this.toolStripContainer.TabIndex = 1;
      this.toolStripContainer.Text = "toolStripContainer1";
      // 
      // toolStripContainer.TopToolStripPanel
      // 
      this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
      this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.pakFileTreeView);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.viewtabControl);
      this.splitContainer.Panel2.Controls.Add(this.propertiesGroupBox);
      this.splitContainer.Size = new System.Drawing.Size(889, 451);
      this.splitContainer.SplitterDistance = 215;
      this.splitContainer.TabIndex = 0;
      // 
      // pakEntryIcons
      // 
      this.pakEntryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pakEntryIcons.ImageStream")));
      this.pakEntryIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.pakEntryIcons.Images.SetKeyName(0, "Empty.png");
      this.pakEntryIcons.Images.SetKeyName(1, "FolderClosed.png");
      this.pakEntryIcons.Images.SetKeyName(2, "FolderOpened.png");
      // 
      // viewtabControl
      // 
      this.viewtabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.viewtabControl.Controls.Add(this.binViewTabPage);
      this.viewtabControl.Controls.Add(this.previewTabPage);
      this.viewtabControl.Location = new System.Drawing.Point(5, 113);
      this.viewtabControl.Name = "viewtabControl";
      this.viewtabControl.SelectedIndex = 0;
      this.viewtabControl.Size = new System.Drawing.Size(657, 335);
      this.viewtabControl.TabIndex = 1;
      // 
      // binViewTabPage
      // 
      this.binViewTabPage.Controls.Add(this.binViewTextBox);
      this.binViewTabPage.Location = new System.Drawing.Point(4, 22);
      this.binViewTabPage.Name = "binViewTabPage";
      this.binViewTabPage.Padding = new System.Windows.Forms.Padding(2, 4, 4, 4);
      this.binViewTabPage.Size = new System.Drawing.Size(649, 309);
      this.binViewTabPage.TabIndex = 0;
      this.binViewTabPage.Text = "Binäransicht";
      this.binViewTabPage.UseVisualStyleBackColor = true;
      // 
      // previewTabPage
      // 
      this.previewTabPage.Controls.Add(this.previewPictureBox);
      this.previewTabPage.Location = new System.Drawing.Point(4, 22);
      this.previewTabPage.Name = "previewTabPage";
      this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.previewTabPage.Size = new System.Drawing.Size(649, 309);
      this.previewTabPage.TabIndex = 1;
      this.previewTabPage.Text = "Vorschau";
      this.previewTabPage.UseVisualStyleBackColor = true;
      // 
      // previewPictureBox
      // 
      this.previewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewPictureBox.Location = new System.Drawing.Point(3, 3);
      this.previewPictureBox.Name = "previewPictureBox";
      this.previewPictureBox.Size = new System.Drawing.Size(643, 303);
      this.previewPictureBox.TabIndex = 0;
      this.previewPictureBox.TabStop = false;
      // 
      // propertiesGroupBox
      // 
      this.propertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.propertiesGroupBox.Controls.Add(this.propertyPakEntryOffsetLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyPakEntryOffsetCaptionLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileInformationLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileInformationCaptionLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyPakEntryIndexLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyPakEntryIndexCaptionLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileSizeLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileSizeCaptionLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileNameCaptionLabel);
      this.propertiesGroupBox.Controls.Add(this.propertyFileNameTextBox);
      this.propertiesGroupBox.Location = new System.Drawing.Point(5, 3);
      this.propertiesGroupBox.Name = "propertiesGroupBox";
      this.propertiesGroupBox.Size = new System.Drawing.Size(655, 104);
      this.propertiesGroupBox.TabIndex = 0;
      this.propertiesGroupBox.TabStop = false;
      this.propertiesGroupBox.Text = "Eigenschaften";
      // 
      // propertyPakEntryOffsetLabel
      // 
      this.propertyPakEntryOffsetLabel.AutoSize = true;
      this.propertyPakEntryOffsetLabel.Location = new System.Drawing.Point(200, 61);
      this.propertyPakEntryOffsetLabel.Name = "propertyPakEntryOffsetLabel";
      this.propertyPakEntryOffsetLabel.Size = new System.Drawing.Size(33, 13);
      this.propertyPakEntryOffsetLabel.TabIndex = 9;
      this.propertyPakEntryOffsetLabel.Text = "Label";
      this.propertyPakEntryOffsetLabel.Visible = false;
      // 
      // propertyPakEntryOffsetCaptionLabel
      // 
      this.propertyPakEntryOffsetCaptionLabel.AutoSize = true;
      this.propertyPakEntryOffsetCaptionLabel.Location = new System.Drawing.Point(166, 61);
      this.propertyPakEntryOffsetCaptionLabel.Name = "propertyPakEntryOffsetCaptionLabel";
      this.propertyPakEntryOffsetCaptionLabel.Size = new System.Drawing.Size(38, 13);
      this.propertyPakEntryOffsetCaptionLabel.TabIndex = 8;
      this.propertyPakEntryOffsetCaptionLabel.Text = "Offset:";
      // 
      // propertyFileInformationLabel
      // 
      this.propertyFileInformationLabel.AutoSize = true;
      this.propertyFileInformationLabel.Location = new System.Drawing.Point(111, 82);
      this.propertyFileInformationLabel.Name = "propertyFileInformationLabel";
      this.propertyFileInformationLabel.Size = new System.Drawing.Size(33, 13);
      this.propertyFileInformationLabel.TabIndex = 7;
      this.propertyFileInformationLabel.Text = "Label";
      this.propertyFileInformationLabel.Visible = false;
      // 
      // propertyFileInformationCaptionLabel
      // 
      this.propertyFileInformationCaptionLabel.AutoSize = true;
      this.propertyFileInformationCaptionLabel.Location = new System.Drawing.Point(6, 82);
      this.propertyFileInformationCaptionLabel.Name = "propertyFileInformationCaptionLabel";
      this.propertyFileInformationCaptionLabel.Size = new System.Drawing.Size(98, 13);
      this.propertyFileInformationCaptionLabel.TabIndex = 6;
      this.propertyFileInformationCaptionLabel.Text = "Dateiinformationen:";
      // 
      // propertyPakEntryIndexLabel
      // 
      this.propertyPakEntryIndexLabel.AutoSize = true;
      this.propertyPakEntryIndexLabel.Location = new System.Drawing.Point(111, 61);
      this.propertyPakEntryIndexLabel.Name = "propertyPakEntryIndexLabel";
      this.propertyPakEntryIndexLabel.Size = new System.Drawing.Size(33, 13);
      this.propertyPakEntryIndexLabel.TabIndex = 5;
      this.propertyPakEntryIndexLabel.Text = "Label";
      this.propertyPakEntryIndexLabel.Visible = false;
      // 
      // propertyPakEntryIndexCaptionLabel
      // 
      this.propertyPakEntryIndexCaptionLabel.AutoSize = true;
      this.propertyPakEntryIndexCaptionLabel.Location = new System.Drawing.Point(6, 61);
      this.propertyPakEntryIndexCaptionLabel.Name = "propertyPakEntryIndexCaptionLabel";
      this.propertyPakEntryIndexCaptionLabel.Size = new System.Drawing.Size(99, 13);
      this.propertyPakEntryIndexCaptionLabel.TabIndex = 4;
      this.propertyPakEntryIndexCaptionLabel.Text = "Pak-Eintrags-Index:";
      // 
      // propertyFileSizeLabel
      // 
      this.propertyFileSizeLabel.AutoSize = true;
      this.propertyFileSizeLabel.Location = new System.Drawing.Point(111, 40);
      this.propertyFileSizeLabel.Name = "propertyFileSizeLabel";
      this.propertyFileSizeLabel.Size = new System.Drawing.Size(33, 13);
      this.propertyFileSizeLabel.TabIndex = 3;
      this.propertyFileSizeLabel.Text = "Label";
      this.propertyFileSizeLabel.Visible = false;
      // 
      // propertyFileSizeCaptionLabel
      // 
      this.propertyFileSizeCaptionLabel.AutoSize = true;
      this.propertyFileSizeCaptionLabel.Location = new System.Drawing.Point(6, 40);
      this.propertyFileSizeCaptionLabel.Name = "propertyFileSizeCaptionLabel";
      this.propertyFileSizeCaptionLabel.Size = new System.Drawing.Size(62, 13);
      this.propertyFileSizeCaptionLabel.TabIndex = 2;
      this.propertyFileSizeCaptionLabel.Text = "Dateigröße:";
      // 
      // propertyFileNameCaptionLabel
      // 
      this.propertyFileNameCaptionLabel.AutoSize = true;
      this.propertyFileNameCaptionLabel.Location = new System.Drawing.Point(6, 16);
      this.propertyFileNameCaptionLabel.Name = "propertyFileNameCaptionLabel";
      this.propertyFileNameCaptionLabel.Size = new System.Drawing.Size(61, 13);
      this.propertyFileNameCaptionLabel.TabIndex = 1;
      this.propertyFileNameCaptionLabel.Text = "Dateiname:";
      // 
      // propertyFileNameTextBox
      // 
      this.propertyFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.propertyFileNameTextBox.Location = new System.Drawing.Point(114, 13);
      this.propertyFileNameTextBox.Name = "propertyFileNameTextBox";
      this.propertyFileNameTextBox.ReadOnly = true;
      this.propertyFileNameTextBox.Size = new System.Drawing.Size(531, 20);
      this.propertyFileNameTextBox.TabIndex = 0;
      // 
      // menuStrip
      // 
      this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(889, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      // 
      // menuItemFile
      // 
      this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFileOpen,
            this.menuStripSeparatorFile,
            this.menuItemFileExit});
      this.menuItemFile.Name = "menuItemFile";
      this.menuItemFile.Size = new System.Drawing.Size(44, 20);
      this.menuItemFile.Text = "&Datei";
      // 
      // menuItemFileOpen
      // 
      this.menuItemFileOpen.Name = "menuItemFileOpen";
      this.menuItemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.menuItemFileOpen.Size = new System.Drawing.Size(212, 22);
      this.menuItemFileOpen.Text = "Pak-File &öffnen...";
      this.menuItemFileOpen.Click += new System.EventHandler(this.menuItemFileOpen_Click);
      // 
      // menuStripSeparatorFile
      // 
      this.menuStripSeparatorFile.Name = "menuStripSeparatorFile";
      this.menuStripSeparatorFile.Size = new System.Drawing.Size(209, 6);
      // 
      // menuItemFileExit
      // 
      this.menuItemFileExit.Name = "menuItemFileExit";
      this.menuItemFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.menuItemFileExit.Size = new System.Drawing.Size(212, 22);
      this.menuItemFileExit.Text = "&Beenden";
      this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarButtonFileOpen});
      this.toolStrip.Location = new System.Drawing.Point(3, 24);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(138, 25);
      this.toolStrip.TabIndex = 1;
      // 
      // toolBarButtonFileOpen
      // 
      this.toolBarButtonFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolBarButtonFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButtonFileOpen.Image")));
      this.toolBarButtonFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolBarButtonFileOpen.Name = "toolBarButtonFileOpen";
      this.toolBarButtonFileOpen.Size = new System.Drawing.Size(95, 22);
      this.toolBarButtonFileOpen.Text = "Pak-File öffnen...";
      this.toolBarButtonFileOpen.Click += new System.EventHandler(this.toolBarButtonFileOpen_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "C:\\Quake_SW\\ID1\\Pak0.pak";
      this.openFileDialog.Filter = "Quake-PAK-Datei|*.pak";
      // 
      // pakFileTreeView
      // 
      this.pakFileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pakFileTreeView.HideSelection = false;
      this.pakFileTreeView.ImageIndex = 0;
      this.pakFileTreeView.ImageList = this.pakEntryIcons;
      this.pakFileTreeView.Location = new System.Drawing.Point(0, 0);
      this.pakFileTreeView.Name = "pakFileTreeView";
      this.pakFileTreeView.SelectedImageIndex = 0;
      this.pakFileTreeView.ShowRootLines = false;
      this.pakFileTreeView.Size = new System.Drawing.Size(215, 451);
      this.pakFileTreeView.Sorted = true;
      this.pakFileTreeView.TabIndex = 0;
      this.pakFileTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pakFileTreeView_AfterSelect);
      // 
      // binViewTextBox
      // 
      this.binViewTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.binViewTextBox.BinaryReader = null;
      this.binViewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.binViewTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.binViewTextBox.Location = new System.Drawing.Point(2, 4);
      this.binViewTextBox.Multiline = true;
      this.binViewTextBox.Name = "binViewTextBox";
      this.binViewTextBox.ReadOnly = true;
      this.binViewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.binViewTextBox.Size = new System.Drawing.Size(643, 301);
      this.binViewTextBox.TabIndex = 0;
      this.binViewTextBox.Text = "00000000: ";
      // 
      // QuakeViewerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(889, 522);
      this.Controls.Add(this.toolStripContainer);
      this.Controls.Add(this.statusStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "QuakeViewerForm";
      this.Text = "Evo-XNA Quake-Viewer";
      this.toolStripContainer.ContentPanel.ResumeLayout(false);
      this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer.TopToolStripPanel.PerformLayout();
      this.toolStripContainer.ResumeLayout(false);
      this.toolStripContainer.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.viewtabControl.ResumeLayout(false);
      this.binViewTabPage.ResumeLayout(false);
      this.binViewTabPage.PerformLayout();
      this.previewTabPage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
      this.propertiesGroupBox.ResumeLayout(false);
      this.propertiesGroupBox.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripContainer toolStripContainer;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuItemFile;
    private System.Windows.Forms.ToolStripMenuItem menuItemFileExit;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton toolBarButtonFileOpen;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ToolStripSeparator menuStripSeparatorFile;
    private System.Windows.Forms.ToolStripMenuItem menuItemFileOpen;
    private PakFileTreeView pakFileTreeView;
    private System.Windows.Forms.ImageList pakEntryIcons;
    private System.Windows.Forms.GroupBox propertiesGroupBox;
    private System.Windows.Forms.TextBox propertyFileNameTextBox;
    private System.Windows.Forms.Label propertyFileNameCaptionLabel;
    private System.Windows.Forms.Label propertyPakEntryIndexLabel;
    private System.Windows.Forms.Label propertyPakEntryIndexCaptionLabel;
    private System.Windows.Forms.Label propertyFileSizeLabel;
    private System.Windows.Forms.Label propertyFileSizeCaptionLabel;
    private System.Windows.Forms.Label propertyFileInformationLabel;
    private System.Windows.Forms.Label propertyFileInformationCaptionLabel;
    private System.Windows.Forms.TabControl viewtabControl;
    private System.Windows.Forms.TabPage binViewTabPage;
    private System.Windows.Forms.TabPage previewTabPage;
    private BinViewTextBox binViewTextBox;
    private System.Windows.Forms.Label propertyPakEntryOffsetLabel;
    private System.Windows.Forms.Label propertyPakEntryOffsetCaptionLabel;
    private System.Windows.Forms.PictureBox previewPictureBox;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
  }
}