using FluentValidation;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.RentStartDate).NotEmpty();
        RuleFor(c => c.RentEndDate).NotEmpty().GreaterThan(c => c.RentStartDate);
        RuleFor(c => c.ReturnDate).NotEmpty();
        RuleFor(c => c.RentStartKilometer).NotEmpty();
        RuleFor(c => c.RentEndKilometer).NotEmpty();
        RuleFor(c => c.CardNumber).NotEmpty().Length(16);

    }
}