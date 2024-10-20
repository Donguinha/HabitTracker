using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class DataContext : DbContext
{
    public DbSet<Goal> Goals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=habittracker.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}