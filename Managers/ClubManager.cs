using DogsExhibitionsSystem.Bases;
using DogsExhibitionsSystem.Interfaces;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Managers
{
    public class ClubManager : BaseManager
    {
        public ClubManager(DbManager dbManager) : base(dbManager)
        { }

        public bool AddDogs(Club club, params Dog[] dogs)
        {
            club.Dogs.AddRange(dogs);
            UpdateAndSave(club);
            return true;
        }

        public bool AddExperts(Club club, params Expert[] experts)
        {
            club.Experts.AddRange(experts);
            UpdateAndSave(club);
            return true;
        }

        public bool RemoveExperts(Club club, params Expert[] experts)
        {
            foreach (var expert in experts)
            {
                club.Experts.Remove(expert);
            }
            UpdateAndSave(club);
            return true;
        }
    }
}
