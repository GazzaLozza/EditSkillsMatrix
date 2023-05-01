using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;

namespace EditSkillsMatrix.Pages.Businisspages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BusinesList> BusinesList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Business != null)
            {
                BusinesList = await _context.Business.ToListAsync();
            }
        }
    }
}
