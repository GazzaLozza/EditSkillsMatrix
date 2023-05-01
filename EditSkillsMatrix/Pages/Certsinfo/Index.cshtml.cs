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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CertsModel> CertsModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CertsModel != null)
            {
                CertsModel = await _context.CertsModel.ToListAsync();
            }
        }
    }
}
