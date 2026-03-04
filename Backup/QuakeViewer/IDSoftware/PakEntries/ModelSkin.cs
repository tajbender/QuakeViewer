using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  /// typedef struct
  /// { long   group;                // value = 0
  ///   u_char skin[skinwidth*skinheight]; // the skin picture
  /// } skin_t;
  /// If the skin is made of a group of pictures, the structure is: 
  /// typedef struct
  /// { long group;                  // value = 1
  ///   long nb;                     // number of pictures in group
  ///   float time[nb];              // time values, for each picture
  ///   u_char skin[nb][skinwidth*skinheight]; // the pictures 
  /// } skingroup_t;  
  /// </summary>
  public class ModelSkin {
    private bool isGroup;
    public bool IsGroup { get { return this.isGroup; } }
    private float[] time = null;
    public float[] Time { get { return this.time; } }
    private Bitmap[] bitmaps = null;
    public Bitmap[] Bitmaps { get { return this.bitmaps; } }

    public ModelSkin(PakStreamReader pakReader, ModelHeader modelHeader) {
      uint numberOfPictures;
      switch (pakReader.ReadUInt32()) {
        case 0:
          this.isGroup = false;
          numberOfPictures = 1;
          break;
        case 1:
          this.isGroup = true;
          numberOfPictures = pakReader.ReadUInt32();
          break;
        default:
          throw new PakFormatException(@"Invalid ModelSkin - Group value out of range");
      }

      this.time = new float[numberOfPictures];
      for (uint i = 0; i < numberOfPictures; i++)
        this.time[i] = (this.isGroup ? pakReader.ReadFloat() : 0.0f);
      this.bitmaps = new Bitmap[numberOfPictures];
      for (uint i = 0; i < numberOfPictures; i++)
        this.bitmaps[i] = pakReader.ReadBitmap(modelHeader.SkinWidth, modelHeader.SkinHeight);
    }
  }
}
