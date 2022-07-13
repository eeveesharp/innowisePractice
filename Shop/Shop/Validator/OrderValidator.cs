using FluentValidation;
using Shop.ViewModels.Order;

namespace Shop.Validator
{
    public class OrderValidator : AbstractValidator<AddOrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(c => c.ClientViewModel.Name).Length(1, 50);
            RuleFor(c => c.Quantity).GreaterThan(0);
        }
    }
}
