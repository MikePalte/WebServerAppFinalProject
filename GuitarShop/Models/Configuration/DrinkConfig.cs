using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models.Configuration
{
    public class DrinkConfig : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> entity)
        {
            entity.HasData(
               new Drink { Id = 1, Name = "Keystone", BarId = 1, CategoryId = 1 },
               new Drink { Id = 2, Name = "Cinci Red Wine", BarId = 2, CategoryId = 2  },
               new Drink { Id = 3, Name = "Cinci Whiskey", BarId = 3, CategoryId = 3  }
            );
        }
    }

}