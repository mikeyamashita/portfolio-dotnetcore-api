using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : IdentityDbContext<User>
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("public");
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<SPTransaction> SPTransactions { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
}
