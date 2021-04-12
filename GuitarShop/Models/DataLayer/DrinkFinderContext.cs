using BeerPlaces.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerPlaces.Models
{
    public class DrinkFinderContext : DbContext
    {
        public DrinkFinderContext(DbContextOptions<DrinkFinderContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Bar> Bars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BarConfig());
            modelBuilder.ApplyConfiguration(new DrinkConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}