using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FsyaFignya.Dto
{
    [JsonObject]
    public class CountryNatoDto
    {
        [JsonPropertyName("countryName")]
        public string? CountryName { get; set; }

        [JsonPropertyName("dateOfEntry")]
        public int DateOfEntry { get; set; }
    }
}

