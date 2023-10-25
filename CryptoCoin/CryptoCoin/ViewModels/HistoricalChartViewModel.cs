using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCoin.Models;
using CryptoCoin.Services;
using System.Windows;
using System.Globalization;
using System.Windows.Markup;
using System.Diagnostics;

namespace CryptoCoin.ViewModels
{
    internal class HistoricalChartViewModel : BaseViewModel
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

        public SeriesCollection HistoricalDataSeries { get; set; }
        public List<string> XLabels { get; set; }
        public Func<double, string> PriceLabelFormatter { get; set; }

        public HistoricalChartViewModel(string modelId)
        {
            _cryptoCoinService = new CryptoCoinService();
            _model = new CryptoCoinModel();
            HistoricalDataSeries = new SeriesCollection();
            XLabels = new List<string>();
            PriceLabelFormatter = value => value.ToString("C");
            Task.Run(() => LoadData(modelId));
        }


        private async Task LoadData(string modelId)
        {
            Model = await _cryptoCoinService.GetModelById(modelId);

            var historicalData = await _cryptoCoinService.GetHistoricalDataById(modelId);

            if (historicalData.Count == 0)
            {
                MessageBox.Show("No historical data available for this currency.");
            }
            else
            {
                var chartValues = historicalData.Select(data => double.Parse(s: data.priceUsd)).ToList();

                HistoricalDataSeries.Add(new LineSeries
                {
                    Title = "Historical Price Data",
                    Values = new ChartValues<double>(chartValues)
                });

                var formattedDates = historicalData.Select(data =>
                {
                    try
                    {
                        var formattedDate = data.date.ToString("MM/dd/yyyy hh:mm:ss tt");
                        MessageBox.Show($"Formatted Date: {formattedDate}");
                        return formattedDate;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Date Formatting Error: {ex.Message}");
                        return "Invalid Date";
                    }
                }).ToList();
                XLabels.AddRange(formattedDates);
            }
        }
    }
}
