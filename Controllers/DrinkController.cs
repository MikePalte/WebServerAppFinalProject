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

        private Repository<Drink> Drinks { get; set; }
        public DrinkController(DrinkFinderContext ctx) => Drinks = new Repository<Drink>(ctx);

        public ViewResult Drink()
        {
            var options = new QueryOptions<Drink>
            {
                OrderBy = c => c.Id
            };
            return View(Drinks.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Drink drink)
        {
            if (ModelState.IsValid)
            {
                Drinks.Insert(drink);
                Drinks.Save();
                return RedirectToAction("Drink");
            }
            else
            {
                return View(drink);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(Drinks.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Drink drink)
        {
            Drinks.Delete(drink);
            Drinks.Save();
            return RedirectToAction("Drink");
        }
    }
}
