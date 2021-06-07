using DogsExhibitionsSystem.Bases;
using DogsExhibitionsSystem.Models;
using System.Collections.Generic;

namespace DogsExhibitionsSystem.Managers
{
    public class DogManager : BaseManager
    {
        public DogManager(DbManager dbManager) : base(dbManager)
        {
        }

        public IEnumerable<Dog> GetDogs() => _dbManager.Dogs;

        public IEnumerable<DogBreed> GetBreeds() => _dbManager.DogBreeds;

        public IEnumerable<DogPedigree> GetPedigrees() => _dbManager.DogPedigrees;

        public IEnumerable<DogHandler> GetHandlers() => _dbManager.DogHandlers;
    }
}
