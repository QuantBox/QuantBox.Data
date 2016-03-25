using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantBox.Data.Serializer
{
    public class ProtobufDataZeroException : Exception
    {
        public readonly int CurrentVersion;
        public int ExpectVersion;
        public ProtobufDataZeroException(string message, int currentVersion, int expectVersion)
            : base(message)
        {
            CurrentVersion = currentVersion;
            ExpectVersion = expectVersion;
        }
    }
}
