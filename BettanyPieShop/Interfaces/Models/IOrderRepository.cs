using BettanyPieShop.Models;

namespace BettanyPieShop.Interfaces.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}