using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  /// typedef struct
  /// { long onseam;                 // 0 or 0x20
  ///   long s;                      // position, horizontally
  ///                                //  in range [0,skinwidth[
  ///   long t;                      // position, vertically
  ///                                //  in range [0,skinheight[
  /// } stvert_t;
  /// </summary>
  public struct ModelSkinVertex {
    private bool isOnSeam;
    public bool IsOnSeam { get { return this.isOnSeam; } }
    private uint s;
    private uint t;
    public ModelSkinVertex(PakStreamReader pakReader) {
      switch (pakReader.ReadUInt32()) {
        case 0:
          this.isOnSeam = false;
          break;
        case 0x20:
          this.isOnSeam = true;
          break;
        default:
          throw new PakFormatException(@"Invalid ModelSkinVertex - OnSeam value out of range");
      }
      this.s = pakReader.ReadUInt32();
      this.t = pakReader.ReadUInt32();
    }
  }

  /// <summary>
  /// typedef struct
  /// { long facesfront;             // boolean
  ///   long vertices[3];            // Index of 3 triangle vertices
  ///                                // in range [0,numverts[
  /// } itriangle_t;
  /// </summary>
  public struct ModelTriangle {
    private bool facesFront;
    public bool FacesFront { get { return this.facesFront; } }
    private uint[] vertices;
    public ModelTriangle(PakStreamReader pakReader, uint numVertices) {
      switch (pakReader.ReadUInt32()) {
        case 0:
          this.facesFront = false;
          break;
        case 1:
          this.facesFront = true;
          break;
        default:
          throw new PakFormatException(@"Invalid ModelTriangle - FacesFront value out of range");
      }
      this.vertices = new uint[3];
      for (uint i = 0; i < 3; i++) {
        this.vertices[i] = pakReader.ReadUInt32();
        if(numVertices <= this.vertices[i])
          throw new PakFormatException(@"Invalid ModelTriangle - vertices value out of range");
      }
    }
  }

  /// <summary>
  ///typedef struct
  ///{ long id;                     // 0x4F504449 = "IDPO" for IDPOLYGON
  ///  long version;                // Version = 6
  ///  vec3_t scale;                // Model scale factors.
  ///  vec3_t origin;               // Model origin.
  ///  scalar_t radius;             // Model bounding radius.
  ///  vec3_t offsets;              // Eye position (useless?)
  ///  long numskins ;              // the number of skin textures
  ///  long skinwidth;              // Width of skin texture
  ///                               //           must be multiple of 8
  ///  long skinheight;             // Height of skin texture
  ///                               //           must be multiple of 8
  ///  long numverts;               // Number of vertices
  ///  long numtris;                // Number of triangles surfaces
  ///  long numframes;              // Number of frames
  ///  long synctype;               // 0= synchron, 1= random
  ///  long flags;                  // 0 (see Alias models)
  ///  scalar_t size;               // average size of triangles
  ///} mdl_t;
  /// </summary>
  public class ModelHeader : PakEntry {
    public const uint PakEntrySize = 0x0054;
    public const int Version_Quake1_SW = 6;

    private string identifier;
    private uint version;
    private Vector3 scale;
    private Vector3 origin;
    private float radius;
    private Vector3 offsets;
    private uint numSkins;
    private uint skinWidth;
    public uint SkinWidth { get { return this.skinWidth; } }
    private uint skinHeight;
    public uint SkinHeight { get { return this.skinHeight; } }
    private uint numVertices;
    public uint NumVertices { get { return this.numVertices; } }
    private uint numTriangles;
    private uint numFrames;
    private uint syncType;
    private uint flags;
    private float size;
    private ModelSkin[] skins;
    public ModelSkin[] Skins { get { return this.skins; } }
    private ModelSkinVertex[] modelSkinVertices;
    public ModelSkinVertex[] ModelSkinVertices { get { return this.modelSkinVertices; } }
    private ModelTriangle[] modelTriangles;
    public ModelTriangle[] ModelTriangles { get { return this.modelTriangles; } }
    private ModelFrame[] modelFrames;
    public ModelFrame[] ModelFrames { get { return this.modelFrames; } }


    public ModelHeader(PakStreamReader pakReader, string contentName)
      : this(pakReader, pakReader.GetPakEntry(contentName)) { }

    public ModelHeader(PakStreamReader pakReader, PakEntry pakEntry)
      : base(pakEntry) {
      pakReader.Position = this.PakFileOffset;
      this.identifier = pakReader.ReadString(4);
      this.version = pakReader.ReadUInt32();
      this.scale = pakReader.ReadVector3();
      this.origin = pakReader.ReadVector3();
      this.radius = pakReader.ReadFloat();
      this.offsets = pakReader.ReadVector3();
      this.numSkins = pakReader.ReadUInt32();
      this.skinWidth = pakReader.ReadUInt32();
      this.skinHeight = pakReader.ReadUInt32();
      this.numVertices = pakReader.ReadUInt32();
      this.numTriangles = pakReader.ReadUInt32();
      this.numFrames = pakReader.ReadUInt32();
      this.syncType = pakReader.ReadUInt32();
      this.flags = pakReader.ReadUInt32();
      this.size = pakReader.ReadFloat();

      // Read out ModelSkin objects
      this.skins = new ModelSkin[this.numSkins];
      for (uint i = 0; i < this.numSkins; i++)
        this.skins[i] = new ModelSkin(pakReader, this);
      // Read out ModelSkinVertex objects
      this.modelSkinVertices = new ModelSkinVertex[this.numVertices];
      for (uint i = 0; i < this.numVertices; i++)
        this.modelSkinVertices[i] = new ModelSkinVertex(pakReader);
      // Read out ModelTriangle objects
      this.modelTriangles = new ModelTriangle[this.numTriangles];
      for (uint i = 0; i < this.numTriangles; i++)
        this.modelTriangles[i] = new ModelTriangle(pakReader, this.numVertices);
      // Read out ModelFrame objects
      this.modelFrames = new ModelFrame[this.numFrames];
      for (uint i = 0; i < this.numFrames; i++)
        this.modelFrames[i] = new ModelFrame(pakReader, this);

      // Verify consistency of PAK Header
      if (!this.identifier.Equals(@"IDPO"))
        throw new PakFormatException(@"Invalid Alias Model - Identifier mismatch");
      if (this.version != ModelHeader.Version_Quake1_SW)
        throw new PakFormatException(@"Invalid Alias Model - Version mismatch");
    }
  }
}
