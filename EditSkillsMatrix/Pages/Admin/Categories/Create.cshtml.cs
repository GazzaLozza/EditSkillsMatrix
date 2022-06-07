using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.Admin.Categories
{
   
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public IEnumerable<QtypeMod> QtypeModList { get; set; }
        public IEnumerable<TeamMod> TeamsList { get; set; }
        public async Task OnGet()
        {
            if (_db.Qtypedb != null)
            {
                TeamsList = await _db.Teams.Where(t => t.TeamName != "zZBLANK").OrderBy(t => t.TeamName).ToListAsync();
                QtypeModList = await _db.Qtypedb.Where(q => q.Genre != "zZBLANK").OrderBy(q => q.Genre).ToListAsync();
            }
        }

            public async Task<IActionResult> OnPost()
        {
            if(Category.Question == Category.Skill.ToString())
            {
                ModelState.AddModelError(string.Empty, "Description and Order Number are the Same!");
            }

        

            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
            
                await _db.SaveChangesAsync();
                _db.Category.FromSqlRaw("exec TeamName");
                TempData["success"] = "Entry has been Created!!!";
            

                return RedirectToPage("/Admin/Categories/Index");
            }
            return Page();

        }
    }
}
