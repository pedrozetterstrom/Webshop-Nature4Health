using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShipperController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShipperController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Shippers.ToList());
        }

        public IActionResult Create()
        {
            Shipper myShipper = new Shipper();

            return View(myShipper);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shipper myShipper)
        {
            if (ModelState.IsValid)
            {
                _context.Shippers.Add(myShipper);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myShipper);
        }

        public IActionResult Edit(int id)
        {
            Shipper shipperToEdit = _context.Shippers.FirstOrDefault(aShipper => aShipper.Id == id);

            return View(shipperToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Shipper myShipper)
        {
            if (ModelState.IsValid)
            {
                _context.Update(myShipper);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myShipper);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Shipper shipperToDelete = await _context.Shippers.FindAsync(id);

            if (shipperToDelete != null)
            {
                ViewBag.ShipperDeleted = $"The Shipper '{shipperToDelete.Name}' was deleted!";

                _context.Shippers.Remove(shipperToDelete);
                await _context.SaveChangesAsync();
            }

            return View("Index", _context.Shippers.ToList());

        }


        [HttpPost]
        public async Task<IActionResult> SearchShipper(string search)
        {
            string filter = "%" + search + "%";
            List<Shipper> shippers = await _context.Shippers.Where( shipper => EF.Functions.Like(shipper.Name, filter)).ToListAsync();

            return View("Index", shippers);

        }



    }
}
