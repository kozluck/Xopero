using Brainfuck;

class Program
{

    public static void Main(String[] args)
    {
        Console.WriteLine("Podaj numer operacji którą chcesz wykonać: 1.Konwertowanie pliku Brainfuck do binarnego 2.Konwertowanie pliku binarnego do pliku Brainfuck");
        int choosenNumber = 0;
        try
        {
            choosenNumber = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.Write("Podaj numer operacji na pliku.");
            Console.ReadKey();
        }

        Console.WriteLine("Podaj ścieżkę bezwzględną do pliku:");
        string path = Console.ReadLine();

        switch (choosenNumber)
        {
            case 0:
                Console.WriteLine("Błędny numer operacji. Uruchom program na nowo");
                Console.ReadKey();
                break;
            case 1:
                if (File.Exists(path))
                {
                    string fileName = Path.GetFileName(path);
                    Console.WriteLine("Rozmiar pliku przed kompresja wynosi: {0}", new System.IO.FileInfo(path).Length);

                    string textFromFile = System.IO.File.ReadAllText(path);
                    string compressedText = RunLengthEncoding.Encode(textFromFile);
                    string binaryText = BinaryUtils.ToBinary(BinaryUtils.ConvertToByteArray(compressedText));
                    byte[] binaryTextInBytes = BinaryUtils.ConvertToByteArray(binaryText);

                    string pathWithoutFileName = path.Replace(Path.GetFileName(path), "");
                    string pathToNewCompressedFile = pathWithoutFileName + "\\" + "encoded" + Path.GetFileNameWithoutExtension(path) + ".bin";

                    using (FileStream fs = File.Create(pathToNewCompressedFile))
                        fs.Write(binaryTextInBytes, 0, binaryTextInBytes.Length);

                    Console.WriteLine("Rozmiar pliku po kompresji wynosi: {0}", new System.IO.FileInfo(pathToNewCompressedFile).Length);

                }
                else
                {
                    Console.WriteLine("Błędna ścieżka");
                    Console.ReadKey();
                }
                break;
            case 2:
                if (File.Exists(path))
                {
                    string pathWithoutFileName = path.Replace(Path.GetFileName(path), "");

                    string text = System.IO.File.ReadAllText(path);
                    string uncompressed = RunLengthEncoding.Decode(BinaryUtils.BinaryToString(text));

                    string pathToNewCompressedFile = pathWithoutFileName + "\\" + "decoded" + Path.GetFileNameWithoutExtension(path) + ".bf";

                    using (FileStream fs = File.Create(pathToNewCompressedFile))
                        fs.Write(BinaryUtils.ConvertToByteArray(uncompressed), 0, BinaryUtils.ConvertToByteArray(uncompressed).Length);
                }
                else
                {
                    Console.WriteLine("Błędna ścieżka");
                    Console.ReadKey();
                }
                break;
        }
    }
}
