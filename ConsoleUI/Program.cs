using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager= new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 10, BrandName = "Tofaş" });
        }
    }
}
