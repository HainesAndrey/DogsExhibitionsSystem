using System.Collections.Generic;
using System.Linq;
using DogsExhibitionsSystem.Bases;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Managers
{
    public class DogManager : BaseManager
    {
        public DogManager(DbManager dbManager) : base(dbManager)
        {
        }

        public IEnumerable<Dog> GetDogs()
        {
            return _dbManager.Dogs.ToArray();
        }
    }
}
