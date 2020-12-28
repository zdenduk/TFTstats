using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.API
{
    public class Api
    {
        private string Key { get; set; }
        protected string Region { get; set; }

        public Api(string region)
        {
            Region = region;
            Key = GetKey("API/Key.txt");
        }

        protected HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        private string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }

        protected string getURLRoutingValuePlatform(string query)
        {
            return "https://" + Region + ".api.riotgames.com/tft/" + query + "?api_key=" + Key;
        }

        protected string getURLRoutingValueRegion(string query, string route)
        {
            Console.WriteLine("https://" + route + ".api.riotgames.com/tft/" + query + "?api_key=" + Key);
            return "https://" + route + ".api.riotgames.com/tft/" + query + "?api_key=" + Key;
        }

        protected string getURLRoutingValueRegionMultipleParameters(string query, string route)
        {
            return "https://" + route + ".api.riotgames.com/tft/" + query + "&api_key=" + Key;
        }
    }
}
