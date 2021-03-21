using BeanWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi.Data
{
    public class BeanData : IBeanData
    {
        BeanContext _context;
        public BeanData(BeanContext context)
        {
            _context = context;
        }

        public Bean AddBean(Bean bean)
        {
            _context.Bean.Add(bean);
            _context.SaveChanges();
            return bean;
        }

        public BeanOfTheDay AddBeanOfTheDay(BeanOfTheDay bean)
        {
            _context.BeanOfTheDay.Add(bean);
            _context.SaveChanges();
            return bean;
        }

        public bool DeleteBeanOfTheDay(int id)
        {
            BeanOfTheDay b = new BeanOfTheDay() { Id = id };
            _context.BeanOfTheDay.Attach(b);
            _context.BeanOfTheDay.Remove(b);
            _context.SaveChanges();

            return true;
        }

        public Bean GetBean(int id)
        {
            return _context.Bean.FirstOrDefault(x => x.Id == id);
        }

        public Bean GetBeanOfTheDay()
        {
            var bean = _context.BeanOfTheDay.FirstOrDefault(x => x.Date == DateTime.UtcNow.Date);

            if (bean != null)
            {
                var beanData = _context.Bean.FirstOrDefault(x => x.Id == bean.BeanId);

                if (beanData != null)
                {
                    return beanData;
                }
                return null;
            }    
            return null;
        }

        public List<BeanOfTheDay> GetAllBeansOfTheDay()
        {
            return _context.BeanOfTheDay.ToList();
        }

        public List<Bean> GetBeans()
        {
            return _context.Bean.ToList();
        }
    }
}
