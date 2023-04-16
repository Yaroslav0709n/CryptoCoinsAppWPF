using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment.Model
{
    public class CoinModel
    {
        public string Id { get; set; }
        public long Rank { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Symbol { get; set; } = String.Empty;
        public double PriceUsd { get; set; }
        public double RoundedPriceUsd => Math.Round(PriceUsd, 2);
        public double MarketCapUsd { get; set; }
        public double RoundedMarketCapUsd => Math.Round(MarketCapUsd, 2);
        public double VolumeUsd24Hr { get; set; }
        public double RoundedVolumeUsd24Hr => Math.Round(VolumeUsd24Hr, 2);
        public double ChangePercent24Hr { get; set; }
        public double RoundedChangePercent24Hr => Math.Round(ChangePercent24Hr, 2);
    }
    
}
