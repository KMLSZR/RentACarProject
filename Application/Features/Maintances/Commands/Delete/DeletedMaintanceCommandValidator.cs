using FluentValidation;

namespace Application.Features.Maintances.Commands.Delete;

public class DeleteMaintanceCommandValidator : AbstractValidator<DeleteMaintanceCommand>
{
    public DeleteMaintanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}