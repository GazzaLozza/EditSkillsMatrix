
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using EditSkillsMatrix.Models;
using Models;

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



        //Pulling the Lists and using lambda to organise them into an order, as per the table they are coming from
        public async Task OnGet()
        {
            await InitialiseModel();
        }

        private async Task InitialiseModel()
        {
            QuestionsByCategory = (await _db.Category.ToArrayAsync()).GroupBy(category => category.Skill).ToArray();
        }

        //This is where I want to send the Data to.  Currently the receiving Category2 table has the same column setup as the Category table.
        //This does grab the username and role as long as no Radios are chosen???  Feeling very out of my depth
        [BindProperty]
        public AnswerModel Answers { get; set; }


        ///in this bit I now want to catch all of the entries made into the Radio buttons as well the User Name and Department > See HTML

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
                    Role = role

                });
            }
            _db.Answers.Add(Answers);
            TempData["info"] = "Thanks you for completing the Skills Matrix!";
            await _db.SaveChangesAsync();

            return RedirectToPage("/Reports/Reports");
        }



    }
}






