using Brainfuck;
using System.IO.Compression;
using System.Text;

class Program 
{
    

    public static void Main(String[] args)
    {
        String str = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";
        String compressedBrainfuck = RunLengthEncoding.Encode(str);
        Console.WriteLine(compressedBrainfuck);
        String binary = BinaryUtils.ToBinary(BinaryUtils.ConvertToByteArray(compressedBrainfuck));
        Console.WriteLine(binary);

        String uncompressedToRLE = BinaryUtils.BinaryToString(binary);
        String uncompressedBF = RunLengthEncoding.Decode(uncompressedToRLE);
        Console.WriteLine(uncompressedBF);
    }
}
