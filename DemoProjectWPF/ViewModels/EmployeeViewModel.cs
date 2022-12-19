using System.Collections.Generic;
using System.Threading.Tasks;
using DemoProjectWPF.Data;
using DemoProjectWPF.Models;

namespace DemoProjectWPF.ViewModels;

public class EmployeeViewModel
{
    private readonly DataContext _dataContext;

    public EmployeeViewModel(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddEmployee(Employee employee)
    {
        var employees = _dataContext.Employees;

        await employees.AddAsync(employee);
        await _dataContext.SaveChangesAsync();
    }
}