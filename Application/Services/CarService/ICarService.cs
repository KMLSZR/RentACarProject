﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CarService;
public interface ICarService
{
    public Task<Car> GetById(int id);
    public Task<Car> Update(Car car);
}
