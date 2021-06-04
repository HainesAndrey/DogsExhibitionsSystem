using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("dog")]
    public class Dog : UniqueEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public uint Age { get; set; }

        [Column("id_dogBreed")]
        public uint BreedId { get; set; }

        [Column("id_dogPedigree")]
        public uint PedigreeId { get; set; }

        [Column("id_dogHandler")]
        public uint HandlerId { get; set; }

        [Column("id_club")]
        public uint ClubId { get; set; }

        [Column("lastVaccinationDate")]
        public DateTime LastVaccinationDate { get; set; }

        #region Navigation props
        public virtual Club Club { get; set; }
        public virtual DogBreed Breed { get; set; }
        public virtual DogPedigree Pedigree { get; set; }
        public virtual DogHandler Handler { get; set; }
        public virtual List<Medal> Medals { get; set; }
        public virtual List<RingDogExpert> Rdes { get; set; }
        #endregion

        public Dog(string name, uint age, uint breedId, uint pedigreeId, uint handlerId, uint clubId, DateTime lastVaccinationDate)
        {
            Name = name;
            Age = age;
            BreedId = breedId;
            PedigreeId = pedigreeId;
            HandlerId = handlerId;
            ClubId = clubId;
            LastVaccinationDate = lastVaccinationDate;
        }
    }
}
