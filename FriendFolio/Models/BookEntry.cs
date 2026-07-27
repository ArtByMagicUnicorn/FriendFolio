namespace FriendFolio.Models
{
    public class BookEntry
    {
        public int Id { get; set; }
        public int MemoryBookId { get; set; }
        public MemoryBook MemoryBook { get; set; } = default!;

        public string DisplayName { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<BookAnswer> Answers { get; set; } = [];
    }
}
