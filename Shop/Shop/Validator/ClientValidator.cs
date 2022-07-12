using FluentValidation;
using Shop.ViewModels.Client;

namespace Shop.Validator
{
    public class ClientValidator : AbstractValidator<AddClientViewModel>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name).Length(1, 50);
            RuleFor(c => c.LastName).Length(1, 60);
        }
    }
}
