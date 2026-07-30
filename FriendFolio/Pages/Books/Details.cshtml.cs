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

    [BindProperty]
    public string QuestionText { get; set; } = string.Empty;

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

    public async Task<IActionResult> OnPostEditQuestionAsync(int id, int questionId)
    {
        if (string.IsNullOrWhiteSpace(QuestionText))
        {
            return RedirectToPage("./Details", new { id });
        }

        var question = await _context.BookQuestions
            .FirstOrDefaultAsync(question =>
                question.Id == questionId &&
                question.MemoryBookId == id);

        if (question is null)
        {
            return NotFound();
        }

        question.Text = QuestionText.Trim();

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id });
    }

    public async Task<IActionResult> OnPostMoveQuestionAsync(int id, int questionId, string direction)
    {
        var questions = await _context.BookQuestions
            .Where(question => question.MemoryBookId == id)
            .OrderBy(question => question.SortOrder)
            .ToListAsync();

        var currentIndex = questions.FindIndex(question => question.Id == questionId);

        if (currentIndex == -1)
        {
            return NotFound();
        }

        var targetIndex = direction == "up"
            ? currentIndex - 1
            : currentIndex + 1;

        if (targetIndex < 0 || targetIndex >= questions.Count)
        {
            return RedirectToPage("./Details", new { id });
        }

        var currentQuestion = questions[currentIndex];
        var targetQuestion = questions[targetIndex];

        (currentQuestion.SortOrder, targetQuestion.SortOrder) =
            (targetQuestion.SortOrder, currentQuestion.SortOrder);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id });
    }

    public async Task<IActionResult> OnPostDeleteQuestionAsync(int id, int questionId)
    {
        var question = await _context.BookQuestions
            .FirstOrDefaultAsync(question =>
                question.Id == questionId &&
                question.MemoryBookId == id);

        if (question is null)
        {
            return NotFound();
        }

        var answers = await _context.BookAnswers
            .Where(answer => answer.BookQuestionId == questionId)
            .ToListAsync();

        _context.BookAnswers.RemoveRange(answers);
        _context.BookQuestions.Remove(question);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id });
    }

    public async Task<IActionResult> OnPostDeleteEntryAsync(int id, int entryId)
    {
        var entry = await _context.BookEntries
            .Include(entry => entry.Answers)
            .FirstOrDefaultAsync(entry =>
                entry.Id == entryId &&
                entry.MemoryBookId == id);

        if (entry is null)
        {
            return NotFound();
        }

        _context.BookAnswers.RemoveRange(entry.Answers);
        _context.BookEntries.Remove(entry);

        await _context.SaveChangesAsync();

        return RedirectToPage("./Details", new { id });
    }
}