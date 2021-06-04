using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("dogBreed")]
    public class DogBreed : UniqueEntity
    {
        [Column("name")]
        public string Name { get; set; }

        #region Navigation props
        public virtual List<Dog> Dogs { get; set; }
        public virtual List<Expert> Experts { get; set; }
        public virtual List<Ring> Rings { get; set; }
        #endregion

        public DogBreed(string name)
        {
            Name = name;
        }
    }
}
