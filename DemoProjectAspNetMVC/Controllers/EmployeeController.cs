using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoProjectAspNetMVC.Data;
using DemoProjectAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DemoProjectAspNetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IStringLocalizer<EmployeeController> _Localizer;

        public EmployeeController(DataContext dataContext, IStringLocalizer<EmployeeController> localizer)
        {
            _dataContext = dataContext;
            _Localizer = localizer;
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
                ModelState.AddModelError("Error", _Localizer["postFirstNameError"]);
            }
            if (employee.LastName == employee.Post)
            {
                ModelState.AddModelError("Error", _Localizer["postLastName"]);
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
                ModelState.AddModelError("Error", _Localizer["postFirstNameError"]);
            }
            if (employee.LastName == employee.Post)
            {
                ModelState.AddModelError("Error", _Localizer["postLastName"]);
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
    }
}