using Friendfolio.Data;
using FriendFolio.Models;
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
            .OrderByDescending(book => book.CreatedAt)
            .ToListAsync();
    }
}