using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogsExhibitionsSystem.Managers;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Helpers
{
    public static class DbFiller
    {
        public static async Task FillAsync(this DbManager dbManager)
        {
            await dbManager.AddRangeAsync(Create_DogBreeds());
            await dbManager.AddRangeAsync(Create_DogPedigrees());
            await dbManager.AddRangeAsync(Create_DogHandlers());
            await dbManager.AddRangeAsync(Create_Clubs());
            await dbManager.AddRangeAsync(Create_Rings());
            await dbManager.SaveChangesAsync();

            await dbManager.AddRangeAsync(Create_Experts(dbManager));
            await dbManager.SaveChangesAsync();

            await dbManager.AddRangeAsync(Create_Dogs(dbManager));
            await dbManager.SaveChangesAsync();

            ConnectDogBreedsAndRings(dbManager);
            await dbManager.SaveChangesAsync();

            await dbManager.AddRangeAsync(Create_Rdes(dbManager));
            await dbManager.SaveChangesAsync();

            await dbManager.AddRangeAsync(Create_Medals(dbManager));
            await dbManager.SaveChangesAsync();
        }

        private static IEnumerable<DogBreed> Create_DogBreeds() => new DogBreed[]
        {
            new DogBreed("LabradorRetriever"),
            new DogBreed("GermanShepherd"),
            new DogBreed("GoldenRetriever"),
            new DogBreed("FrenchBulldog"),
            new DogBreed("EnglishBulldog"),
            new DogBreed("Beagle"),
            new DogBreed("Poodle"),
        };

        private static IEnumerable<DogPedigree> Create_DogPedigrees() => new DogPedigree[]
        {
            new DogPedigree(123, "Дуся", "Шарик"),
            new DogPedigree(345, "Герда", "Барсик"),
        };

        private static IEnumerable<DogHandler> Create_DogHandlers() => new DogHandler[]
        {
            new DogHandler("Иванов", "Иван", "Иванович", "MP123123"),
            new DogHandler("Петров", "Петр", "Петрович", "MP345345"),
        };

        private static IEnumerable<Club> Create_Clubs() => new Club[]
        {
            new Club("клуб 1"),
            new Club("клуб 2"),
            new Club("клуб 3"),
        };

        private static IEnumerable<Dog> Create_Dogs(DbManager dbManager)
        {
            var breeds = dbManager.DogBreeds.ToArray();
            var pedigrees = dbManager.DogPedigrees.ToArray();
            var handlers = dbManager.DogHandlers.ToArray();
            var clubs = dbManager.Clubs.ToArray();
            return new Dog[]
            {
                new Dog("Жучка", 5, breeds[0].Id, pedigrees[0].Id, handlers[0].Id, clubs[0].Id, DateTime.Parse("10.10.2020")),
            };
        }

        private static IEnumerable<Expert> Create_Experts(DbManager dbManager)
        {
            var breeds = dbManager.DogBreeds.ToArray();
            var clubs = dbManager.Clubs.ToArray();
            return new Expert[]
            {
                new Expert("Николаев", "Николай", breeds[0].Id, clubs[0].Id),
            };
        } 

        private static IEnumerable<Ring> Create_Rings() => new Ring[]
        {
            new Ring("№1"),
            new Ring("№2"),
            new Ring("№3"),
            new Ring("№4"),
        };

        private static void ConnectDogBreedsAndRings(DbManager dbManager)
        {
            var breeds = dbManager.DogBreeds.Include(x => x.Rings).ToArray();
            var rings = dbManager.Rings.Include(x => x.DogBreeds).ToArray();
            rings.First().DogBreeds.Add(breeds.First());
            dbManager.UpdateRange(rings);
        }

        private static IEnumerable<RingDogExpert> Create_Rdes(DbManager dbManager)
        {
            var rings = dbManager.Rings.ToArray();
            var dogs = dbManager.Dogs.ToArray();
            var experts = dbManager.Experts.ToArray();
            return new RingDogExpert[]
            {
                new RingDogExpert(rings[0].Id, dogs[0].Id, experts[0].Id),
            };
        }

        private static IEnumerable<Medal> Create_Medals(DbManager dbManager)
        {
            var dogs = dbManager.Dogs.ToArray();
            return new Medal[]
            {
                new Medal(MedalTypes.Bronze, dogs[0].Id),
            };
        }
    }
}
