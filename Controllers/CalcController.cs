using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalcController : Controller
    {

        public string str = "calc";

        public IActionResult Calc()
        {
            return View();
        }

        public IActionResult ButtonHandler(string btnValue)
        {
            return View("Calc");
        }
    }
}
