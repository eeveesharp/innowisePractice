using FluentValidation;
using Shop.ViewModels.Order;

namespace Shop.Validator
{
    public class OrderValidator : AbstractValidator<AddOrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(c => c.ClientId).GreaterThan(0);
            RuleFor(c => c.ProductId).GreaterThan(0);
            RuleFor(c => c.Quantity).GreaterThan(0);
        }
    }
}
