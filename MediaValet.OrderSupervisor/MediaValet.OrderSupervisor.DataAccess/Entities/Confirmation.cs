using System;
using System.Collections.Generic;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Helpers;
using Microsoft.Azure.Cosmos.Table;

namespace MediaValet.OrderSupervisor.DataAccess.Entities
{
    /// <summary>
    /// Contain details on the status of an order
    /// </summary>
    [Label("confirmations")]
    public class Confirmation : TableEntity
    {
        public Confirmation(int orderId, Guid agentId)
        {
            RowKey = orderId.ToString();
            PartitionKey = agentId.ToString();
        }

        /// <summary>
        /// Guid of the agent that processed this order.
        /// </summary>
        public Guid AgentId { get; set; }

        /// <summary>
        /// Unique identity of the order being processed.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Status of the order being processed.
        /// </summary>
        public string OrderStatus { get; set; }
    }
}
