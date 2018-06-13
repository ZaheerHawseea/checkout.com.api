using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Action
{
    public interface IRemoveItemsFromOrder
    {
        Task ExecuteAsync(Order order, IList<Item> items);
    }
}