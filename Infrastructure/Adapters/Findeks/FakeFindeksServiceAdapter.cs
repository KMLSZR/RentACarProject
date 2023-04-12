using Application.Services.FindeksService;
using InfraStructure.OutServices;

namespace InfraStructure.Adapters.Findeks;

public class FakeFindeksServiceAdapter : IFindeksService
{
    public short GetScore(string nationalityId)
    {
        FakeFindeksService service = new();
        return service.GetFindeksScore(nationalityId);

    }
}
