using Microsoft.EntityFrameworkCore;
using TodoListt.Models;

namespace TodoListt.Database
{
    public class TodoListContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("tasks");

            modelBuilder.Entity<Task>().HasKey(task => task.taskId).HasName("id");
        }
    }
}