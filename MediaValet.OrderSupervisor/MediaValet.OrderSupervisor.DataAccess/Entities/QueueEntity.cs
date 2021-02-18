using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MediaValet.OrderSupervisor.DataAccess.Entities
{
    public abstract class QueueEntity
    {
        [JsonIgnore]
        public string QueueId { get; set; }
        [JsonIgnore]
        public string Receipt { get; set; }
        public abstract void SetEntityId(int id);
    }
}
