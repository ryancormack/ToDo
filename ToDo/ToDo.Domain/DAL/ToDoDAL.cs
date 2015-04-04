using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.DAL
{
    public interface IToDoDAL
    {
        Todo GetToDoFromId(int id);
    }

    public class ToDoDAL : IToDoDAL
    {
        private ToDoDbContext _db = new ToDoDbContext();

        public Todo GetToDoFromId(int id)
        {
            return _db.Todos.Find(id);
        }
    }
}
