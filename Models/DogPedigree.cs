using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("dogPedigree")]
    public class DogPedigree : UniqueEntity
    {
        [Column("documentNumber")]
        public long DocumentNumber { get; set; }

        [Column("motherName")]
        public string MotherName { get; set; }

        [Column("fatherName")]
        public string FatherName { get; set; }

        #region Navigation props
        public virtual Dog Dog { get; set; }
        #endregion

        public DogPedigree(long documentNumber, string motherName, string fatherName)
        {
            DocumentNumber = documentNumber;
            MotherName = motherName;
            FatherName = fatherName;
        }
    }
}
