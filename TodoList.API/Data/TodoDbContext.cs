using Microsoft.EntityFrameworkCore;
using TodoListModelClassLibrary;
using System.Collections.Generic;

namespace TodoListAPI.Data
{
    public class TodoDbContext : DbContext
    {
        // create a db context for the database using ToDoListClassLibrary

        public TodoDbContext() { }

        // Reference for database migration
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) => Database.Migrate();

        public DbSet<ToDoItem> ToDoItems { get; set; }
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite();
    }

}