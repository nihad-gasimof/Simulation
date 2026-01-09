using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProniaSimulaiton.DAL;
using ProniaSimulaiton.Models;

namespace ProniaSimulaiton.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class CategoryController : Controller
    {
      private readonly  ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            var categories= _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if (category!=null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var category=_context.Categories.FirstOrDefault(c=> c.Id == id);

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var existcategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
                existcategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
