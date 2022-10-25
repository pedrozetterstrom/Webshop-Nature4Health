using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

 
        }
}
