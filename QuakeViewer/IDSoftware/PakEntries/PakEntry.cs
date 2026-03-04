using System;
using System.IO;

namespace IDSoftware.PakEntries {
  public class PakEntry {
    public const int SizeOf = 0x0040;
    public const int SizeOf_ContentNameChars = 0x0038;

    private uint index;
    public uint Index { get { return this.index; } }
    private string contentName;
    public string ContentName { get { return this.contentName; } }
    private uint pakFileOffset;
    public uint PakFileOffset { get { return this.pakFileOffset; } }
    protected uint contentSize;
    public uint ContentSize { get { return this.contentSize; } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source">Source PakEntry, to inherit member values from</param>
    public PakEntry(PakEntry source) {
      this.index = source.index;
      this.contentName = source.contentName;
      this.pakFileOffset = source.pakFileOffset;
      this.contentSize = source.contentSize;
    }

    /// <summary>
    /// 
    /// </summary>
    public PakEntry(PakStreamReader pakReader, uint index) {
      pakReader.Position = pakReader.PakHeader.GetDirectoryEntryOffset(index);
      this.contentName = pakReader.ReadString(SizeOf_ContentNameChars);
      this.pakFileOffset = pakReader.ReadUInt32();
      this.contentSize = pakReader.ReadUInt32();
      this.index = index;


      // Verify consistency of PAK Entry
      if ((this.pakFileOffset + this.contentSize) > pakReader.BinaryReader.BaseStream.Length)
        throw new PakFormatException(@"Invalid PakEntry - PAK entry reaches beyond PAK file size");
    }

    /// <summary>
    /// 
    /// </summary>
    public uint SaveContentToStream(PakStreamReader pakReader, BinaryWriter outputWriter) {
      pakReader.Position = this.pakFileOffset;

      for (uint i = 0; i < this.contentSize; i++)
        outputWriter.Write(pakReader.BinaryReader.ReadByte());

      return this.contentSize;
    }

    public bool IsPalette() {
      return (this.ContentName.Equals(@"gfx/palette.lmp"));
    }

    public bool IsColormap() {
      return (this.ContentName.Equals(@"gfx/colormap.lmp"));
    }

    public Type? TypeOf() {
      string ext = Path.GetExtension(this.contentName).ToUpper();
      for (Type i = Type.lowest; i <= Type.highest; i++)
        if (PakEntry.typeExtension[(int)i].Equals(ext))
          return i;
      return null;
    }


    #region PakEntry-Type Descriptions
    /// <summary>
    /// PakEntry.Type - Enumeration
    /// </summary>
    public enum Type : int {
      lowest = Sound, Sound = 0, Level, Model,
      Sprite, Pseudo, Resource, Config, Lump, Binary, WAD, highest = WAD
    }
    protected static string[] typeExtension = { ".WAV", ".BSP", ".MDL",
      ".SPR", ".DAT", ".RC", ".CFG", ".LMP", ".BIN", ".WAD" };
    protected static string[] typeDescription = { "Sound", "Level", "Model",
      "Sprite", "Pseudo", "Resource", "Config", "Lump", "Binary", "WAD" };

    /// <summary>
    /// 
    /// </summary>
    public static string GetTypeExtension(Type type) {
      if ((type >= Type.lowest) && (type <= Type.highest))
        return PakEntry.typeExtension[(int)type];
      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    public static string GetTypeDescription(Type type) {
      if ((type >= Type.lowest) && (type <= Type.highest))
        return PakEntry.typeDescription[(int)type];
      return null;
    }
    #endregion PakEntry-Type Descriptions
  }
}
