using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Friendfolio.Pages.Books;

public class DetailsModel : PageModel
{
    private readonly FriendfolioDbContext _context;

    public DetailsModel(FriendfolioDbContext context)
    {
        _context = context;
    }

    public MemoryBook MemoryBook { get; set; } = default!;

    [BindProperty]
    public string NewQuestionText { get; set; } = string.Empty;

    public string InviteUrl { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var memoryBook = await _context.MemoryBooks
    .Include(book => book.Questions.OrderBy(question => question.SortOrder))
    .Include(book => book.Entries)
        .ThenInclude(entry => entry.Answers)
            .ThenInclude(answer => answer.BookQuestion)
    .FirstOrDefaultAsync(book => book.Id == id);

        if (memoryBook is null)
        {
            return NotFound();
        }

        MemoryBook = memoryBook;

        InviteUrl = Url.Page(
    "/Books/Join",
    pageHandler: null,
    values: new { inviteToken = memoryBook.InviteToken },
    protocol: Request.Scheme) ?? string.Empty;

        return Page();
    }

    public async Task<IActionResult> OnPostAddQuestionAsync(int id)
    {
        if (string.IsNullOrWhiteSpace(NewQuestionText))
        {
            return RedirectToPage("./Details", new { id });
        }

        var memoryBook = await _context.MemoryBooks
            .Include(book => book.Questions)
            .FirstOrDefaultAsync(book => book.Id == id);

        if (memoryBook is null)
        {
            return NotFound();
        }

        var nextSortOrder = memoryBook.Questions.Count == 0
            ? 1
            : memoryBook.Questions.Max(question => question.SortOrder) + 1;

        var question = new BookQuestion
        {
            MemoryBookId = memoryBook.Id,
            Text = NewQuestionText.Trim(),
            SortOrder = nextSortOrder
        };

        _context.BookQuestions.Add(question);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id });
    }
}