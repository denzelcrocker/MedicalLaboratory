using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? UserIp { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
