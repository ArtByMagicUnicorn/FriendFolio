namespace FriendFolio.Models

{
    using System.ComponentModel.DataAnnotations;
    public class MemoryBook
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Skriv en titel för boken.")]
        [StringLength(120, ErrorMessage = "Titeln får vara max 120 tecken.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Beskrivningen får vara max 500 tecken.")]
        public string? Description { get; set; }
        public string InviteToken { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string OwnerId { get; set; } = string.Empty;

        public string? OwnerEmail { get; set; }

        public List<BookQuestion> Questions { get; set; } = [];
        public List<BookEntry> Entries { get; set; } = [];
    }
}
