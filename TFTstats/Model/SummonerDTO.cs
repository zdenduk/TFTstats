using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.Model
{
    public class SummonerDTO
    {
        private static SummonerDTO instance = null;

        private SummonerDTO() { }

        public string accountId { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string puuid { get; set; }
        public long summonerLevel { get; set; }

        public static SummonerDTO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SummonerDTO();
                }
                return instance;
            }
        }
    }
}
