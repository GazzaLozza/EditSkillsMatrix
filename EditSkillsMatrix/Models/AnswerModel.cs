using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        public string Role { get; set; }
        [BindProperty]
        public string Rep { get; set; }

        public DateTime DTime { get; set; }

        public AnswerModel()
        {
            this.DTime = DateTime.UtcNow;

        }


    }
  
}
