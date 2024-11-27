using Microsoft.EntityFrameworkCore;
using MyBackend.Models;

namespace MyBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // جداول
    public DbSet<User> Users { get; set; }
}
