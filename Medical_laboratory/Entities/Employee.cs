using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? EmployeeIp { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();

    public virtual Role? Role { get; set; }
}
