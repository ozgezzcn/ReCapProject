using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            bool action = true;

            while(action)
            {
                Console.WriteLine(
                    "\n\n----------------------- RENT A CAR -----------------------\n\n" + "1. SİSTEME ARAÇ EKLEME\n" + "2. SİSTEMDEN ARAÇ GÜNCELLEME\n" + "3. SİSTEMDEN ARAÇ SİLME\n" + "4. SİSTEMDEKİ ARAÇLARI LİSTELEME\n" +
                    "5. ARAÇLARIN ID'LERİNE GÖRE LİSTELENMESİ\n" + "6. ARAÇLARIN FİYAT ARALIĞINA GÖRE LİSTELENMESİ\n" + "7. ARAÇLARIN MARKA ID'LERİNE GÖRE LİSTELENMESİ\n" + "8. ARAÇLARIN RENK ID'LERİNE GÖRE LİSTELENMESİ\n" +
                    "9. ARAÇLARIN FİYAT ARALIĞINA GÖRE LİSTELENMESİ\n" + "10. ÇIKIŞ\n\n ----------- YUKARIDAKİ İŞLEMLERDEN HANGİSİNİ GERÇEKLEŞTİRMEK İSTİYORSUNUZ? ----------- ");

                int goal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------\n");
                switch (goal)
                {
                    case 1:
                        Console.WriteLine("Color List");
                        GetAllColor(colorManager);

                        Console.WriteLine("Brand List");
                        GetAllBrand(brandManager);

                        Console.WriteLine("\n Brand Id : ");
                        int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id: ");
                        int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Car Type :");
                        string carTypeForAdd = Console.ReadLine();

                        Console.WriteLine("Daily Price: ");
                        decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Model Year: ");
                        string modelYearForAdd = Console.ReadLine();

                        Console.WriteLine("Description : ");
                        string descriptionForAdd = Console.ReadLine();

                        Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, CarType = carTypeForAdd, DailyPrice = dailyPriceForAdd, ModelYear = modelYearForAdd, Description = descriptionForAdd };
                        carManager.Add(carForAdd);
                        break;


                    case 2:
                        GetAllCarDetails(carManager);

                        Console.WriteLine("Car Id :");
                        int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Brand Id: ");
                        int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Color Id: ");
                        int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Car Type :");
                        string carTypeForUpdate = Console.ReadLine();

                        Console.WriteLine("Daily Price: ");
                        decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Model Year: ");
                        string modelYearForUpdate = Console.ReadLine();

                        Console.WriteLine("Description : ");
                        string descriptionForUpdate = Console.ReadLine();

                        Car carForUpdate = new Car {CarId = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUpdate, CarType = carTypeForUpdate, DailyPrice = dailyPriceForUpdate, ModelYear = modelYearForUpdate, Description = descriptionForUpdate };
                        carManager.Add(carForUpdate);
                        break;


                    case 3:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Hangi Id'ye Sahip Aracı Silmek İstiyorsunuz? ");
                        int carIdForDelete = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(carManager.GetById(carIdForDelete));
                        break;


                    case 4:
                        Console.WriteLine("Arabaların Listesi:  \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription");
                        GetAllCar(carManager);
                        break;


                    case 5:
                        GetAllCarDetails(carManager);
                        Console.WriteLine("Sistemdeki Hangi Aracı Görüntülemek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz! ");
                        int carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\n Id Değeri {carId} Olan Araç : \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription");
                        Car carById = carManager.GetById(carId);
                        Console.WriteLine($"{carById.CarId}\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{carById.CarType}\t\t{carById.DailyPrice}\t\t{carById.ModelYear}\t\t{carById.Description}");
                        break;

                    case 6:
                        decimal min = Convert.ToDecimal(Console.ReadLine());
                        decimal max = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine($"\n\n Günlük Fiyat Aralığı {min} ile {max} Olan Araçlar : \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription");
                        foreach (var car in carManager.GetByDailyPrice(min,max))
                        {
                            Console.WriteLine($"{car.CarId}\t{brandManager.GetById(car.BrandId).BrandName}\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
                        }
                        break;


                    case 7:
                        GetAllBrand(brandManager);
                        Console.WriteLine("Sistemdeki Hangi Aracı Görüntülemek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz!");
                        int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\n Brand Id Değeri {brandIdForCarList} Olan Araçlar : \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription ");

                        foreach (var car in carManager.GetAllByBrandId(brandIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{brandManager.GetById(car.BrandId).BrandName}\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
                        }
                        break;


                    case 8:
                        GetAllColor(colorManager);
                        Console.WriteLine("Sistemdeki Hangi Renge Sahip Aracı Görüntülemek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz!");
                        int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nColor Id Değeri {colorIdForCarList} Olan Araçlar : \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription ");

                        foreach (var car in carManager.GetAllByColorId(colorIdForCarList))
                        {
                            Console.WriteLine($"{car.CarId}\t{brandManager.GetById(car.BrandId).BrandName}\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
                        }
                        break;


                    case 9:
                         min = Convert.ToDecimal(Console.ReadLine());
                         max = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine($"\n\n Günlük Fiyat Aralığı {min} ile {max} Olan Araçlar : \nId\tBrand Name\tColor Name\tCar Type\tDaily Price\tModel Year\tDescription ");
                        foreach (var car in carManager.GetByDailyPrice(min,max))
                        {
                            Console.WriteLine($"{car.CarId}\t{brandManager.GetById(car.BrandId).BrandName}\t\t{colorManager.GetById(car.ColorId).ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
                        }
                        break;

                    case 10:

                        action = false;
                        Console.WriteLine("Sistemden Çıkış İşleminiz Gerçekleşmiştir.");
                        break;

                }
            }
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandName}\t\t{car.ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandId}\t\t{car.ColorId}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId}\t{color.ColorName}");
            }
        }

    }
}
