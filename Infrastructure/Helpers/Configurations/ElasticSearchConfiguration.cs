using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers.Configurations
{
    public class ElasticSearchConfiguration
    {
#if DEBUG
        public const string Host = "http://localhost:9200";
#else
        public const string Host = "http://elasticsearch:9200";
#endif
    }
}
