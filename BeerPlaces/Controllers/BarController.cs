using BeerPlaces.Models;
using BeerPlaces.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Controllers
{
    public class BarController : Controller
    {
        private Repository<Bar> bars { get; set; }
        public BarController(DrinkContext ctx) => bars = new Repository<Bar>(ctx);

        public IActionResult Bar()
        {
            var options = new QueryOptions<Bar>
            {
                OrderBy = c => c.Id
            };
            return View(bars.List(options));

        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Bar bar)
        {
            if (ModelState.IsValid)
            {
                bars.Insert(bar);
                bars.Save();
                return RedirectToAction("Bar");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(bars.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Bar bar)
        {
            bars.Delete(bar);
            bars.Save();
            return RedirectToAction("Bar");
        }
    }
}