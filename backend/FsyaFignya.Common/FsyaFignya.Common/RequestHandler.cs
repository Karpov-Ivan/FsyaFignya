using System;
using Newtonsoft.Json.Linq;

namespace FsyaFignya.Common
{
    public class RequestHandler
    {
        public RequestHandler() { }

        public async Task<JObject> GetJson(string url)
        {
            try
            {
                JObject json;

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    json = JObject.Parse(responseBody);
                }

                return json;
            }
            catch (HttpRequestException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

