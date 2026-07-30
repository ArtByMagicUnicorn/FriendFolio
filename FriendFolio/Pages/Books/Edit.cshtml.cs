using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Friendfolio.Pages.Books;

public class EditModel : PageModel
{
    private readonly FriendfolioDbContext _context;

    public EditModel(FriendfolioDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MemoryBook MemoryBook { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var memoryBook = await _context.MemoryBooks
            .FirstOrDefaultAsync(book => book.Id == id);

        if (memoryBook is null)
        {
            return NotFound();
        }

        MemoryBook = memoryBook;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        ModelState.Remove("MemoryBook.InviteToken");
        ModelState.Remove("MemoryBook.CreatedAt");
        ModelState.Remove("MemoryBook.Questions");
        ModelState.Remove("MemoryBook.Entries");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var memoryBookToUpdate = await _context.MemoryBooks
            .FirstOrDefaultAsync(book => book.Id == id);

        if (memoryBookToUpdate is null)
        {
            return NotFound();
        }

        memoryBookToUpdate.Title = MemoryBook.Title.Trim();
        memoryBookToUpdate.Description = string.IsNullOrWhiteSpace(MemoryBook.Description)
            ? null
            : MemoryBook.Description.Trim();

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id = memoryBookToUpdate.Id });
    }
}