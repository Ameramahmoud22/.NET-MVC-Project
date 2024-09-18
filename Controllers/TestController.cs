using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class TestController : Controller
    {
        public string Display()
        {
            return " Welcome to my first MVC App";
        }

        public int  Add(int x , int y)
        {
            return x+y;
        }
        public ViewResult Show()
        {
            return View();
        }
    }
}
