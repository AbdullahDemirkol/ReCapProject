using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryColorDal:IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Green"},
                new Color{ColorId=2,ColorName="Red"},
                new Color{ColorId=3,ColorName="Gray"},
                new Color{ColorId=4,ColorName="Black"}
            };
                
        }

        public string GetByColor(Car car)
        {
            return _colors.FirstOrDefault(p=>p.ColorId==car.ColorId).ColorName;
        }
    }
}
