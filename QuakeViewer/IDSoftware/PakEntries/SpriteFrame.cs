using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  ///   long group;                  // not zero (0x1 or 0x10000000)
  ///   long npics;                  // Number of pictures
  ///   float times[npics];          // 0.0, 0.2, 0.3, ...
  ///   picture pic[npics];          // Pictures
  /// </summary>
  public class SpriteFrame {
    private bool isGroup;
    public bool IsGroup { get { return this.isGroup; } }
    private uint numberOfPictures;
    public uint NumberOfPictures { get { return this.numberOfPictures; } }
    private float[] time = null;
    public float[] Time { get { return this.time; } }
    private uint[] offsetX = null;
    private uint[] offsetY = null;
    private Bitmap[] bitmap = null;
    public Bitmap[] Bitmap { get { return this.bitmap; } }

    public SpriteFrame(PakStreamReader pakReader, SpriteHeader spriteHeader) {
      pakReader.Position = spriteHeader.PakFileOffset + SpriteHeader.PakEntrySize;
      switch(pakReader.ReadUInt32()) {
        case 0:
          this.isGroup = false;
          this.numberOfPictures = 1;
          break;
        case 1:
        case 0x10000000:
          this.isGroup = true;
          this.numberOfPictures = pakReader.ReadUInt32();
          break;
        default:
          throw new PakFormatException(@"Invalid SpritePicture - Group value out of range");
      }
      this.time = new float[this.numberOfPictures];
      for (uint i = 0; i < this.numberOfPictures; i++)
        this.time[i] = (this.isGroup ? pakReader.ReadFloat() : 0.0f);
      this.offsetX = new uint[this.numberOfPictures];
      this.offsetY = new uint[this.numberOfPictures];
      this.bitmap = new Bitmap[this.numberOfPictures];
      for (uint i = 0; i < this.numberOfPictures; i++) {
        this.offsetX[i] = pakReader.ReadUInt32();
        this.offsetY[i] = pakReader.ReadUInt32();
        uint width = pakReader.ReadUInt32();
        uint height = pakReader.ReadUInt32();
        this.bitmap[i] = pakReader.ReadBitmap(width, height);
      }
    }
  }
}
