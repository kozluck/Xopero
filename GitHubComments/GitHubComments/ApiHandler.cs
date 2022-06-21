using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using static GitHubComments.JSONModel;


public class ApiHandler
{
    private HttpClient httpClient;
    private string uri;
    public ApiHandler(string owner, string repo)
    {
        httpClient = new HttpClient();

        uri = String.Format($"https://api.github.com/repos/{owner}/{repo}", owner, repo).ToString();
        httpClient.DefaultRequestHeaders.Add("Authorization", "token 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");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "kozluck");
    }

    public List<Root> GetIssuesAndPulls()
    {
        HttpResponseMessage response = httpClient.GetAsync(uri + "/issues").Result;
        var jsonInString = response.Content.ReadAsStringAsync().Result;
        List<Root> data = null;
        try
        {
            data = System.Text.Json.JsonSerializer.Deserialize<List<>>(jsonInString);
        }
        catch (System.Text.Json.JsonException)
        {
            Console.WriteLine("Run application once again, with correct data.");
            Environment.Exit(0);
        }
        return data;
    }


    public void writeCommentsToIssuesAndPulls(List<Root> issuesAndPulls, int numberOfComments)
    {
        issuesAndPulls.ForEach(e =>
        {
            HttpResponseMessage mes = new HttpResponseMessage();

            for (int i = 1; i <= numberOfComments; i++)
            {
                string body = "{\"body\":\"" + i + "\"}";
                mes = httpClient.PostAsync(uri + "/issues/" + e.number + "/comments", new StringContent(body)).Result;
                while (mes.IsSuccessStatusCode == false)
                {
                    Console.WriteLine("Waiting");
                    Thread.Sleep(30000);
                    mes = httpClient.PostAsync(uri + "/issues/" + e.number + "/comments", new StringContent(body)).Result;
                };
                Console.WriteLine("Success");

            }
        });

    }

}
