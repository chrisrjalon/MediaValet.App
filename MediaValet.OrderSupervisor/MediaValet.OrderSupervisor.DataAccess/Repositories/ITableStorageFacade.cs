using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public interface ITableStorageFacade
    {
        ITableStorage<Confirmation> Confirmations { get; }
    }
}
