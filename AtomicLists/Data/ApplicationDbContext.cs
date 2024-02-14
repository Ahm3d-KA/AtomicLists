using Microsoft.EntityFrameworkCore;
using AtomicLists.Models;

namespace AtomicLists.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<AtomicLists.Models.Task> UserTasks2 { get; set; }
    public DbSet<Stats> UserStats { get; set; }

}