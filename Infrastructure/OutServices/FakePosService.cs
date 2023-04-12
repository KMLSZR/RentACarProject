using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.OutServices;

public class FakePosService
{

    public bool PayControl(string carNumber, string cardHolder, string expiredDate, string cvcNumber)
    {
        Random rnd = new Random();
        return Convert.ToBoolean(new Random(rnd.Next(2))); ;
    }
}
