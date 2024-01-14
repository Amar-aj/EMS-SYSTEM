using employee_management_system.Data;
using employee_management_system.Models;
using employee_management_system.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace employee_management_system.Controllers;

[Authorize(Roles = "EMP")]
public class EmployeeController(AppDbContext _context, ICurrentUser _currentUser) : Controller
{
    public async Task<IActionResult> Index()
    {
        EmployeeModel employee = new EmployeeModel();
        int userId = await _currentUser.GetCurrentUserIdAsync();
        if (userId == 0)
        {
            return View(employee);
        }

        employee = await _context.Employees.FirstOrDefaultAsync(x => x.UserID == userId);
        if (employee == null)
        {
            return View(employee);
        }
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DeptId", "DeptId", employee.DepartmentId);
        //ViewData["TaskID"] = new SelectList(_context.Tasks, "Id", "Id", employeeModel.TaskID);
        //ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", employeeModel.UserID);
        return View(employee);
    }
    [HttpPost]
    public async Task<IActionResult> Index(EmployeeModel employee)
    {
        int userId = await _currentUser.GetCurrentUserIdAsync();

        employee.UserID = userId;
        employee.CreatedBy = userId;
        employee.UpdatedBy = userId;
        employee.UpdatedOn = DateTime.Now;
        if (employee.EmployeeID < 0)
        {

            _context.Add(employee);

        }
        else
        {
            _context.Update(employee);
        }
        await _context.SaveChangesAsync();
        employee = await _context.Employees.FirstOrDefaultAsync(x => x.UserID == userId);

        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DeptId", "DeptId", employee.DepartmentId);
        return View(employee);
    }

}
