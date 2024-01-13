namespace employee_management_system.Data;
using employee_management_system.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<CEOModel> CEOs { get; set; }
    public DbSet<SupervisorModel> Supervisors { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<DepartmentModel> Departments { get; set; }

}
