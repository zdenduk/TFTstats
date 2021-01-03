using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTstats.Model;
using TFTstats.Support;

namespace TFTstats.ViewModel
{
    public class MatchViewModel : ViewModelBase
    {
        public MatchViewModel(MainViewModel mainViewModel, MatchDTO match, string puuid)
        {
            foreach (ParticipantDTO participant in match.Info.participants)
            {
                if (participant.puuid.Equals(puuid))
                {
                    Placement = "#" + participant.placement.ToString();
                }
            }
        }

        private string _placement;

        public string Placement { get { return _placement; } set { _placement = value; OnPropertyChanged(); } }

    }
}
