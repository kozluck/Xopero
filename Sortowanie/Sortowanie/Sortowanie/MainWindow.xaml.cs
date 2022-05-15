using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Sortowanie.algorithms;

namespace Sortowanie
{
    public partial class MainWindow : Window
    {
        private string fileName ="";
        private Algorithm algorithm = new Algorithm();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chooseFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "TXT Files (*.txt)|*.txt" };
            var result = ofd.ShowDialog();
            chooseFile.Content = ofd.FileName;
            fileName = ofd.FileName;
        }

        private async void startSorting_Click(object sender, RoutedEventArgs e)
        {
            string choosenAlgorithm = sortingType.SelectionBoxItem.ToString();
        
            if (fileName != null)
            {
                string[] text = System.IO.File.ReadAllLines(fileName);
                List<string> textFromFileInList = text.ToList();
                List<int> intsFromFileInList = textFromFileInList.Select(s => int.Parse(s)).ToList();

                switch (choosenAlgorithm)
                {
                    case "Bubblesort":
                        if (intsFromFileInList.Count == textFromFileInList.Count)
                            doAlgorithmWithSettingTime(new BubblesortAlgorithm(), intsFromFileInList);
                        else
                            doAlgorithmWithSettingTime(new BubblesortAlgorithm(), textFromFileInList);

                        break;

                    case "Quicksort":
                        if (intsFromFileInList.Count == textFromFileInList.Count)
                            doAlgorithmWithSettingTime(new QuicksortAlgorithm(), intsFromFileInList, 0, (intsFromFileInList.Count - 1));
                        else
                            doAlgorithmWithSettingTime(new QuicksortAlgorithm(), textFromFileInList, 0, (textFromFileInList.Count - 1));

                        break;

                    case "Insertionsort":
                        if (intsFromFileInList.Count == textFromFileInList.Count)
                            doAlgorithmWithSettingTime(new InsertionsortAlgorithm(), intsFromFileInList);
                        else
                            doAlgorithmWithSettingTime(new InsertionsortAlgorithm(), textFromFileInList);

                        break;
                }
            }
            else
                MessageBox.Show("Choose file!","Error");
            
        }


        public void doAlgorithmWithSettingTime(AlgorithmStrategy algorithmStrategy, List<int> ints)
        {
            Stopwatch stopwatch = new Stopwatch();
            algorithm.setStrategy(algorithmStrategy);

            if (ints != null)
            {
                stopwatch.Start();
                algorithm.doAlgorithm(ints);
                stopwatch.Stop();

                System.IO.File.WriteAllLines(fileName, ints.Select(x => x.ToString()));
            }
           
            time.Content = ("Sorting time in ms: " + stopwatch.ElapsedMilliseconds + " Sorted elements: " + ints.Count);
        }
        private void doAlgorithmWithSettingTime(AlgorithmStrategy algorithmStrategy, List<string> strings)
        {
            Stopwatch stopwatch = new Stopwatch();
            algorithm.setStrategy(algorithmStrategy);

            stopwatch.Start();
            algorithm.doAlgorithm(strings);
            stopwatch.Stop();

            System.IO.File.WriteAllLines(fileName, strings);
            time.Content = ("Sorting time in ms: " + stopwatch.ElapsedMilliseconds + "Sorted elements: " + strings.Count);
        }

        private void doAlgorithmWithSettingTime(AlgorithmWithRecursionStrategy algorithmStrategy, List<int> ints, int left, int right)
        {
            Stopwatch stopwatch = new Stopwatch();
            algorithm.setStrategy(algorithmStrategy);

            if (ints != null)
            {
                stopwatch.Start();
                algorithm.doAlgorithm(ints,left,right);
                stopwatch.Stop();

                System.IO.File.WriteAllLines(fileName, ints.Select(x => x.ToString()));
            }

            time.Content = ("Sorting time in ms: " + stopwatch.ElapsedMilliseconds + "Sorted elements: " + ints.Count);
        }
        private void doAlgorithmWithSettingTime(AlgorithmWithRecursionStrategy algorithmStrategy, List<string> strings, int left, int right)
        {
            Stopwatch stopwatch = new Stopwatch();
            algorithm.setStrategy(algorithmStrategy);
           
            stopwatch.Start();
            algorithm.doAlgorithm(strings,left,right);
            stopwatch.Stop();

            System.IO.File.WriteAllLines(fileName, strings);
            time.Content = ("Sorting time in ms: " + stopwatch.ElapsedMilliseconds + " Sorted elements: " + strings.Count );
        }

    }
}
