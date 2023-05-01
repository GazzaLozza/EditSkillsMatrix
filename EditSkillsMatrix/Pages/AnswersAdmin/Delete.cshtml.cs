using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.AnswersAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AnswerModel AnswerModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answermodel = await _context.Answers.FirstOrDefaultAsync(m => m.ID == id);

            if (answermodel == null)
            {
                return NotFound();
            }
            else 
            {
                AnswerModel = answermodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }
            var answermodel = await _context.Answers.FindAsync(id);

            if (answermodel != null)
            {
                AnswerModel = answermodel;
                _context.Answers.Remove(AnswerModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
