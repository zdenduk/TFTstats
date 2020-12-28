using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.Model
{
    public class InfoDTO
    {
        public long game_datetime { get; set; }
        public float game_length { get; set; }
        public string game_variation { get; set; }
        public string game_version { get; set; }
        public List<ParticipantDTO> participants { get; set; }
    }
}
