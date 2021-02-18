using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public class QueueStorageFacade : IQueueStorageFacade
    {
        public IQueueStorage<Order> Orders { get; }

        public QueueStorageFacade(IQueueStorage<Order> orders)
        {
            Orders = orders;
        }
    }
}
