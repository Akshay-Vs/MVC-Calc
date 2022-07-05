using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Calc()
        {
            return View();
        }
    }
}
