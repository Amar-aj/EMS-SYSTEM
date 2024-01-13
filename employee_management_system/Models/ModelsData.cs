namespace employee_management_system.Models;

public class ModelsData
{
}
public class UserModel
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

public enum UserRole
{
    CEO,
    SP,
    EMP
}

public class EmployeeModel
{
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
    public int CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }
    public int? DeletedBy { get; set; }
    public int UserID { get; set; }
    public int TaskID { get; set; }
    public int DepartmentId { get; set; }
}

public class CEOModel
{
    public int CEOID { get; set; }
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DOJ { get; set; }
    public int CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }
    public int? DeletedBy { get; set; }
}

public class SupervisorModel
{
    public int SPID { get; set; }
    public int TaskID { get; set; }
    public int DepartmentID { get; set; }
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
    public int CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }
    public int? DeletedBy { get; set; }
}


public class TaskModel
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public TaskStatus Status { get; set; }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Complete,
    Cancelled
}


public class DepartmentModel
{
    public int DeptId { get; set; }
    public string DeptName { get; set; }
}
