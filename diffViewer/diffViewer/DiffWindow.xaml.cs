using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;


namespace diffViewer
{

    public partial class DiffWindow : Window
    {

        public DiffWindow(string firstFileName, string secondFileName)
        {
            InitializeComponent();

            if(!FileCompare(firstFileName, secondFileName))
            {
                var firstFileText = System.IO.File.ReadAllLines(firstFileName).ToList();
                var secondFileText = System.IO.File.ReadAllLines(secondFileName).ToList();

                var inFirstFileOnly = firstFileText.Except(secondFileText).ToList();
                var inSecondFileOnly = secondFileText.Except(firstFileText).ToList();


                List<string> fixedInFirstFileOnly = new List<string>();
                List<string> fixedInSecondFileOnly = new List<string>();

                foreach (var str in inFirstFileOnly)
                {
                    int lineNumber = firstFileText.IndexOf(str) + 1;
                    str.Replace("\t", "");
                    fixedInFirstFileOnly.Add(lineNumber + ": " + str);
                }
                    

                foreach (var str in inSecondFileOnly)
                {
                    int lineNumber = secondFileText.IndexOf(str) + 1;
                    str.Replace("\t", "");
                    fixedInSecondFileOnly.Add(lineNumber + ": " + str);
                }

                firstFileTextBlock.Text = string.Join("\n", fixedInFirstFileOnly);
                secondFileTextBlock.Text = string.Join("\n", fixedInSecondFileOnly);
            }
            else
            {
                firstLabel.Content = "Files are the same.";
                firstLabel.FontSize = 50;
                secondLabel.Visibility = Visibility.Hidden;
                firstFileTextBlock.Visibility = Visibility.Hidden;
                secondFileTextBlock.Visibility = Visibility.Hidden;
            }
        }

        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            if (file1 == file2) return true;
            
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();

                return false;
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            fs1.Close();
            fs2.Close();

            return ((file1byte - file2byte) == 0);
        }
    }
}
