//namespace DineNDash
//{
//internal interface IRepository
//{
//}
//}
using System.Collections.Generic;
using System.Threading.Tasks;
using DineNDash.Models;

namespace DineNDash.Services
{
    public interface IRepository
    {
        Task<IList<OrderItem>> GetItem();

        Task<IList<OrderItem>> GetItem(int numberOfItems);

        Task AddItem(OrderItem newOrderItem);

        Task RemoveItem(OrderItem removeOrderItem);

        Task RemoveAllItems(OrderItem removeAllItems);
    }
}