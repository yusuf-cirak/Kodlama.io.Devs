using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.AddProgrammingLanguage;

public sealed class AddProgrammingLanguageCommandValidator:AbstractValidator<AddProgrammingLanguageCommandRequest>
{
    public AddProgrammingLanguageCommandValidator()
    {
        RuleFor(pl => pl.Name).NotEmpty().MinimumLength(2);
    }
}