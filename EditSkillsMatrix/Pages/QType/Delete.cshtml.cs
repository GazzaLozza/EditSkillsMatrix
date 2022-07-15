﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EditSkillsMatrix.Pages.QType
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public QtypeMod QtypeMod { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Qtypedb == null)
            {
                return NotFound();
            }

            var qtypemod = await _context.Qtypedb.FirstOrDefaultAsync(m => m.Id == id);

            if (qtypemod == null)
            {
                return NotFound();
            }
            else 
            {
                QtypeMod = qtypemod;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Qtypedb == null)
            {
                return NotFound();
            }
            var qtypemod = await _context.Qtypedb.FindAsync(id);

            if (qtypemod != null)
            {
                QtypeMod = qtypemod;
                _context.Qtypedb.Remove(QtypeMod);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
