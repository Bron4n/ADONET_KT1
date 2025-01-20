using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ADONET_KT1.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                ViewData["Message"] = "Сообщение не может быть пустым!";
            }
            else
            {
                ViewData["Message"] = $"Вы отправили сообщение: {message}";
            }

            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Greet(string name)
        {
            ViewData["Name"] = name ?? "Гость";
            return View();
        }

    }
}


