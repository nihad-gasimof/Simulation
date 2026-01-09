using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaSimulaiton.DAL;

namespace ProniaSimulaiton.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           var products= _context.Products.Include(x => x.Category).ToList();
            return View(products);
        }
    }
}
