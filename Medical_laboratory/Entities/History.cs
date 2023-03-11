using System;
using System.Collections.Generic;

namespace Medical_laboratory.Entities;

public partial class History
{
    public int HistoryId { get; set; }

    public string? Login { get; set; }

    public DateTime? Date { get; set; }

    public string? Ip { get; set; }

    public DateTime? Block { get; set; }
}
