using Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Entities.Concrete;
using Microsoft.Extensions.ObjectPool;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public List<Rental> Rentals { get; set; }
        public int MinFindexPoint { get; set; }

    }
}
