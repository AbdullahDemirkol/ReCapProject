using Business.Concrete;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Core.Entities.Concrete;
using System;
using System.IO;
using Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Security.Hashing;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\mydir.old\myfile.ext";
            string path = @"C:\mydir.old";
            string extension;

            extension = Path.GetExtension(fileName);
            Console.WriteLine("GetExtension('{0}') returns '{1}'",
                fileName, extension);

            extension = Path.GetExtension(path);
            Console.WriteLine("GetExtension('{0}') returns '{1}'",
                path, extension); 
            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
            Console.WriteLine(Guid.NewGuid());
            //RentalTest();
            //CarTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand()
            {
                BrandName = "Nissan",
            };
            Console.WriteLine(brandManager.Add(brand).Message);
            Console.WriteLine("---------------------");
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }
            Console.WriteLine("---------------------");
            Console.WriteLine(brandManager.Delete(brand).Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("Kullanıcı Adı Soyadı:{0} {1}", item.UserFirstName, item.UserLastName);
                Console.WriteLine("Kullanıcı Email Adresi:{0}", item.UserEmail);
                Console.WriteLine("Kullanıcının Kiraladığı Sirket:{0} ", item.CompanyName);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine();
        }

        private static void UserTest()
        {
            byte[] passwordHash, passwordSalt;
            UserManager userManager = new UserManager(new EfUserDal());
            UserForRegisterDto userForRegisterDto = new UserForRegisterDto()
            {
                FirstName = "Hande",
                LastName = "Güler",
                Email = "handegüler@gmail.com",
                Password = "12345678910",
            };
            HashingHelper.CreatePasswordHas(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            Console.WriteLine(userManager.Add(user).Message);
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("Kullanıcı Adı Soyadı:{0} {1}", item.FirstName, item.LastName);
                Console.WriteLine("Kullanıcı Email Adresi:{0}", item.Email);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine(userManager.Delete(user).Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                ColorName = "Yellow",
            };
            Console.WriteLine(colorManager.Add(color).Message);
            Console.WriteLine("---------------------");
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
            Console.WriteLine("---------------------");
            Console.WriteLine(colorManager.Delete(color).Message);
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var item in rentalManager.GetRentalDetailsDto().Data)
            {
                Console.WriteLine("Kiralanan Arabanın Markası {0} --- Model {1} --- Renk {2}", item.BrandName, item.CarDescription, item.ColorName);
                Console.WriteLine("Kiralayan Kişinin Ismi {0} {1}", item.CustomerFirstName, item.CustomerLastName);
                Console.WriteLine("Kiralanılan Firma {0}", item.CompanyName);
                Console.WriteLine("Kiralama Tarihi {0}", item.RentDate);
                Console.WriteLine("Kiralama Süresi Sonu {0}", item.ReturnDate);
                Console.WriteLine("Kiralama Ucreti {0} Tl", item.DailyPrice);
                Console.WriteLine("--------------------------------------------------");
            }
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.Id);
            }
        }
        private static void CarTest()
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
            Console.WriteLine(carManager.GetCarDetailsDto().Message);
            Console.WriteLine("-----------------------------------");
            foreach (var item in carManager.GetCarDetailsDto().Data)
            {
                Console.WriteLine("Model Yılı:" + item.ModelYear);
                Console.WriteLine("Markası:" + item.BrandName);
                Console.WriteLine("Modeli:" + item.Description);
                Console.WriteLine("Rengi:" + item.ColorName);
                Console.WriteLine("Günlük Kiralama Ücreti:" + item.DailyPrice);
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(carManager.Delete(car).Message);
        }
    }
}
