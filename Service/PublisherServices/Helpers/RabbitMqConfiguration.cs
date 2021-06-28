using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PublisherServices.Helpers
{
    public class RabbitMqConfiguration
    {
#if DEBUG
        public const string RABBIT_MQ_URL = "localhost";
        public const int PORT = 5672;

#else
                public const string RABBIT_MQ_URL = "rabbitmq";
                public const int PORT = 5672;
#endif
    }
}
