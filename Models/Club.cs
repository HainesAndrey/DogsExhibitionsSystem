using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("club")]
    public class Club : UniqueEntity
    {
        [Column("name")]
        public string Name { get; set; }

        #region Navigation props
        public virtual List<Expert> Experts { get; set; }
        public virtual List<Dog> Dogs { get; set; }
        #endregion

        public Club(string name)
        {
            Name = name;
        }
    }
}
