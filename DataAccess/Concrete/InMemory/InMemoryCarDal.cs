using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000000, ModelYear = 2002, Description = "Beyaz Tofaş"},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 50000, ModelYear = 2012, Description = "Siyah Honda Civic"},
                new Car{Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 80000, ModelYear = 2018, Description = "Siyah Renault Megane"},
                new Car{Id = 4, BrandId = 4, ColorId = 1, DailyPrice = 100000, ModelYear = 2020, Description = "Beyaz Volkswagen Passat"},
                new Car{Id = 5, BrandId = 2, ColorId = 3, DailyPrice = 150000, ModelYear = 2020, Description = "Kırmızı Honda Civic"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void DeleteById(int Id)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(p => p.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
