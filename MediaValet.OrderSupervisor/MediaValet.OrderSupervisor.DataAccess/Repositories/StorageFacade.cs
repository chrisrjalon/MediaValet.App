using System;
using System.Collections.Generic;
using System.Text;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public class StorageFacade : IStorageFacade
    {
        public IQueueStorageFacade Queues { get; }

        public StorageFacade(IQueueStorageFacade queues)
        {
            Queues = queues;
        }
    }
}
