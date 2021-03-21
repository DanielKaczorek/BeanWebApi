using BeanWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi.Controllers
{
    [ApiController]
    public class BeanOfTheDayController : ControllerBase
    {
        private IBeanData _beanData;
        public BeanOfTheDayController(IBeanData beanData)
        {
            _beanData = beanData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBean()
        {
            return Ok(_beanData.GetBeanOfTheDay());
        }
        [HttpGet]
        [Route("api/[controller]/all")]
        public IActionResult GetAllBeans()
        {
            return Ok(_beanData.GetAllBeansOfTheDay());
        }
        [HttpPost]
        [Route("api/[controller]/addbean")]
        public IActionResult Addbean(BeanOfTheDay bean)
        {
            return Ok(_beanData.AddBeanOfTheDay(bean));
        }
        [HttpDelete]
        [Route("api/[controller]/removebean/{id}")]
        public IActionResult RemoveBean(int id)
        {
            return Ok(_beanData.DeleteBeanOfTheDay(id));
        }
    }
}
