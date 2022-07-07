using FluentValidation;
using Shop.ViewModels.Order;

namespace Shop.Validator
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(c => c.ClientName).Length(1, 50);
            RuleFor(c => c.FinalPrice).GreaterThan(1);
        }
    }
}
