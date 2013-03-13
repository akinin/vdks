using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdks.Model
{
    class Messages
    {
        public static readonly byte[] Handshake = new byte[2]{0xAB,0xBC};
        public static readonly byte ReadCommandByte = 0x1;
        public static readonly byte WriteCommandByte = 0x2;
        public static readonly byte SerialOffset = 0x1;
        public static readonly byte FirstNumberOffset = 0x3;
        public static readonly byte NumberCountOffset = 0x0;
        public static byte[] ReadCommand(byte offset)
        {
            return new byte[2] { ReadCommandByte, offset };
        }
        public static byte[] WriteCommand(byte offset, byte valueToWrite)
        {
            return new byte[3] { WriteCommandByte, offset, valueToWrite };
        }
    }
}
