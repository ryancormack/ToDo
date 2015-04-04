namespace ToDo.Domain.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoTask { get; set; }
        public bool IsComplete { get; set; }
    }
}
