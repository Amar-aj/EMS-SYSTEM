using System.ComponentModel.DataAnnotations;

namespace employee_management_system.Models;

public class BaseModel
{
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; private set; }
    public int? UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }
    public BaseModel()
    {
        CreatedOn = DateTime.Now;
    }
}
public class UserModel : BaseModel
{
    [Key]
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

    // Navigation property for Employee
    public EmployeeModel? Employee { get; set; }
}

public enum UserRole
{
    CEO,
    SP,
    EMP
}

public class EmployeeModel : BaseModel
{
    [Key]
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DOJ { get; set; }
    public DateTime DOB { get; set; }
    public int AdharCard { get; set; }
    public string PANCard { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string District { get; set; }

    // Foreign keys and navigation properties
    public int UserID { get; set; }
    public UserModel User { get; set; }

    public int? TaskID { get; set; }
    public TaskModel Task { get; set; }

    public int? DepartmentId { get; set; }
    public DepartmentModel Department { get; set; }
}

public class CEOModel : BaseModel
{
    [Key]
    public int CEOID { get; set; }
    // Foreign key and navigation property
    public int UserID { get; set; }
    public UserModel User { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DOJ { get; set; }

}

public class SupervisorModel : BaseModel
{
    [Key]
    public int SPID { get; set; }
    public int UserID { get; set; }
    public UserModel User { get; set; }
    public int? TaskID { get; set; }
    public TaskModel Task { get; set; }

    public int? DepartmentID { get; set; }
    public DepartmentModel Department { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DOJ { get; set; }
    public DateTime DOB { get; set; }
    public int AdharCard { get; set; }
    public string PANCard { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string District { get; set; }
}


public class TaskModel : BaseModel
{
    [Key]
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public TaskStatus Status { get; set; }

    // Navigation properties
    public ICollection<EmployeeModel> Employees { get; set; }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Complete,
    Cancelled
}


public class DepartmentModel : BaseModel
{
    [Key]
    public int DeptId { get; set; }
    public string DeptName { get; set; }


    // Navigation properties
    public ICollection<EmployeeModel> Employees { get; set; }
    public ICollection<SupervisorModel> Supervisors { get; set; }
}
