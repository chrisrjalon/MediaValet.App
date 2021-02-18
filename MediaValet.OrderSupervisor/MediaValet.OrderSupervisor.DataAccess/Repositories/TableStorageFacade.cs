using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public class TableStorageFacade : ITableStorageFacade
    {
        public ITableStorage<Confirmation> Confirmations { get; }

        public TableStorageFacade(ITableStorage<Confirmation> confirmations)
        {
            Confirmations = confirmations;
        }
    }
}
