namespace Order.Application.Interfaces
{
    using Shared.Contracts.Events;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotificationPublisher
    {
        Task PublishAsync(OrderCreatedEvent orderCreatedEvent);
    }
}
