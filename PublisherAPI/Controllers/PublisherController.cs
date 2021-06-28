using Entities.Request;
using Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.PublisherServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpPost("order")]
        public IActionResult OrderListener([FromBody]OrderRequest orderRequest)
        {
            return Ok(_publisherService.OrderPublisher(orderRequest));
        }
    }
}
