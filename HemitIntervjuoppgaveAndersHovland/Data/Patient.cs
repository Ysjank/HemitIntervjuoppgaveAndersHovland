using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HemitIntervjuoppgaveAndersHovland.Data
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Conditions { get; set; }

        public int Age {
            get {
                var now = DateTime.Today;
                var age = now.Year - DateOfBirth.Year;
                if (DateOfBirth.AddYears(age) > now) age--;
                return age;
            }
        }
    }
}
