using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [BindProperties]
    public class QtypeMod
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Question Category")]
        [MaxLength(100, ErrorMessage = "Too Long, try shortening the name to under 100 characters")]
        public string Genre { get; set; }

        [Display(Name = "Value sent to the DB")]
        [MaxLength(100, ErrorMessage = "Too Long, try shortening the name to under 100 characters")]
        public string ValuetoDB { get; set; }



    }
}


       

