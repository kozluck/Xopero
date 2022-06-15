using System.Collections.Generic;
using System.Windows;
using static GitLabBackup.JSONModel;

namespace GitLabBackup
{

    public partial class MainWindow : Window
    {
        private APIHandler handler = new();
        private DBManager dbManager = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void doBackup_Click(object sender, RoutedEventArgs e)
        {
            string id = projectId.Text;

            List<Issue> issues = handler.getIssuesFromApi(id);
            List<Note> allNotes = new List<Note>();

            issues.ForEach(issue =>
            {
                allNotes.AddRange(handler.getNotesFromIssue(id, issue.iid));
            });

            dbManager.saveIssues(issues);
            dbManager.saveNotes(allNotes);

            if (label.Visibility != Visibility.Visible) label.Visibility = Visibility.Visible;
            label.Content = "Backup was succesfull, data is saved in database.";
        }

        private void restore_Click(object sender, RoutedEventArgs e)
        {
            List<Issue> issues = dbManager.getIssues();
            List<Note> notes = dbManager.getNotes();
            int projectId = issues[0].project_id;

            handler.postIssues(issues);
            System.Threading.Thread.Sleep(2000);
            handler.postNotes(notes, projectId);

            if (label.Visibility != Visibility.Visible) label.Visibility = Visibility.Visible;
            label.Content = "Backup is restored on GitLab.";
        }
    }
}
