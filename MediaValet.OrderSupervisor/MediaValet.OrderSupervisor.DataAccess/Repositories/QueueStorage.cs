using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using MediaValet.OrderSupervisor.DataAccess.Entities;
using MediaValet.OrderSupervisor.DataAccess.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public class QueueStorage<T> : IQueueStorage<T> where T : QueueEntity
    {
        private readonly IEntityManager<T> _orderManager;
        private readonly QueueClient _queueClient;

        public QueueStorage(IConfiguration configuration, IEntityManager<T> entityManager)
        {
            _orderManager = entityManager;
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            var queueClient = new QueueClient(connectionString, typeof(T).GetCustomAttribute<LabelAttribute>()?.Label);
            queueClient.CreateIfNotExists();

            _queueClient = queueClient;
        }

        public async Task<T> Peek()
        {
            var message = await _queueClient.PeekMessageAsync();
            var entity = JsonConvert.DeserializeObject<T>(message.Value.MessageText);

            return entity;
        }

        public async Task<T> Get()
        {
            var message = await _queueClient.ReceiveMessageAsync();
            if (message.Value == null) return null;

            var entity = JsonConvert.DeserializeObject<T>(message.Value.MessageText);
            entity.QueueId = message.Value.MessageId;
            entity.Receipt = message.Value.PopReceipt;

            return entity;
        }

        public async Task<T> Enqueue(T entity)
        {
            _orderManager.SetEntityId(entity);
            await _queueClient.SendMessageAsync(JsonConvert.SerializeObject(entity));

            return entity;
        }

        public async Task Dequeue(T entity)
        {
            await _queueClient.DeleteMessageAsync(entity.QueueId, entity.Receipt);
        }
    }
}
