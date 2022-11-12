using DemoProjectAspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectAspNetMVC.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}