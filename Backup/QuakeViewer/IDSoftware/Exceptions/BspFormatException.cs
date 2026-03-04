using System;

namespace IDSoftware {
  class BspFormatException : Exception {
    public BspFormatException(string message)
      : base(message) {
    }
  }
}
