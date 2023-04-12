using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDto
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public string BrandName { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
}
