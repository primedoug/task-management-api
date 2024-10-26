namespace TaskManagement.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}