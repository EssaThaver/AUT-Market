using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    [JsonObject]
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("verified_email")]
        public string VerifiedEmail { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string GivenName { get; set; }

        [JsonProperty("last_name")]
        public string FamilyName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

    }
}
