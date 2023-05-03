using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EditSkillsMatrix.Models
{
    public class CertsAnswerModel
    {
        public int ID { get; set; }


        public string Name { get; set; }

        [BindProperty]
        public string TeamName { get; set; }
        [BindProperty]
        public string Value { get; set; }
        public int TeamId { get; set; }

        public DateTime DTime { get; set; }

       
        public CertsAnswerModel()
        {
            this.DTime = DateTime.UtcNow;

        }

    }

}

