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

        Task<IList<RestaurantSideItem>> GetItems();

        Task<IList<RestaurantSideItem>> GetItems(int numberOfItems);

        Task AddItem(RestaurantSideItem newOrderItem0);

        Task RemoveItem(RestaurantSideItem removeOrderItem0);

        Task<IList<Restaurant2SideItem>> GetItems2();

        Task<IList<Restaurant2SideItem>> GetItems2(int numberOfItems);

        Task AddItem(Restaurant2SideItem newOrderItem1);

        Task RemoveItem(Restaurant2SideItem removeOrderItem1);
    }
}