namespace MIT.API;

using FluentValidation;
using global::MIT.BL;
public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
{
    public AddCustomerDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(320);
    }
}

public class CreateOrderRequestValidator : AbstractValidator<AddOrderDto>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);

        // If using product IDs only:
        RuleFor(x => x.ProductIds)
            .NotNull().WithMessage("Products are required.")
            .Must(p => p.Count > 0).WithMessage("Order must contain at least one product.");

        // If using items with quantity, use:
        // RuleFor(x => x.Items).NotEmpty();
        // RuleForEach(x => x.Items).SetValidator(new OrderItemDtoValidator());
    }
}

public class OrderProductDtoValidator : AbstractValidator<OrderProduct>
{
    public OrderProductDtoValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0)
            .WithMessage("Quantity must be at least 1.");
    }
}
