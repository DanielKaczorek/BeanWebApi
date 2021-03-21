using BeanWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi
{
    public interface IBeanData
    {
        List<Bean> GetBeans();

        Bean GetBean(int id);

        Bean AddBean(Bean bean);
        BeanOfTheDay AddBeanOfTheDay(BeanOfTheDay bean);

        bool DeleteBeanOfTheDay(int id);

        Bean GetBeanOfTheDay();
        List<BeanOfTheDay> GetAllBeansOfTheDay();

    }
}
