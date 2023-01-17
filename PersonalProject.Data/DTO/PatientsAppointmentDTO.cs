using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Data.DTO;

public partial class PatientsAppointmentDTO
{
    public Guid IdPatientsAppointments { get; set; }
    [Required]
    [Display(Name = "Patient")]
    public Guid IdPatient { get; set; }
    [Required]
    [Display(Name = "Assignation Date")]
    public DateTime AssignationDate { get; set; }
    public bool? AppointmentStatus { get; set; }
    public string PatientFullName { get; set; } = null!;
}

public partial class SearchPatientsAppointments
{
    [Display(Name = "Initial Date")]
    public DateTime? InitialAssignationDate { get; set; }
    [Display(Name = "Final Date")]
    public DateTime? FinalAssignationDate { get; set; }
    [Display(Name = "Patient Name")]
    public string? PatientFullName { get; set; }
    [Display(Name = "Status")]
    public bool? Status { get; set; }
}