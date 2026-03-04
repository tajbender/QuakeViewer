using System;

namespace IDSoftware.PakEntries {
  class BspHeader : PakEntry {
//    public new const int SizeOf = 0x0004;
    public const int Version_Quake1_SW = 29;

    private uint version;
    public uint Version { get { return this.version; } }
    private BspMipMapHeader mipHeader = null;
    public BspMipMapHeader MipHeader { get { return this.mipHeader; } }
    //private BspEntry Entities;
    //private BspEntry Planes;
    //private BspEntry MipHeader;
    //private BspEntry Vertices;
    //private BspEntry VisiList;
    //private BspEntry Nodes;
    //private BspEntry Surfaces;
    //private BspEntry Faces;
    //private BspEntry LightMaps;
    //private BspEntry ClipNodes;
    //private BspEntry Leaves;
    //private BspEntry LFace;
    //private BspEntry Edges;
    //private BspEntry LEdges;
    //private BspEntry Models;

    /// <summary>
    /// 
    /// </summary>
    public BspHeader(PakStreamReader pakReader, string contentName)
      : this(pakReader, pakReader.GetPakEntry(contentName)) { }

    /// <summary>
    /// 
    /// </summary>
    public BspHeader(PakStreamReader pakReader, PakEntry pakEntry)
      : base(pakEntry) {
      pakReader.Position = this.PakFileOffset;
      this.version = pakReader.ReadUInt32();
      BspEntry Entities = new BspEntry(pakReader);
      BspEntry Planes = new BspEntry(pakReader);
      BspEntry MipHeader = new BspEntry(pakReader);
      BspEntry Vertices = new BspEntry(pakReader);
      BspEntry VisiList = new BspEntry(pakReader);
      BspEntry Nodes = new BspEntry(pakReader);
      BspEntry Surfaces = new BspEntry(pakReader);
      BspEntry Faces = new BspEntry(pakReader);
      BspEntry LightMaps = new BspEntry(pakReader);
      BspEntry ClipNodes = new BspEntry(pakReader);
      BspEntry Leaves = new BspEntry(pakReader);
      BspEntry LFace = new BspEntry(pakReader);
      BspEntry Edges = new BspEntry(pakReader);
      BspEntry LEdges = new BspEntry(pakReader);
      BspEntry Models = new BspEntry(pakReader);

      // Verify consistency of PAK Entry
      if (!(this.version == BspHeader.Version_Quake1_SW))
        throw new BspFormatException(@"Invalid BSP version - currently only Quake 1 Shareware supported!");

      this.mipHeader = new BspMipMapHeader(MipHeader, pakReader, this);
    }
  }
}
