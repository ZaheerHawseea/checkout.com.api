using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkout.com.api.Dto;
using checkout.com.api.Entities;

namespace checkout.com.api.Action
{
    public interface IProcessOrder
    {
        Task ExecuteAsync(Order order, Billing billing);
    }
}