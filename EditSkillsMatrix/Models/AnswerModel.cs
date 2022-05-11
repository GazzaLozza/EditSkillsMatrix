using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AnswerModel
    {
        [Key]
        public int ID { get; set; }
        public int Order { get; set; }
       
        public int Question { get; set; }
        public int Answer { get; set; }
        [Required(ErrorMessage = "Please add a name")]
        public string User { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please choose a team or nearest area")]
        public string Role { get; set; }

     
    }
}
