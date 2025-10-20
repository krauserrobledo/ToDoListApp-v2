using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<Domain.Models.Task> Tasks { get; set; } = null!;

        public DbSet<Subtask> Subtasks { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<TaskTag> TaskTags { get; set; } = null!;

        public DbSet<TaskCategory> TaskCategories { get; set; } = null!;

        // Apply all configurations from the current assembly
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
     }    
}
        
