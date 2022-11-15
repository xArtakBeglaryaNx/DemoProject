using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DemoProjectAspNetMVC.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("First Name")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "You can enter only letters")]
    public string? FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "You can enter only letters")]
    public string? LastName { get; set; }
    
    [Required]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "You can enter only letters")]
    public string? Post { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}