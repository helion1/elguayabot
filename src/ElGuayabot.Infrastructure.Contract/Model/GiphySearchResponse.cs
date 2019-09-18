using System;
using Newtonsoft.Json;

namespace ElGuayabot.Infrastructure.Contract.Model
{
    public class GiphySearchResponse
    {
        [JsonProperty("data")]
        public SearchData Data { get; set; }
        [JsonProperty("pagination")]
        public SearchPagination Pagination { get; set; }
        [JsonProperty("meta")]
        public SearchMeta Meta { get; set; }
        
        public class SearchData
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("slug")]
            public string Slug { get; set; }
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("bitly_url")]
            public string BitlyUrl { get; set; }
            [JsonProperty("embed_url")]
            public string EmbedUrl { get; set; }
            [JsonProperty("rating")]
            public string Rating { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
        }
        
        public class SearchPagination
        {
            [JsonProperty("offset")]
            public int Offset { get; set; }
            [JsonProperty("total_count")]
            public int TotalCount { get; set; }
            [JsonProperty("count")]
            public int Count { get; set; }
        }
        
        public class SearchMeta
        {
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("status")]
            public int Status { get; set; }
            [JsonProperty("response_id")]
            public string ResponseId { get; set; }
        }
    }
}