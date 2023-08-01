using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FsyaFignya.Dto
{
    [JsonObject]
    public class AgeByNameOrCountryDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}