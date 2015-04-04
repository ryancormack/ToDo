using ToDo.Domain.Models;

namespace ToDo.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDo.Domain.Models.ToDoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDo.Domain.Models.ToDoDbContext context)
        {
            context.Todos.AddOrUpdate(
                x => x.Id,
                new Todo { TodoTask = "Create a fully working API with authentication" }
                );
        }
    }
}
