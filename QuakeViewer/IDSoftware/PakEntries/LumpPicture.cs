using System;
//using System.Collections.Generic;
using System.Drawing;
//using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  /// typedef struct
  /// { long width;
  ///   long height;
  ///   u_char Color[width*height];                                       
  /// } picture_t;
  /// </summary>
  class LumpPicture : PakEntry {
    private uint width;
    public uint Width { get { return this.width; } }
    private uint height;
    public uint Height { get { return this.height; } }
    private Bitmap bitmap = null;
    public Bitmap Bitmap { get { return this.bitmap; } }

    public LumpPicture(PakStreamReader pakReader, string contentName)
      : this(pakReader, pakReader.GetPakEntry(contentName)) { }

    public LumpPicture(PakStreamReader pakReader, PakEntry pakEntry)
      : base(pakEntry) {
      pakReader.Position = this.PakFileOffset;
      this.width = pakReader.ReadUInt32();
      this.height = pakReader.ReadUInt32();
      this.bitmap = pakReader.ReadBitmap(this.width, this.height);
    }
  }
}
