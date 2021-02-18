using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaValet.OrderSupervisor.Business.Logics;

namespace MediaValet.Agent
{
    public class App
    {
        private readonly IOrderBusiness _orderBusiness;
        private readonly Guid _agentId;
        private readonly int _magicNumber;

        public App(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
            _agentId = Guid.NewGuid();
            _magicNumber = new Random().Next(1, 11);
        }

        public async Task Run()
        {
            Console.WriteLine($"I'm agent {_agentId}, my magic number is {_magicNumber}");
            while (true)
            {
                var order = await _orderBusiness.GetOrder();
                if (order == null) continue;

                Console.WriteLine($"Received order {order.OrderId}");

                // Send confirmation here

                await _orderBusiness.RemoveOrder(order);
                if (order.MagicNumber != _magicNumber) continue;
                Console.WriteLine("Oh no, my magic number was found");
                break;
            }

            Console.ReadLine();
        }

    }
}
