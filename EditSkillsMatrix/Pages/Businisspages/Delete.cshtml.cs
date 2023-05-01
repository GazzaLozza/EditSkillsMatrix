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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BusinesList BusinesList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Business == null)
            {
                return NotFound();
            }

            var busineslist = await _context.Business.FirstOrDefaultAsync(m => m.ID == id);

            if (busineslist == null)
            {
                return NotFound();
            }
            else 
            {
                BusinesList = busineslist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Business == null)
            {
                return NotFound();
            }
            var busineslist = await _context.Business.FindAsync(id);

            if (busineslist != null)
            {
                BusinesList = busineslist;
                _context.Business.Remove(BusinesList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
