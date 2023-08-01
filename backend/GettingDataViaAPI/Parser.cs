using System;
using AngleSharp;

namespace GettingDataViaAPI
{
    public class Parser : IParser
    {
        private string addressSeries = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";

        private string cellSelectorSeries = "tr.vevent td:nth-child(3)";

        private string addressNato = "https://ru.wikipedia.org/wiki/Список_государств_—_членов_НАТО";

        private string cellSelectorNato = "tbody tr";

        public Parser() { }

        public async Task<List<string>> GetListOfSeriesTitlesOfTheBigBangTheory()
        {
            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync(this.addressSeries);

            var titles = document.QuerySelectorAll(this.cellSelectorSeries).Select(m => m.TextContent).ToList();

            return titles;
        }

        public async Task<List<string[]>> GetListOfNameCountryNato()
        {
            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync(this.addressNato);

            var rows = document.QuerySelectorAll(this.cellSelectorNato);

            var countriesList = new List<string[]>();

            foreach (var row in rows)
            {
                var columns = row.QuerySelectorAll("td");
                if (columns.Length >= 7)
                {
                    var countryName = columns[0].TextContent.Trim();
                    var dateOfEntry = columns[1].TextContent.Trim();

                    if (DateTime.TryParse(dateOfEntry, out DateTime date))
                    {
                        var year = date.Year.ToString();
                        countriesList.Add(new string[] { countryName, year });
                    }
                }
            }

            return countriesList;
        }
    }
}