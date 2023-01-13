using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Data.DTO;

public partial class EmployeeDTO
{
    public Guid IdEmployee { get; set; }

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

    [Display(Name ="Scholarity")]
    [Required(ErrorMessage = "Scholarity Required")]
    public string Scholarity { get; set; } = null!;

    public Guid IdAddress { get; set; }

    [Display(Name ="Phone Number")]
    [Required(ErrorMessage = "Phone Number Required")]
    public string PhoneNumber { get; set; } = null!;

}