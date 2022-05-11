

using EditSkillsMatrix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        [BindProperty]
        public List<SubjectModel> Subs { get; set; }


        public void OnGet(int ID)
        {
            Category = _db.Category.Find(ID);
            Subs = _db.Subjects.Select(a =>
                                   new SubjectModel
                                   {

                                       Subjects = a.Subjects
                                   }).ToList();

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
                TempData["success"] = "Entry has been Updated!!!";
                return RedirectToPage("/Admin/Categories/Index");
            }
            return Page();

        }
    }
}

