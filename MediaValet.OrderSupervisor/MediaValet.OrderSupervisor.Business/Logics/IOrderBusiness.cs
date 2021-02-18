using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.Business.DTOs;

namespace MediaValet.OrderSupervisor.Business.Logics
{
    public interface IOrderBusiness
    {

        Task<Order> AddOrder(string orderDetails);
        Task RemoveOrder(Order order);
        Task<Order> GetOrder();
    }
}
