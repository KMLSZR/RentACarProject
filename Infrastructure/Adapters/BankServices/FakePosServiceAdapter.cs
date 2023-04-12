using Application.Services.PosService;
using InfraStructure.OutServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Adapters.BankServices;

public class FakePosServiceAdapter:IPosService
{
    public bool PayControl(string carNumber, string cardHolder, string expiredDate, string cvcNumber)
    {
        FakePosService service = new();
        return service.PayControl(carNumber, cardHolder, expiredDate, cvcNumber);

    }
}
