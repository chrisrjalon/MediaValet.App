using System;
using System.Collections.Generic;
using System.Text;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public interface IStorageFacade
    {
        IQueueStorageFacade Queues { get; }
    }
}
