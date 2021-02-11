using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryBrandDal : IBrandDal
    public class InMemoryBrandDal
    {
       /* List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand(){Id = 1, BrandName="Honda Cıvıc"},
                new Brand(){Id = 2, BrandName="Opel Astra"},
                new Brand(){Id = 3, BrandName="Chevrolet Cruze"},
                new Brand(){Id = 4, BrandName="Volkswagen Amarok"},
                new Brand(){Id = 5, BrandName="Bmw 6 Serisi"},

            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }
        public void Delete(int ıd)
        {
            var brandToDelete = _brands.SingleOrDefault(b => b.Id == ıd);
            _brands.Remove(brandToDelete);
        }
        public List<Brand> GetAll()
        {
            return _brands;
        }
        public void Update(Brand brand)
        {
            var brandToUpdate = _brands.SingleOrDefault(b => b.Id == brand.Id);
            brandToUpdate.BrandName = brand.BrandName;
        } */
    }
}
