using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class MedicalHistory
{
    public Guid IdMedicalHistories { get; set; }

    public DateTime AssignationHistory { get; set; }

    public string PatientCondition { get; set; } = null!;

    public string PatientSurgeries { get; set; } = null!;

    public string PatientMedication { get; set; } = null!;

    public virtual ICollection<PatientsHistory> PatientsHistories { get; } = new List<PatientsHistory>();
}
