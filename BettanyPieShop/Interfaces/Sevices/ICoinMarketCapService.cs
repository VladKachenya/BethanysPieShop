namespace BethanysPieShop.Interfaces.Services
{
    public interface ICoinMarketCapService
    {
        decimal BitcoinPriceInUsd { get; }
        string Sumbol{ get; }

    }
}