using System;
using FsyaFignya.DataBase.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FsyaFignya.DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<AgeByNameOrCountry> AgeByNameOrCountry { get; set; }

        public DbSet<CountryNato> CountryNato { get; set; }

        public DbSet<FactsAboutDogs> FactsAboutDogs { get; set; }

        public DbSet<InformationAboutBitcoin> InformationAboutBitcoin { get; set; }

        public DbSet<ListOfSeriesTitlesOfTheBigBangTheory> ListOfSeriesTitlesOfTheBigBangTheory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeByNameOrCountry>().HasKey(x => x.Id);
            modelBuilder.Entity<CountryNato>().HasKey(x => x.Id);
            modelBuilder.Entity<FactsAboutDogs>().HasKey(x => x.Id);
            modelBuilder.Entity<InformationAboutBitcoin>().HasKey(x => x.Id);
            modelBuilder.Entity<ListOfSeriesTitlesOfTheBigBangTheory>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

