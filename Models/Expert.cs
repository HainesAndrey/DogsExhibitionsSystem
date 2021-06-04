using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("expert")]
    public class Expert : UniqueHuman
    {
        [Column("id_dogBreed")]
        public uint DogBreedId { get; set; }

        [Column("id_club")]
        public uint ClubId { get; set; }

        #region Navigation props
        public virtual DogBreed DogBreed { get; set; }
        public virtual List<RingDogExpert> Rdes { get; set; }
        public virtual Club Club { get; set; }
        #endregion

        public Expert(string surname, string firstName, uint dogBreedId, uint clubId) :
            base(surname, firstName)
        {
            DogBreedId = dogBreedId;
            ClubId = clubId;
        }
    }
}
