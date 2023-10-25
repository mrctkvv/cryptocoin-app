using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCoin.Models
{
    public class CryptoCoinModel
    {
        public string? Id { get; set; }
        public string? Rank { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Supply { get; set; }
        public string? MaxSupply { get; set; }
        public string? MarketCapUsd { get; set; }
        public string? VolumeUsd24Hr { get; set; }
        public string? PriceUsd { get; set; }
        public string? ChangePercent24Hr { get; set; }
        public string? VWap24Hr { get; set; }
        public string? Explorer { get; set; }
        public long timestamp { get; set; }
        public List<HistoricalDataPoint>? HistoricalData { get; set; }
    }

    public class HistoricalDataPoint
    {
        public string? priceUsd { get; set; }
        public long time { get; set; }
        public DateTime date { get; set; }
    }
}

