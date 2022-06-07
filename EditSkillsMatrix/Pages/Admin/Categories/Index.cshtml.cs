using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EditSkillsMatrix.Pages.Admin.Categories
{

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string OrderSort { get; set; }
        public string QuestSort { get; set; }
        public string OrderSort1 { get; set; }
        public string Team { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Category> Categories { get; set; }
    


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            _db.Category.FromSqlRaw("exec TeamName");
            OrderSort = sortOrder == "datedesc" ? "datedesc" : "dates";
            QuestSort = sortOrder == "names" ? "names" : "namedesc";
            OrderSort1 = sortOrder == "datedesc" ? "datedesc" : "namedesc";
            Team = sortOrder == "team" ? "team" : "namedesc";

            CurrentFilter = searchString;

            IQueryable<Category> Sorted = from s in _db.Category
                                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Sorted = Sorted.Where(s => s.TeamName.Contains(searchString) || s.Question.Contains(searchString) || s.Skill.Contains(searchString));
                                       
            }

            switch (sortOrder)
            {
                //case "namedesc":
                //    Sorted = Sorted.OrderBy(s => s.Skill).ThenBy(s => s.DisplayOrder);
                //    break;
                //case "names":
                //    Sorted = Sorted.OrderBy(s => s.DisplayOrder);
                //    break;
                //case "team":
                //    Sorted = Sorted.OrderBy(s => s.TeamName).ThenBy(s => s.Skill).ThenBy(s => s.DisplayOrder); ;
                //    break;



                //case "datedesc": Sorted = Sorted.OrderBy(s => s.Skill).ThenBy(s => s.DisplayOrder);
                //    break;
                //case "dates":
                //    Sorted = Sorted.OrderByDescending(s => s.DisplayOrder);
                //    break;


                default:
                    Sorted = Sorted.OrderBy(s => s.TeamName).ThenBy(s => s.Skill).ThenBy(s => s.DisplayOrder).Where(t => t.TeamName != "zZBLANK"); ;
                    break;

            };
            Categories = await Sorted.AsNoTracking().ToListAsync();
            
          


       
        }

          


        
    }

}
