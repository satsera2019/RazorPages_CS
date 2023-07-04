using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Services;

namespace RazorPages.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _ctx;
        private readonly IFileService _fileService;

        public CreateModel(DatabaseContext ctx, IFileService fileService)
        {
            _ctx = ctx;
            _fileService = fileService;
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
                if(Person.ImageFile != null)
                {
                    var fResult = _fileService.SaveImage(Person.ImageFile);
                    if (fResult.Item1 == 1)
                    {
                        Person.ProfilePicture = fResult.Item2;  // name of image
                    }
                }
                _ctx.Person.Add(Person);
                await _ctx.SaveChangesAsync();
                TempData["success"] = "Saved Successfully.";
            } catch (Exception ex)
            {
                TempData["error"] = "Error has occured.";
            }
            return RedirectToPage();
        }    
    }
}
