using BeerPlaces.Models;
using BeerPlaces.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Controllers
{
    public class DrinkController : Controller
    {

        private DrinkUnitOfWork data { get; set; }
        public DrinkController(DrinkContext ctx)
        {
            data = new DrinkUnitOfWork(ctx);
        }

        public ViewResult Drink()
        {
            var options = new QueryOptions<Drink>
            {
                OrderBy = c => c.Id,
                Includes = "Category, Bar"
            };
            return View(data.Drink.List(options));
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Categories = data.Category.List(new QueryOptions<Category>
            {
                OrderBy = c => c.Name
            });
            ViewBag.Bars = data.Bar.List(new QueryOptions<Bar>
            {
                OrderBy = b => b.Name
            });
            ViewBag.Title = "Add";
            return View();
        }

       

        [HttpPost]
        public IActionResult Add(Drink drink)
        {
            if (ModelState.IsValid)
            {
                if (drink.Id == 0)
                    data.Drink.Insert(drink);
                else
                    data.Drink.Update(drink);
                data.Save();
                return RedirectToAction("Drink", "Drink");
            }
            else
            {
                ViewBag.Title = "Add";
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var drink = this.GetDrink(id);
            return View(drink);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Drink drink)
        {
            data.Drink.Delete(drink);
            data.Save();
            return RedirectToAction("Drink", "Drink");
        }

        private Drink GetDrink(int id)
        {
            var drinkOptions = new QueryOptions<Drink>
            {
                Includes = "Category, Bar",
                Where = drink => drink.Id == id
            };
            var list = data.Drink.Get(drinkOptions);

            return list;
        }
      
    }
}