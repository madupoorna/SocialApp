using Newtonsoft.Json;
using System;

namespace SocialApp.Data
{
    public class Post
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int userId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string body { get; set; }
    }
}
