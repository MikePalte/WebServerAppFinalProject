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
       /* public IActionResult Index()
        {
            return View();
        }*/

        private Repository<Drink> drinks { get; set; }
        public DrinkController(DrinkFinderContext ctx) => drinks = new Repository<Drink>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOptions<Drink>
            {
                OrderBy = c => c.Id
            };
            return View(drinks.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Drink drink)
        {
            if (ModelState.IsValid)
            {
                drinks.Insert(drink);
                drinks.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(drink);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(drinks.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Drink drink)
        {
            drinks.Delete(drink);
            drinks.Save();
            return RedirectToAction("Index");
        }
    }
}
