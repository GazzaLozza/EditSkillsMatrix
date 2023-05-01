using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EditSkillsMatrix.Models;
using Models;

namespace EditSkillsMatrix.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {

            InitialiseModel();

        }

        private void InitialiseModel()
        {

            Teams = _context.Teams.ToList().Where(t1 => t1.TeamName != "zZBLANK").OrderBy(t1 => t1.TeamName);
            UseList = _context.Business.ToList().Where(b1 => b1.Business != "zZBLANK").OrderBy(b1 => b1.Business);


        }

        [BindProperty]
        public UserList UserList { get; set; }
        [BindProperty]
        public IEnumerable<TeamMod> Teams { get; set; }
        [BindProperty]
        public IEnumerable<BusinesList> UseList { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserList.Add(UserList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
