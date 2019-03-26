using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class PieViewModel
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal PriceInUSD { get; set; }
        public decimal PriceInCryptocurrency { get; set; }
        public string CryptocurrencyMarc { get; set; }

        public string ImageThumbnailUrl { get; set; }
    }
}
