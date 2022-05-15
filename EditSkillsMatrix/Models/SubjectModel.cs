using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditSkillsMatrix.Models
{
    public class SubjectModel

    {
      
        [BindProperty]
        [Key]
        public int ID { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(100)]
        public string Subjects { get; set; }
        public DateTime DTime { get; set; }

        public SubjectModel()
        {
            this.DTime = DateTime.UtcNow;

        }


    }

}
