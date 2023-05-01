using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [BindProperties]
    public class QtypeMod
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Question Category")]
        [MaxLength(100, ErrorMessage = "Text is too long, try shortening the name to under 100 characters")]
        public string Genre { get; set; }

        [Display(Name = "Value passed on to Reporting")]
        [MaxLength(100, ErrorMessage = "Text is too long, try shortening the name to under 100 characters")]
        public string ValuetoDB { get; set; }


        public DateTime DTime { get; set; }

        public QtypeMod()
        {
            this.DTime = DateTime.UtcNow;

        }




    }
}


       

