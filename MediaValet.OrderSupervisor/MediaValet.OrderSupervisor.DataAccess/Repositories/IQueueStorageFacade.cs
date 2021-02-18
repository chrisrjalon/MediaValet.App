using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public interface IQueueStorageFacade
    {
        IQueueStorage<Order> Orders { get; }
    }
}
