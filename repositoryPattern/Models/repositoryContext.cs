using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace repositoryPattern.Models
{
    public class repositoryContext : DbContext
    {
        public repositoryContext(DbContextOptions<repositoryContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
