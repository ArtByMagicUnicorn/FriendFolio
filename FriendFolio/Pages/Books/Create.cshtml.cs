using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friendfolio.Pages.Books;

public class CreateModel : PageModel
{
    private readonly FriendfolioDbContext _context;

    public CreateModel(FriendfolioDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MemoryBook MemoryBook { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        MemoryBook.InviteToken = Guid.NewGuid().ToString("N");
        MemoryBook.CreatedAt = DateTime.UtcNow;

        _context.MemoryBooks.Add(MemoryBook);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id = MemoryBook.Id });
    }
}