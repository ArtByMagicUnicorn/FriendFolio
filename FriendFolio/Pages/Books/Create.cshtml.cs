using Friendfolio.Data;
using FriendFolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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

        MemoryBook.Questions =
[
    new BookQuestion
    {
        Text = "Vad är ditt bästa minne med mig/oss?",
        SortOrder = 1
    },
    new BookQuestion
    {
        Text = "Beskriv mig/oss med tre ord.",
        SortOrder = 2
    },
    new BookQuestion
    {
        Text = "Vilken låt, film eller serie påminner dig om mig/oss?",
        SortOrder = 3
    },
    new BookQuestion
    {
        Text = "Vad borde vi göra tillsammans någon gång?",
        SortOrder = 4
    },
    new BookQuestion
    {
        Text = "Har du något råd, hälsning eller hemlig visdom att lämna här?",
        SortOrder = 5
    }
];

        MemoryBook.OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        MemoryBook.OwnerEmail = User.FindFirstValue(ClaimTypes.Email);

        _context.MemoryBooks.Add(MemoryBook);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id = MemoryBook.Id });
    }
}