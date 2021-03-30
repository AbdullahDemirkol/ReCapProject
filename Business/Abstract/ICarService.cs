﻿using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandid);
        IDataResult<List<Car>> GetCarsByColorId(int colorid);
        IResult Add(Car car);
        IResult Remove(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetailsDto();
    }
}