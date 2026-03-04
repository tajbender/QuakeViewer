using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware.PakEntries {
  /// <summary>
  /// typedef struct
  /// { u_char packedposition[3];    // X,Y,Z coordinate, packed on 0-255
  ///   u_char lightnormalindex;     // index of the vertex normal
  /// } trivertx_t;
  /// </summary>
  public struct TriVertex {
    public byte x;
    public byte y;
    public byte z;
    public byte NormalIndex;
    public TriVertex(PakStreamReader pakReader) {
      this.x = pakReader.ReadByte();
      this.y = pakReader.ReadByte();
      this.z = pakReader.ReadByte();
      this.NormalIndex = pakReader.ReadByte();
    }
  }

  /// <summary>
  /// typedef struct
  /// { trivertx_t min;              // minimum values of X,Y,Z
  ///   trivertx_t max;              // maximum values of X,Y,Z
  ///   char name[16];               // name of frame
  ///   trivertx_t frame[numverts];  // array of vertices
  /// } simpleframe_t;
  /// </summary>
  public struct SimpleFrame {
    public TriVertex min;
    public TriVertex max;
    string name;
    public TriVertex[] vertices;
    public SimpleFrame(PakStreamReader pakReader, uint verticesCount) {
      this.min = new TriVertex(pakReader);
      this.max = new TriVertex(pakReader);
      this.name = pakReader.ReadString(16);
      this.vertices = new TriVertex[verticesCount];
      for (uint i = 0; i < verticesCount; i++)
        this.vertices[i] = new TriVertex(pakReader);
    }
  }

  /// <summary>
  /// struct
  /// { long type;                   // Value != 0
  ///   trivertx_t min;              // min position in all simple frames
  ///   trivertx_t max;              // max position in all simple frames
  ///   float time[nb]               // time for each of the single frames
  ///   simpleframe_t frames[nb];    // a group of simple frames
  /// }
  /// </summary>
  public class ModelFrame {
    private bool isGroup;
    public bool IsGroup { get { return this.isGroup; } }
    private uint frameCount;
    public uint FrameCount { get { return this.frameCount; } }
    private TriVertex min;
    private TriVertex max;
    private float[] times;
    private SimpleFrame[] frames;

    public ModelFrame(PakStreamReader pakReader, ModelHeader modelHeader) {
      this.frameCount = pakReader.ReadUInt32();
      if (this.frameCount > 0) {
        this.isGroup = true;
        this.min = new TriVertex(pakReader);
        this.max = new TriVertex(pakReader);
      }
      else {
        this.isGroup = false;
        this.frameCount = 1;
      }

      this.times = new float[this.frameCount];
      for (uint i = 0; i < this.frameCount; i++)
        this.times[i] = (this.isGroup ? pakReader.ReadFloat() : 0.0f);

      this.frames = new SimpleFrame[this.frameCount];
      for (uint i = 0; i < this.frameCount; i++)
        this.frames[i] = new SimpleFrame(pakReader, modelHeader.NumVertices);

      if (!this.isGroup) {
        this.min = this.frames[0].min;
        this.max = this.frames[0].max;
      }
    }
  }
}
