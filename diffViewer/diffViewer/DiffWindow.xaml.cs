using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace diffViewer
{

    public partial class DiffWindow : Window
    {

        public DiffWindow(string firstFileName, string secondFileName)
        {
            InitializeComponent();

            var firstFileText = System.IO.File.ReadAllLines(firstFileName).ToList();
            var secondFileText = System.IO.File.ReadAllLines(secondFileName).ToList();

            var inFirstFileOnly = firstFileText.Except(secondFileText).ToList();
            var inSecondFileOnly = secondFileText.Except(firstFileText).ToList();


            List<string> fixedInFirstFileOnly = new List<string>();
            List<string> fixedInSecondFileOnly = new List<string>();

            foreach (var str in inFirstFileOnly)
                fixedInFirstFileOnly.Add(str.Replace("\t", ""));

            foreach (var str in inSecondFileOnly)
                fixedInSecondFileOnly.Add(str.Replace("\t", ""));

            firstFileTextBlock.Text = string.Join("\n", fixedInFirstFileOnly);
            secondFileTextBlock.Text = string.Join("\n", fixedInSecondFileOnly);

        }
    }
}
