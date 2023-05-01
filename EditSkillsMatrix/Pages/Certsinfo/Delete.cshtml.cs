using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;

namespace EditSkillsMatrix.Pages.Certsinfo
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CertsModel CertsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CertsModel == null)
            {
                return NotFound();
            }

            var certsmodel = await _context.CertsModel.FirstOrDefaultAsync(m => m.ID == id);

            if (certsmodel == null)
            {
                return NotFound();
            }
            else 
            {
                CertsModel = certsmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CertsModel == null)
            {
                return NotFound();
            }
            var certsmodel = await _context.CertsModel.FindAsync(id);

            if (certsmodel != null)
            {
                CertsModel = certsmodel;
                _context.CertsModel.Remove(CertsModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
