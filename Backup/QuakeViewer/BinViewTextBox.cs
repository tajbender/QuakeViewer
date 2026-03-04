using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuakeViewer {
  public partial class BinViewTextBox : TextBox {
    private BinaryReader binaryReader = null;
    public BinaryReader BinaryReader {
      get { return this.binaryReader; }
      set { this.SetBinaryReader(value); }
    }
    private long scopeOffset = 0;
    private long scopeLength = -1;

    public BinViewTextBox() {
      this.Multiline = true;
      this.ReadOnly = true;
      this.AcceptsTab = false;
      this.HideSelection = true;
      this.ScrollBars = ScrollBars.Vertical;
    }

    protected void SetBinaryReader(BinaryReader binaryReader) {
      this.binaryReader = binaryReader;
      this.scopeOffset = 0;
      this.scopeLength = 1024; //binaryReader.BaseStream.Length;

      this.RefreshView();
    }

    public void SetBinaryReaderScoped(BinaryReader binaryReader, long scopeOffset, long scopeLength) {
      this.binaryReader = binaryReader;
      this.scopeOffset = scopeOffset;
      this.scopeLength = ((scopeLength > 1024) ? 1024 : scopeLength);// scopeLength;

      this.RefreshView();
    }

    public new void Clear() {
      this.binaryReader = null;
      this.RefreshView();
    }

    protected void RefreshView() {
      string newText = "00000000: ";

      if (this.binaryReader != null) {
        this.binaryReader.BaseStream.Position = scopeOffset;
        byte[] data = binaryReader.ReadBytes((int)this.scopeLength);

        if (this.scopeLength > 0) {
          StringBuilder strb = new StringBuilder();
          StringBuilder text = new StringBuilder();

          for (uint y = 0; y < (uint)this.scopeLength; y += 16) {
            text.Length = 0;
            strb.AppendFormat("{0,0:X8}: ", y);

            for (uint x = 0; x < 16; x++) {
              if ((x + y) > ((uint)this.scopeLength - 1))
                strb.Append("   ");
              else {
                byte ch = data[x + y];
                strb.AppendFormat("{0,0:X2} ", ch);
                text.Append(((ch < 32) || (ch > 127)) ? '.' : (char)ch);
              }
            }
            strb.Append("  ");
            strb.Append(text.ToString());
            if (y < this.scopeLength - 16)
              strb.Append("\r\n");
          }

          newText = strb.ToString();
        }
      }

      this.Text = newText;
    }
  }
}
