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

public class AddOrderDtoValidator : AbstractValidator<AddOrderDto>
{
    public AddOrderDtoValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);

        RuleFor(x => x.ProductIds)
            .NotNull().WithMessage("Products are required.")
            .Must(p => p.Count > 0).WithMessage("Order must contain at least one product.");


    }
}

