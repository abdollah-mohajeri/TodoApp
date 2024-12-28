namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // "normal", "high", "low"
        public string Status { get; set; } // "active", "finished", "archived"
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}