﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
    }
}
