using IndependecyApi.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Type> Types { get; set; }

    public DbSet<Expense> Expenses{get; set;}
}