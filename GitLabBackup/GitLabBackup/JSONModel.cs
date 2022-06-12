using System;
using System.Text.Json.Serialization;

namespace GitLabBackup
{
    class JSONModel
    {
        public class Issue
        {
            [JsonPropertyName("iid")]
            public int iid { get; set; }

            [JsonPropertyName("project_id")]
            public int project_id { get; set; }

            [JsonPropertyName("title")]
            public string title { get; set; }

            [JsonPropertyName("description")]
            public string description { get; set; }

            [JsonPropertyName("created_at")]
            public DateTime created_at { get; set; }

            [JsonPropertyName("labels")]
            public object[] labels { get; set; }

            [JsonPropertyName("milestone")]
            public object milestone { get; set; }

            //[JsonPropertyName("assignees")]
            //public object[] assignees { get; set; }

            [JsonPropertyName("assignee")]
            public object assignee { get; set; }

            [JsonPropertyName("due_date")]
            public object due_date { get; set; }

            [JsonPropertyName("confidential")]
            public bool confidential { get; set; }
        }
    }
}
