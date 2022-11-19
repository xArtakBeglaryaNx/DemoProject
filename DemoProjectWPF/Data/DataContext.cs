using DemoProjectWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectWPF.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
    {
        
    }
    
    public DbSet<Employee> Employees { get; set; }
}