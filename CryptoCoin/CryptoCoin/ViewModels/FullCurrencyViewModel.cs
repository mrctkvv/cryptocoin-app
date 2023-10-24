using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCoin.Models;
using CryptoCoin.Services;

namespace CryptoCoin.ViewModels
{
    internal class FullCurrencyViewModel : BaseViewModel
    {

        private readonly CryptoCoinService _cryptoCoinService;
        private CryptoCoinModel _model;

        public CryptoCoinModel Model
        {
            get => _model;
            private set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public FullCurrencyViewModel(string modelId)
        {
            _cryptoCoinService = new CryptoCoinService();
            _model = new CryptoCoinModel();
            Task.Run(() => LoadData(modelId));
        }

        private async Task LoadData(string modelId)
        {
            Model = await _cryptoCoinService.GetModelById(modelId);
        }
    }
}
