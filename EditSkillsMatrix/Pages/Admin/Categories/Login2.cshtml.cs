
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;
using Models;

namespace EditSkillsMatrix.Pages.Admin.Categories
{
    [BindProperties]
    public class Login2Model : PageModel
    {
        private readonly ApplicationDbContext _db;


        public Login2Model(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        //These lists are pulled out of the Categpory table and displayed as Questions in the Questions Page
        public IGrouping<string, Category>[] QuestionsByCategory { get; set; }
        //public IEnumerable<TeamMod> Teams { get; set; }
     
        [BindProperty]
        public AnswerModel Answers { get; set; }
        public AnswerModel AnswerL { get; set; }

        
        public string Coco { get; set; }

        //Pulling the Lists and using lambda to organise them into an order, as per the table they are coming from
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _db.Answers == null)
            {
                return NotFound();
            }

            _db.Qtypedb.FromSqlRaw("exec TeamName");

            var qtypemod = await _db.Answers.FirstOrDefaultAsync(m => m.ID == id);
          


            if (qtypemod == null)
            {
                return NotFound();
            }
            else
            {
                Answers = qtypemod;
            }

            var Coco = qtypemod.TeamName;

            //Teams = _db.Teams.ToList();cate
            //await _db.Answers.ToArrayAsync();
            QuestionsByCategory = (await _db.Category.ToArrayAsync()).Where(category => category.TeamName == Coco).OrderBy(category => category.Skill).GroupBy(category => category.Skill).ToArray();
            

            return Page();
        }

        //        await InitialiseModel();

        //    }

        //    private async Task InitialiseModel()
        //    {

        //        QuestionsByCategory = (await _db.Category.ToArrayAsync()).GroupBy(category => category.Skill).ToArray();
        //        Teams = _db.Teams.ToList();
        //        await _db.Answers.ToArrayAsync();

        //    }




        public async Task<IActionResult> OnPostAsync()
        {

            //if (!ModelState.IsValid)
            //{
            //    await InitialiseModel();
            //    return Page();
            //}


            var questions = await _db.Category.ToArrayAsync();



            foreach (var question in questions)
            {
                var radioGroupName = $"Q_{question.Id}";
                var answer = Request.Form[radioGroupName].FirstOrDefault();
                var user = Request.Form["Answers.User"];
                var role = Request.Form["Answers.TeamName"];
               
            


                if (answer == null) continue;

                await _db.Answers.AddAsync(new AnswerModel //  Changed this to an Answer object
                {
                    Question = question.Id,
                    Answer = int.Parse(answer), // int from 1 - 5
                    User = user,
                    TeamName = role
                    
                    
                   

                });
            }
            _db.Answers.Add(Answers);
            TempData["info"] = "Thanks you for completing the Skills Matrix! Lets take a look at the reporting pages!";
            await _db.SaveChangesAsync();
            await _db.Database.ExecuteSqlRawAsync("Exec TeamName");


            return RedirectToPage("/Reports/Reports");
        }
    }
}


