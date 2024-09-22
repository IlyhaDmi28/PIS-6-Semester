using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Task2.Controllers
{
    [Route("/it")]
    public class TAResearch : Controller
    {
        [HttpGet]
        [Route("{number:int}/{str}")]
        public IActionResult M04(int number, string str)
        {
            return Content($"GET:M04:/{number}/{str}");
        }

        [HttpGet]
        [HttpPost]
        [Route("{boolean:bool}/{letters:alpha}")]
        public IActionResult M05(bool boolean, string letters)
        {
            return Content($"{HttpContext.Request.Method}:M05:/{boolean}/{letters}");
        }

        [HttpGet]
        [HttpDelete]
        [Route("{floatNumber:float}/{str:length(2,5)}")]
        public IActionResult M06(float floatNumber, string str)
        {
            return Content($"{HttpContext.Request.Method}:M06:/{floatNumber}/{str}");
        }

        [HttpPut]
        [Route("{letters:alpha:length(3,4)}/{number:int:range(100,200)}")]
        public IActionResult M07(int number, string letters)
        {
            return Content($"PUT:MO7:/{letters}/{number}");
        }

        [HttpPost]
        [Route("{email:regex(^\\w+@\\w+\\.\\w+)}")]
        public IActionResult M08(string email)
        {
            return Content($"POST:MO8:/{email}");
        }
    }
}
