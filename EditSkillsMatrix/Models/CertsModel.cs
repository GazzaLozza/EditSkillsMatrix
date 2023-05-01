using System.ComponentModel.DataAnnotations;

namespace EditSkillsMatrix.Models
{
    public class CertsModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name of the Cert or Award (Required)")]
        [MaxLength(100, ErrorMessage = "Text is too long, try shortening the name to under 100 characters or using the Description field")]
        public string Name { get; set; }

        [Display(Name = "Specific ID for the Cert ot Award (Optional")]
        [MaxLength(100, ErrorMessage = "This can only be 100 characters long")]
        public string Certid { get; set; }

        [Display(Name = "Decription and additional details for Cert or Award (Optional")]
        [MaxLength(500, ErrorMessage = "This can only be 500 characters long")]
        public string Description { get; set; }

    }

}

