using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.Model
{
    public class ParticipantDTO
    {
        CompanionDTO companion { get; set; }
        int gold_left { get; set; }
        int last_round { get; set; }
        int level { get; set; }
        int placement { get; set; }
        int players_eliminated { get; set; }
        string puuid { get; set; }
        float time_eliminated { get; set; }
        int total_damage_to_players { get; set; }
        List<TraitDTO> traits { get; set; }
        List<UnitDTO> units { get; set; }
    }
}
