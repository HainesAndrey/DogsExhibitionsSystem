using Microsoft.EntityFrameworkCore;
using DogsExhibitionsSystem.Helpers;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Managers
{
    public class DbManager : DbContext
    {
        private readonly string _dbFilePath;

        public DbSet<DogBreed> DogBreeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogHandler> DogHandlers { get; set; }
        public DbSet<DogPedigree> DogPedigrees { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Ring> Rings { get; set; }
        public DbSet<Medal> Medals { get; set; }

        public DbManager(string dbFilePath) : base()
        {
            _dbFilePath = dbFilePath;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite($"Filename={_dbFilePath}");
        }
    }
}
