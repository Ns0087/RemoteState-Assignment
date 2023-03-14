namespace Todo_CRUD.Models.RequestViewModel
{
    public class TodoItemRequestModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool isCompleted { get; set; }
    }
}
