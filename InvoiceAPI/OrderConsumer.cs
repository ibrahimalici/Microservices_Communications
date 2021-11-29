using MassTransit;
using Models;
using System;
using System.Threading.Tasks;

namespace InvoiceAPI
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var resultStr = context.Message.ToString();

            await Console.Out.WriteLineAsync(resultStr);
        }
    }
}