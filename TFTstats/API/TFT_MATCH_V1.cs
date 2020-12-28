using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.API
{
    public class TFT_MATCH_V1 : Api
    {
        public TFT_MATCH_V1(string region) : base(region) { }

        public string[] getLastMatches(string puuid, int number)
        {
            string query = "match/v1/matches/by-puuid/" + puuid + "/ids?count=" + number.ToString();

            string route;
            switch (Region)
            {
                case "eun1":
                case "euw1":
                case "tr1":
                case "ru":
                    route = "europe";
                    break;
                case "na1":
                case "br1":
                case "la1":
                case "la2":
                case "oc1":
                    route = "americas";
                    break;
                case "kr":
                case "jp1":
                    route = "asia";
                    break;
                default:
                    throw new Exception("Region must be one of known values. See https://developer.riotgames.com/docs/tft#_routing-values for more information."); 
            }

            var response = GET(getURLRoutingValueRegion(query, route));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string[] arr = JsonConvert.DeserializeObject<string[]>(content);
                return arr;
            }
            return null;
        }
    }
}
