using System;
using System.Windows.Media.Imaging;
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
            WinRate = (((double)summonerLeague.wins / (summonerLeague.wins + summonerLeague.losses)*100)).ToString() + " %";
            Played = (summonerLeague.wins + summonerLeague.losses).ToString();
            RankBorderIcon = new BitmapImage(new Uri("pack://application:,,,/Resources/" + summonerLeague.tier + ".png"));
            Tier = summonerLeague.tier;
            LeaguePoints = summonerLeague.leaguePoints + " LP";
        }

        private string _summonerName;
        private string _summonerIcon;
        private BitmapImage _rankBorderIcon;
        private string _wins;
        private string _winRate;
        private string _played;
        private string _tier;
        private string _leaguePoints;

        public string SummonerName { get { return _summonerName; } set { _summonerName = value; OnPropertyChanged(); } }
        public string SummonerIcon { get { return _summonerIcon; } set { _summonerIcon = value; OnPropertyChanged(); } }
        public BitmapImage RankBorderIcon { get { return _rankBorderIcon; } set { _rankBorderIcon = value; OnPropertyChanged(); } }
        public string Wins { get { return _wins; } set { _wins = value; OnPropertyChanged(); } }
        public string WinRate { get { return _winRate; } set { _winRate = value; OnPropertyChanged(); } }
        public string Played { get { return _played; } set { _played = value; OnPropertyChanged(); } }
        public string Tier { get { return _tier; } set { _tier = value; OnPropertyChanged(); } }
        public String LeaguePoints { get { return _leaguePoints; } set { _leaguePoints = value; OnPropertyChanged(); } }
    }
}
