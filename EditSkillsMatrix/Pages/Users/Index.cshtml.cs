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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserList> UserList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserList != null)
            {
                UserList = await _context.UserList.ToListAsync();
            }
        }
    }
}
