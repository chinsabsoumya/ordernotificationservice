namespace Order.Application.Handlers
{
    using MediatR;
    using Order.Application.Commands;
    using Order.Application.DTOs;
    using Order.Application.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using INotificationPublisher = Interfaces.INotificationPublisher;
    using Order.Domain.Entities;
    using Shared.Contracts.Events;
    using FluentValidation;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IValidator<CreateOrderCommand> _validator;

        public CreateOrderCommandHandler(IOrderRepository repository, INotificationPublisher notificationPublisher, IValidator<CreateOrderCommand> validator)
        {
            _repository = repository;
            _notificationPublisher = notificationPublisher;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var validation  = _validator.Validate(command);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var order = new Order
            {
                CustomerName = command.CustomerName,
                Amount = command.Amount,
                ProductName = command.ProductName,
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            };

           await _repository.AddAsync(order);

            var orderCreatedEvent = new OrderCreatedEvent(
                order.Id, order.CustomerName, order.ProductName, order.Amount);

           await _notificationPublisher.PublishAsync(orderCreatedEvent);

            return order.Id;
        }
    }
}
