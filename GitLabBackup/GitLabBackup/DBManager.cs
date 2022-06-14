using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static GitLabBackup.JSONModel;
using Dapper;

namespace GitLabBackup
{
    class DBManager
    {
        
        public void saveIssues(List<Issue> issues)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;Version=3;");
            conn.Open();
            string sql = @"INSERT INTO issues (project_id, title, description) VALUES (@project_id, @title, @description)";

            conn.Execute(sql,issues);
            conn.Close();
        }

        public void saveNotes(List<Note> notes)
        {
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
    }
}
