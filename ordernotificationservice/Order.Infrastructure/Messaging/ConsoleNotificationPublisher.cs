namespace Order.Infrastructure.Messaging
{
    using Microsoft.Extensions.Logging;
    using Order.Application.Interfaces;
    using Shared.Contracts.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleNotificationPublisher : INotificationPublisher
    {
        private readonly ILogger<ConsoleNotificationPublisher> _logger;

        public ConsoleNotificationPublisher(ILogger<ConsoleNotificationPublisher> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync(OrderCreatedEvent orderCreatedEvent)
        {
            _logger.LogInformation("Notification: order created. OrderId: {orderId}, Customer : {customer}, Product:{product}, Amount:{amount}", orderCreatedEvent.OrderId, orderCreatedEvent.CustomerName, orderCreatedEvent.ProductName, orderCreatedEvent.Amount);

            return Task.CompletedTask;
        }
    }
}
