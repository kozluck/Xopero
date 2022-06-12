using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using static GitLabBackup.JSONModel;

namespace GitLabBackup
{
    //https://gitlab.com/api/v4/projects/36884934/issues

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

        public async void postIssues(List<Issue> issues, string projectId)
        {
            
            var json = JsonConvert.SerializeObject(issues);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
                
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://gitlab.com/api/v4/projects/" + projectId);
                http.DefaultRequestHeaders.Add("PRIVATE-TOKEN", "glpat-eG5CYC1a_tFV_Kk1m3zf");
                var result = await http.PostAsync("/issues" , data);
                string t = String.Empty;
            }
        }
    }
}
