using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.RabbitMq
{
    public class BasicPublishModel
    {
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
        public IBasicProperties BasicProperties { get; set; }
        public ReadOnlyMemory<byte> Body { get; set; }
    }
}
