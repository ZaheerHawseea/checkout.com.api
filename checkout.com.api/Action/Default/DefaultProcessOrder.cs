using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Dto;
using checkout.com.api.Entities;

namespace checkout.com.api.Action.Default
{
    public class DefaultProcessOrder : IProcessOrder
    {
        public Task ExecuteAsync(Order order, Billing billing)
        {
            return Task.FromResult(true);
        }
    }
}
