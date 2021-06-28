using Entities.Request;
using Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PublisherServices.Interfaces
{
    public interface IPublisherService
    {
        IResult OrderPublisher(OrderRequest orderRequest);
    }
}
