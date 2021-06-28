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

namespace Service.PublisherServices.Abstract
{
    public abstract class PublisherServiceBase : IPublisherService
    {
        protected ConnectionFactory _connectionFactory;
        protected IConnection _connection;
        public PublisherServiceBase()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            if (_connectionFactory == null)
            {
                _connectionFactory = new ConnectionFactory() { HostName = RabbitMqConfiguration.RABBIT_MQ_URL, Port = RabbitMqConfiguration.PORT };
                _connection = _connectionFactory.CreateConnection();
            }
        }
        [ExceptionLogAspect(typeof(ElasticLogger))]
        public virtual IResult OrderPublisher(OrderRequest orderRequest)
        {
            var channel = _connection.CreateModel();

            DeclareQueueInChannel(channel, new QueueDeclareModel
            {
                Arguments = null,
                AutoDelete = false,
                Durable = true,
                Exclusive = false,
                Queue = "Order"
            });

            var properties = DeclareProperties(channel, new BasicPropertiesModel());

            var body = BodyParser(orderRequest);


            BasicPublish(channel, new BasicPublishModel
            {
                Exchange = "",
                BasicProperties = properties,
                Body = body,
                RoutingKey = "Order"
            });

            return new SuccessResult("Transaction is Successfull");
        }

        protected virtual IModel DeclareQueueInChannel(IModel channel, QueueDeclareModel queueDeclareModel)
        {
            channel.QueueDeclare
                (
                queue: queueDeclareModel.Queue,
                durable: queueDeclareModel.Durable,
                exclusive: queueDeclareModel.Exclusive,
                autoDelete: queueDeclareModel.AutoDelete,
                arguments: queueDeclareModel.Arguments
                );
            return channel;
        }
        protected virtual IBasicProperties DeclareProperties(IModel channel, BasicPropertiesModel basicPropertiesModel)
        {
            var properties = channel.CreateBasicProperties();
            properties.Persistent = basicPropertiesModel.Persistense;
            return properties;
        }
        protected virtual void BasicPublish(IModel channel, BasicPublishModel basicPublishModel)
        {
            channel.BasicPublish(exchange: basicPublishModel.Exchange,
                                     routingKey: basicPublishModel.RoutingKey,
                                     basicProperties: basicPublishModel.BasicProperties,
                                     body: basicPublishModel.Body);
        }
        protected virtual ReadOnlyMemory<byte> BodyParser(object model)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(model));
        }
    }
}
