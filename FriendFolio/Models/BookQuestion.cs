namespace FriendFolio.Models
{
    public class BookQuestion
    {
        public int Id { get; set; }
        public int MemoryBookId { get; set; }
        public MemoryBook MemoryBook { get; set; } = default!;

        public string Text { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
