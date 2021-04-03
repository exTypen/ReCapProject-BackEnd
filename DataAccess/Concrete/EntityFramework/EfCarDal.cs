using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId

                    select new CarDetailDto
                    {
                        CarId = car.CarId,

                        ModelYear = car.ModelYear,

                        Description = car.Description,

                        DailyPrice = car.DailyPrice,

                        ColorId = color.ColorId,

                        ColorName = color.ColorName,

                        BrandName = brand.BrandName,

                        BrandId = brand.BrandId,

                        Images =
                            (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                        
                        Rentals = (from r in context.Rentals where  r.CarId == car.CarId 
                            select r).ToList()

                    };
                return result.ToList();
            }
        }

        
    }
}
