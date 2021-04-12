using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models.Configuration
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasData(
           new Category { Id = 1, Name = "Beer" },
           new Category { Id = 2, Name = "Wine"},
           new Category { Id = 3, Name = "Whiskey"},
           new Category { Id = 4, Name = "Seltzer"}
        );
    }
}

}