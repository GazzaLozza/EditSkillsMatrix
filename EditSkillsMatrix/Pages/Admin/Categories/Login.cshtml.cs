using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EditSkillsMatrix.Models;
using Models;
using Microsoft.EntityFrameworkCore;

namespace EditSkillsMatrix.Pages.Admin.Categories
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        //These lists are pulled out of the Categpory table and displayed as Questions in the Questions Page
        public IGrouping<string, Category>[] QuestionsByCategory { get; private set; }





        //Pulling the Lists and using lambda to organise them into an order, as per the table they are coming from
        public async Task OnGet()
        {

            await InitialiseModel();

        }

        private async Task InitialiseModel()
        {
            _db.Qtypedb.FromSqlRaw("exec TeamName");
            QuestionsByCategory = (await _db.Category.ToArrayAsync()).GroupBy(category => category.Skill).ToArray();
            Teams = _db.Teams.ToList().Where(t1 => t1.TeamName != "zZBLANK").OrderBy(t1 => t1.TeamName);
            UserLists = _db.UserList.ToList().OrderBy(n1 => n1.Name);
           
        }


        [BindProperty]
        public AnswerModel Answers { get; set; }
        [BindProperty]
        public IEnumerable<TeamMod> Teams { get; set; }
        public IEnumerable<UserList> UserLists { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                await InitialiseModel();
                return Page();
            }

            var questions = await _db.Category.ToArrayAsync();
           

            foreach (var question in questions)
            {
                var radioGroupName = $"Q_{question.Id}";
                var answer = Request.Form[radioGroupName].FirstOrDefault();
                var user = Request.Form["Answers.User"];
                var role = Request.Form["Answers.Role"];
             

                if (answer == null) continue;

                await _db.Answers.AddAsync(new AnswerModel // TODO: Change this to an Answer object
                {
                    Question = question.Id,
                    Answer = int.Parse(answer), // int from 1 - 5
                    User = user,
                    TeamName = role
                    


                });
            }
            _db.Answers.Add(Answers);
            //TempData["info"] = "Thanks you for completing the Skills Matrix!";
            
            await _db.SaveChangesAsync();
            await _db.Database.ExecuteSqlRawAsync("Exec TeamName");
            return RedirectToPage("Login2", new { Answers.ID });
        }
    }
}

