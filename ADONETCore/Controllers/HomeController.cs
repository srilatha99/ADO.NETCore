using ADONETCore.DataLayer;
using ADONETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADONETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CategoryDAL _CategoryDAL = new CategoryDAL();
            List<Categories> CategoryList = new List<Categories>();
            CategoryList = _CategoryDAL.GetAllCategories();
            return View(CategoryList);
        }
        [HttpPost]
        public IActionResult SearchCategory
            (int categoryId)
        {
            CategoryDAL _CategoryDAL = new CategoryDAL();
            List<Categories> CategoryList = new List<Categories>();
            CategoryList = _CategoryDAL.GetCategoryById(categoryId);
            return View("Index",CategoryList);
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