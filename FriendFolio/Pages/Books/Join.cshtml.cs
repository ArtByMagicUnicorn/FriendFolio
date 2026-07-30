using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Friendfolio.Pages.Books;

public class JoinModel : PageModel
{
    private readonly FriendfolioDbContext _context;

    public JoinModel(FriendfolioDbContext context)
    {
        _context = context;
    }

    public MemoryBook MemoryBook { get; set; } = default!;

    [BindProperty]
    public string DisplayName { get; set; } = string.Empty;

    [BindProperty]
    [Url(ErrorMessage = "Skriv en giltig bildlänk.")]
    public string? PhotoUrl { get; set; }

    [BindProperty]
    public Dictionary<int, string> Answers { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(string inviteToken)
    {
        var memoryBook = await LoadMemoryBookAsync(inviteToken);

        if (memoryBook is null)
        {
            return NotFound();
        }

        MemoryBook = memoryBook;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string inviteToken)
    {
        var memoryBook = await LoadMemoryBookAsync(inviteToken);

        if (memoryBook is null)
        {
            return NotFound();
        }

        MemoryBook = memoryBook;

        if (string.IsNullOrWhiteSpace(DisplayName))
        {
            ModelState.AddModelError(nameof(DisplayName), "Skriv ditt namn.");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var entry = new BookEntry
        {
            MemoryBookId = memoryBook.Id,
            DisplayName = DisplayName.Trim(),
            CreatedAt = DateTime.UtcNow,
            PhotoUrl = string.IsNullOrWhiteSpace(PhotoUrl)
    ? null
    : PhotoUrl.Trim(),
        };

        foreach (var question in memoryBook.Questions)
        {
            Answers.TryGetValue(question.Id, out var answerText);

            entry.Answers.Add(new BookAnswer
            {
                BookQuestionId = question.Id,
                Text = answerText?.Trim() ?? string.Empty
            });
        }

        _context.BookEntries.Add(entry);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Thanks");
    }

    private async Task<MemoryBook?> LoadMemoryBookAsync(string inviteToken)
    {
        return await _context.MemoryBooks
            .Include(book => book.Questions.OrderBy(question => question.SortOrder))
            .FirstOrDefaultAsync(book => book.InviteToken == inviteToken);
    }
}