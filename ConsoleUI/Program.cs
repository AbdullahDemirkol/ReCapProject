using Business.Concrate;
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
            //InMemory();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Car car = new Car()
            {
                ColorId = 3,
                BrandId = 1,
                DailyPrice = 500,
                ModelYear = 2015,
                Description = "Audi R8",
            };
            carManager.Add(car);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + brandManager.GetByBrand(item));
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + colorManager.GetByColor(item));
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }
        }

        //private static void InMemory()
        //{
        //    CarManager carManager = new CarManager(new InMemoryCarDal());
        //    BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
        //    ColorManager colorManager = new ColorManager(new InMemoryColorDal());
        //    foreach (var item in carManager.GetAll())
        //    {
        //        Console.WriteLine("Model Yılı:" + item.ModelYear);
        //        Console.WriteLine("Markası:" + brandManager.GetByBrand(item));
        //        Console.WriteLine("Rengi:" + colorManager.GetByColor(item));
        //        Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
        //        Console.WriteLine("--------------------");
        //    }
        //}
    }
}
