using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FsyaFignya.Dto
{
    [JsonObject]
    public class InformationAboutBitcoinDto
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("requestDate")]
        public string? RequestDate { get; set; }
    }
}

