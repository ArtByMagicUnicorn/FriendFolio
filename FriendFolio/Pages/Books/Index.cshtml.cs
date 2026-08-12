using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Friendfolio.Pages.Books;

public class IndexModel : PageModel
{
    private readonly FriendfolioDbContext _context;

    public IndexModel(FriendfolioDbContext context)
    {
        _context = context;
    }

    public IList<MemoryBook> MemoryBooks { get; set; } = [];

    public async Task OnGetAsync()
    {
        var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        MemoryBooks = await _context.MemoryBooks
            .Where(book => book.OwnerId == ownerId)
            .Include(book => book.Questions)
            .Include(book => book.Entries)
            .OrderByDescending(book => book.CreatedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var memoryBook = await _context.MemoryBooks
            .Include(book => book.Questions)
            .Include(book => book.Entries)
                .ThenInclude(entry => entry.Answers)
            .FirstOrDefaultAsync(book => book.Id == id && book.OwnerId == ownerId);

        if (memoryBook is null)
        {
            return NotFound();
        }

        foreach (var entry in memoryBook.Entries)
        {
            _context.BookAnswers.RemoveRange(entry.Answers);
        }

        _context.BookEntries.RemoveRange(memoryBook.Entries);
        _context.BookQuestions.RemoveRange(memoryBook.Questions);
        _context.MemoryBooks.Remove(memoryBook);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}