using System.Linq;
using DogsExhibitionsSystem.Bases;
using DogsExhibitionsSystem.Interfaces;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Managers
{
    public class RingManager : BaseManager
    {
        public RingManager(DbManager dbManager) : base(dbManager)
        { }

        public bool AddDogsToRing(Ring ring, params Dog[] dogs)
        {
            if (dogs.Any(d => !ring.DogBreeds.Contains(d.Breed)))
                return false;

            //ring.Rdes.AddRange(dogs);
            UpdateAndSave(ring);
            return true;
        }

        public bool AddExpertsToRing(Ring ring, params Expert[] experts)
        {
            //ring.Rdes.Experts.AddRange(experts);
            UpdateAndSave(ring);
            return true;
        }
    }
}
