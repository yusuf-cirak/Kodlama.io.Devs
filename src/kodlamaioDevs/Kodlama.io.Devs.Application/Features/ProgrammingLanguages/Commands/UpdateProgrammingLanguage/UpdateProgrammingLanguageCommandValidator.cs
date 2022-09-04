using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommandRequest>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(pl => pl.Id).NotEmpty();
        RuleFor(pl => pl.Name).NotEmpty().MinimumLength(1);
    }
}