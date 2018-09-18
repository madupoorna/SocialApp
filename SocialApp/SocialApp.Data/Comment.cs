using Newtonsoft.Json;

namespace SocialApp.Data
{
    public class Comment
    {
        [JsonProperty(PropertyName = "postId")]
        public int postId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string body { get; set; }
    }
}
