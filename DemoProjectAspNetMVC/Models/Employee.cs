using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.Extensions.Localization;
using DemoProjectAspNetMVC.Resources;

namespace DemoProjectAspNetMVC.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("First Name")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessageResourceType = typeof(Resources.Models.Employee), ErrorMessageResourceName = "onlyLetters")]
    public string? FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessageResourceType = typeof(Resources.Models.Employee), ErrorMessageResourceName = "onlyLetters")]
    public string? LastName { get; set; }
    
    [Required]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessageResourceType = typeof(Resources.Models.Employee), ErrorMessageResourceName = "onlyLetters")]
    public string? Post { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}