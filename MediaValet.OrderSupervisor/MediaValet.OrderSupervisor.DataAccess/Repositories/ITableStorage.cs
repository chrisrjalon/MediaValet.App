using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.DataAccess.Entities;
using Microsoft.Azure.Cosmos.Table;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public interface ITableStorage<T> where T : TableEntity
    {
    }
}
