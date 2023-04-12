using Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto 
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindeksCreditRate { get; set; }
}