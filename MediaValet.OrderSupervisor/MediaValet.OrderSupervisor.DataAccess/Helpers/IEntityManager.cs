using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Helpers
{
    public interface IEntityManager<in T> where T : QueueEntity
    {
        void SetEntityId(T entity);
    }
}
