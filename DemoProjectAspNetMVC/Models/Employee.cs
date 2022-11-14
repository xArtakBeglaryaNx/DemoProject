using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoProjectAspNetMVC.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("First Name")]
    public string? FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string? LastName { get; set; }
    
    [Required]
    public string? Post { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}