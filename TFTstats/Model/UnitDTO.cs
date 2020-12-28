using System.Collections.Generic;

namespace TFTstats.Model
{
    public class UnitDTO
    {
        public List<int> items { get; set; }
        public string character_id { get; set; }
        public string chosen { get; set; }
        public string name { get; set; }
        public int rarity { get; set; }
        public int tier { get; set; }
    }
}