using Core.Application.Responses;

namespace Application.Features.Customers.Commands.Update;

public class UpdatedCustomerResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string NationalId { get; set; }
    public int BirthYear { get; set; }
}