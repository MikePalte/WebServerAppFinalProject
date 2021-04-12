using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models.Configuration
{
    public class BarConfig : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> entity)
        {
            entity.HasData(
               new Bar { Id = 1, Name = "Uncle Woodys", Address = "Calhoun Street, Cincinati", State = "OH", Zip = "45219" },
               new Bar { Id = 2, Name = "Macs", Address = "West Mcmillian, Cincinnati", State = "OH", Zip = "45219" },
               new Bar { Id = 3, Name = "Top Cats", Address = "Vine St, Cincinnati", State = "OH", Zip = "45219" }
            );
        }
    }

}