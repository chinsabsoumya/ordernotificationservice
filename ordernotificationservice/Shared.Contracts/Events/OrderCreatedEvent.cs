namespace Shared.Contracts.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record OrderCreatedEvent(
    Guid OrderId,
    string CustomerName,
    string ProductName,
    decimal Amount);
}
