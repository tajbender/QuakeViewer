using System;

namespace IDSoftware {
  class PakFormatException : Exception {
    public PakFormatException(string message)
      : base(message) {
    }
  }
}
