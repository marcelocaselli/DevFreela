using DevFreela.Application.Commands.UsersCommands.InsertUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertUserValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("Email inválido.");

            RuleFor(x => x.BirthDate)
                .Must(x => x < DateTime.Now.AddYears(18))
                    .WithMessage("Deve ter 18 anos ou mais.");

        }
        

    }
}
