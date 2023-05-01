using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;
using Models;

namespace EditSkillsMatrix.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public UserList UserList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserList == null)
            {
                return NotFound();
            }

            var userlist = await _context.UserList.FirstOrDefaultAsync(m => m.Id == id);
            if (userlist == null)
            {
                return NotFound();
            }
            else 
            {
                UserList = userlist;
            }
            return Page();
        }
    }
}
