
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EditSkillsMatrix.Models;
using Models;

namespace EditSkillsMatrix.Pages.Admin.Categories
{
    [BindProperties]
    public class CertsModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public CertsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //public static implicit operator CertsModel(Models.CertsModel v)
        //{
        //    throw new NotImplementedException();
        //}
        //[BindProperty]
        //These lists are pulled out of the Categpory table and displayed as Questions in the Questions Page
        //    public IGrouping<string, CertsModel>[] CertsList { get; set; }
        //    //public IEnumerable<TeamMod> Teams { get; set; }
        //    [BindProperty]
        //    public AnswerModel Answers { get; set; }

        //    [BindProperty]
        //    public CertsModel Certselect { get; set; }
        //    public CertsAnswerModel Answerc { get; set; }


        //    public string Coco { get; set; }

        //    //Pulling the Lists and using lambda to organise them into an order, as per the table they are coming from
        //    public async Task<IActionResult> OnGetAsync(int? id)
        //    {
        //        if (id == null || _db.CertsModel == null)
        //        {
        //            return NotFound();
        //        }

        //        _db.Certtype.FromSqlRaw("exec spCertName");

        //        var clist = await _db.Certtype.FirstOrDefaultAsync(m => m.ID == id);



        //        if (clist == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            Certselect = clist;
        //        }

        //        var Coco = clist.Name;

        //        //Teams = _db.Teams.ToList();cate
        //        //await _db.Answers.ToArrayAsync();
        //        CertsList = (IGrouping<string, CertsModel>[])(await _db.CertsModel.ToArrayAsync()).Where(CertsModel => CertsModel.Name == Coco).OrderBy(CertsModel => CertsModel.ID).GroupBy(CertsModel => CertsModel.Name).ToArray();


        //        return Page();
        //    }

        //    public async Task<IActionResult> OnPostAsync()
        //    {


        //        var questions = await _db.CertsModel.ToArrayAsync();

        //        foreach (var question in questions)
        //        {
        //            var radioGroupName = $"Q_{question.Name}";
        //            var answer = Request.Form[radioGroupName].FirstOrDefault();
        //            var user = Request.Form["Answers.User"];
        //            var role = Request.Form["Answers.TeamName"];




        //            if (answer == null) continue;

        //            await _db.Certanswers.AddAsync(new CertsAnswerModel //  Changed this to an Answer object
        //            {
        //                Name = question.Name,
        //                UserName = int.Parse(answer), // int from 1 - 5
        //                Certid = user,
        //                Description = role




        //            });
        //        }
        //        _db.Certanswers.Add(Answerc);
        //        TempData["info"] = "Thanks you for completing the Skills Matrix! Lets take a look at the reporting pages!";
        //        await _db.SaveChangesAsync();
        //        await _db.Database.ExecuteSqlRawAsync("Exec TeamName");
        //        await _db.Database.ExecuteSqlRawAsync("Exec sp_RemoveBlanks");


        //        return RedirectToPage("/Reports/Reports");
        //    }

        //    public static implicit operator CertsModel(Models.CertsModel v)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }

}




