using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaValet.OrderSupervisor.Business.DTOs;
using DAL = MediaValet.OrderSupervisor.DataAccess.Entities;
using MediaValet.OrderSupervisor.DataAccess.Repositories;

namespace MediaValet.OrderSupervisor.Business.Logics
{
    public class OrderBusiness : BaseBusiness, IOrderBusiness
    {
        public OrderBusiness(IStorageFacade storages, IMapper mapper) : base(storages, mapper)
        {
        }

        public async Task<Order> AddOrder(string orderDetails)
        {
            var rand = new Random();
            var newOrder = await _storages.Queues.Orders.Enqueue(
                new DAL.Order
                    {RandomNumber = rand.Next(1, 11), OrderText = orderDetails});

            return _mapper.Map<Order>(newOrder);
        }

        public async Task RemoveOrder(Order order)
        {
            var orderToDelete = _mapper.Map<DAL.Order>(order);
            await _storages.Queues.Orders.Dequeue(orderToDelete);
        }

        public async Task<Order> GetOrder()
        {
            var order = await _storages.Queues.Orders.Get();
            return order == null ? null : _mapper.Map<Order>(order);
        }
    }
}
