using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.QType
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<QtypeMod> QtypeMod { get;set; } = default!;

        public IEnumerable<QtypeMod> QtypeModList { get;set; }

        public async Task OnGetAsync()
        {
            if (_context.Qtypedb != null)
            {
                QtypeMod = await _context.Qtypedb.ToListAsync();
                QtypeModList = await _context.Qtypedb.ToListAsync();
            }
        }
    }
}
