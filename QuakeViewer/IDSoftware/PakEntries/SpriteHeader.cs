using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  /// typedef struct
  /// { char name[4];                // "IDSP"
  ///   long ver1;                   // Version = 1
  ///   long type;                   // See below
  ///   float radius;                // Bounding Radius
  ///   long maxwidth;               // Width of the largest frame
  ///   long maxheight;              // Height of the largest frame
  ///   long nframes;                // Number of frames
  ///   float beamlength;            // 
  ///   long synchtype;              // 0=synchron 1=random
  /// } spr_t;
  /// </summary>
  public class SpriteHeader : PakEntry {
    public const uint PakEntrySize = 0x0024;

    private string identifier;
    private uint version;
    private uint type;
    private float radius;
    private uint maxWidth;
    private uint maxHeight;
    private uint numFrames;
    public uint NumFrames { get { return this.numFrames; } }
    private float beamLength;
    private uint syncType;
    private SpriteFrame[] spriteFrame;
    public SpriteFrame[] SpriteFrame { get { return this.spriteFrame; } }


    public SpriteHeader(PakStreamReader pakReader, string contentName)
      : this(pakReader, pakReader.GetPakEntry(contentName)) { }

    public SpriteHeader(PakStreamReader pakReader, PakEntry pakEntry)
      : base(pakEntry) {
      pakReader.Position = this.PakFileOffset;
      this.identifier = pakReader.ReadString(4);
      this.version = pakReader.ReadUInt32();
      this.type = pakReader.ReadUInt32();
      this.radius = pakReader.ReadFloat();
      this.maxWidth = pakReader.ReadUInt32();
      this.maxHeight = pakReader.ReadUInt32();
      this.numFrames = pakReader.ReadUInt32();
      this.beamLength = pakReader.ReadFloat();
      this.syncType = pakReader.ReadUInt32();
      this.spriteFrame = new SpriteFrame[this.numFrames];
      for (uint i = 0; i < this.numFrames; i++)
        this.spriteFrame[i] = new SpriteFrame(pakReader, this);
    }
  }
}
