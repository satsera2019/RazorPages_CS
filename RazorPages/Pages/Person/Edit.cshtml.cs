using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;

namespace RazorPages.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _ctx;

        public EditModel(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Data.Person Person { get; set; }

        public IActionResult OnGet(int id)
        {
            var person = _ctx.Person.Find(id);
            if (person == null)
                return NotFound();
            Person = person;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if (Person == null)
                    return NotFound();
                _ctx.Person.Update(Person);
                _ctx.SaveChanges();
                TempData["success"] = "Update Successfully.";
                return RedirectToPage("DisplayAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error has occured.";
                return Page();
            }
        }
    }
}
