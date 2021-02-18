using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Helpers;

namespace MediaValet.OrderSupervisor.DataAccess.Entities
{
    /// <summary>
    /// Contain details of an order
    /// </summary>
    [Label("orders")]
    public class Order : QueueEntity
    {
        /// <summary>
        /// Unique identity of an order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Random number between 1-10.
        /// </summary>
        public int RandomNumber { get; set; }

        /// <summary>
        /// Details of an order.
        /// </summary>
        public string OrderText { get; set; }

        public override void SetEntityId(int id)
        {
            OrderId = id;
        }
    }
}
