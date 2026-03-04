using System;
using System.Collections.Generic;
using System.Text;

using IDSoftware.PakEntries;

namespace IDSoftware {
  class BspMipMapHeader : BspEntry {
    private uint numberOfTextures;
    private BspMipMapInfo[] mipMapInfo = null;
    public BspMipMapInfo[] MipMapInfo { get { return this.mipMapInfo; } }

    public BspMipMapHeader(BspEntry bspEntry, PakStreamReader pakReader, BspHeader bspHeader)
      : base(bspEntry) {
      pakReader.Position = bspHeader.PakFileOffset + this.BspFileOffset;
      this.numberOfTextures = pakReader.ReadUInt32();

      // Read texture file offsets
      uint[] relativeOffset = new uint[this.numberOfTextures];
      for (uint i = 0, cnt = this.numberOfTextures; i < cnt; i++)
        relativeOffset[i] = pakReader.ReadUInt32();

      this.mipMapInfo = new BspMipMapInfo[this.numberOfTextures];
      for (uint i = 0, cnt = this.numberOfTextures; i < cnt; i++)
        this.mipMapInfo[i] = new BspMipMapInfo(pakReader, bspHeader.PakFileOffset + this.BspFileOffset + relativeOffset[i]);
    }
  }
}
