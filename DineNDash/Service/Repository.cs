//namespace DineNDash
//{
//    internal class Repository
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using DineNDash.Models;
using DineNDash.Services;

namespace DineNDash.Services
{
    public class Repository : IRepository
    {
        IList<OrderItem> itemFromSomeDataSource = null;

        public Repository()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Repository)}:  ctor");
        }

        // Method summary provided in interface.
        public async Task<IList<OrderItem>> GetItem()
        {
            await Task.Delay(500);

            return itemFromSomeDataSource;
        }

        public async Task<IList<OrderItem>> GetItem(int numberOfItems)
        {
            itemFromSomeDataSource = new List<OrderItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var newOrderItem = new OrderItem()
                {
                    Item = $"{i}"
                };

                itemFromSomeDataSource.Add(newOrderItem);
            }

            await Task.Delay(500);

            return itemFromSomeDataSource;
        }

        // Method summary provided in interface.
        public async Task AddItem(OrderItem newOrderItem)
        {
            if (itemFromSomeDataSource == null)
            {
                itemFromSomeDataSource = new List<OrderItem>();
            }
            itemFromSomeDataSource.Add(newOrderItem);
            await Task.Delay(500);
        }

        public async Task RemoveItem(OrderItem removeOrderItem)
        {
            if (itemFromSomeDataSource == null)
            {
            }
            itemFromSomeDataSource.Remove(removeOrderItem);
            await Task.Delay(500);
        }

        public async Task RemoveAllItems(OrderItem removeAllItems)
        {
            itemFromSomeDataSource = new List<OrderItem>();

            if (itemFromSomeDataSource != null)
            {
                itemFromSomeDataSource.Remove(removeAllItems);
            }
        }
    }
}