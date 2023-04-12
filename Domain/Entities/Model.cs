using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model : Entity<int>
{
    public int BrandId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public virtual Brand? Brand { get; set; }
    public virtual Transmission? Transmission { get; set; }
    public virtual Fuel? Fuel { get; set; }


    public Model()
    {

    }

    public Model(int id, int brandId,int transmissionId,int fuelId, string name, double dailyPrice, string imageUrl) : this()
    {
        Id = id;
        BrandId = brandId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
        TransmissionId = transmissionId;
        FuelId= fuelId;

    }


}
