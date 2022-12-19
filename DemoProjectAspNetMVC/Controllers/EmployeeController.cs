using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoProjectAspNetMVC.Data;
using DemoProjectAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace DemoProjectAspNetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IStringLocalizer<EmployeeController> _localizer;

        public EmployeeController(DataContext dataContext, IStringLocalizer<EmployeeController> localizer)
        {
            _dataContext = dataContext;
            _localizer = localizer;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _dataContext.Employees;
            
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (employee.FirstName == employee.Post)
            {
                ModelState.AddModelError("Error", _localizer["postFirstNameError"]);
            }
            if (employee.LastName == employee.Post)
            {
                ModelState.AddModelError("Error", _localizer["postLastName"]);
            }
            if (ModelState.IsValid)
            {
                _dataContext.Add(employee);
                _dataContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDataContext = _dataContext.Employees.Find(id);
            
            return View(employeeFromDataContext);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (employee.FirstName == employee.Post)
            {
                ModelState.AddModelError("Error", _localizer["postFirstNameError"]);
            }
            if (employee.LastName == employee.Post)
            {
                ModelState.AddModelError("Error", _localizer["postLastName"]);
            }
            if (ModelState.IsValid)
            {
                _dataContext.Update(employee);
                _dataContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDataContext = _dataContext.Employees.Find(id);
            
            return View(employeeFromDataContext);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dataContext.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dataContext.Remove(obj);
            _dataContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SortByName()
        {
            IEnumerable<Employee>  employeesList= _dataContext.Employees;
            IEnumerable<Employee> sortedList = from sN in employeesList orderby sN.FirstName select sN;

            return View("Index", sortedList);
        }
        
        [HttpGet]
        public IActionResult SortByNameLastName()
        {
            IEnumerable<Employee>  employeesList= _dataContext.Employees;
            var sortedList = from sN in employeesList orderby sN.LastName select sN;

            return View("Index", sortedList);
        }
        
        [HttpGet]
        public IActionResult SortByPost()
        {
            IEnumerable<Employee>  employeesList= _dataContext.Employees;
            var sortedList = from sN in employeesList orderby sN.Post select sN;

            return View("Index", sortedList);
        }
        
        [HttpGet]
        public IActionResult SortByDate()
        {
            IEnumerable<Employee>  employeesList= _dataContext.Employees;
            var sortedList = from sN in employeesList orderby sN.Date select sN;

            return View("Index", sortedList);
        }
    }
}