using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Car : Entity<int>
{
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindeksCreditRate { get; set; }
    public virtual Model? Model { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
    public virtual ICollection<Maintance> Maintances { get; set; }


    public Car()
    {
        Rentals = new HashSet<Rental>();
        Maintances = new HashSet<Maintance>();
    }

    public Car(int id, int modelId, CarState carState, int kilometer,
        short modelYear, string plate, short minFindeksCreditRate)
    {
        Id = id;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindeksCreditRate = minFindeksCreditRate;
    }
}
