using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? NameOfService { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
