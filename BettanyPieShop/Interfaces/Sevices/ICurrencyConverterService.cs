namespace BethanysPieShop.Interfaces.Services
{
    public interface ICurrencyConverterService
    {
        decimal ConvertBYNtoUSD(decimal BYN);
        decimal ConvertBYNtoCryptocurrency(decimal BYN, out string cryptocurrencyMark);

    }
}