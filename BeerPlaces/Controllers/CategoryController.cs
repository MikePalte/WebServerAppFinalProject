using BeerPlaces.Models;
using BeerPlaces.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace BeerPlaces.Controllers
{
    public class CategoryController : Controller
    {
        private Repository<Category> categories { get; set; }
        public CategoryController(DrinkContext ctx) => categories = new Repository<Category>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOptions<Category>
            {
                OrderBy = c => c.Id
            };
            return View(categories.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Insert(category);
                categories.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(categories.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Category category)
        {
            categories.Delete(category);
            categories.Save();
            return RedirectToAction("Index");
        }
    }
}