using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTstats.Model;

namespace TFTstats.API
{
    public class TFT_MATCH_V1 : Api
    {
        public TFT_MATCH_V1(string region) : base(region) { }

        public string[] getMatchHistoryIds(string puuid, int number)
        {
            string query = "match/v1/matches/by-puuid/" + puuid + "/ids?count=" + number.ToString();
            string route = getRoutingValue();

            var response = GET(getURLRoutingValueRegionMultipleParameters(query, route));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string[] arr = JsonConvert.DeserializeObject<string[]>(content);
                return arr;
            }
            return null;
        }

        public List<MatchDTO> getMatchHistory(string puuid, int number)
        {
            List<MatchDTO> ret = new List<MatchDTO>();

            string[] matchHistoryIds = getMatchHistoryIds(puuid, number);

            string route = getRoutingValue();

            for (int i = 0; i < matchHistoryIds.Length; i++)
            {
                string query = "match/v1/matches/" + matchHistoryIds[i];
                var response = GET(getURLRoutingValueRegion(query, route));
                string content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MatchDTO match = JsonConvert.DeserializeObject<MatchDTO>(content);
                    ret.Add(match);
                    Console.WriteLine(match.Info.game_datetime);
                }
                else
                {
                    return null;
                }
            }
            return ret;
        }

        private string getRoutingValue()
        {
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

            return route;
        }
    }
}
