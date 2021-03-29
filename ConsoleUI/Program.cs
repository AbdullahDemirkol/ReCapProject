using Business.Concrate;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                ColorId = 3,
                BrandId = 1,
                DailyPrice = 500,
                ModelYear = "2015",
                Description = "Audi R8",
            };
            Console.WriteLine(carManager.Add(car).Message);
            Console.WriteLine("-----------------------------------");
            GoodMethod(carManager);
            Console.WriteLine(carManager.Remove(car).Message);
        }

        private static void GoodMethod(CarManager carManager)
        {
            Console.WriteLine(carManager.GetCarDetailsDto().Message);
            foreach (var item in carManager.GetCarDetailsDto().Data)
            {

                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + item.BrandName);
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + item.ColorName);
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }
        }
    }
}
