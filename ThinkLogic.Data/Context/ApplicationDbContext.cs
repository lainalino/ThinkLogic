using Microsoft.EntityFrameworkCore;
using ThinkLogic.Domain.Entities;

namespace ThinkLogic.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
