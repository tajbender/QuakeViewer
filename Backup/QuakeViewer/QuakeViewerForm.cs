using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IDSoftware;
using IDSoftware.PakEntries;

namespace QuakeViewer {
  public partial class QuakeViewerForm : Form {
    private PakStreamReader pakStream = null;

    public QuakeViewerForm() {
      this.InitializeComponent();
      this.OpenPakFile(@"C:\Quake_SW\ID1\Pak0.pak");
    }

    private void OpenPakFile(string fileName) {
      this.pakFileTreeView.BeginUpdate();
      this.pakFileTreeView.Clear();

      try {
        // Evtl. geladenes Pak-File schliessen und angegebenes Pak-File laden
        this.ClosePakFile();
        this.pakStream = new PakStreamReader(fileName);
        this.pakFileTreeView.SetPakFileName(fileName);

        // Nun für jeden einzelnen PakEntry einen eigenen Node im TreeView anlegen
        foreach (PakEntry pe in this.pakStream.PakEntries)
          this.pakFileTreeView.AddPakEntry(pe);
      }
      finally {
        this.pakFileTreeView.Sort();
        this.pakFileTreeView.EndUpdate();
      }

      this.pakFileTreeView.Nodes[0].Expand();
      this.pakFileTreeView.SelectedNode = this.pakFileTreeView.Nodes[0];
    }

    private void ClosePakFile() {
      if (this.pakStream != null)
        this.pakStream.Dispose();
      this.pakFileTreeView.Clear();
    }

    private void menuItemFileExit_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void toolBarButtonFileOpen_Click(object sender, EventArgs e) {
      menuItemFileOpen_Click(sender, e);
    }

    private void menuItemFileOpen_Click(object sender, EventArgs e) {
      if (this.openFileDialog.ShowDialog() == DialogResult.OK)
        this.OpenPakFile(this.openFileDialog.FileName);
    }

    private void pakFileTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
      PakEntry pakEntry = e.Node.Tag as PakEntry;
      string fileName = null;
      uint? fileSize = null;
      uint? pakEntryIndex = null;
      uint? pakEntryOffset = null;
      string fileInformation = null;
      Bitmap previewBitmap = null;

      if (pakEntry == null) {
        // Werte setzen, falls der gewählte Node der Pak-File-Node selbst ist
        if (e.Node.Equals(this.pakFileTreeView.Nodes[0])) {
          fileName = this.pakStream.FileName;
          fileSize = (uint)this.pakStream.BinaryReader.BaseStream.Length;
          fileInformation = "Quake I Pak-File, Shareware-Version (" +
            this.pakStream.PakEntries.Length.ToString() + " Verzeichniseinträge)";

          this.binViewTextBox.BinaryReader = this.pakStream.BinaryReader;
        } // Werte setzen, falls Node ein Directory-Node
        else {
          fileName = e.Node.FullPath;
          fileInformation = ((e.Node.Nodes.Count == 1) ?
            "1 Verzeichniseintrag" : e.Node.Nodes.Count.ToString() + " Verzeichniseinträge");

          this.binViewTextBox.Clear();
        }
      } // Werte für einen richtigen PakEntry setzen
      else {
        fileName = e.Node.FullPath;
        fileSize = pakEntry.ContentSize;
        pakEntryIndex = pakEntry.Index;
        pakEntryOffset = pakEntry.PakFileOffset;
        PakEntry.Type? type = pakEntry.TypeOf();
        if (type != null) {
          fileInformation = PakEntry.GetTypeDescription(type.Value);

          if ((type == PakEntry.Type.Lump) && (!pakEntry.IsPalette()) && (!pakEntry.IsColormap()))
            previewBitmap = new LumpPicture(this.pakStream, pakEntry).Bitmap;
          else if (type == PakEntry.Type.Model) {
            ModelHeader modelHeader = new ModelHeader(this.pakStream, pakEntry);
            previewBitmap = modelHeader.Skins[modelHeader.Skins.Length - 1].Bitmaps[0];

            if (modelHeader.Skins.Length > 1)
              fileInformation += " [" + modelHeader.Skins.Length.ToString() + " Skins]";
          }
          else if (type == PakEntry.Type.Sprite) {
            SpriteHeader spriteHeader = new SpriteHeader(this.pakStream, pakEntry);
            previewBitmap = spriteHeader.SpriteFrame[0].Bitmap[0];

            if (spriteHeader.SpriteFrame.Length > 1)
              fileInformation += " [" + spriteHeader.SpriteFrame.Length.ToString() + " Frames]";
          }
        }

        this.binViewTextBox.SetBinaryReaderScoped(this.pakStream.BinaryReader,
          pakEntry.PakFileOffset, pakEntry.ContentSize);
      }

      this.propertyFileNameTextBox.Text = fileName;

      if (fileSize != null) {
        this.propertyFileSizeLabel.Text = fileSize.ToString() + " Byte, " +
          ((float)fileSize / 1024).ToString("#,##0.00;") + " KByte, " +
          ((float)fileSize / (1024 * 1024)).ToString("#,##0.00;") + " MByte";
        this.propertyFileSizeLabel.Visible = true;
      }
      else
        this.propertyFileSizeLabel.Visible = false;

      if (pakEntryIndex != null) {
        this.propertyPakEntryIndexLabel.Text = pakEntryIndex.ToString();
        this.propertyPakEntryIndexLabel.Visible = true;
      }
      else
        this.propertyPakEntryIndexLabel.Visible = false;

      if (pakEntryOffset != null) {
        this.propertyPakEntryOffsetLabel.Text = pakEntryOffset.ToString();
        this.propertyPakEntryOffsetLabel.Visible = true;
      }
      else
        this.propertyPakEntryOffsetLabel.Visible = false;

      this.propertyFileInformationLabel.Text = fileInformation;
      this.propertyFileInformationLabel.Visible = true;

      if (previewBitmap != null) {
        this.viewtabControl.SelectedTab = this.previewTabPage;
        this.pakFileTreeView.Focus();
        this.previewPictureBox.Image = previewBitmap;
        this.previewPictureBox.Visible = true;
      }
      else {
        this.viewtabControl.SelectedTab = this.binViewTabPage;
        this.pakFileTreeView.Focus();
        this.previewPictureBox.Visible = false;
      }
    }
  }
}