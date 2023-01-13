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

    [Display(Name ="First Name")]
    [Required(ErrorMessage = "First Name Required")]
    public string FirstName { get; set; } = null!;

    [Display(Name ="Last Name")]
    [Required(ErrorMessage = "Last Name Required")]
    public string LastName { get; set; } = null!;

    [Display(Name ="Rol")]
    [Required(ErrorMessage = "Rol Required")]
    public string Rol { get; set; } = null!;

    [Display(Name ="Email")]
    [Required(ErrorMessage = "Email Required")]
    public string Email { get; set; } = null!;
}
