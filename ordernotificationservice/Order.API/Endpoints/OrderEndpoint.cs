namespace Order.API.Endpoints
{
    using MediatR;
    using Order.Application.Commands;
    using Order.Application.DTOs;
    using Order.Application.Interfaces;

    public static class OrderEndpoint
    {
        public static IEndpointRouteBuilder MapOrderEndpoint(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/orders", async (CreateOrderDTO dto, IMediator mediator) =>
            {
                var command = new CreateOrderCommand
                (
                     dto.CustomerName,
                    dto.ProductName,
                    dto.Amount
                );

                var orderId = await mediator.Send(command);

                return Results.Created("/orders/{orderId}", new { OrderId = orderId });
            });

            builder.MapGet("/orders", async (IOrderRepository repository) =>
            {
                var orders = await repository.GetAllAsync();
                return Results.Ok(orders);
            });

            return builder;
        }
    }
}
