using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class PatientsHistory
{
    public Guid IdPatientsHistory { get; set; }

    public Guid IdPatient { get; set; }

    public Guid IdHistory { get; set; }

    public virtual MedicalHistory IdHistoryNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
