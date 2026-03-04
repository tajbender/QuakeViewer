using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using IDSoftware;
using IDSoftware.PakEntries;

namespace QuakeViewer {
  public partial class PakFileTreeView : TreeView {
    private Hashtable directoryNodeHash = new Hashtable();
    private string pakFileName;

    public PakFileTreeView() {
      this.TreeViewNodeSorter = new PakFileTreeViewNodeSorter();
    }

    public void Clear() {
      this.Nodes.Clear();
      this.directoryNodeHash.Clear();
    }

    public void SetPakFileName(string pakFileName) {
      this.pakFileName = pakFileName;
      this.Clear();

      TreeNode newNode = this.Nodes.Add("[" + pakFileName + "]");
    }

    public void AddPakEntry(PakEntry pakEntry) {
      if (this.Nodes.Count == 0)
        this.Nodes.Add("[Unbekanntes PakFile]");

      string nodeName = Path.GetFileName(pakEntry.ContentName);
      string pathName = Path.GetDirectoryName(pakEntry.ContentName);
      TreeNode parentNode = ((pathName.Length == 0) ?
        this.Nodes[0] : GetOrCreateDirectoryNode(pathName));
      TreeNode pakNode = parentNode.Nodes.Add(nodeName);
      pakNode.Tag = pakEntry;
    }

    protected TreeNode GetOrCreateDirectoryNode(string pathName) {
      TreeNode directoryNode = this.directoryNodeHash[pathName] as TreeNode;

      if (directoryNode == null) {
        TreeNode parentNode;
        int seperator = pathName.LastIndexOf('\\');
        string nodeName;

        if (seperator == -1) {
          nodeName = pathName;
          parentNode = this.Nodes[0];
        } else {
          nodeName = pathName.Substring(seperator + 1);
          parentNode = GetOrCreateDirectoryNode(pathName.Substring(0, seperator));
        }

        directoryNode = parentNode.Nodes.Add(nodeName);
        this.directoryNodeHash.Add(pathName, directoryNode);
        directoryNode.ImageIndex = 1;
        directoryNode.SelectedImageIndex = 2;
      }

      return directoryNode;
    }

    #region PakFileTreeViewNodeSorter - Klasse

    /// <summary>
    /// Subklasse zum sortieren der Nodes
    /// </summary>
    protected class PakFileTreeViewNodeSorter : IComparer {
      public int Compare(object x, object y) {
        TreeNode nodeX = x as TreeNode;
        TreeNode nodeY = y as TreeNode;
        bool hasChildsX = (nodeX.GetNodeCount(false) > 0);
        bool hasChildsY = (nodeY.GetNodeCount(false) > 0);

        if (hasChildsX != hasChildsY)
          return (hasChildsX ? -1 : 1);
        return string.Compare(nodeX.Text, nodeY.Text);
      }
    }

    #endregion PakFileTreeViewNodeSorter - Klasse
  }
}
