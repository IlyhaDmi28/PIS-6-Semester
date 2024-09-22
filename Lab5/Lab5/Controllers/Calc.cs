using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class Calc : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Sum([FromForm] float? x, [FromForm] float? y)
        {
            ViewBag.press = "+";
            ViewBag.x = x;
            ViewBag.y = y;
            if (HttpContext.Request.Method == "POST")
            {
                try
                {
                    if (x == null || y == null) throw new Exception();
                    ViewBag.z = x + y;
                }
                catch
                {
                    ViewBag.Error = "-- ERROR --";
                    ViewBag.z = 0.00f;
                }
            }
            return View("Views/Calc/Index.cshtml");
        }

        public IActionResult Sub([FromForm] float? x, [FromForm] float? y)
        {
            ViewBag.press = "-";
            ViewBag.x = x;
            ViewBag.y = y;
            if (HttpContext.Request.Method == "POST")
            {
                try
                {
                    if (x == null || y == null) throw new Exception();


                    ViewBag.z = x - y;
                }
                catch
                {
                    ViewBag.Error = "-- ERROR --";
                    ViewBag.z = 0.00f;
                }
            }
            return View("Views/Calc/Index.cshtml");
        }

        public IActionResult Mul([FromForm] float? x, [FromForm] float? y)
        {
            ViewBag.press = "*";
            ViewBag.x = x;
            ViewBag.y = y;
            if (HttpContext.Request.Method == "POST")
            {
                try
                {
                    if (x == null || y == null) throw new Exception();

                    ViewBag.z = x * y;
                }
                catch
                {
                    ViewBag.Error = "-- ERROR --";
                    ViewBag.z = 0.00f;
                }
            }
            return View("Views/Calc/Index.cshtml");
        }
        public IActionResult Div([FromForm] float? x, [FromForm] float? y)
        {
            ViewBag.press = "/";
            ViewBag.x = x;
            ViewBag.y = y;
            if (HttpContext.Request.Method == "POST")
            {
                try
                {
                    if (x == null || y == null) throw new Exception();

                    ViewBag.z = x / y;
                }
                catch
                {
                    ViewBag.Error = "-- ERROR --";
                    ViewBag.z = 0.00f;
                }
            }
            return View("Views/Calc/Index.cshtml");
        }
    }
}
