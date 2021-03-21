using BeanWebApi.Data;
using BeanWebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi.Controllers
{

    [ApiController]
    public class BeansController : ControllerBase
    {
        private IBeanData _beanData;
        public BeansController(IBeanData beanData)
        {
            _beanData = beanData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBeans()
        {
            return Ok(_beanData.GetBeans());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBean(int id)
        {
            return Ok(_beanData.GetBean(id));
        }

        [HttpPost]
        [Route("api/[controller]/uploadFile")]
        public IActionResult UploadFile()
        {
            var link = $"https://{Request.Host.Value}/Resources/Images/";
            Guid g = Guid.NewGuid();
            var file = Request.Form.Files[0];
            string extension = file.FileName.Split(".")[1];
            string fName = g.ToString() + $".{extension}";
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, fName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return new JsonResult($"{link}{fName}");
        }


        [HttpPost]
        [Route("api/[controller]/addbean")]
        public IActionResult AddBean(Bean bean)
        {
            return Ok(_beanData.AddBean(bean));
        }
    }
}
