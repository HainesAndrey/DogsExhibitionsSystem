using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("ring_dog_expert")]
    public class RingDogExpert : UniqueEntity
    {
        [Column("id_ring")]
        public uint RingId { get; set; }

        [Column("id_dog")]
        public uint DogId { get; set; }

        [Column("id_expert")]
        public uint ExpertId { get; set; }

        #region Navigation props
        public virtual Ring Ring { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual Expert Expert { get; set; }
        #endregion

        public RingDogExpert(uint ringId, uint dogId, uint expertId)
        {
            RingId = ringId;
            DogId = dogId;
            ExpertId = expertId;
        }
    }
}
