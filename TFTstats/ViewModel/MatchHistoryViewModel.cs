using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTstats.Model;
using TFTstats.Support;

namespace TFTstats.ViewModel
{
    public class MatchHistoryViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public ObservableCollection<MatchViewModel> MatchHistoryCards { get; set; } = new ObservableCollection<MatchViewModel>();

        public MatchHistoryViewModel(MainViewModel mainViewModel, List<MatchDTO> matchHistory, string puuid)
        {
            this._mainViewModel = mainViewModel;
            foreach (MatchDTO match in matchHistory) {
                MatchHistoryCards.Add(new MatchViewModel(_mainViewModel, match, puuid));
            }
        }
    }
}
