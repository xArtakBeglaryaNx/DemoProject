using System.ComponentModel.DataAnnotations;

namespace DemoProjectAspNetMVC.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Post { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}