namespace Order.Application.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation;
    using Order.Application.Commands;
    using Order.Domain.Entities;

    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().MaximumLength(100);

            RuleFor(c=>c.ProductName) .NotEmpty().MaximumLength(100);

            RuleFor(c => c.Amount).GreaterThan(0);
        }
    }
}
