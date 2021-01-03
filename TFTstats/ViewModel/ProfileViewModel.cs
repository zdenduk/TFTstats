using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using TFTstats.API;
using TFTstats.Model;
using TFTstats.Support;

namespace TFTstats.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ProfileViewModel(MainViewModel mainViewModel, String region)
        {
            this._mainViewModel = mainViewModel;
            Menu = new RelayCommand(GoToMenu);
            MatchHistory = new RelayCommand(ShowMatchHistory);
            this._region = region;

            SummonerDTO summoner = SummonerDTO.Instance;
            SummonerLeagueDTO summonerLeague = SummonerLeagueDTO.Instance;
            SummonerName = summoner.name;
            SummonerIcon = summoner.profileIconId.ToString();
            Wins = summonerLeague.wins.ToString();
            WinRate = (((double)summonerLeague.wins / (summonerLeague.wins + summonerLeague.losses)*100)).ToString() + "%";
            Played = (summonerLeague.wins + summonerLeague.losses).ToString();
            RankBorderIcon = new BitmapImage(new Uri("pack://application:,,,/Resources/" + summonerLeague.tier + ".png"));
            Tier = summonerLeague.tier;
            LeaguePoints = summonerLeague.leaguePoints + " LP";
        }

        public void GoToMenu(object o)
        {
            _mainViewModel.SelectedViewModel = new MenuViewModel(_mainViewModel);
        }

        public void ShowMatchHistory(object o)
        {
            TFT_MATCH_V1 matchApi = new TFT_MATCH_V1(_region);
            List<MatchDTO> matchHistory = matchApi.getMatchHistory(SummonerDTO.Instance.puuid, 5);
            _mainViewModel.SelectedViewModel = new MatchHistoryViewModel(_mainViewModel, matchHistory, SummonerDTO.Instance.puuid);
        }

        private string _region;
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
        public RelayCommand Menu { get; private set; }
        public RelayCommand MatchHistory { get; private set; }
    }
}
