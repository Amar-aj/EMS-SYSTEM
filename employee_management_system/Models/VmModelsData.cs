
using System.ComponentModel.DataAnnotations;

namespace employee_management_system.Models;

public class VmModelsData
{
}
public class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class RegisterRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class TaskViewModel
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public TaskStatus Status { get; set; }
    public bool IsActive { get; set; }
}


public class DepartmentViewModel
{
    public int DeptId { get; set; }
    public string DeptName { get; set; }
    public bool IsActive { get; set; }
}
