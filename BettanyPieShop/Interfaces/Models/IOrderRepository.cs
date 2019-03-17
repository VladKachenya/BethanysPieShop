using BethanysPieShop.Models;

namespace BethanysPieShop.Interfaces.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}