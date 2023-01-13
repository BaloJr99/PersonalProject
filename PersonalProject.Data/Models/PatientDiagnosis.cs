using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class PatientDiagnosis
{
    public Guid IdPatientDiagnose { get; set; }

    public Guid IdPatientAppointment { get; set; }

    public Guid IdDoctor { get; set; }

    public string? Symptoms { get; set; }

    public string? Diagnose { get; set; }

    public string? Prescription { get; set; }

    public virtual User IdDoctorNavigation { get; set; } = null!;

    public virtual PatientsAppointment IdPatientAppointmentNavigation { get; set; } = null!;
}
