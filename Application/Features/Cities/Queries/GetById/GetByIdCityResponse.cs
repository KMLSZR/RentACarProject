using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse:IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
