using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalcController : Controller
    {

        public string str = "calc";

        public IActionResult Calc()
        {
            Models.CalcModel calcModel = new Models.CalcModel()
            {
                Operation = "Calc",
                Result = 0000
            };
            return View();
        }

        public IActionResult ButtonClick(string btnValue)
        {
            return View("Calc");
        }
    }
}
