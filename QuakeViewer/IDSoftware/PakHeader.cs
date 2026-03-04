using System;
using System.IO;

using IDSoftware.PakEntries;

namespace IDSoftware {
  public class PakHeader {
    public string identifier;
    public uint directoryOffset;
    public uint directorySize;
    public uint directoryEntries;

    /// <summary>
    /// 
    /// </summary>
    public PakHeader(PakStreamReader pakReader, uint offset) {
      pakReader.Position = offset;
      this.identifier = pakReader.ReadString(4);
      this.directoryOffset = pakReader.ReadUInt32();
      this.directorySize = pakReader.ReadUInt32();
      this.directoryEntries = this.directorySize / PakEntry.SizeOf;

      // Verify consistency of PAK Header
      if (!this.identifier.Equals(@"PACK"))
        throw new PakFormatException(@"Invalid PakHeader - Identifier mismatch");
      if ((this.directoryOffset + this.directorySize) > pakReader.BinaryReader.BaseStream.Length)
        throw new PakFormatException(@"Invalid PakHeader - Directory reaches beyond PAK file size");
      if ((this.directorySize % PakEntry.SizeOf) != 0)
        throw new PakFormatException(@"Invalid PakHeader - Directory doesn't match PakEntry size");
    }

    /// <summary>
    /// 
    /// </summary>
    public uint GetDirectoryEntryOffset(uint i) {
      return (this.directoryOffset + (i * PakEntry.SizeOf));
    }
  }
}
