using FluentValidation;

namespace Application.Features.Maintances.Commands.Create;

public class CreateMaintanceCommandValidator : AbstractValidator<CreateMaintanceCommand>
{
    public CreateMaintanceCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
    }
}