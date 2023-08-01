using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FsyaFignya.Dto
{
    [JsonObject]
    public class ListOfSeriesTitlesOfTheBigBangTheoryDto
    {
        [JsonPropertyName("seriesName")]
        public string? SeriesName { get; set; }
    }
}

