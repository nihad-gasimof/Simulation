using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaSimulaiton.DAL;
using ProniaSimulaiton.Models;
using ProniaSimulaiton.ViewModels.Product;
using System.Threading.Tasks;

namespace ProniaSimulaiton.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM vM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(vM);
            }
            ViewBag.Categories = _context.Categories.ToList();
            var category = _context.Categories.FirstOrDefault(x => x.Id == vM.CategoryId);
            Product product = new()
            {
                Name = vM.Name,
                CategoryId = category.Id,
                Category = category,
                ImgUrl = vM.ImgUrl,
                Price = vM.Price,
                Rate = vM.Rate,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            EditProductVM vm = new()
            {
                Id = id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                ImgUrl = product.ImgUrl,
                Price = product.Price,
                Rate = product.Rate

            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EditProductVM vM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(vM);
            }
            ViewBag.Categories = _context.Categories.ToList();

            if (vM != null)
            {

                var product = await _context.Products.Include(x=>x.Category).FirstOrDefaultAsync(x => x.Id == vM.Id);
                product.Name = vM.Name;
                product.Price = vM.Price;
                product.Rate = vM.Rate;
                product.ImgUrl = vM.ImgUrl;
                if (vM.CategoryId != null)
                {
                    product.CategoryId = vM.CategoryId;
                    product.Category = _context.Categories.FirstOrDefault(x => x.Id == vM.CategoryId);
                }
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
            return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product= _context.Products.FirstOrDefault(x=>x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
