using Core.Application.Dtos;

namespace Application.Features.Maintances.Queries.GetList;

public class GetListMaintanceListItemDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }
}