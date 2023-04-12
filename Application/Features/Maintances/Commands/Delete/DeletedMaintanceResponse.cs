using Core.Application.Responses;

namespace Application.Features.Maintances.Commands.Delete;

public class DeletedMaintanceResponse : IResponse
{
    public int Id { get; set; }
}