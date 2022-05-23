using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EditSkillsMatrix.Pages.Help
{
    public class BinderModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
      
            ViewData["confirmation"] = $"{Name}, information will be sent to {Email}";
        }
    }

}
