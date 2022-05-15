using System.ComponentModel.DataAnnotations;

namespace EditSkillsMatrix.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "50 charachters max my little Cheddar Cheese!!")]
        public string? Team { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "250 charachters max my little Cheddar Cheese!!")]
        public string? Question { get; set; }

     
        [Required]
        [MaxLength(100, ErrorMessage = "Too Long, try shortening the name to under 100 characters")]
        public string? Skill { get; set; }

        public bool? Option1 { get; set; }

        public bool? Option2 { get; set; }
        public bool? Option3 { get; set; }
        public bool? Option4 { get; set; }
        public bool? Option5 { get; set; }
        [Range(1, 250)]
        [Display(Name ="Display Order")]
        public int? DisplayOrder { get; set; }
        public string? User { get; set; }
        public string? Role { get; set; }
        public DateTime DTime { get; set; }

        public Category()
        {
            this.DTime = DateTime.UtcNow;

        }


    }
    


}
