using System;
using System.Collections.Generic;
using System.Text;

namespace IDSoftware {
  /// <summary>
  /// vec3_t
  /// </summary>
  public struct Vector3 {
    public float x;
    public float y;
    public float z;

    public Vector3(PakStreamReader pakReader) {
      this.x = pakReader.ReadFloat();
      this.y = pakReader.ReadFloat();
      this.z = pakReader.ReadFloat();
    }

  }
}
