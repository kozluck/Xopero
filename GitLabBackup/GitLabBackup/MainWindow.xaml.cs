using System.Collections.Generic;
using System.Windows;
using static GitLabBackup.JSONModel;

namespace GitLabBackup
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void doBackup_Click(object sender, RoutedEventArgs e)
        {
            APIHandler handler = new APIHandler();
            List<Issue> issues = handler.getIssuesFromApi("36884934");
            handler.postIssues(issues , "36884934");
        }
    }
}
