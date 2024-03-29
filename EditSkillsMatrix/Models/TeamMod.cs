﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class TeamMod
    {

        [Key]
        public int TeamId { get; set; }
           
        [Display(Name = "Team Name")]
        [MaxLength(40)]
        public string TeamName { get; set; }
  
        [Display(Name = "Value passed on to Reporting")]
        [MaxLength(40)]
        public string Value { get; set; }

        public IEnumerable<TeamMod> Teams { get; set; }

        public DateTime DTime { get; set; }

   
    }
}
