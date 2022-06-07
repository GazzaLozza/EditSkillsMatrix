using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.TeamAdd
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TeamMod> Teams { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Teams != null)
            {
                Teams = await _context.Teams.Where(q => q.TeamName != "zZBLANK").ToListAsync();
            }
        }
    }
}
