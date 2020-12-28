using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TFTstats.API;
using TFTstats.Model;
using TFTstats.Support;

namespace TFTstats.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public MenuViewModel(MainViewModel mainViewModel)
        {
            SpinnnerVisible = Visibility.Hidden;
            Lookup = new RelayCommand(LookupSummoner, SummonerNameAndRegionFilled);
            this._mainViewModel = mainViewModel;
        }

        private string _region;
        private string _summonerName;
        private Visibility _spinnerVisible;

        public string Region { get { return _region; } set { _region = value; OnPropertyChanged(); } }
        public string SummonerName { get { return _summonerName; } set { _summonerName = value; OnPropertyChanged(); } }
        public Visibility SpinnnerVisible { get { return _spinnerVisible; } set { _spinnerVisible = value; OnPropertyChanged(); } }
        public RelayCommand Lookup { get; private set; }

        public async void LookupSummoner(object o)
        {
            SpinnnerVisible = Visibility.Visible;

            TFT_SUMMONER_V1 summonerApi = new TFT_SUMMONER_V1(Region);
            summonerApi.getSummonerByName(SummonerName);

            TFT_LEAGUE_V1 summonerLeagueApi = new TFT_LEAGUE_V1(Region);
            summonerLeagueApi.getSummonerLeagueBySummonerId(SummonerDTO.Instance.id);

            TFT_MATCH_V1 matchApi = new TFT_MATCH_V1(Region);
            string[] arr = matchApi.getMatchHistoryIds(SummonerDTO.Instance.puuid, 5);
            for (int i = 0; i < arr.Length; i++) {
                Console.WriteLine(arr[i]);
            }

            await Task.Delay(1500);

            _mainViewModel.SelectedViewModel = new ProfileViewModel(_mainViewModel);
        }

        public bool SummonerNameAndRegionFilled(object o)
        {
            return true;
        }
    }
}
