using System;
using System.Collections.Generic;

namespace DClinic.Domain.Entities;

public partial class Reason
{
    public int Id { get; set; }

    public string ReasonCode { get; set; }

    public string ReasonShortName { get; set; }

    public string ReasonDescription { get; set; }

    public virtual ICollection<PatientLog> PatientLogs { get; set; } = new List<PatientLog>();
}
