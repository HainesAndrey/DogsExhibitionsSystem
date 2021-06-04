using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("medal")]
    public class Medal : UniqueEntity
    {
        [Column("type")]
        public MedalTypes Type { get; set; }

        [Column("id_dog")]
        public uint DogId { get; set; }

        #region Navigation props
        public virtual Dog Dog { get; set; } 
        #endregion

        public Medal(MedalTypes type, uint dogId)
        {
            Type = type;
            DogId = dogId;
        }
    }

    public enum MedalTypes
    {
        Bronze,
        Silver,
        Gold
    }
}
