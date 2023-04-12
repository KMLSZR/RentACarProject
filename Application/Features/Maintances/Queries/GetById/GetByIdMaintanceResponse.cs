using Core.Application.Responses;

namespace Application.Features.Maintances.Queries.GetById;

public class GetByIdMaintanceResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }
}