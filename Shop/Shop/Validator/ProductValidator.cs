using FluentValidation;
using Shop.ViewModels.Product;

namespace Shop.Validator
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).Length(1, 50);
            RuleFor(c => c.Price).InclusiveBetween(1, 1500);
            RuleFor(c => c.Quantity).InclusiveBetween(1, 1000);
        }
    }
}
