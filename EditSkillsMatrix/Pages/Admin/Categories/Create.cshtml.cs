using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
     
    
        public void OnGet()
        {
           
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
                TempData["success"] = "Entry has been Created!!!";
                return RedirectToPage("/Admin/Categories/Index");
            }
            return Page();

        }
    }
}
