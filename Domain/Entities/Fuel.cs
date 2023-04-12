using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Fuel : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; }

    public Fuel()
    {

    }

    public Fuel(int id, string name) : this()
    {
        Id = id;
        Name = name;

    }

}
