using Business.Concrate;
using DataAccess.Concrate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + brandManager.GetByBrand(item));
                Console.WriteLine("Rengi:" + colorManager.GetByColor(item));
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }
        }
    }
}
