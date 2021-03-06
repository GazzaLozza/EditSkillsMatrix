

using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.Admin.Categories
{

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
            
        public IEnumerable<QtypeMod> QtypeModList { get; set; }
        public IEnumerable<TeamMod> TeamsList { get; set; }
        
      
        public void OnGet(int ID)
        {
            _db.Qtypedb.FromSqlRaw("exec TeamName");

            Category = _db.Category.Find(ID);
            //Subs = _db.Subjects.Select(a =>
            //                       new SubjectModel
            //                       {

            //                           Subjects = a.Subjects
            //                       }).ToList();

            TeamsList = _db.Teams.Where(t => t.TeamName != "zZBLANK").ToList();
            QtypeModList = _db.Qtypedb.Where(p => p.Genre != "zZBLANK").ToList();


        }
      



        

        public async Task<IActionResult> OnPost()
        {
            //if (Category.Question == Category.Question.ToString())
            //{
            //    TempData["failure"] = "Entry has NOT been Updated!!!";
            //    ModelState.AddModelError(string.Empty, "This position is already taken");
            //}

            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                
                await _db.SaveChangesAsync();
                _db.Category.FromSqlRaw("execute TeamName");
                await _db.Database.ExecuteSqlRawAsync("Exec TeamName");
                TempData["success"] = "Entry has been Updated!!!";
               
                return RedirectToPage("/Admin/Categories/Index");
            }
            
            return Page();

        }
    }
}

