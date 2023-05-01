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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
