using System.Data.Entity;

namespace ToDo.Domain.Models
{
    public class ToDoDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todos");
        }
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ToDoDbContext() : base("name=ToDoContext")
        {
        }

        public System.Data.Entity.DbSet<ToDo.Domain.Models.Todo> Todos { get; set; }
    
    }
}
