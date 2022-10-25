using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;

namespace ProjectLexiconWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
    }
}
