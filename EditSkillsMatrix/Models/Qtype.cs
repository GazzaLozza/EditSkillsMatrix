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
    public class Qtype
    {
        [Key]
        public int Id { get; set; }
        public string Genre { get; set; }
       
    }
}


       

