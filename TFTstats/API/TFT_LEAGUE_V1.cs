using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTstats.Model;

namespace TFTstats.API
{
    public class TFT_LEAGUE_V1 : Api
    {
        public TFT_LEAGUE_V1(string region) : base(region) { }

        public void getSummonerLeagueBySummonerId(string summonerId)
        {
            string query = "league/v1/entries/by-summoner/" + summonerId;

            var response = GET(getURLRoutingValuePlatform(query));
            string content = response.Content.ReadAsStringAsync().Result;
            content = content.Substring(1, content.Length - 2);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JsonConvert.PopulateObject(content, SummonerLeagueDTO.Instance);
            }
        }
    }
}
