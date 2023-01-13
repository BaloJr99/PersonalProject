using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class PatientsAppointment
{
    public Guid IdPatientsAppointments { get; set; }

    public Guid IdPatient { get; set; }

    public DateTime AssignationDate { get; set; }

    public bool? AppointmentStatus { get; set; }

    public virtual Patient IdPatientNavigation { get; set; } = null!;

    public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; } = new List<PatientDiagnosis>();
}
