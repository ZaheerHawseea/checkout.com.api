using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores
{
    /// <summary>
    /// The interface for retrieval and storage of order
    /// </summary>
    /// <typeparam name="TOrder">
    /// The type of <see cref="Order"/> to store
    /// </typeparam>
    public interface IOrderStore<TOrder> : IStore<TOrder>
        where TOrder : Order
    { }
}
