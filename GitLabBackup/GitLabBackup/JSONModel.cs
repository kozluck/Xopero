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

            [JsonPropertyName("due_date")]
            public object due_date { get; set; }

            [JsonPropertyName("confidential")]
            public bool confidential { get; set; }
        }
        public class Note
        {
            public string body { get; set; }
            public DateTime created_at { get; set; }

            public bool confidential { get; set; }
            public int noteable_iid { get; set; }
        }
    }
}
