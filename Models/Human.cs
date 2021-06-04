using System.ComponentModel.DataAnnotations.Schema;
using DogsExhibitionsSystem.Interfaces;

namespace DogsExhibitionsSystem.Bases
{
    public class Human
    {
        [Column("surname")]
        public string Surname { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("secondName")]
        public string SecondName { get; set; }

        public Human(string surname, string firstName, string secondName = null)
        {
            Surname = surname;
            FirstName = firstName;
            SecondName = secondName;
        }
    }

    public class UniqueHuman : Human, IUniqueEntity
    {
        [Column("id")]
        public uint Id { get; set; }

        public UniqueHuman(string surname, string firstName, string secondName = null) :
            base(surname, firstName, secondName)
        { }
    }
}
