using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerPlaces.Models;
using BeerPlaces.Models.DataLayer;

namespace BeerPlaces.Controllers
{
    public class HomeController: Controller
    {
        private Repository<Drink> drinks { get; set; }
              public HomeController(DrinkFinderContext ctx) => drinks = new Repository<Drink>(ctx);
        

        public IActionResult Index() {
            var options = new QueryOptions<Drink>
            {
                OrderBy = c => c.Id
            };
            return View(drinks.List(options));
        }

       
       
    }
}
