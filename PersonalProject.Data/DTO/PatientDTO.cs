using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Data.DTO;

public partial class PatientDTO
{
    public Guid IdPatient { get; set; }

    [Display(Name ="Name")]
    [Required(ErrorMessage = "Name Required")]
    public string Name { get; set; } = null!;

    [Display(Name ="Last Name")]
    [Required(ErrorMessage = "Last Name Required")]
    public string LastName { get; set; } = null!;

    [Display(Name ="Birthday")]
    [Required(ErrorMessage = "Birthday Required")]
    public DateTime Birthday { get; set; }

    [Display(Name ="Gender")]
    [Required(ErrorMessage = "Gender Required")]
    public string Gender { get; set; } = null!;

    public Guid IdAddress { get; set; }

    public string? Address { get; set; }
}

public partial class SearchPatient
{
    public string FullName { get; set; } = null!;
    public DateTime? Birthday { get; set; }
    public string? Gender { get; set; }
}
