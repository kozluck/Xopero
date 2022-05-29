using System.Windows;


namespace diffViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string firstFileName, secondFileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void firstFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            var result = ofd.ShowDialog();
            firstFile.Content = ofd.FileName;
            firstFileName = ofd.FileName;

        }

        private void secondFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            var result = ofd.ShowDialog();
            secondFile.Content = ofd.FileName;
            secondFileName = ofd.FileName;
        }

        private void checkDifferences_Click(object sender, RoutedEventArgs e)
        {
            if (firstFileName != null && secondFileName != null)
            {
                this.Hide();
                Window diffWindow = new DiffWindow(firstFileName, secondFileName);
                diffWindow.Show();
            }
            else
            {
                MessageBox.Show("Choose 2 files to check!", "Error");
            }
        }
    }
}
