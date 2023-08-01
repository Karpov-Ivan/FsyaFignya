using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FsyaFignya.Dto
{
    [JsonObject]
    public class FactsAboutDogsDto
    {
        [JsonPropertyName("factAboutDogs")]
        public string? FactAboutDogs { get; set; }
    }
}

