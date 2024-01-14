using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using employee_management_system.Data;
using employee_management_system.Models;

namespace employee_management_system.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,TaskDescription,Status")] TaskViewModel taskViewModel)
        {
           

            if (ModelState.IsValid)
            {
                var taskModel=new TaskModel
                {
                    IsActive=true,
                    TaskName=taskViewModel.TaskName,
                    TaskDescription=taskViewModel.TaskDescription,
                    Status=taskViewModel.Status,
                    CreatedBy=1,
                    UpdatedBy=1,
                    UpdatedOn=DateTime.Now,
                };
                _context.Add(taskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskViewModel);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }
            var taskViewModel = new TaskViewModel
            {
                Id=taskModel.Id,
                TaskName = taskModel.TaskName,
                TaskDescription = taskModel.TaskDescription,
                Status=taskModel.Status,
                IsActive = taskModel.IsActive
            };
            return View(taskViewModel);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,TaskDescription,Status,IsActive")] TaskViewModel taskViewModel)
        {
            if (id != taskViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var taskModel = new TaskModel
                    {
                        Id = taskViewModel.Id,
                        IsActive = taskViewModel.IsActive,
                        TaskName = taskViewModel.TaskName,
                        TaskDescription = taskViewModel.TaskDescription,
                        Status = taskViewModel.Status,
                        UpdatedBy = 1,
                        UpdatedOn = DateTime.Now,
                    };

                    _context.Update(taskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskModelExists(taskViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskViewModel);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskModel = await _context.Tasks.FindAsync(id);
            if (taskModel != null)
            {
                _context.Tasks.Remove(taskModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskModelExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
