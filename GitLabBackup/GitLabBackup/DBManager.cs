using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using static GitLabBackup.JSONModel;

namespace GitLabBackup
{
    class DBManager
    {
        public void saveIssues(List<Issue> issues)
        {
            if (issues.Count > 0)
            {
                clearIssues();
                SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
                conn.Open();
                string sql = @"INSERT INTO issues (iid,project_id, title, description, created_at, due_date, confidential) VALUES (@iid, @project_id, @title, @description, @created_at, @due_date, @confidential)";

                conn.Execute(sql, issues);
                conn.Close();
            }
        }

        public void saveNotes(List<Note> notes)
        {
            clearNotes();
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();

            string sql = @"INSERT INTO notes (body, created_at, noteable_iid, confidential) 
                                VALUES (@body, @created_at, @noteable_iid,@confidential)";

            conn.Execute(sql, notes);
            conn.Close();
        }

        public List<Issue> getIssues()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();

            string sql = @"SELECT * FROM issues";
            List<Issue> issues = conn.Query<Issue>(sql).AsList();

            conn.Close();
            return issues;
        }

        public List<Note> getNotes()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();

            string sql = @"SELECT * FROM notes";
            List<Note> notes = conn.Query<Note>(sql).AsList();

            conn.Close();
            return notes;
        }

        private void clearIssues()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            conn.Query("DELETE FROM issues");
            conn.Close();
        }
        private void clearNotes()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            conn.Query("DELETE FROM notes");
            conn.Close();
        }
    }
}
