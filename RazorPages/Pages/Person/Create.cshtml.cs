using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;

namespace RazorPages.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _ctx;

        public CreateModel(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Data.Person Person { get; set; }

        public IActionResult OnGet()
        {
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
                _ctx.Person.Add(Person);
                _ctx.SaveChanges();
                TempData["success"] = "Saved Successfully.";
            } catch (Exception ex)
            {
                TempData["error"] = "Error has occured.";
            }
            return RedirectToPage();
        }    
    }
}
