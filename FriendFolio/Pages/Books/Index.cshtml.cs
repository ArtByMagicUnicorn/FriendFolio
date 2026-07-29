using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        MemoryBooks = await _context.MemoryBooks
    .Include(book => book.Questions)
    .Include(book => book.Entries)
    .OrderByDescending(book => book.CreatedAt)
    .ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var memoryBook = await _context.MemoryBooks
            .Include(book => book.Questions)
            .Include(book => book.Entries)
                .ThenInclude(entry => entry.Answers)
            .FirstOrDefaultAsync(book => book.Id == id);

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