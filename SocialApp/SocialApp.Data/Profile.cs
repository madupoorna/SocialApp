using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.Data
{
    public class Profile
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "username ")]
        public string username { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string phone { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string website { get; set; }
    }
}
