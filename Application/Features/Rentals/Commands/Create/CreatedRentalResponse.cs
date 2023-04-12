using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Rentals.Commands.Create;

public class CreatedRentalResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
    public string CardNumber { get; set; }
    public string CardHolder { get; set; }
    public string ExpiredDate { get; set; }
    public string CVCNumber { get; set; }
}