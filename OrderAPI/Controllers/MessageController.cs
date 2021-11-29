using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IPublishEndpoint publisherProvider;
        public MessageController(IPublishEndpoint publisher_provider)
        {
            this.publisherProvider = publisher_provider;
        }

        [HttpPost]
        public async Task<IActionResult> sendMessage()
        {
            await publisherProvider.Publish<Order>(new Order()
            {
                CustomerId = 1,
                Price = 10,
                Id = 1,
                ProccessDateTime = DateTime.Now,
                ProductId = 1
            });

            return Ok(true);
        }
    }
}
