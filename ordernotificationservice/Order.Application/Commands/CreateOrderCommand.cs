namespace Order.Application.Commands
{
    using MediatR;
    using Order.Application.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record CreateOrderCommand(
        string CustomerName,
        string ProductName,
        decimal Amount) : IRequest<Guid>;

}
