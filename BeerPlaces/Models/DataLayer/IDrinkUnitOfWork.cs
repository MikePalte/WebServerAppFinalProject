using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models.DataLayer
{
    public interface IDrinkUnitOfWork
    {
        Repository<Drink> Drink { get; }
        Repository<Category> Category { get; }
        Repository<Bar> Bar { get; }

        void Save();
    }
}
