using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{


    public class AnswerModel
    {
      
      
        public int ID { get; set; }
          
        public int Question { get; set; }
        public int Answer { get; set; }
        [Required(ErrorMessage = "Please add a name")]
        public string User { get; set; }
  
        [BindProperty]
        [Required(ErrorMessage = "Please choose a team or nearest area")]
        public string TeamName { get; set; }
        [BindProperty]
        public string Value { get; set; }
        public int TeamId { get; set; } 

        public DateTime DTime { get; set; }

        public AnswerModel()
        {
            this.DTime = DateTime.UtcNow;

        }


    }
  
}
