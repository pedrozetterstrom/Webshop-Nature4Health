﻿using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Controllers
{
	public class CategoryController : Controller
	{
        private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
            _context = context;
        }

        public IActionResult Index()
		{
			return View(_context.Categories.ToList());
		}

        public IActionResult Create()
        {
            Category myCategory = new Category();

            return View(myCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category myCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(myCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myCategory);
        }

        public IActionResult Edit(int id)
        {
            Category categoryToEdit = _context.Categories.FirstOrDefault(aCategory => aCategory.Id == id);

            return View(categoryToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category categoryToEdit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(categoryToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryToEdit);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category categoryToDelete = await _context.Categories.FindAsync(id);

            if (categoryToDelete != null)
            {
                ViewBag.CategoryDeleted = $"The Category '{categoryToDelete.Name}' was deleted!";

                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }

            return View("Index", _context.Categories.ToList());

        }


    }
}