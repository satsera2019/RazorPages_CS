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

        public void OnGet()
        {
            People = _ctx.Person.ToList();
        }
    }
}
