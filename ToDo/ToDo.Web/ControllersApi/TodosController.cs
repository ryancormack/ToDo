using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ToDo.Domain.DAL;
using ToDo.Domain.Models;

namespace ToDo.Web.Controllers
{
    public class TodosController : ApiController
    {
        private readonly IToDoDAL _todoDal;

        public TodosController(ToDoDAL todoDal)
        {
            this._todoDal = todoDal;
        }

        // GET: api/Todos
        public IQueryable<Todo> GetTodos()
        {
            return _todoDal.GetAllTodos();
        }

        // GET: api/Todos/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
            Todo todo = _todoDal.GetToDoFromId(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT: api/Todos
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (todo.Id == 0)
            {
                return BadRequest();
            }

            todo.TodoTask = _todoDal.GetToDoFromId(todo.Id).TodoTask;

            _todoDal.SetState(todo, EntityState.Modified);

            try
            {
                _todoDal.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/Todos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, Todo todo)
        {
            var oldTodo = _todoDal.GetToDoFromId(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PopulateNewTodo(todo, oldTodo);

            _todoDal.SetState(todo, EntityState.Modified);

            try
            {
                _todoDal.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private void PopulateNewTodo(Todo todo, Todo oldTodo)
        {
            if (todo.Id == 0)
            {
                todo.Id = oldTodo.Id;
            }

            if (todo.TodoTask == null)
            {
                todo.TodoTask = oldTodo.TodoTask;
            }

            if (todo.IsComplete)
            {
                todo.IsComplete = true;
            }
        }

        // POST: api/Todos
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _todoDal.AddTodo(todo);
            _todoDal.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todos/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id)
        {
            var todo = _todoDal.GetToDoFromId(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoDal.RemoveTodo(todo);

            _todoDal.SaveChanges();

            return Ok(todo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _todoDal.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoExists(int id)
        {
            var todo =_todoDal.GetToDoFromId(id);

            return todo != null && todo.Id > 0;
        }
    }
}