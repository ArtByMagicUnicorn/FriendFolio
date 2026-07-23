namespace FriendFolio.Models
{
    public class BookAnswer
    {
        public int Id { get; set; }
        public int BookEntryId { get; set; }
        public BookEntry BookEntry { get; set; } = default!;

        public int BookQuestionId { get; set; }
        public BookQuestion BookQuestion { get; set; } = default!;

        public string Text { get; set; } = string.Empty;
    }
}
