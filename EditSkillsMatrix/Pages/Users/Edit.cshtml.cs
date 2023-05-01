using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;
using Models;

namespace EditSkillsMatrix.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserList UserList { get; set; }
        [BindProperty]
        public IEnumerable<TeamMod> Teams { get; set; }
        [BindProperty]
        public IEnumerable<BusinesList> UseList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null || _context.UserList == null)
            {
                return NotFound();
              
            }

            var userlist =  await _context.UserList.FirstOrDefaultAsync(m => m.Id == id);
            Teams = _context.Teams.ToList().Where(t1 => t1.TeamName != "zZBLANK").OrderBy(t1 => t1.TeamName);
            UseList = _context.Business.ToList().Where(b1 => b1.Business != "zZBLANK").OrderBy(b1 => b1.Business);

            if (userlist == null)
            {
                return NotFound();
            }
            UserList = userlist;
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserListExists(UserList))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserListExists(UserList userList)
        {
            throw new NotImplementedException();
        }

        private bool UserListExists(int id)
        {
          return _context.UserList.Any(e => e.Id == id);
        }
    }
}
