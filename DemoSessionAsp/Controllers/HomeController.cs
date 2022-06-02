using DemoSessionAsp.Infrastructure;
using DemoSessionAsp.Models;
using DemoSessionAsp.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSessionAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, SessionManager sessionManager)
        {
            _logger = logger;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            _sessionManager.Courriel = "thierry.morre@cognitic.be";
            _sessionManager.AddIntoBasket("Test1");
            _sessionManager.AddIntoBasket("Test2");
            _sessionManager.AddIntoBasket("Test3");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBasket(BasketForm form)
        {
            if (!ModelState.IsValid)
                return View("Privacy", form);

            _sessionManager.AddIntoBasket(form.Value!);
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}