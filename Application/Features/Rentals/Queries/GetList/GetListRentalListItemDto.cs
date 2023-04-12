using Core.Application.Dtos;

namespace Application.Features.Rentals.Queries.GetList;

public class GetListRentalListItemDto 
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
}