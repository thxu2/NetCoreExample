using Microsoft.EntityFrameworkCore;
using SampleApi.Domain;


namespace SampleApi.Infrastructure
{
    public class SampleApiDbContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> TodoListItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=blogging.db");
        }
    }
}