using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Models
{
    public class UserList
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose a Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose a team")]
        [MaxLength(50)]
        public string Team { get; set; }

        [Required(ErrorMessage = "Please choose a team")]
        [MaxLength(50)]
        public string Business { get; set; }

    }
}
