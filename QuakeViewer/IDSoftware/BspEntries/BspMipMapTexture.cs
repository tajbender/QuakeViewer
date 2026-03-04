using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

using IDSoftware.PakEntries;

namespace IDSoftware {
  class BspMipMapTexture {
    private BspMipMapInfo mipMapInfo = null;
    private uint width;
    private uint height;
    private uint level;
    private byte[][] paletteIndices = null;

    public BspMipMapTexture(PakStreamReader pakReader, uint absoluteOffset, BspMipMapInfo mipMapInfo, uint level) {
      pakReader.Position = absoluteOffset;
      this.mipMapInfo = mipMapInfo;
      this.width = mipMapInfo.Width >> (int)level;
      this.height = mipMapInfo.Height >> (int)level;
      this.level = level;

      this.paletteIndices = new byte[this.height][];
      for (uint y = 0, cnty = this.height; y < cnty; y++)
        this.paletteIndices[y] = pakReader.BinaryReader.ReadBytes((int)this.width);
    }

    public Bitmap GetBitmap(GamePalette gamePalette) {
      Bitmap bmp = new Bitmap((int)this.width, (int)this.height);
      for (uint y = 0, cnty = this.height; y < cnty; y++) {
        for (uint x = 0, cntx = this.width; x < cntx; x++) {
          int idx = this.paletteIndices[y][x];
          bmp.SetPixel((int)x, (int)y, gamePalette.Color[idx]);
        }
      }

      return bmp;
    }
  }
}
