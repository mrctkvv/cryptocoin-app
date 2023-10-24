using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCoin.Models;
using CryptoCoin.Services;

namespace CryptoCoin.ViewModels
{
    internal class CryptoCoinViewModel : BaseViewModel
    {


        private readonly CryptoCoinService _cryptoCoinService;
        private ObservableCollection<CryptoCoinModel> _models;

        public ObservableCollection<CryptoCoinModel> Models
        {
            get => _models;
            private set
            {
                _models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        public ObservableCollection<CryptoCoinModel> _selectedModels;

        public ObservableCollection<CryptoCoinModel> SelectedModels
        {
            get => _selectedModels;
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(SelectedModels));
            }
        }

        public CryptoCoinViewModel()
        {
            _cryptoCoinService = new CryptoCoinService();
            _models = new ObservableCollection<CryptoCoinModel>();
            _selectedModels = new ObservableCollection<CryptoCoinModel>();
            Task.Run(() => LoadData());
        }

        private async Task LoadData()
        {
            var modelsList = await _cryptoCoinService.GetCryptoCoins();
            Models = new ObservableCollection<CryptoCoinModel>(modelsList);
            SelectedModels = Models;
        }
    }
}
