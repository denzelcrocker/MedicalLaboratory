using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class Result
{
    public int ResultId { get; set; }

    public int? UserId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ServiceId { get; set; }

    public string? Result1 { get; set; }

    public DateTime? Date { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
