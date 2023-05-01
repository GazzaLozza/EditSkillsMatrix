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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AnswerModel> AnswerModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Answers != null)
            {
                AnswerModel = await _context.Answers.OrderBy(a => a.Question).ThenBy(a => a.Answer).ToListAsync();
            }
        }
    }
}
