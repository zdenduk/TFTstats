using TFTstats.Model;
using TFTstats.Support;

namespace TFTstats.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ProfileViewModel(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;

            SummonerDTO summoner = SummonerDTO.Instance;
            SummonerLeagueDTO summonerLeague = SummonerLeagueDTO.Instance;
            SummonerName = summoner.name;
            SummonerIcon = summoner.profileIconId.ToString();
            Wins = summonerLeague.wins.ToString();
            WinRate = (((double)summonerLeague.wins / (summonerLeague.wins + summonerLeague.losses)*100)).ToString();
            Played = (summonerLeague.wins + summonerLeague.losses).ToString();
        }

        private string _summonerName;
        private string _summonerIcon;
        private string _rankBorderIcon;
        private string _wins;
        private string _winRate;
        private string _top4;
        private string _top4Rate;
        private string _played;
        private string _avgRank;

        public string SummonerName { get { return _summonerName; } set { _summonerName = value; OnPropertyChanged(); } }
        public string SummonerIcon { get { return _summonerIcon; } set { _summonerIcon = value; OnPropertyChanged(); } }
        public string RankBorderIcon { get { return _rankBorderIcon; } set { _rankBorderIcon = value; OnPropertyChanged(); } }
        public string Wins { get { return _wins; } set { _wins = value; OnPropertyChanged(); } }
        public string WinRate { get { return _winRate; } set { _winRate = value; OnPropertyChanged(); } }
        public string Top4 { get { return _top4; } set { _top4 = value; OnPropertyChanged(); } }
        public string Top4Rate { get { return _top4Rate; } set { _top4Rate = value; OnPropertyChanged(); } }
        public string Played { get { return _played; } set { _played = value; OnPropertyChanged(); } }
        public string AvgRank { get { return _avgRank; } set { _avgRank = value; OnPropertyChanged(); } }
    }
}
