
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using EditSkillsMatrix.Models;
using Models;
using System.Web.Mvc;
using ActionResult = System.Web.Mvc.ActionResult;

namespace EditSkillsMatrix.Pages.Questions
{
    
    [BindProperties]
    public class QuestionsModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;


        public QuestionsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        //These lists are pulled out of the Categpory table and displayed as Questions in the Questions Page
        public IGrouping<string, Category>[] QuestionsByCategory { get; private set; }
        public IEnumerable<TeamMod> Teams { get; set; }
       
        
     

        //Pulling the Lists and using lambda to organise them into an order, as per the table they are coming from
        public async Task OnGet()
        {
           
            await InitialiseModel();
          
        }

        private async Task InitialiseModel()
        {
            QuestionsByCategory = (await _db.Category.ToArrayAsync()).GroupBy(category => category.Skill).ToArray();
            Teams = _db.Teams.ToList();
           
        }

     
        [BindProperty]
        public AnswerModel Answers { get; set; }
        
       
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
            TempData["info"] = "Thanks you for completing the Skills Matrix!";
            await _db.SaveChangesAsync();

            return RedirectToPage("/Reports/Reports");
        }



    }
}






