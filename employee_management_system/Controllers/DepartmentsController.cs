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
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptId,DeptName")] DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                var departmentModel = new DepartmentModel
                {
                    DeptName= departmentViewModel.DeptName,
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    UpdatedOn = DateTime.Now,
                };
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentViewModel);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            var departmentViewModel = new DepartmentViewModel
            {
                DeptId= departmentModel.DeptId,
                DeptName=departmentModel.DeptName,
                IsActive = departmentModel.IsActive,
            };
            return View(departmentViewModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptId,DeptName,IsActive")] DepartmentViewModel departmentViewModel)
        {
            if (id != departmentViewModel.DeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var departmentModel = new DepartmentModel
                    {
                        DeptId= departmentViewModel.DeptId,
                        DeptName = departmentViewModel.DeptName,
                        IsActive = departmentViewModel.IsActive,
                        CreatedBy = 1,
                        UpdatedBy = 1,
                        UpdatedOn = DateTime.Now,
                    };

                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentViewModel.DeptId))
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
            return View(departmentViewModel);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Departments
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel != null)
            {
                _context.Departments.Remove(departmentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
            return _context.Departments.Any(e => e.DeptId == id);
        }
    }
}
