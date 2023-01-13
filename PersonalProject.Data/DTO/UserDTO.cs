using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Data.DTO;

public partial class UserDTO
{
    public Guid IdUser { get; set; }

    [Display(Name ="Username")]
    [Required(ErrorMessage = "Username Required")]
    public string Username { get; set; } = null!;

    [Display(Name ="Password")]
    [Required(ErrorMessage = "Password Required")]
    public string Password { get; set; } = null!;
    [Display(Name ="Rol")]
    [Required(ErrorMessage = "Rol Required")]
    public string Rol { get; set; } = null!;

    [Display(Name ="Email")]
    [Required(ErrorMessage = "Email Required")]
    public string Email { get; set; } = null!;

    [Display(Name ="Employee")]
    [Required(ErrorMessage = "Employee Required")]
    public Guid IdEmployee { get; set; }
}
