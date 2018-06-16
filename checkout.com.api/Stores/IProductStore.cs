using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores
{
    /// <summary>
    /// The interface for retrieval and storage of product
    /// </summary>
    /// <typeparam name="TProduct">
    /// The type of <see cref="Product"/> to store
    /// </typeparam>
    public interface IProductStore<TProduct> : IStore<TProduct>
        where TProduct : Product
    { }
}
