using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Helpers
{
    public class EntityManager<T> : IEntityManager<T> where T : QueueEntity
    {
        private int _id;

        public void SetEntityId(T entity)
        {
            _id++;
            entity.SetEntityId(_id);
        }
    }
}
