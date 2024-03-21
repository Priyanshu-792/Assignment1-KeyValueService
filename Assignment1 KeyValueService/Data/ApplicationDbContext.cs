using Microsoft.EntityFrameworkCore;
using Assignment1_KeyValueService.Models;

namespace Assignment1_KeyValueService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CustomKeyValuePair> CustomKeyValuePairs { get; set; }
    }
}
