using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
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
                new Color{ColorId=3,ColorName="Grey"},
                new Color{ColorId=4,ColorName="Black"}
            };
                
        }

        public void Add(Color Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color Entity)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public string GetByColor(Car car)
        {
            return _colors.FirstOrDefault(p=>p.ColorId==car.ColorId).ColorName;
        }

        public void Update(Color Entity)
        {
            throw new NotImplementedException();
        }
    }
}
