using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class User
{
    public Guid IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Email { get; set; } = null!;
}
