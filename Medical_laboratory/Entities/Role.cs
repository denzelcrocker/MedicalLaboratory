using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? NameOfRole { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
