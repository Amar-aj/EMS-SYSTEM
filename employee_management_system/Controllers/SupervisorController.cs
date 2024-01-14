using employee_management_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace employee_management_system.Controllers
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Task()
        {
            return View();
        } 
        [HttpGet]
        public IActionResult Task(TaskModel taskModel)
        {
            return View();
        }
    }
}
