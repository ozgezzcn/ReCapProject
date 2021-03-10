using Business.Concrete;
using Core.Entities.Concrete;
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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool action = true;

            while (action)
            {
                Console.WriteLine(
                    "\n\n----------------------- RENT A CAR -----------------------\n\n" + "1. SİSTEME ARAÇ EKLEME\n" + "2. SİSTEMDEN ARAÇ GÜNCELLEME\n" + "3. SİSTEMDEN ARAÇ SİLME\n" + "4. SİSTEMDEKİ ARAÇLARI LİSTELEME\n" +
                    "5. ARAÇLARIN ID'LERİNE GÖRE LİSTELENMESİ\n" + "6. ARAÇLARIN FİYAT ARALIĞINA GÖRE LİSTELENMESİ\n" + "7. ARAÇLARIN MARKA ID'LERİNE GÖRE LİSTELENMESİ\n" + "8. ARAÇLARIN RENK ID'LERİNE GÖRE LİSTELENMESİ\n" +
                    "9. ARAÇLARIN MODEL YILLARINA GÖRE LİSTELENMESİ\n" + "10. SİSTEME KULLANICI EKLEME\n" + "11. SİSTEME MÜŞTERİ EKLEME\n" + "12. SİSTEMDEKİ KULLANICILARIN LİSTESİ\n" + "13. SİSTEMDEKİ MÜŞTERİLERİN LİSTESİ\n" +
                    "14. SİSTEMDEN ARAÇ KİRALAMA\n" + "15. SİSTEMDEKİ ARAÇLARIN KİRALANMA LİSTESİ\n" + "16. ARAÇ TESLİMİ\n" + "17.  ÇIKIŞ\n\n ----------- YUKARIDAKİ İŞLEMLERDEN HANGİSİNİ GERÇEKLEŞTİRMEK İSTİYORSUNUZ? ----------- ");

                int goal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------\n");
                switch (goal)
                {
                    case 1:
                        CarAddition(carManager, brandManager, colorManager);
                        break;
                    case 2:
                        GetAllCarDetails(carManager);
                        CarUpdate(carManager);
                        break;

                    case 3:
                        GetAllCarDetails(carManager);
                        CarDeletion(carManager);
                        break;


                    case 4:
                        GetAllCar(carManager);
                        break;


                    case 5:
                        GetAllCarDetails(carManager);
                        CarById(carManager, brandManager, colorManager);
                        break;

                    case 6:
                        CarByDailyPrice(carManager, brandManager, colorManager);
                        break;


                    case 7:
                        GetAllBrand(brandManager);
                        CarListByBrand(carManager);
                        break;


                    case 8:
                        GetAllColor(colorManager);
                        CarListByColor(carManager);
                        break;


                    case 9:
                        GetAllCarDetails(carManager);
                        CarByModelYear(carManager, brandManager, colorManager);
                        break;

                    case 10:
                        UserAddition(userManager);
                        break;

                    case 11:
                        GetAllUserList(userManager);
                        CustomerAddition(customerManager);
                        break;

                    case 12:
                        GetAllUserList(userManager);
                        break;

                    case 13:
                        GetAllCustomerList(customerManager);
                        break;

                    case 14:
                        GetAllCarDetails(carManager);
                        GetAllCustomerList(customerManager);
                        RentalAddition(rentalManager);
                        break;

                    case 15:
                        GetAllRentalDetailList(rentalManager);
                        break;

                    case 16:
                        ReturnRental(rentalManager);
                        break;

                    case 17:
                        action = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;
                }
            }
        }

        private static void GetAllRentalDetailList(RentalManager rentalManager)
        {
            Console.WriteLine("Sistemden Kiralanan Araçların Listesi: \nId\tCar Name\tCustomer Name\tRent Date\tReturn Date");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.CustomerName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void ReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("Kiraladığınız Araç Hangi Car Id Değerine Sahiptir?");
            int carId = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetails(I => I.CarId == carId);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Message);
            }
        }

        private static void RentalAddition(RentalManager rentalManager)
        {
            Console.WriteLine("Car Id: ");
            int carIdAdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int customerIdAdd = Convert.ToInt32(Console.ReadLine());

            Rental rentalAdd = new Rental
            {
                CarId = carIdAdd,
                CustomerId = customerIdAdd,
                RentDate = DateTime.Now,
                ReturnDate = null
            };
            Console.WriteLine(rentalManager.Add(rentalAdd).Message);
        }

        private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Color Listesi");
            GetAllColor(colorManager);

            Console.WriteLine("Brand Listesi");
            GetAllBrand(brandManager);

            Console.WriteLine("\nBrand Id: ");
            int brandIdAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorIdAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Car Type: ");
            string carTypeAdd = Console.ReadLine();

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceAdd = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Model Year: ");
            string modelYearAdd = Console.ReadLine();

            Console.WriteLine("Description : ");
            string descriptionAdd = Console.ReadLine();

            Car carAdd = new Car { BrandId = brandIdAdd, ColorId = colorIdAdd, CarType = carTypeAdd, DailyPrice = dailyPriceAdd, ModelYear = modelYearAdd, Description = descriptionAdd };
            carManager.Add(carAdd);
        }

        private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi  Aracı Görmek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz.");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nId Değeri {carId} Olan Araç: \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");
            Car carById = carManager.GetById(carId).Data;
            Console.WriteLine($"{carById.Id}\t{colorManager.GetById(carById.ColorId).Data.ColorName}\t\t{brandManager.GetById(carById.BrandId).Data.BrandName}\t\t{carById.CarType}\t\t{carById.DailyPrice}\t\t{carById.ModelYear}\t\t{carById.Description}");

        }

        private static void CarByDailyPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            decimal min = Convert.ToDecimal(Console.ReadLine());
            decimal max = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"\n\nGünlük Fiyat Aralığı {min} İle {max} Olan Araçlar:  \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");

            foreach (var car in carManager.GetCarDetails(I => I.DailyPrice >= min & I.DailyPrice <= max).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandName}\t\t{car.ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }

        private static void CarByModelYear(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi Model Yılına Sahip Aracı Görmek İstiyorsunuz? Lütfen Bir Yıl Giriniz.");
            string modelYearCarList = Console.ReadLine();
            Console.WriteLine($"\n\n Color Id Değeri {modelYearCarList} Olan Araçlar:  \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");

            foreach (var car in carManager.GetCarDetails(I => I.ModelYear == modelYearCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.BrandName}\t\t{car.ColorName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }

        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Sistemdeki Araçların Listesi:  \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}\t{car.BrandId}\t\t{car.ColorId}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("Sistemdeki Araçların Detaylı Listesi: \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }
        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Listesi: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.Password}");
            }
        }
        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("Müşteri Listesi: \nId\tKullanıcı Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.Id}\t{customer.UserId}\t{customer.CustomerName}");
            }
        }
        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}\t{brand.BrandName}");
            }
        }
        private static void CarListByBrand(CarManager carManager)
        {
            Console.WriteLine("Hangi Markaya Sahip Aracı Görmek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz.");
            int brandIdCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nBrand Id Değeri {brandIdCarList} Olan Araçlar: \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");

            foreach (var car in carManager.GetCarDetails(I => I.BrandId == brandIdCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }
        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id}\t{color.ColorName}");
            }
        }
        private static void CarListByColor(CarManager carManager)
        {
            Console.WriteLine("Hangi Renge Sahip Aracı Görmek İstiyorsunuz? Lütfen Bir Id Değeri Giriniz.");
            int colorIdCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nColor Id Değeri {colorIdCarList} Olan Araçlar: \nId\tColor Name\tBrand Name\tCar Type\tDaily Price\tModel Year\tDescription");

            foreach (var car in carManager.GetCarDetails(I => I.ColorId == colorIdCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.CarType}\t\t{car.DailyPrice}\t\t{car.ModelYear}\t\t{car.Description}");
            }
        }
        private static void CarDeletion(CarManager carManager)
        {
            Console.WriteLine("Hangi Id Değerine Sahip Aracı Sistemden Silmek İstiyorsunuz? ");
            int carIdDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(carIdDelete).Data);
        }
        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("\nCar Id: ");
            int carIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nBrand Id: ");
            int brandIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Car Type: ");
            string carTypeUpdate = Console.ReadLine();

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceUpdate = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Model Year: ");
            string modelYearUpdate = Console.ReadLine();

            Console.WriteLine("Description : ");
            string descriptionUpdate = Console.ReadLine();

            Car carUpdate = new Car { Id = carIdUpdate, BrandId = brandIdUpdate, ColorId = colorIdUpdate, CarType = carTypeUpdate, DailyPrice = dailyPriceUpdate, ModelYear = modelYearUpdate, Description = descriptionUpdate };
            carManager.Add(carUpdate);

        }
        private static void UserAddition(UserManager userManager)
        {
            Console.WriteLine("First Name: ");
            string userNameAdd = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string userSurnameAdd = Console.ReadLine();
            Console.WriteLine("Email Name: ");
            string userEmailAdd = Console.ReadLine();
            Console.WriteLine("Password Name: ");
            string userPasswordAdd = Console.ReadLine();

            User userAdd = new User
            {
                FirstName = userNameAdd,
                LastName = userSurnameAdd,
                Email = userEmailAdd,
                Password = userPasswordAdd

            };
            userManager.Add(userAdd);
        }
        private static void CustomerAddition(CustomerManager customerManager)
        {
            Console.WriteLine("User Id: ");
            int userIdAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Customer Name: ");
            string customerNameAdd = Console.ReadLine();

            Customer customerAdd = new Customer
            {
                UserId = userIdAdd,
                CustomerName = customerNameAdd
            };
            customerManager.Add(customerAdd);
        }
    }
}