using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TFTstats.Support;

namespace TFTstats.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public MainViewModel()
        {
            _selectedViewModel = new MenuViewModel(this);
        }

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
