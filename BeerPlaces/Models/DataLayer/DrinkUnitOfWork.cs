using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models.DataLayer
{
   
    public class DrinkUnitOfWork : IDrinkUnitOfWork
    {
        private DrinkContext context { get; set; }
        public DrinkUnitOfWork(DrinkContext ctx) => context = ctx;
        private Repository<Category> categoryData;
        public Repository<Category> Category
        {
            get
            {
                if (categoryData == null)
                    categoryData = new Repository<Category>(context);
                return categoryData;

            }
        }
        private Repository<Bar> barData;
        public Repository<Bar> Bar
        {
            get
            {
                if (barData == null)
                    barData = new Repository<Bar>(context);
                return barData;

            }
        }

        private Repository<Drink> drinkData;
        public Repository<Drink> Drink
        {
            get
            {
                if (drinkData == null)
                    drinkData = new Repository<Drink>(context);
                return drinkData;

            }
        }


        public void Save() => context.SaveChanges();

    }
}
