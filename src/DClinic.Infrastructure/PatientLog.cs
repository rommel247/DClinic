using System;
using System.Collections.Generic;

namespace DClinic.Infrastructure;

public partial class PatientLog
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public int? ReasonId { get; set; }

    public string Comments { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual Reason Reason { get; set; }
}
