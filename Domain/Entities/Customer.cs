using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer : Entity<int>
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string NationalId { get; set; }
    public int BirthYear { get; set; }
    public ICollection<Rental> Rentals { get; set; }

    public Customer()
    {

    }
    public Customer(int id, int userId, string nationalId, int birthYear) : this()
    {
        Id = id;
        UserId = userId;
        NationalId = nationalId;
        BirthYear = birthYear;
    }


}

