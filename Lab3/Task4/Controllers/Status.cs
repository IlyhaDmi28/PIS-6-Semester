using Microsoft.AspNetCore.Mvc;

namespace Task4.Controllers
{
    public class Status : Controller
    {
        private readonly Random random = new Random();
        public IActionResult S200()
        {
            return StatusCode(random.Next(200, 299));
        }

        public IActionResult S300()
        {
            return StatusCode(random.Next(300, 399));
        }

        public IActionResult S500()
        {
            int result;
            int zero = 0;
            try
            {
                result = 93 / zero;
            }
            catch
            {
                return StatusCode(random.Next(500, 599));
            }

            return StatusCode(200);
        }
    }
}
