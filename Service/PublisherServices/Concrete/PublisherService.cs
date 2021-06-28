using Entities.Concrete.RabbitMq;
using Entities.Request;
using Infrastructure.Aspects.Autofac.Exception;
using Infrastructure.CrossCuttingConcerns.Logging.ElasticSearch;
using Infrastructure.Utilities.Results;
using RabbitMQ.Client;
using Service.PublisherServices.Abstract;
using Service.PublisherServices.Helpers;
using Service.PublisherServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.PublisherServices.Concrete
{
    public class PublisherService : PublisherServiceBase
    {
        public PublisherService() 
        {

        }
        
    }
}
