using Core.Application.Dtos;

namespace Application.Features.Customers.Queries.GetList;

public class GetListCustomerListItemDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string NationalId { get; set; }
    public int BirthYear { get; set; }
}