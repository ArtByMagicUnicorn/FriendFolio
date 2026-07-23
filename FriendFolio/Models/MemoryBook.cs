namespace FriendFolio.Models
{
    public class MemoryBook
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string InviteToken { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<BookQuestion> Questions { get; set; } = [];
        public List<BookEntry> Entries { get; set; } = [];
    }
}
