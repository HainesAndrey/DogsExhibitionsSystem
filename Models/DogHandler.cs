using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Bases;

namespace DogsExhibitionsSystem.Models
{
    [Table("dogHandler")]
    public class DogHandler : UniqueHuman
    {
        [Column("passportNumber")]
        public string PassportNumber { get; set; }

        #region Navigation props
        public virtual Dog Dog { get; set; }
        #endregion

        public DogHandler(string surname, string firstName, string secondName, string passportNumber) :
            base(surname, firstName, secondName)
        {
            Surname = surname;
            FirstName = firstName;
            SecondName = secondName;
            PassportNumber = passportNumber;
        }
    }
}
