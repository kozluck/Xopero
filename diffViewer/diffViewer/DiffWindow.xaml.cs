using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace diffViewer
{

    public partial class DiffWindow : Window
    {

        public DiffWindow(string firstFileName, string secondFileName)
        {
            InitializeComponent();

            if (!FileCompare(firstFileName, secondFileName))
            {
                var firstFileText = System.IO.File.ReadAllLines(firstFileName).ToList();
                var secondFileText = System.IO.File.ReadAllLines(secondFileName).ToList();

                var inFirstFileOnly = firstFileText.Except(secondFileText).ToList();
                var inSecondFileOnly = secondFileText.Except(firstFileText).ToList();

                var p = new Paragraph();

                bool checking = true;
                int i = 0;

                while (checking)
                {
                    string str = firstFileText[i];
                    i++;
                    foreach (var strInSecondFile in secondFileText)
                    {
                        int lineNumber = secondFileText.IndexOf(strInSecondFile);
                        Run run;

                        if (str.Equals(strInSecondFile))
                        {
                            run = new Run(lineNumber + ": " + strInSecondFile + "\n");
                            p.Inlines.Add(run);
                            break;
                        }

                        if (inFirstFileOnly.Contains(str))
                        {
                            lineNumber = firstFileText.IndexOf(str);
                            run = new Run(lineNumber + ": " + str + "\n")
                            {
                                Background = Brushes.IndianRed
                            };
                            p.Inlines.Add(run);
                            inFirstFileOnly.Remove(str);
                            break;
                        }

                        if (inSecondFileOnly.Contains(strInSecondFile))
                        {
                            run = new Run(lineNumber + ": " + strInSecondFile + "\n")
                            {
                                Background = Brushes.LawnGreen
                            };
                            p.Inlines.Add(run);
                            inSecondFileOnly.Remove(strInSecondFile);
                            continue;
                        }

                    }
                    if (inFirstFileOnly.Count == 0 && inSecondFileOnly.Count == 0 && i == firstFileText.Count) checking = false;
                }

                textBox.Document.Blocks.Add(p);
            }
            else
            {
                label.Content = "There is no difference between these files.";
                textBox.Visibility = Visibility.Hidden;
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
