using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal
    {
   /* public class InMemoryColorDal : IColorDal
    
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color(){Id=1, ColorName="Siyah"},
                new Color(){Id=2, ColorName="Gri"},
                new Color(){Id=3, ColorName="Beyaz"},
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(int ıd)
        {
            var colorToDelete = _colors.SingleOrDefault(b => b.Id == ıd);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }
        public void Update(Color color)
        {
            var colorToUpdate = _colors.SingleOrDefault(b => b.Id == color.Id);
            colorToUpdate.ColorName = color.ColorName;
        } */
    }
}
