using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Team
    {
      
        public int Id { get; set; }
    
        public string TeamName { get; set; }

        public string Value { get; set; }

        public IEnumerable<Team> Teams { get; set; }



    }
}
