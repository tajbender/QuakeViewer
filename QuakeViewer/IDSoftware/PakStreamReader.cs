using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

using IDSoftware.PakEntries;

namespace IDSoftware {
  public class PakStreamReader : IDisposable {
    private string fileName = null;
    public string FileName { get { return this.fileName; } }
    private Stream inputStream = null;
    public Stream InputStream { get { return this.inputStream; } }
    private BinaryReader binaryReader = null;
    public BinaryReader BinaryReader { get { return this.binaryReader; } }
    private PakHeader pakHeader = null;
    public PakHeader PakHeader { get { return this.pakHeader; } }
    private PakEntry[] pakEntries = null;
    public PakEntry[] PakEntries { get { return this.pakEntries; } }
    private GamePalette gamePalette = null;
    public GamePalette GamePalette { get { return this.gamePalette; } }

    /// <summary>
    /// 
    /// </summary>
    public PakStreamReader(string fileName) {
      this.fileName = fileName;

      // Create input stream
      this.inputStream = new FileStream(fileName, FileMode.Open);
      this.binaryReader = new BinaryReader(this.inputStream);

      // Read out PAK Header
      this.pakHeader = new PakHeader(this, 0);

      // Read out PAK Directory Entries
      this.pakEntries = new PakEntry[this.pakHeader.directoryEntries];
      for (uint i = 0; i < this.pakHeader.directoryEntries; i++)
        this.pakEntries[i] = new PakEntry(this, i);

      this.gamePalette = new GamePalette(this);
    }

    /// <summary>
    /// 
    /// </summary>
    public PakEntry GetPakEntry(string contentName) {
      foreach (PakEntry pe in this.pakEntries)
        if (pe.ContentName.Equals(contentName))
          return pe;

      throw new ArgumentException("PakEntry with named content '" + contentName + "' not found!");
    }

    /// <summary>
    /// 
    /// </summary>
    public uint SavePakEntryContent(uint pakEntryIndex, string fileName) {
      return this.SavePakEntryContent(this.pakEntries[pakEntryIndex], fileName);
    }

    public uint SavePakEntryContent(string contentName, string fileName) {
      return this.SavePakEntryContent(this.GetPakEntry(contentName), fileName);
    }

    public uint SavePakEntryContent(PakEntry pakEntry, string fileName) {
      using (FileStream outputStream = new FileStream(fileName, FileMode.Create)) {
        using (BinaryWriter outputWriter = new BinaryWriter(outputStream)) {
          return pakEntry.SaveContentToStream(this, outputWriter);
        }
      }
    }

    public uint Position { set { this.BinaryReader.BaseStream.Position = value; } }
    public Vector3 ReadVector3() { return new Vector3(this); }
    public uint ReadUInt32() { return this.BinaryReader.ReadUInt32(); }
    public float ReadFloat() { return this.BinaryReader.ReadSingle(); }
    public byte ReadByte() { return this.BinaryReader.ReadByte(); }
    public string ReadString(int length) {
      StringBuilder sb = new StringBuilder();
      byte[] chars = this.binaryReader.ReadBytes(length);
      for (uint i = 0; i < length; i++)
        if (chars[i] == 0)
          break;
        else
          sb.Append((char)chars[i]);
      return sb.ToString();
    }

    public Bitmap ReadBitmap(uint width, uint height) { return this.ReadBitmap((int)width, (int)height); }
    public Bitmap ReadBitmap(int width, int height) {
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height),
        ImageLockMode.WriteOnly, bitmap.PixelFormat);

      try {
        byte[] paletteIndex = this.BinaryReader.ReadBytes(width * height);
        int[] rowData = new int[width];

        for (uint y = 0; y < (width * height); y += (uint)width) {
          for (uint x = 0; x < width; x++)
            rowData[x] = this.GamePalette.Color[paletteIndex[y + x]].ToArgb();

          Marshal.Copy(rowData, 0, new IntPtr(bmpData.Scan0.ToInt64() + (y * 4)), width);
        }
      }
      finally {
        bitmap.UnlockBits(bmpData);
      }

      return bitmap;
    }

    #region IDisposable Member

    public void Dispose() {
      if (this.binaryReader != null)
        this.binaryReader.Close();
      if (this.inputStream != null)
        this.inputStream.Dispose();
    }

    #endregion
  }
}
