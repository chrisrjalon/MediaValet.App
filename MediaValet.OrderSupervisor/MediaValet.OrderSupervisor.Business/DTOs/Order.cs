using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MediaValet.OrderSupervisor.Business.DTOs
{
    public class Order
    {
        [JsonIgnore]
        public string QueueId { get; set; }
        [JsonIgnore]
        public string Receipt { get; set; }
        public int OrderId { get; set; }
        public int MagicNumber { get; set; }
        public string OrderDetails { get; set; }
    }
}
