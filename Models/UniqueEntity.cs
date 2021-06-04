using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Interfaces;

namespace DogsExhibitionsSystem.Bases
{
    public abstract class UniqueEntity : IUniqueEntity
    {
        [Column("id")]
        public uint Id { get; set; }
    }
}
