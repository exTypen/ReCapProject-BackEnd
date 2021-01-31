using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car { Id = 6, BrandId = 4, ColorId = 4, DailyPrice = 30000, ModelYear = 2016, Description = "Deneme" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "\n");
            }

            Console.WriteLine("---------------------------");

            carManager.DeleteById(2);
            Console.WriteLine("ID'si 2 olan araba silindi\n");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "\n");
            }
            Car car1 = new Car{Id = 1, BrandId=10, ColorId=10, DailyPrice= 10, Description= "Bu ürün düzenlendi", ModelYear=2000 };

            carManager.Update(car1);

            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine("\n\n" + car.Description + "\n\n");
            }

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "\n");
            }

        }
    }
}
