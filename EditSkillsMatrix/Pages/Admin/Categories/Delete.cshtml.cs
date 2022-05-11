

using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EditSkillsMatrix.Pages.Admin.Categories
{

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
         

       
            {
                var categoryFromDb = _db.Category.Find(Category.Id);
                if (categoryFromDb != null)

                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Entry has been Deleted!!!";
                    return RedirectToPage("Index");
                }

                
                
                
            }
            return Page();

        }
    }
}

