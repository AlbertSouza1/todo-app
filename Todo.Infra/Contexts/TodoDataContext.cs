using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infra.Contexts
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext(DbContextOptions<TodoDataContext> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(120).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}
