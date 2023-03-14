namespace Todo_CRUD.DAL.Entity
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
    }
}
