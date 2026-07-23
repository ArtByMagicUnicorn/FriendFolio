using FriendFolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Friendfolio.Data;

public class FriendfolioDbContext : DbContext
{
    public FriendfolioDbContext(DbContextOptions<FriendfolioDbContext> options)
        : base(options)
    {
    }

    public DbSet<MemoryBook> MemoryBooks => Set<MemoryBook>();
    public DbSet<BookQuestion> BookQuestions => Set<BookQuestion>();
    public DbSet<BookEntry> BookEntries => Set<BookEntry>();
    public DbSet<BookAnswer> BookAnswers => Set<BookAnswer>();
}