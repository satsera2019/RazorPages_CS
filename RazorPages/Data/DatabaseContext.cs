using Microsoft.EntityFrameworkCore;

namespace RazorPages.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) 
        {
           
        }

        public DbSet<Person> Person { get; set; }
    }
}
