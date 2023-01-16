using FluentValidation;
using VetScheduler.Data.Entities;

namespace VetScheduler.Services.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator() 
        {
            RuleFor(x => x.EmailAddress).NotEmpty().NotNull().MaximumLength(100).Matches("^[\\w\\.]+@([\\w\\-]+\\.)+[\\w-]{2,4}$");
            RuleFor(x => x.FullName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100);
        }
    }
}
