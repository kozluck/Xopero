using System.Text;

namespace Brainfuck
{
    public class RunLengthEncoding
    {
        public static string Encode(string text)
        {
            int n = text.Length;
            StringBuilder compressedText = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                int count = 1;
                while (i < n - 1 && text[i] == text[i + 1])
                {
                    count++;
                    i++;
                }
                compressedText.Append(count);
                compressedText.Append(text[i]);
            }

            return compressedText.ToString();
        }
        public static string Decode(string text)
        {
            string tmp = String.Empty;
            StringBuilder decodedText = new StringBuilder();

            foreach (char current in text)
            {
                if (char.IsDigit(current))
                    tmp += current;
                else
                {
                    if (tmp == String.Empty)
                        decodedText.Append(current);
                    else
                    {
                        int count = int.Parse(tmp);
                        tmp = String.Empty;
                        for (int j = 0; j < count; j++)
                            decodedText.Append(current);
                    }
                }
            }
            return decodedText.ToString();
        }
    }
}
