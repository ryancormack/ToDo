using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ToDo.Domain.Models;

namespace ToDo.Domain.DAL
{
    public interface IToDoDAL
    {
        IQueryable<Todo> GetAllTodos();
        Todo GetToDoFromId(int id);
        void AddTodo(Todo todo);
        void SetState(Todo todo, EntityState state);
        void SaveChanges();
        void RemoveTodo(Todo todo);
        void Dispose();
    }

    public class ToDoDAL : IToDoDAL
    {
        private ToDoDbContext _db = new ToDoDbContext();

        public Todo GetToDoFromId(int id)
        {
            var todo = _db.Todos.Find(id);

            return todo;
        }

        public IQueryable<Todo> GetAllTodos()
        {
            var todos = _db.Todos.Take(100);
            return todos;
        }

        public void AddTodo(Todo todo)
        {
            _db.Todos.Add(todo);
        }

        public void SetState(Todo todo, EntityState state)
        {
            _db.Todos.AddOrUpdate(todo);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void RemoveTodo(Todo todo)
        {
            _db.Todos.Remove(todo);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
