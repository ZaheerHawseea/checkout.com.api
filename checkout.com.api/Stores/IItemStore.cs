using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Entities;

namespace checkout.com.api.Stores
{
    public interface IItemStore<TItem> : IStore<TItem>
        where TItem : Item
    {
    }
}
