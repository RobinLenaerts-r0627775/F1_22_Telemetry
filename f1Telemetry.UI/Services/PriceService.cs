using f1Telemetry.Data;

namespace f1Telemetry.UI.Services;
public class PriceService
{
    public Price BinancePrice { get; set; }
    double count;
    double BestAskPrice;
    double BestBidPrice;
    public PriceService()
    {
        NotifyCompleted();
        BestAskPrice = 102.09;
        BestBidPrice = 101.03;
        BinancePrice = new Price((double)BestAskPrice, (double)BestBidPrice);

    }

    private void NotifyCompleted()
    {
        count ++;
    }
}
