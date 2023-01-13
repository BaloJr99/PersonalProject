using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class PatientsAppointMent
{
    public Guid IdAppointMent { get; set; }

    public DateTime AssignationDate { get; set; }

    public bool? AppointMentStatus { get; set; }

    public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; } = new List<PatientDiagnosis>();
}
