using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("ring")]
    public class Ring : UniqueEntity
    {
        [Column("number")]
        public string Number { get; set; }

        #region Navigation props
        public virtual List<DogBreed> DogBreeds { get; set; }
        public virtual List<RingDogExpert> Rdes { get; set; }
        #endregion

        public Ring(string number)
        {
            Number = number;
            //DogBreeds = dogBreeds;
        }
    }
}
