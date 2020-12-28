using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTstats.Model;

namespace TFTstats.API
{
    public class TFT_SUMMONER_V1 : Api
    {
        public TFT_SUMMONER_V1(string region) : base(region) { }

        public void getSummonerByName(string name)
        {
            string query = "summoner/v1/summoners/by-name/" + name;

            var response = GET(getURLRoutingValuePlatform(query));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JsonConvert.PopulateObject(content, SummonerDTO.Instance);
            }
        }
    }
}
