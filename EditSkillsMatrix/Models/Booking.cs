using System.ComponentModel.DataAnnotations;


namespace EditSkillsMatrix.Models
{
    public class Booking
    {

        [Key]
        public int Id { get; set; }


        [Display(Name = "Most recent time")]
        public DateTime MyDate { get; set; }


        [Required]
        [Display(Name = "Choose Activity")]
        public string Activity { get; set; }

        [Required, Display(Name = "Enter Details")]
        public string Details { get; set; }

        [Required, Display(Name = "For How Long in Minutes?")]
        [Range(1, 100000)]
        public int Time { get; set; }

        [Display(Name = "How do you feel?  1 to 10")]
        [Range(1, 10)]
        public int Rating { get; set; }

        public Booking()
        {
            this.MyDate = DateTime.UtcNow;

        }

        

    }
}
