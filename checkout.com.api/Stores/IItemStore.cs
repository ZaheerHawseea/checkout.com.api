using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores
{
    /// <summary>
    /// The interface for retrieval and storage of item
    /// </summary>
    /// <typeparam name="TItem">
    /// The type of <see cref="Item"/> to store
    /// </typeparam>
    public interface IItemStore<TItem> : IStore<TItem>
        where TItem : Item
    {
        Task<IQueryable<TItem>> FindByOrderIdAsync(string orderId);
    }
}
