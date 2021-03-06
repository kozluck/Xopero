using System;
using System.Collections.Generic;
using System.Net.Http;
using static GitLabBackup.JSONModel;

namespace GitLabBackup
{

    class APIHandler
    {

        public List<Issue> getIssuesFromApi(string projectId)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://gitlab.com/api/v4/projects/");
                HttpResponseMessage response = http.GetAsync(projectId + "/issues").Result;

                string jsonInString = response.Content.ReadAsStringAsync().Result;

                var data = System.Text.Json.JsonSerializer.Deserialize<List<Issue>>(jsonInString);
                return data;
            }
        }

        public List<Note> getNotesFromIssue(string projectId, int issueId)
        {
            using (var http = new HttpClient())
            {
                var url = "https://gitlab.com/api/v4/projects/" + projectId + "/issues/" + issueId + "/notes";
                http.DefaultRequestHeaders.Add("PRIVATE-TOKEN", "glpat-eG5CYC1a_tFV_Kk1m3zf");
                HttpResponseMessage response = http.GetAsync(url).Result;

                string jsonInString = response.Content.ReadAsStringAsync().Result;

                var data = System.Text.Json.JsonSerializer.Deserialize<List<Note>>(jsonInString);
                return data;
            }
        }

        public async void postIssues(List<Issue> issues)
        {

            issues.ForEach(async issue =>
            {
                var parameters = new Dictionary<string, string>();
                string url = "https://gitlab.com/api/v4/projects/" + issue.project_id + "/issues";

                if (issue.title != null)
                {
                    parameters.Add("title", issue.title);
                    parameters.Add("iid", issue.iid.ToString());
                    parameters.Add("description", issue.description);
                    parameters.Add("created_at", issue.created_at.ToString());
                    parameters.Add("due_date", (string)issue.due_date);
                    parameters.Add("confidential", issue.confidential.ToString());

                    var encodedContent = new FormUrlEncodedContent(parameters);

                    using (var http = new HttpClient())
                    {
                        http.DefaultRequestHeaders.Add("PRIVATE-TOKEN", "glpat-eG5CYC1a_tFV_Kk1m3zf");
                        var response = await http.PostAsync(url, encodedContent).ConfigureAwait(false);
                    }
                }

            });
        }

        public async void postNotes(List<Note> notes, int projectId)
        {
            notes.ForEach(async note =>
            {
                string url = "https://gitlab.com/api/v4/projects/" + projectId + "/issues/" + note.noteable_iid + "/notes";
                var parameters = new Dictionary<string, string>();

                if (note.body != null)
                {
                    parameters.Add("body", note.body);
                    parameters.Add("created_at", note.created_at.ToString());
                    parameters.Add("confidential", note.confidential.ToString());
                    parameters.Add("noteable_iid", note.noteable_iid.ToString());

                    var encodedContent = new FormUrlEncodedContent(parameters);

                    using (var http = new HttpClient())
                    {
                        http.DefaultRequestHeaders.Add("PRIVATE-TOKEN", "glpat-eG5CYC1a_tFV_Kk1m3zf");
                        var response = await http.PostAsync(url, encodedContent).ConfigureAwait(false);
                    }
                }
            });
        }

    }
}
