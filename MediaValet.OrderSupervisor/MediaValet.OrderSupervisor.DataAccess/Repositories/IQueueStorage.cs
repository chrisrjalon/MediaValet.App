using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.DataAccess.Entities;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public interface IQueueStorage<T> where T : QueueEntity
    {
        Task<T> Peek();
        Task<T> Get();
        Task<T> Enqueue(T entity);
        Task Dequeue(T entity);
    }
}
