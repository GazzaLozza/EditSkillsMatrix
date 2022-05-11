using Models;
using System.ComponentModel.DataAnnotations;

namespace EditSkillsMatrix.Models
{
    public class Category2
    {
        [Key]
        public int ID { get; set; }
        public int Order { get; set; }
 
        public int? Question { get; set; }


        public int Answer { get; set; }

        public string User { get; set; }
        public string Role { get; set; }



    }
}