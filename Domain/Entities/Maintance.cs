using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Maintance : Entity<int>
{
   
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }

    public virtual Car Car { get; set; }

    public Maintance()
    {
    }

    public Maintance(int id,int carId, DateTime date, DateTime returnDate):this()
    {
        Id = id;
        CarId = carId;
        Date = date;
        ReturnDate = returnDate;
    }
}

