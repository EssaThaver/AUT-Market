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
        public static string Id { get; set; }

        [JsonProperty("email")]
        public static string Email { get; set; }

        [JsonProperty("verified_email")]
        public static string VerifiedEmail { get; set; }

        [JsonProperty("name")]
        public static string Name { get; set; }

        [JsonProperty("first_name")]
        public static string GivenName { get; set; }

        [JsonProperty("last_name")]
        public static string FamilyName { get; set; }

        [JsonProperty("link")]
        public static string Link { get; set; }

        [JsonProperty("picture")]
        public static string Picture { get; set; }

        [JsonProperty("gender")]
        public static string Gender { get; set; }

        [JsonProperty("profile")]
        public static string Profile { get; set; }

    }
}
