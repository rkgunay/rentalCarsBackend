using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aşağıdaki AddColorsAndBBrands fonksiyonu, veritabanına brand ve color eklemek için bir kere çalıştırıldı.
            //veritabanında id'leri otomatik artacak şekilde verdim. Bu yüzden ayrıca id belirtmeme gerek yok
            //AddColorsAndBrands();

            TestBrands();
            TestColors();
            TestCars();

        }

        private static void TestCars()
        {
            Car car1 = new Car
            {
                Name = "Honda 5.Seri",
                BrandId = 1,
                ColorId = 4,
                DailyPrice = 1590,
                Description = "OTV indirimli araçlar, uygun ödeme şartları.",
                ModelYear = "2021"
            };
            Car car2 = new Car
            {
                Name = "Audi 3.Seri",
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 1100,
                Description = "Honda Civic ailesinin en yeni üyesi. ",
                ModelYear = "2021"
            };

            Console.WriteLine("Honda 5.Seri ve Audi 3.Seri Geldiyse GetAll() ve Add() başarılı.");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            carManager.Add(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("En sondaki Audi 4.Seri olduysa Update() başarılı.");
            car1.Name = "Audi 4.Seri";
            carManager.Update(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("Audi 4.Seri gittiyse Delete() başarılı.");
            carManager.Delete(car2);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("Honda 5.Seri geldiyse GetById() başarılı.");
            Console.WriteLine(carManager.GetById(1).Name);


            Console.WriteLine("Eğer tüm arabalar renk ve marka ismi ile gelmişse GetCarDetails() başarılı.");
            foreach (var carDetails in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetails.Name);
                Console.WriteLine(carDetails.BrandName);
                Console.WriteLine(carDetails.ColorName);
                Console.WriteLine(carDetails.DailyPrice);
            }
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.Name);
            //}
            //foreach (var car in carManager.GetCarsByColorId(4))
            //{
            //    Console.WriteLine(car.Name);
            //    Console.WriteLine(car.ColorId);
            //}
        }

        //7 renk ve 7 markayı veritabanına ekleyen fonksiyon
        private static void AddColorsAndBrands()
        {
            Brand brand1 = new Brand() { BrandName = "Honda" };
            Brand brand2 = new Brand() { BrandName = "Audi" };
            Brand brand3 = new Brand() { BrandName = "Mercedes" };
            Brand brand4 = new Brand() { BrandName = "BMW" };
            Brand brand5 = new Brand() { BrandName = "Chevrolet" };
            Brand brand6 = new Brand() { BrandName = "Rolce Royce" };
            Brand brand7 = new Brand() { BrandName = "Range Rover" };

            Color color1 = new Color() { ColorName = "Beyaz" };
            Color color2 = new Color() { ColorName = "Sarı" };
            Color color3 = new Color() { ColorName = "Kırmızı" };
            Color color4 = new Color() { ColorName = "Siyah" };
            Color color5 = new Color() { ColorName = "Lacivert" };
            Color color6 = new Color() { ColorName = "Yeşil" };
            Color color7 = new Color() { ColorName = "Pembe" };

            List<Brand> brands = new List<Brand> { brand1, brand2, brand3, brand4, brand5, brand6, brand7 };
            List<Color> colors = new List<Color> { color1, color2, color3, color4, color5, color6, color7 };

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var brand in brands)
            {
                brandManager.Add(brand);
            }
            foreach (var color in colors)
            {
                colorManager.Add(color);
            }
        }

        private static void TestBrands()
        {
            Console.WriteLine("Markalar geldiyse GetAll() başarılı.");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("En alta 'Citren' geldiyse  Add() başarılı.");
            Brand brand8 = new Brand() { BrandName = "Citren" };
            brandManager.Add(brand8);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("En alttaki 'Citroen' olduysa Update() başarılı.");
            brand8.BrandName = "Citroen";
            brandManager.Update(brand8);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("En alttaki 'Citroen' gittiyse Delete() başarılı.");
            brandManager.Delete(brand8);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("Aşağıya 'Range Rover' yazdıysa GetById() başarılı.");
            Console.WriteLine(brandManager.GetById(7).BrandName);

        }

        private static void TestColors()
        {
            Console.WriteLine("Renkler geldiyse GetAll() başarılı.");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("En alta 'Tuncu' geldiyse Add() başarılı.");
            Color color8 = new Color() { ColorName = "Tuncu" };
            colorManager.Add(color8);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("En alttaki 'Turuncu' olduysa Update() başarılı.");
            color8.ColorName = "Turuncu";
            colorManager.Update(color8);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("En alttaki 'Turuncu' gittiyse Delete() başarılı.");
            colorManager.Delete(color8);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("Aşağıya 'Pembe' yazdıysa GetById() başarılı.");
            Console.WriteLine(colorManager.GetById(7).ColorName);

        }


    }

   
}
