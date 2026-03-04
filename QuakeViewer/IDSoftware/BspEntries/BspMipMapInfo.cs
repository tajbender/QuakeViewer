using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware {
  class BspMipMapInfo {
    public const int SizeOf_Name = 0x0010;
    public const int Default_MipMapLevel = 4;

    private string name;
    public string Name { get { return this.name; } }
    private uint width;
    public uint Width { get { return this.width; } }
    private uint height;
    public uint Height { get { return this.height; } }

    private BspMipMapTexture[] mipMapTexture = null;
    public BspMipMapTexture[] MipMapTexture { get { return this.mipMapTexture; } }

    public BspMipMapInfo(PakStreamReader pakReader, uint absoluteOffset) {
      pakReader.Position = absoluteOffset;
      string nameChars = pakReader.ReadString(SizeOf_Name);
      this.name = nameChars.Substring(0, nameChars.IndexOf('\0'));
      this.width = pakReader.ReadUInt32();
      this.height = pakReader.ReadUInt32();

      uint[] relativeOffset = new uint[Default_MipMapLevel];
      for (uint i = 0, cnt = Default_MipMapLevel; i < cnt; i++)
        relativeOffset[i] = pakReader.ReadUInt32();

      this.mipMapTexture = new BspMipMapTexture[Default_MipMapLevel];
      for (uint i = 0, cnt = Default_MipMapLevel; i < cnt; i++)
        this.mipMapTexture[i] = new BspMipMapTexture(pakReader, absoluteOffset + relativeOffset[i], this, i);
    }
  }
}
