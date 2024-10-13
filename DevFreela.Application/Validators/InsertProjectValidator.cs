using DevFreela.Application.Commands.ProjectsCommands.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                    .WithMessage("O Título deve ser preenchido.")
                .MaximumLength(50)
                    .WithMessage("Maximo de 50 caracteres.");

            RuleFor(x => x.TotalCost)
                .NotEmpty()
                    .WithMessage("O Valor deve ser preenchido")
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("O Valor deve ser acima de R$ 1.000");


        }
    }
}
