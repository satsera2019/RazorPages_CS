using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;

namespace RazorPages.Pages.Person
{
    public class DisplayAllModel : PageModel
    {
        private readonly DatabaseContext _ctx;
        public DisplayAllModel(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Data.Person> People { get; set; }

        public IActionResult OnGet()
        {
            People = _ctx.Person.ToList();
            return Page();  
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var person = _ctx.Person.Find(id);
            if(person == null)
                return NotFound();
            try 
            {
                _ctx.Person.Remove(person);
                _ctx.SaveChanges();
                TempData["success"] = "Deleted successfuly.";
            } catch(Exception ex) {
                TempData["error"] = "Error on deleting record.";
            }
            return RedirectToPage();
        }
    }
}
