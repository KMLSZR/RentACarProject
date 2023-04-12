using FluentValidation;

namespace Application.Features.Maintances.Commands.Update;

public class UpdateMaintanceCommandValidator : AbstractValidator<UpdateMaintanceCommand>
{
    public UpdateMaintanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.ReturnDate).NotEmpty();
    }
}