using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores
{
    public interface IProductStore<TProduct> : IStore<TProduct>
        where TProduct : Product
    {
    }
}
