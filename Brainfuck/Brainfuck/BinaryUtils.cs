using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfuck
{
    public class BinaryUtils
    {
        public static byte[] ConvertToByteArray(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static String ToBinary(Byte[] data)
        {
            return String.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        
        public static String ByteArrayToString(byte[] bytes) 
        {
            return Encoding.ASCII.GetString(bytes);
        }

        public static string BinaryToString(String binary)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < binary.Length; i += 8)
                bytes.Add(Convert.ToByte(binary.Substring(i, 8), 2));

            return Encoding.ASCII.GetString(bytes.ToArray());
        }

    }
}
