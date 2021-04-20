﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public string ModelYear { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public List<string> CarImages { get; set; }
    }
}
