using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware {
  class BspEntry {
    private uint bspFileOffset;
    public uint BspFileOffset { get { return this.bspFileOffset; } }
    private uint contentSize;

    public BspEntry(BspEntry source) {
      this.bspFileOffset = source.bspFileOffset;
      this.contentSize = source.contentSize;
    }

    public BspEntry(PakStreamReader pakReader) {
      this.bspFileOffset = pakReader.ReadUInt32();
      this.contentSize = pakReader.ReadUInt32();
    }
  }
}
