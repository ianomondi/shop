using Microsoft.AspNetCore.Mvc;
using Onlineshop.Data;
using Onlineshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlineshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data = _db.productTypes.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes categoty)
        {
            if (ModelState.IsValid)
            {
                _db.productTypes.Add(categoty);
                await _db.SaveChangesAsync();
                TempData["Save"] = "Product Created Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(categoty);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            
            var category = _db.productTypes.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product Updated Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = _db.productTypes.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ProductTypes category)
        {
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var category = _db.productTypes.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.productTypes.FirstOrDefault(c=>c.Id == id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product type has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

    }
}
