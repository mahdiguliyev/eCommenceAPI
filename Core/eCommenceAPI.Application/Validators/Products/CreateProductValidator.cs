using eCommenceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace eCommenceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull().WithMessage("Please, fill the name field.")
                .MaximumLength(150)
                .MinimumLength(3).WithMessage("Please, enter 3-150 characters for name field.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull().WithMessage("Please, fill the stock field.")
                .Must(s => s >= 0).WithMessage("Stock cannot be a negative number");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull().WithMessage("Please, fill the price field.")
                .Must(p => p >= 0).WithMessage("Price cannot be a negative number");
        }
    }
}
