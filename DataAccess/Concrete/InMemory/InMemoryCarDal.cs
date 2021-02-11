using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    // public class InMemoryCarDal : ICarDal
    public class InMemoryCarDal
    {
        /*List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                 new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice = 350, ModelYear="2012", CarType="Sedan", Description="Otomatik Dizel"},   // Siyah  Honda Cıvıc
                 new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice = 250, ModelYear="2011", CarType="Hatchback", Description=" Yarı Otomatik Dizel"},  //Gri Opel Astra 
                 new Car{CarId=3, BrandId=3, ColorId=1, DailyPrice = 550, ModelYear="2010", CarType="Sedan", Description="Otomatik Benzin"},   //Siyah Chevrolet Cruze 1.6
                 new Car{CarId=4, BrandId=4, ColorId=3, DailyPrice = 650, ModelYear="2018", CarType="Pick Up", Description="Düz Vites Dizel"},   //Beyaz Volkswagen Amarok 3.0
                 new Car{CarId=5, BrandId=5, ColorId=1, DailyPrice = 1000, ModelYear="2015", CarType="Cabrio", Description="Otomatik Benzin"},  // Siyah BMW 6 Serisi 
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int ıd)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == ıd);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();  
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarType = car.CarType;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        } */
    }
}
