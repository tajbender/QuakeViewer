using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IDSoftware.PakEntries {
  public class GamePalette : PakEntry {
    public const uint PakEntrySize = GamePalette.Colors * 3;
    public const uint Colors = 256;

    private Color[] color = new Color[GamePalette.Colors];
    public Color[] Color { get { return this.color; } }

    public GamePalette(PakStreamReader pakReader)
      : this(pakReader, @"gfx/palette.lmp") { }

    public GamePalette(PakStreamReader pakReader, string contentName)
      : this(pakReader, pakReader.GetPakEntry(contentName)) { }

    public GamePalette(PakStreamReader pakReader, PakEntry pakEntry)
      : base(pakEntry) {
      pakReader.Position = this.PakFileOffset;

      if (this.contentSize != GamePalette.PakEntrySize)
        throw new PakFormatException(@"Invalid QuakeGamePalette - Size doesn't match " + GamePalette.PakEntrySize);

      byte[] rgb = pakReader.BinaryReader.ReadBytes((int)GamePalette.PakEntrySize);
      for (uint i = 0, rgbIdx = 0; i < GamePalette.Colors; i++) {
        // TODO: Einige Paletteneinträge sind transparent (IMHO die letzten Beiden)
        this.color[i] = System.Drawing.Color.FromArgb(255, rgb[rgbIdx++], rgb[rgbIdx++], rgb[rgbIdx++]);
      }
    }
  }
}
