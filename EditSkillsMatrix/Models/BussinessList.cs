using System.ComponentModel.DataAnnotations;

namespace EditSkillsMatrix.Models
{
    public class BusinesList
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Business { get; set; }
    }
}
