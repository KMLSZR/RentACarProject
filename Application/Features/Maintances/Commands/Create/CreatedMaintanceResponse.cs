using Core.Application.Responses;

namespace Application.Features.Maintances.Commands.Create;

public class CreatedMaintanceResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }
}