using Microsoft.EntityFrameworkCore;
using Assignment1_KeyValueService.Models;

namespace Assignment1_KeyValueService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // DbSet representing the table of custom key-value pairs in the database
        public DbSet<CustomKeyValuePair> CustomKeyValuePairs { get; set; }
    }
}
