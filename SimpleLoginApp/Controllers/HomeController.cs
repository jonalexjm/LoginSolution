using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SimpleLoginApp.Helpers;
using SimpleLoginApp.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataContext _datacontext;


        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _datacontext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

  

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
