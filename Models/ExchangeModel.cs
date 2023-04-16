using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment.Model
{
    public class ExchangeModel
    {
        public string ExchangeId { get; set; } = String.Empty;
        public string BaseSymbol { get; set; } = String.Empty;
        public string QuoteSymbol { get; set; } = String.Empty;
        public double PriceUsd { get; set; }
        public double RoundedPriceUsd => Math.Round(PriceUsd, 4);
        public double VolumeUsd24Hr { get; set; }
        public double RoundedVolumeUsd24Hr => Math.Round(VolumeUsd24Hr, 3);
        public double VolumePercent { get; set; }
        public double RoundedVolumePercent => Math.Round(VolumePercent, 2);
    }
}
